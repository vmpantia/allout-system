﻿using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models.Requests;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AllOut.Desktop.Views.ProductForms
{
    public partial class ProductListForm : Form
    {
        private List<Guid> _productIDs = new List<Guid>();
        private const int BUTTON_COL_IDX = 0;
        private const int CHECKBOX_COL_IDX = 1;
        private const int ID_COL_IDX = 2;
        private const int STATUS_COL_IDX = 11;

        public ProductListForm()
        {
            InitializeComponent();
            PopulateProducts();

            btnSearchToolTip.SetToolTip(btnSearch, string.Format(Constants.TOOLTIP_SEARCH, Constants.OBJECT_PRODUCT));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PopulateProducts(txtSearch.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new ProductForm();
            form.ShowDialog();
            PopulateProducts();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            IsSelectAll(true);
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {
            IsSelectAll(false);
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            UpdateStatusByIDs(Constants.FUNCTION_ID_BULK_CHANGE_PRODUCT_BY_ADMIN, Constants.REQUEST_STATUS_COMPLETED, Constants.STATUS_ENABLED_INT);
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            UpdateStatusByIDs(Constants.FUNCTION_ID_BULK_CHANGE_PRODUCT_BY_ADMIN, Constants.REQUEST_STATUS_COMPLETED, Constants.STATUS_DISABLED_INT);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UpdateStatusByIDs(Constants.FUNCTION_ID_BULK_DELETE_PRODUCT_BY_ADMIN, Constants.REQUEST_STATUS_POST_DELETE, Constants.STATUS_DELETION_INT);
        }

        private void tblObjectList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 && (e.ColumnIndex != BUTTON_COL_IDX || e.ColumnIndex != CHECKBOX_COL_IDX))
                return;

            var id = Utility.GetGuidByCellValue(tblObjectList.Rows[e.RowIndex].Cells[ID_COL_IDX].Value);

            //Check if Edit Button is Clicked
            if (e.ColumnIndex == BUTTON_COL_IDX)
            {
                IsSelectAll(false);

                //Show Form
                var form = new ProductForm(id);
                form.ShowDialog();
                PopulateProducts();
            }

            //Check if Select CheckBox is Clicked
            else if (e.ColumnIndex == CHECKBOX_COL_IDX)
            {
                var isIDExist = _productIDs.Exists(data => data == id);
                if (isIDExist)
                    _productIDs.Remove(id);
                else
                    _productIDs.Add(id);

                EnableOtherControls(_productIDs.Count > 0);
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

        private void PopulateProducts(string query = null)
        {
            Response response;
            if (string.IsNullOrEmpty(query))
                response = HttpController.GetProductsAsync(Globals.ClientInformation.ClientID);
            else
                response = HttpController.GetProductsByQueryAsync(Globals.ClientInformation.ClientID, query);

            btnSelectAll.Enabled = false;
            tblObjectList.Visible = false;
            lblTableDescription.Visible = true;

            if (response.Result != ResponseResult.SUCCESS)
            {
                lblTableDescription.Text = (string)response.Data;
                return;
            }

            var products = (List<ProductFullInformation>)response.Data;
            if (products == null || products.Count == 0)
            {
                lblTableDescription.Text = Constants.ERROR_NO_RECORDS;
                return;
            }

            btnSelectAll.Enabled = true;
            tblObjectList.Visible = true;
            lblTableDescription.Visible = false;
            PopulateTable(products);
            return;
        }

        private void PopulateTable(List<ProductFullInformation> products)
        {
            _productIDs = new List<Guid>();
            tblObjectList.DataSource = null;
            tblObjectList.Rows.Clear();
            tblObjectList.Columns.Clear();
            EnableOtherControls(false);

            tblObjectList.DataSource = products.OrderBy(data => data.ProductName)
                                               .Select(data => new
                                               {
                                                    Id = data.ProductID,
                                                    Name = data.ProductName,
                                                    Brand = data.BrandName,
                                                    Category = data.CategoryName,
                                                    Description = data.ProductDescription,
                                                    data.Price,
                                                    data.Stock,
                                                    data.ReorderPoint,
                                                    data.ReorderState,
                                                    Status = Utility.ConvertStatusToString(data.Status),
                                                    CreatedDate = data.CreatedDate == null ? Constants.NA : DateTime.Parse(data.CreatedDate.ToString()).ToString(Constants.DATE_FORMAT),
                                                    ModifiedDate = data.ModifiedDate == null ? Constants.NA : DateTime.Parse(data.ModifiedDate.ToString()).ToString(Constants.DATE_FORMAT),
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

        private void UpdateStatusByIDs(string functionID, string requestStatus, int newStatus)
        {
            string action;
            if (newStatus == Constants.STATUS_ENABLED_INT)
                action = Constants.STATUS_ENABLE_STRING;
            else if (newStatus == Constants.STATUS_DISABLED_INT)
                action = Constants.STATUS_DISABLE_STRING;
            else
                action = Constants.STATUS_DELETE_STRING;

            var dialogResult = MessageBox.Show(string.Format(Constants.MESSAGE_CONFIRMATION, action, _productIDs.Count, Constants.OBJECT_PRODUCT),
                                               string.Format(Constants.TITLE_UPDATE_STATUS, Constants.OBJECT_PRODUCT),
                                               MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No)
                return;

            var request = new UpdateStatusByGUIDsRequest
            {
                FunctionID = functionID,
                RequestStatus = requestStatus,
                client = Globals.ClientInformation,
                IDs = _productIDs,
                newStatus = newStatus
            };

            var response = HttpController.PostUpdateProductStatusByIDsAsync(request);

            if (response.Result != ResponseResult.SUCCESS)
            {
                MessageBox.Show(response.Data.ToString(),
                                string.Format(Constants.TITLE_UPDATE_STATUS, Constants.OBJECT_PRODUCT),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(string.Format(Constants.SUCCESS_UPDATE, Constants.OBJECT_PRODUCT, response.Data),
                            string.Format(Constants.TITLE_UPDATE_STATUS, Constants.OBJECT_PRODUCT),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            PopulateProducts();
        }

        private void IsSelectAll(bool value)
        {
            //Reset ProductIDs
            _productIDs = new List<Guid>();

            foreach (DataGridViewRow item in tblObjectList.Rows)
            {
                //Change CheckBox Value
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)item.Cells[CHECKBOX_COL_IDX];
                cell.Value = value;

                var id = Utility.GetGuidByCellValue(item.Cells[ID_COL_IDX].Value);
                if (value)
                    _productIDs.Add(id);
                else
                    _productIDs.Remove(id);
            }

            EnableOtherControls(_productIDs.Count > 0);
        }

        private void EnableOtherControls(bool value)
        {
            btnUnselectAll.Enabled = value;
            btnEnable.Enabled = value;
            btnDisable.Enabled = value;
            btnDelete.Enabled = value;
        }
    }
}
