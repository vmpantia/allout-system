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
            tblBrandList.Columns.Insert(0, editButton);

            //Hide Column 2nd Column
            tblBrandList.Columns[1].Visible = false;
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            var form = new BrandForm();
            form.ShowDialog();
            PopulateBrands();
        }

        private void tblBrandList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = tblBrandList.Rows[e.RowIndex];
            var cell = row.Cells[4];
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

        private void tblBrandList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var val = tblBrandList.Rows[e.RowIndex].Cells[1].Value;
                if(val == null)
                {
                    MessageBox.Show(string.Format(Constants.MESSAGE_OBJECT_UNABLE_EDIT, Constants.OBJECT_BRAND),
                                    Constants.TITLE_EDIT_BRAND,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }

                var id = Guid.Parse(val.ToString());
                var form = new BrandForm(id);
                form.ShowDialog();
                PopulateBrands();
            }
        }
    }
}
