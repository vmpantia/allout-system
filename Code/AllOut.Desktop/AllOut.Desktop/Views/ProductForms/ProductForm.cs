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

namespace AllOut.Desktop.Views.ProductForms
{
    public partial class ProductForm : Form
    {
        private bool _isAdd = true;
        private Product _productInfo = new Product();

        public ProductForm(Guid productID = new Guid())
        {
            InitializeComponent();

            _isAdd = productID == Guid.Empty;
            lblFormTitle.Text = _isAdd ? string.Format(Constants.TITLE_ADD, Constants.OBJECT_PRODUCT) : string.Format(Constants.TITLE_EDIT, Constants.OBJECT_PRODUCT);
            lblFormDescription.Text = _isAdd ? string.Format(Constants.DESC_ADD, Constants.OBJECT_PRODUCT) : string.Format(Constants.DESC_EDIT, Constants.OBJECT_PRODUCT);

            PopulateProduct(productID);
            PopulateBrands();
            PopulateCategories();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            //Disable Controls
            EnableControls(false);

            //Populate Text Fields in Data
            _productInfo.Name = txtName.Text;
            _productInfo.BrandID = (Guid)cmbBrand.SelectedValue;
            _productInfo.CategoryID = (Guid)cmbCategory.SelectedValue;
            _productInfo.ReorderPoint = int.Parse(txtReorderPoint.Text);
            _productInfo.Price = decimal.Parse(txtPrice.Text);
            _productInfo.Description = txtDescription.Text;
            _productInfo.Status = Constants.STATUS_ENABLED_INT;

            //Prepare Request for Save
            var request = new SaveProductRequest
            {
                FunctionID = _isAdd ? Constants.FUNCTION_ID_ADD_PRODUCT_BY_ADMIN : 
                                      Constants.FUNCTION_ID_CHANGE_PRODUCT_BY_ADMIN,
                RequestStatus = Constants.REQUEST_STATUS_COMPLETED,
                client = Globals.ClientInformation,
                inputProduct = _productInfo
            };

            //Send Request for Save
            var response = await HttpController.PostSaveProductAsync(request);

            //Enable Controls
            EnableControls(true);

            //Check Response Result
            if (response.Result != ResponseResult.SUCCESS)
            {
                MessageBox.Show(response.Data.ToString(),
                                string.Format(Constants.TITLE_SAVE, Constants.OBJECT_PRODUCT),
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show(string.Format(Constants.SUCCESS_SAVED, Constants.OBJECT_PRODUCT, response.Data),
                            string.Format(Constants.TITLE_SAVE, Constants.OBJECT_PRODUCT),
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _productInfo = null;
            Close();
        }

        private async void PopulateProduct(Guid brandID)
        {
            //Check if Add or Edit
            if (!_isAdd)
            {
                //Get Product based on the given ID
                var response = await HttpController.GetProductByIDAsync(Globals.ClientInformation.ClientID, brandID);
                if (response.Result != ResponseResult.SUCCESS)
                {
                    MessageBox.Show((string)response.Data,
                                    string.Format(Constants.TITLE_EDIT, Constants.OBJECT_PRODUCT),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
                _productInfo = response.Data as Product;
            }
            
            //Populate Data in Text Fields
            txtName.Text = _productInfo.Name;
            cmbBrand.SelectedValue = _productInfo.BrandID;
            cmbCategory.SelectedValue = _productInfo.CategoryID;
            txtReorderPoint.Text = _productInfo.ReorderPoint.ToString();
            txtPrice.Text = _productInfo.Price.ToString();
            txtDescription.Text = _productInfo.Description;

            EnableControls(_productInfo.Status == Constants.STATUS_ENABLED_INT);
        }

        private async void PopulateBrands()
        {
            var brands = new List<Brand>();
            var response = await HttpController.GetBrandsByStatusAsync(Globals.ClientInformation.ClientID, Constants.STATUS_ENABLED_INT);

            if (response.Result == ResponseResult.SUCCESS)
                brands = ((List<Brand>)response.Data).OrderBy(data => data.Name).ToList();

            brands.Insert(0, new Brand
            {
                BrandID = Guid.Empty,
                Name = string.Format(Constants.CMB_PLACEHOLDER, Constants.OBJECT_BRAND),
            });

            cmbBrand.DataSource = brands;
            cmbBrand.DisplayMember = Constants.CMB_DISPLAY_NAME;
            cmbBrand.ValueMember = Constants.CMB_VALUE_BRAND_ID;
        }

        private async void PopulateCategories()
        {
            var categories = new List<Category>();
            var response = await HttpController.GetCategoriesByStatusAsync(Globals.ClientInformation.ClientID, Constants.STATUS_ENABLED_INT);

            if (response.Result == ResponseResult.SUCCESS)
                categories = ((List<Category>)response.Data).OrderBy(data => data.Name).ToList();

            categories.Insert(0, new Category
            {
                CategoryID = Guid.Empty,
                Name = string.Format(Constants.CMB_PLACEHOLDER, Constants.OBJECT_CATEGORY),
            });

            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = Constants.CMB_DISPLAY_NAME;
            cmbCategory.ValueMember = Constants.CMB_VALUE_CATEGORY_ID;
        }

        private void EnableControls(bool isEnabled)
        {
            txtName.Enabled = isEnabled;
            cmbBrand.Enabled = isEnabled;
            cmbCategory.Enabled = isEnabled;
            txtReorderPoint.Enabled = isEnabled;
            txtPrice.Enabled = isEnabled;
            txtDescription.Enabled = isEnabled;
            btnSave.Enabled = isEnabled;
        }
    }
}
