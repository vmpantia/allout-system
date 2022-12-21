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

namespace AllOut.Desktop.Views.CategoryForms
{
    public partial class CategoryListForm : Form
    {
        private List<Guid> _categoryIDs = new List<Guid>();
        private const int ID_COL_IDX = 2;
        private const int STATUS_COL_IDX = 5;
        private const int BUTTON_COL_IDX = 0;
        private const int CHECKBOX_COL_IDX = 1;

        public CategoryListForm()
        {
            InitializeComponent();
            LoadPage();
        }

        private async void LoadPage()
        {
            var categories = await GetCategories();
            PopulateCategories(categories);
            btnSearchToolTip.SetToolTip(btnSearch, string.Format(Constants.TOOLTIP_SEARCH, Constants.OBJECT_CATEGORY));
        }

        private async Task<List<Category>> GetCategories(string query = null)
        {
            Response response;
            if(string.IsNullOrEmpty(query))
                response = await HttpController.GetCategories();
            else
                response = await HttpController.GetCategoriesByQuery(query);

            if (response.Result == ResponseResult.SYSTEM_ERROR ||
                response.Result == ResponseResult.API_ERROR)
            {
                return null;
            }

            return response.Data as List<Category>;
        }

        private async void UpdateStatusByIDs(string functionID, int newStatus)
        {
            var action = string.Empty;
            if (newStatus == Constants.STATUS_ENABLED_INT)
                action = Constants.STATUS_ENABLE_STRING;
            else if (newStatus == Constants.STATUS_DISABLED_INT)
                action = Constants.STATUS_DISABLE_STRING;
            else
                action = Constants.STATUS_DELETE_STRING;

            var dialogResult = MessageBox.Show(string.Format(Constants.MESSAGE_CONFIRMATION, action, _categoryIDs.Count, Constants.OBJECT_CATEGORY),
                                               string.Format(Constants.TITLE_UPDATE_STATUS, Constants.OBJECT_CATEGORY),
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No)
                return;

            var request = new UpdateStatusByIDsRequest
            {
                UserID = Guid.NewGuid(),
                FunctionID = functionID,
                RequestStatus = Constants.REQUEST_STATUS_COMPLETED,
                IDs = _categoryIDs,
                newStatus = newStatus
            };

            var response = await HttpController.PostUpdateCategoryStatusByIDs(request);

            if (response.Result != ResponseResult.SUCCESS)
            {
                MessageBox.Show(response.Data.ToString(),
                                string.Format(Constants.TITLE_UPDATE_STATUS, Constants.OBJECT_CATEGORY),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(string.Format(Constants.SUCCESS_UPDATE, Constants.OBJECT_CATEGORY, response.Data),
                            string.Format(Constants.TITLE_UPDATE_STATUS, Constants.OBJECT_CATEGORY),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            LoadPage();
        }

        private void PopulateCategories(List<Category> categories)
        {
            ResetTools();

            if (categories == null || categories.Count == 0)
            {
                btnSelectAll.Enabled = false;
                lblTableDescription.Visible = true;
                tblObjectList.Visible = false;
                return;
            }

            btnSelectAll.Enabled = true;
            tblObjectList.Visible = true;
            lblTableDescription.Visible = false;
            tblObjectList.DataSource = categories.Select( data => new
            {
                Id = data.CategoryID,
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
            //Reset CategoryID's
            _categoryIDs = new List<Guid>();
            foreach (DataGridViewRow item in tblObjectList.Rows)
            {
                //Change CheckBox Value
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)item.Cells[CHECKBOX_COL_IDX];
                cell.Value = isSelectAll;

                var id = ParseCategoryIDByCellValue(item.Cells[ID_COL_IDX].Value);
                if (isSelectAll)
                    _categoryIDs.Add(id);
                else
                    _categoryIDs.Remove(id);
            }

            EnableOtherActionButtons(_categoryIDs.Count > 0);
        }
        
        private Guid ParseCategoryIDByCellValue(object value)
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

            _categoryIDs = new List<Guid>();
            txtSearch.Text = string.Empty;
            tblObjectList.DataSource = null;
            tblObjectList.Rows.Clear();
            tblObjectList.Columns.Clear();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var categories = await GetCategories(txtSearch.Text);
            PopulateCategories(categories);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new CategoryForm();
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
            UpdateStatusByIDs(Constants.FUNCTION_ID_BULK_CHANGE_CATEGORY_BY_ADMIN, Constants.STATUS_ENABLED_INT);
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            UpdateStatusByIDs(Constants.FUNCTION_ID_BULK_CHANGE_CATEGORY_BY_ADMIN, Constants.STATUS_DISABLED_INT);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UpdateStatusByIDs(Constants.FUNCTION_ID_BULK_DELETE_CATEGORY_BY_ADMIN, Constants.STATUS_DELETION_INT);
        }

        private void tblObjectList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 && (e.ColumnIndex != BUTTON_COL_IDX || e.ColumnIndex != CHECKBOX_COL_IDX))
                return;

            var row = tblObjectList.Rows[e.RowIndex];
            var id = ParseCategoryIDByCellValue(row.Cells[ID_COL_IDX].Value);

            //Check if Edit Button is Clicked
            if (e.ColumnIndex == BUTTON_COL_IDX)
            {
                SelectAll(false);

                //Show Category Form
                var form = new CategoryForm(id);
                form.ShowDialog();
                LoadPage();
            }
            //Check if Select CheckBox is Clicked
            else if (e.ColumnIndex == CHECKBOX_COL_IDX)
            {
                var isIDExist = _categoryIDs.Exists(data => data == id);
                if (isIDExist)
                    _categoryIDs.Remove(id);
                else
                    _categoryIDs.Add(id);

                EnableOtherActionButtons(_categoryIDs.Count > 0);
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
