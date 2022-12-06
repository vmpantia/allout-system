using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
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

        private async void PopulateProducts()
        {
            var response = await HttpController.GetProducts();

            if (response.Result == ResponseResult.SYSTEM_ERROR ||
                response.Result == ResponseResult.API_ERROR)
            {
                tblProductList.Visible = false;
                return;
            }

            var productList = response.Data as List<Product>;
            tblProductList.DataSource = productList;
        }
    }
}
