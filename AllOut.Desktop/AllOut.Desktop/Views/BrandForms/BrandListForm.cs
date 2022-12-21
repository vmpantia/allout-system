using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models.Requests;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllOut.Desktop.Views.BrandForms
{
    public partial class BrandListForm : Form
    {
        private List<Guid> _brandIDs = new List<Guid>();
        private const int ID_COL_IDX = 2;
        private const int STATUS_COL_IDX = 5;
        private const int BUTTON_COL_IDX = 0;
        private const int CHECKBOX_COL_IDX = 1;

        public BrandListForm()
        {
            InitializeComponent();
            LoadPage();
        }

        private async void LoadPage()
        {
            var brands = await GetBrands();
            PopulateBrands(brands);
            btnSearchToolTip.SetToolTip(btnSearch, string.Format(Constants.TOOLTIP_SEARCH, Constants.OBJECT_BRAND));
        }

        private async Task<List<Brand>> GetBrands(string query = null)
        {
            Response response;
            if(string.IsNullOrEmpty(query))
                response = await HttpController.GetBrands();
            else
                response = await HttpController.GetBrandsByQuery(query);

            if (response.Result == ResponseResult.SYSTEM_ERROR ||
                response.Result == ResponseResult.API_ERROR)
            {
                return null;
            }

            return response.Data as List<Brand>;
        }

        private async void UpdateStatusByIDs(string functionID, string requestStatus, int newStatus)
        {
            var action = string.Empty;
            if (newStatus == Constants.STATUS_ENABLED_INT)
                action = Constants.STATUS_ENABLE_STRING;
            else if (newStatus == Constants.STATUS_DISABLED_INT)
                action = Constants.STATUS_DISABLE_STRING;
            else
                action = Constants.STATUS_DELETE_STRING;

            var dialogResult = MessageBox.Show(string.Format(Constants.MESSAGE_CONFIRMATION, action, _brandIDs.Count, Constants.OBJECT_BRAND),
                                               string.Format(Constants.TITLE_UPDATE_STATUS, Constants.OBJECT_BRAND),
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No)
                return;

            var request = new UpdateStatusByIDsRequest
            {
                UserID = Guid.NewGuid(),
                FunctionID = functionID,
                RequestStatus = requestStatus,
                IDs = _brandIDs,
                newStatus = newStatus
            };

            var response = await HttpController.PostUpdateBrandStatusByIDs(request);

            if (response.Result != ResponseResult.SUCCESS)
            {
                MessageBox.Show(response.Data.ToString(),
                                string.Format(Constants.TITLE_UPDATE_STATUS, Constants.OBJECT_BRAND),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(string.Format(Constants.SUCCESS_UPDATE, Constants.OBJECT_BRAND, response.Data),
                            string.Format(Constants.TITLE_UPDATE_STATUS, Constants.OBJECT_BRAND),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            LoadPage();
        }

        private void PopulateBrands(List<Brand> brands)
        {
            ResetTools();

            if (brands == null || brands.Count == 0)
            {
                btnSelectAll.Enabled = false;
                lblTableDescription.Visible = true;
                tblObjectList.Visible = false;
                return;
            }

            btnSelectAll.Enabled = true;
            tblObjectList.Visible = true;
            lblTableDescription.Visible = false;
            tblObjectList.DataSource = brands.Select( data => new
            {
                Id = data.BrandID,
                Name = data.Name,
                Description = data.Description,
                Status = Utility.ConvertStatusToString(data.Status),
                CreatedDate = data.CreatedDate == null ? Constants.NA : DateTime.Parse(data.CreatedDate.ToString()).ToShortDateString(),
                ModifiedDate = data.ModifiedDate == null ? Constants.NA : DateTime.Parse(data.ModifiedDate.ToString()).ToShortDateString(),
            }).ToList();


            //Add Edit Button on 1st Column
            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn
            {
                Name = Constants.BUTTON_NAME_EDIT,
                HeaderText = Constants.BUTTON_HEADER_ACTION,
                Text = Constants.BUTTON_NAME_EDIT,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
                UseColumnTextForButtonValue = true
            };
            tblObjectList.Columns.Insert(BUTTON_COL_IDX, editButton);

            //Add Select Checkbox on 1st Column
            DataGridViewCheckBoxColumn selectCheckBox = new DataGridViewCheckBoxColumn
            {
                Name = Constants.BUTTON_NAME_SELECTION,
                HeaderText = Constants.BUTTON_HEADER_SELECT,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                
            };
            tblObjectList.Columns.Insert(CHECKBOX_COL_IDX, selectCheckBox);

            //Hide Column 2nd Column
            tblObjectList.Columns[ID_COL_IDX].Visible = false;
        }

        private void SelectAll(bool isSelectAll)
        {
            //Reset BrandID's
            _brandIDs = new List<Guid>();
            foreach (DataGridViewRow item in tblObjectList.Rows)
            {
                //Change CheckBox Value
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)item.Cells[CHECKBOX_COL_IDX];
                cell.Value = isSelectAll;

                var id = ParseBrandIDByCellValue(item.Cells[ID_COL_IDX].Value);
                if (isSelectAll)
                    _brandIDs.Add(id);
                else
                    _brandIDs.Remove(id);
            }

            EnableOtherActionButtons(_brandIDs.Count > 0);
        }
        
        private Guid ParseBrandIDByCellValue(object value)
        {
            return value == null ? Guid.Empty : Guid.Parse(value.ToString());
        }

        private void EnableOtherActionButtons(bool value)
        {
            btnUnselectAll.Enabled = value;
            btnEnable.Enabled = value;
            btnDisable.Enabled = value;
            btnDelete.Enabled = value;
        }

        private void ResetTools()
        {
            EnableOtherActionButtons(false);

            _brandIDs = new List<Guid>();
            txtSearch.Text = string.Empty;
            tblObjectList.DataSource = null;
            tblObjectList.Rows.Clear();
            tblObjectList.Columns.Clear();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var brands = await GetBrands(txtSearch.Text);
            PopulateBrands(brands);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new BrandForm();
            form.ShowDialog();
            LoadPage();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            SelectAll(true);
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            SelectAll(false);
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            UpdateStatusByIDs(Constants.FUNCTION_ID_BULK_CHANGE_BRAND_BY_ADMIN, Constants.REQUEST_STATUS_COMPLETED, Constants.STATUS_ENABLED_INT);
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            UpdateStatusByIDs(Constants.FUNCTION_ID_BULK_CHANGE_BRAND_BY_ADMIN, Constants.REQUEST_STATUS_COMPLETED, Constants.STATUS_DISABLED_INT);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UpdateStatusByIDs(Constants.FUNCTION_ID_BULK_DELETE_BRAND_BY_ADMIN, Constants.REQUEST_STATUS_POST_DELETE, Constants.STATUS_DELETION_INT);
        }

        private void tblObjectList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 && (e.ColumnIndex != BUTTON_COL_IDX || e.ColumnIndex != CHECKBOX_COL_IDX))
                return;

            var row = tblObjectList.Rows[e.RowIndex];
            var id = ParseBrandIDByCellValue(row.Cells[ID_COL_IDX].Value);

            //Check if Edit Button is Clicked
            if (e.ColumnIndex == BUTTON_COL_IDX)
            {
                SelectAll(false);

                //Show Brand Form
                var form = new BrandForm(id);
                form.ShowDialog();
                LoadPage();
            }
            //Check if Select CheckBox is Clicked
            else if (e.ColumnIndex == CHECKBOX_COL_IDX)
            {
                var isIDExist = _brandIDs.Exists(data => data == id);
                if (isIDExist)
                    _brandIDs.Remove(id);
                else
                    _brandIDs.Add(id);

                EnableOtherActionButtons(_brandIDs.Count > 0);
            }
        }

        private void tblObjectList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = tblObjectList.Rows[e.RowIndex];
            var cell = row.Cells[STATUS_COL_IDX];
            if (cell.Value != null)
            {
                var val = cell.Value.ToString();
                if (val == Constants.STATUS_ENABLED_STRING)
                    cell.Style.ForeColor = Color.FromArgb(39, 174, 96);

                else if (val == Constants.STATUS_DISABLED_STRING)
                    cell.Style.ForeColor = Color.FromArgb(64, 64, 64);

                else
                    cell.Style.ForeColor = Color.FromArgb(192, 57, 43);

                cell.Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }
        }
    }
}
