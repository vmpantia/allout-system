using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models.Requests;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AllOut.Desktop.Views.InventoryForms
{
    public partial class InventoryForm : Form
    {
        private bool _isAdd = true;
        private Inventory _inventoryInfo = new Inventory();

        public InventoryForm(string inventoryID = "")
        {
            InitializeComponent();

            _isAdd = string.IsNullOrEmpty(inventoryID);
            lblFormTitle.Text = _isAdd ? string.Format(Constants.TITLE_ADD, Constants.OBJECT_INVENTORY) : string.Format(Constants.TITLE_EDIT, Constants.OBJECT_INVENTORY);
            lblFormDescription.Text = _isAdd ? string.Format(Constants.DESC_ADD, Constants.OBJECT_INVENTORY) : string.Format(Constants.DESC_EDIT, Constants.OBJECT_INVENTORY);
            
            PopulateProducts();
            PopulateInventory(inventoryID);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            //Disable Controls
            EnableControls(false);

            //Populate Text Fields in Data
            _inventoryInfo.InventoryID = txtInventoryID.Text;
            _inventoryInfo.ProductID = (Guid)cmbProduct.SelectedValue;
            _inventoryInfo.Quantity = int.Parse(txtQuantity.Text);
            _inventoryInfo.Status = Constants.STATUS_ENABLED_INT;

            //Prepare Request for Save
            var request = new SaveInventoryRequest
            {
                FunctionID = _isAdd ? Constants.FUNCTION_ID_ADD_INVENTORY_BY_ADMIN : 
                                      Constants.FUNCTION_ID_CHANGE_INVENTORY_BY_ADMIN,
                RequestStatus = Constants.REQUEST_STATUS_COMPLETED,
                client = Globals.ClientInformation,
                inputInventory = _inventoryInfo
            };

            //Send Request for Save
            var response = await HttpController.PostSaveInventoryAsync(request);

            //Enable Controls
            EnableControls(true);

            //Check Response Result
            if (response.Result != ResponseResult.SUCCESS)
            {
                MessageBox.Show(response.Data.ToString(),
                                string.Format(Constants.TITLE_SAVE, Constants.OBJECT_INVENTORY),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(string.Format(Constants.SUCCESS_SAVED, Constants.OBJECT_INVENTORY, response.Data),
                            string.Format(Constants.TITLE_SAVE, Constants.OBJECT_INVENTORY),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _inventoryInfo = null;
            Close();
        }

        private async void PopulateInventory(string inventoryID)
        {
            //Check if Add or Edit
            if (!_isAdd)
            {
                //Get Inventory based on the given ID
                var response = await HttpController.GetInventoryByIDAsync(Globals.ClientInformation.ClientID, inventoryID);
                if (response.Result != ResponseResult.SUCCESS)
                {
                    MessageBox.Show((string)response.Data,
                                    string.Format(Constants.TITLE_EDIT, Constants.OBJECT_INVENTORY),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
                _inventoryInfo = response.Data as Inventory;
            }
            
            //Populate Data in Text Fields
            txtInventoryID.Text = _inventoryInfo.InventoryID;
            cmbProduct.SelectedValue = _inventoryInfo.ProductID;
            txtQuantity.Text = _inventoryInfo.Quantity.ToString();

            EnableControls(_inventoryInfo.Status == Constants.STATUS_ENABLED_INT);
        }

        private async void PopulateProducts()
        {
            var products = new List<ProductFullInformation>();
            var response = await HttpController.GetProductsByStatusAsync(Globals.ClientInformation.ClientID, Constants.STATUS_ENABLED_INT);

            if (response.Result == ResponseResult.SUCCESS)
                products = ((List<ProductFullInformation>)response.Data).OrderBy(data => data.ProductName).ToList();

            products.Insert(0, new ProductFullInformation
            {
                ProductID = Guid.Empty,
                ProductName = string.Format(Constants.CMB_PLACEHOLDER, Constants.OBJECT_PRODUCT),
            });

            cmbProduct.DataSource = products;
            cmbProduct.DisplayMember = Constants.CMB_DISPLAY_PRODUCT_NAME;
            cmbProduct.ValueMember = Constants.CMB_VALUE_PRODUCT_ID;
        }

        private void EnableControls(bool isEnabled)
        {
            cmbProduct.Enabled = isEnabled;
            txtQuantity.Enabled = isEnabled;
            btnSave.Enabled = isEnabled;
        }
    }
}
