using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models.Requests;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AllOut.Desktop.Views.ProductForms
{
    public partial class SalesForm : Form
    {
        public SalesForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
