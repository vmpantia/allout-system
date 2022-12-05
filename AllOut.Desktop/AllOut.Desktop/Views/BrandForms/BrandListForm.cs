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

namespace AllOut.Desktop.Views.BrandForms
{
    public partial class BrandListForm : Form
    {
        public BrandListForm()
        {
            InitializeComponent();
            PopulateBrands();
        }

        private void PopulateBrands()
        {
            var brandList = HTTPController.GetBrands();

            if (brandList == null)
                brandList = new List<Brand>();

            tblBrandList.DataSource = brandList;
        }

        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            var form = new BrandForm();
            form.ShowDialog();
        }
    }
}
