using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models;
using AllOut.Desktop.Views.BrandForms;
using AllOut.Desktop.Views.CategoryForms;
using AllOut.Desktop.Views.ProductForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AllOut.Desktop.Views.UserForms;
using AllOut.Desktop.Views.InventoryForms;
using AllOut.Desktop.Views.SalesForms;

namespace AllOut.Desktop.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            SetUserInfo(Globals.ClientInformation);
            SetActiveForm(Constants.FORM_DASHBOARDS);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SetActiveForm(Constants.FORM_DASHBOARDS);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            SetActiveForm(Constants.FORM_INVENTORIES);
        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            SetActiveForm(Constants.FORM_SALES);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            SetActiveForm(Constants.FORM_PRODUCTS);
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            SetActiveForm(Constants.FORM_BRANDS);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {

            SetActiveForm(Constants.FORM_CATEGORIES);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            SetActiveForm(Constants.FORM_USERS);
        }

        private void SetActiveForm(string formName)
        {
            Form activeForm = null;

            //Clear Controls
            pnlContent.Controls.Clear();

            switch(formName)
            {
                case Constants.FORM_DASHBOARDS:
                    activeForm = new DashboardForm();
                    break;
                case Constants.FORM_INVENTORIES:
                    activeForm = new InventoryListForm();
                    break;
                case Constants.FORM_SALES:
                    activeForm = new SalesListForm();
                    break;
                case Constants.FORM_PRODUCTS:
                    activeForm = new ProductListForm();
                    break;
                case Constants.FORM_BRANDS:
                    activeForm = new BrandListForm();
                    break;
                case Constants.FORM_CATEGORIES:
                    activeForm = new CategoryListForm();
                    break;
                case Constants.FORM_USERS:
                    activeForm = new UserListForm();
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
            lblUserEmail.Text = user.Email.ToLower();
            lblUsername.Text = user.Username;
        }
    }
}
