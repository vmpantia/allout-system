using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllOut.Desktop.Views.ProductForms
{
    public partial class ProductListForm : Form
    {
        public ProductListForm()
        {
            InitializeComponent();
            PopulateProducts();
        }

        private void PopulateProducts()
        {
            var productList = HTTPController.GetProducts();

            if(productList == null)
                productList = new List<Product>();

            tblProductList.DataSource = productList;
        }
    }
}
