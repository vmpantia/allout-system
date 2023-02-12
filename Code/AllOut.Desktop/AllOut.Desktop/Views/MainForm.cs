using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models;
using AllOut.Desktop.Views.BrandForms;
using AllOut.Desktop.Views.CategoryForms;
using AllOut.Desktop.Views.ProductForms;
using System;
using System.Windows.Forms;
using AllOut.Desktop.Views.UserForms;
using AllOut.Desktop.Views.InventoryForms;
using AllOut.Desktop.Views.SalesForms;
using AllOut.Desktop.Properties;
using AllOut.Desktop.Views.RoleForms;

namespace AllOut.Desktop.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetUserInfo(Globals.ClientInformation);
            SetActiveForm(Constants.FORM_DASHBOARD);

            //Set App Version
            lblAppVersion.Text = Constants.APP_VERSION;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SetActiveForm(Constants.FORM_DASHBOARD);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            SetActiveForm(Constants.FORM_INVENTORY);
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            SetActiveForm(Constants.FORM_SALES);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            SetActiveForm(Constants.FORM_PRODUCT);
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            SetActiveForm(Constants.FORM_BRAND);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {

            SetActiveForm(Constants.FORM_CATEGORY);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            SetActiveForm(Constants.FORM_USER);
        }

        private void btnRole_Click(object sender, EventArgs e)
        {
            SetActiveForm(Constants.FORM_ROLE);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var response = HttpController.PostLogoutUserAsync(Globals.ClientInformation.ClientID);
            //Get Product based on the given ID
            if (response.Result != ResponseResult.SUCCESS)
            {
                MessageBox.Show((string)response.Data);
                return;
            }
            Globals.ClientInformation = null;
            this.Close();
        }

        private void SetActiveForm(string formName)
        {
            Form activeForm = null;

            //Clear Controls
            pnlContent.Controls.Clear();

            switch(formName)
            {
                case Constants.FORM_DASHBOARD:
                    formTitle.Text = Constants.FORM_DASHBOARD;
                    formDescription.Text = string.Format(Constants.DESC_FORM, Constants.FORM_DASHBOARD);
                    formIcon.Image = Resources.dg_dashboard;
                    activeForm = new DashboardForm();
                    break;
                case Constants.FORM_INVENTORY:
                    formTitle.Text = Constants.FORM_INVENTORY;
                    formDescription.Text = string.Format(Constants.DESC_FORM, Constants.FORM_INVENTORY);
                    formIcon.Image = Resources.dg_inventory;
                    activeForm = new InventoryListForm();
                    break;
                case Constants.FORM_SALES:
                    formTitle.Text = Constants.FORM_SALES;
                    formDescription.Text = string.Format(Constants.DESC_FORM, Constants.FORM_SALES);
                    formIcon.Image = Resources.dg_sales;
                    activeForm = new SalesListForm();
                    break;
                case Constants.FORM_PRODUCT:
                    formTitle.Text = Constants.FORM_PRODUCT;
                    formDescription.Text = string.Format(Constants.DESC_FORM, Constants.FORM_PRODUCT);
                    formIcon.Image = Resources.dg_product;
                    activeForm = new ProductListForm();
                    break;
                case Constants.FORM_BRAND:
                    formTitle.Text = Constants.FORM_BRAND;
                    formDescription.Text = string.Format(Constants.DESC_FORM, Constants.FORM_BRAND);
                    formIcon.Image = Resources.dg_brand;
                    activeForm = new BrandListForm();
                    break;
                case Constants.FORM_CATEGORY:
                    formTitle.Text = Constants.FORM_CATEGORY;
                    formDescription.Text = string.Format(Constants.DESC_FORM, Constants.FORM_CATEGORY);
                    formIcon.Image = Resources.dg_category;
                    activeForm = new CategoryListForm();
                    break;
                case Constants.FORM_USER:
                    formTitle.Text = Constants.FORM_USER;
                    formIcon.Image = Resources.dg_users;
                    formDescription.Text = string.Format(Constants.DESC_FORM, Constants.FORM_USER);
                    activeForm = new UserListForm();
                    break;
                case Constants.FORM_ROLE:
                    formTitle.Text = Constants.FORM_ROLE;
                    formIcon.Image = Resources.dg_role;
                    formDescription.Text = string.Format(Constants.DESC_FORM, Constants.FORM_ROLE);
                    activeForm = new RoleListForm();
                    break;
            }

            activeForm.TopLevel = false;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.Dock = DockStyle.Fill;
            activeForm.Show();
            pnlContent.Controls.Add(activeForm);

            //Change Title
            this.Text = formName;
        }

        private void SetUserInfo(Client client)
        {
            if (client == null)
            {
                lblUserEmail.Text = Constants.NA;
                lblUsername.Text = Constants.NA;
                return;
            }

            var response = HttpController.GetUserByIDAsync(client.ClientID, client.UserID);
            //Get Product based on the given ID
            if (response.Result != ResponseResult.SUCCESS)
            {
                lblUserEmail.Text = Constants.NA;
                lblUsername.Text = Constants.NA;
                return;
            }
            var user = response.Data as User;
            lblUsername.Text = user.Username;
            lblUserEmail.Text = user.Email.ToLower();
        }
    }
}
