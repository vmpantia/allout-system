using AllOut.Desktop.Common;
using AllOut.Desktop.Views.BrandForms;
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

namespace AllOut.Desktop.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            SetActiveForm(Constants.FORM_PRODUCTS);
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            SetActiveForm(Constants.FORM_BRANDS);
        }

        private void SetActiveForm(string formName)
        {
            Form activeForm = null;

            //Clear Controls
            pnlContent.Controls.Clear();

            switch(formName)
            {
                case Constants.FORM_PRODUCTS:
                    activeForm = new ProductListForm();
                    break;
                case Constants.FORM_BRANDS:
                    activeForm = new BrandListForm();
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
    }
}
