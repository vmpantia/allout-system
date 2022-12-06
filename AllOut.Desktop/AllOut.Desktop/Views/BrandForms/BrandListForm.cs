using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            PopulateBrands();
        }

        private async void PopulateBrands()
        {
            tblBrandList.DataSource = null;
            tblBrandList.Rows.Clear();
            tblBrandList.Columns.Clear();

            var response = await HttpController.GetBrands();

            if (response.Result == ResponseResult.SYSTEM_ERROR ||
                response.Result == ResponseResult.API_ERROR)
            {
                tblBrandList.Visible = false;
                return;
            }

            var brandList = response.Data as List<Brand>;
            tblBrandList.DataSource = brandList.Select( data => new
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
            tblBrandList.Columns.Insert(BUTTON_COL_IDX, editButton);

            //Add Select Checkbox on 1st Column
            DataGridViewCheckBoxColumn selectCheckBox = new DataGridViewCheckBoxColumn
            {
                Name = Constants.BUTTON_NAME_SELECTION,
                HeaderText = Constants.BUTTON_HEADER_SELECT,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
                
            };
            tblBrandList.Columns.Insert(CHECKBOX_COL_IDX, selectCheckBox);

            //Hide Column 2nd Column
            tblBrandList.Columns[ID_COL_IDX].Visible = false;
        }

        private void SelectAll(bool isSelectAll)
        {
            _brandIDs = new List<Guid>();
            foreach (DataGridViewRow item in tblBrandList.Rows)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)item.Cells[CHECKBOX_COL_IDX];
                cell.Value = isSelectAll;

                var val = item.Cells[ID_COL_IDX].Value;
                var id = Guid.Parse(val.ToString());

                if (isSelectAll)
                    _brandIDs.Add(id);

                else
                    _brandIDs.Remove(id);
            }
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            var form = new BrandForm();
            form.ShowDialog();
            PopulateBrands();
        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {
            SelectAll(true);
        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {
            SelectAll(false);
        }

        private void tblBrandList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 && (e.ColumnIndex != BUTTON_COL_IDX || e.ColumnIndex != CHECKBOX_COL_IDX))
                return;

            var row = tblBrandList.Rows[e.RowIndex];

            var val = row.Cells[ID_COL_IDX].Value;
            if (val == null)
            {
                MessageBox.Show(string.Format(Constants.MESSAGE_OBJECT_UNABLE_EDIT, Constants.OBJECT_BRAND),
                                Constants.TITLE_EDIT_BRAND,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            var id = Guid.Parse(val.ToString());
            if (e.ColumnIndex == BUTTON_COL_IDX)
            {
                var form = new BrandForm(id);
                form.ShowDialog();
                PopulateBrands();
            }
            else if (e.ColumnIndex == CHECKBOX_COL_IDX)
            {
                var isIDExist = _brandIDs.Exists(data => data == id);
                if (isIDExist)
                    _brandIDs.Remove(id);
                else
                    _brandIDs.Add(id);
            }
        }

        private void tblBrandList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = tblBrandList.Rows[e.RowIndex];
            var cell = row.Cells[STATUS_COL_IDX];
            if (cell.Value != null)
            {
                var val = cell.Value.ToString();
                if (val == Constants.STRING_STATUS_ENABLED)
                    cell.Style.ForeColor = Constants.COLOR_STATUS_ENABLED;

                else if (val == Constants.STRING_STATUS_DISABLED)
                    cell.Style.ForeColor = Constants.COLOR_STATUS_DISABLED;

                else
                    cell.Style.ForeColor = Constants.COLOR_STATUS_DELETION;

                cell.Style.Font = Constants.FONT_STATUS;
            }
        }
    }
}
