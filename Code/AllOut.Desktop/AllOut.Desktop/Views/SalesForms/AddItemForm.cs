using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models.Requests;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AllOut.Desktop.Views.ProductForms
{
    public partial class AddItemForm : Form
    {
        private List<Guid> _productIDs = new List<Guid>();
        private List<ProductFullInformation> _productFullInfoList = new List<ProductFullInformation>();

        private const int CHECKBOX_COL_IDX = 0;
        private const int ID_COL_IDX = 1;
        private const int STOCK_COL_IDX = 6;
        public AddItemForm()
        {
            InitializeComponent();
            PopulateProducts();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PopulateProducts(txtSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtQuantity.Text) ||
               !Regex.IsMatch(txtQuantity.Text, Constants.REGEX_NUMBER_PATTERN))
            {
                MessageBox.Show("Please input valid quantity.");
                return;
            }


            if (_productIDs.Count() == 0)
            {
                MessageBox.Show("Please check product(s) to add.");
                return;
            }

            var quantity = int.Parse(txtQuantity.Text);
            foreach (var id in _productIDs)
            {
                var products = _productFullInfoList.Where(data => data.ProductID == id).ToList();
                if(products != null && products.Count() > 0)
                {
                    var product = products.First();

                    //Check if already exist in SalesItems Global
                    if(Globals._salesItems.Exists(data => data.ProductID == product.ProductID))
                    {
                        MessageBox.Show("One of your selected product is already in the POS Item list.");
                        return;
                    }

                    if (quantity > product.Stock)
                    {
                        MessageBox.Show("One of your selected product quantity is already exceed in the current stocks.");
                        return;
                    }

                    Globals._salesItems.Add(new SalesItemFullInformation
                    {
                        SalesID = string.Empty,
                        ProductID = product.ProductID,
                        ProductName = product.ProductName,
                        Quantity = quantity,
                        Price = product.Price,
                        Total = Math.Round(product.Price * quantity, 2)
                    });
                }
            }
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tblProductList_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = tblProductList.Rows[e.RowIndex];
            var cellStock = row.Cells[STOCK_COL_IDX];
            var cellAction = row.Cells[CHECKBOX_COL_IDX] as DataGridViewCheckBoxCell;
            if (cellStock.Value != null)
            {
                var val = int.Parse(cellStock.Value.ToString());
                if (val == 0)
                {
                    cellAction.ReadOnly = true;
                    row.DefaultCellStyle.BackColor = Color.FromArgb(231, 76, 60);
                    row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(192, 57, 43);
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.DefaultCellStyle.SelectionForeColor = Color.White;
                }
                cellStock.Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }
        }

        private void tblProductList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != CHECKBOX_COL_IDX)
                return;

            var id = Utility.GetGuidByCellValue(tblProductList.Rows[e.RowIndex].Cells[ID_COL_IDX].Value);

            var isIDExist = _productIDs.Exists(data => data == id);
            if (isIDExist)
                _productIDs.Remove(id);
            else
                _productIDs.Add(id);
        }

        private void PopulateProducts(string query = null)
        {
            _productFullInfoList = new List<ProductFullInformation>();

            Response response;
            if (string.IsNullOrEmpty(query))
                response = HttpController.GetProductsAsync(Globals.ClientInformation.ClientID);
            else
                response = HttpController.GetProductsByQueryAsync(Globals.ClientInformation.ClientID, query);

            if (response.Result == ResponseResult.SUCCESS)
            {
                _productFullInfoList = (List<ProductFullInformation>)response.Data;
            }
            PopulateTable(_productFullInfoList);
        }

        private void PopulateTable(List<ProductFullInformation> products)
        {
            tblProductList.DataSource = null;
            tblProductList.Rows.Clear();
            tblProductList.Columns.Clear();

            tblProductList.DataSource = products.Where(data => data.Status == Constants.STATUS_ENABLED_INT)
                                                .OrderBy(data => data.ProductName)
                                                .Select(data => new
                                                {
                                                    Id = data.ProductID,
                                                    Name = data.ProductName,
                                                    Brand = data.BrandName,
                                                    Category = data.CategoryName,
                                                    data.Price,
                                                    data.Stock
                                                }).ToList();

            DataGridViewCheckBoxColumn selectCheckBox = new DataGridViewCheckBoxColumn
            {
                Name = Constants.BUTTON_NAME_SELECTION,
                HeaderText = Constants.BUTTON_HEADER_SELECT,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader

            };
            tblProductList.Columns.Insert(CHECKBOX_COL_IDX, selectCheckBox);
            tblProductList.Columns[ID_COL_IDX].Visible = false;
        }
    }
}
