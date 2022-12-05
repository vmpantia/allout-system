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

        private void btnProduct_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();

            var productList = new ProductListForm();
            productList.TopLevel = false;
            productList.FormBorderStyle = FormBorderStyle.None;
            productList.Dock = DockStyle.Fill;
            productList.Show();
            pnlContent.Controls.Add(productList);
            this.Text = "Product";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
