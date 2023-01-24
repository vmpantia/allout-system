using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Models.Requests;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AllOut.Desktop.Views.SalesForms
{
    public partial class AddOtherChargeForm : Form
    {
        public AddOtherChargeForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtChargeName.Text))
            {
                MessageBox.Show("Please input charge name.");
                return;
            }

            if (string.IsNullOrEmpty(txtAmount.Text) ||
               !Regex.IsMatch(txtAmount.Text, Constants.REGEX_NUMBER_PATTERN))
            {
                MessageBox.Show("Please input valid quantity.");
                return;
            }

            var quantity = decimal.Parse(txtAmount.Text);

            //Check if already exist in Other Charges Global
            if (Globals._salesOtherCharges.Exists(data => data.ChargeName == txtChargeName.Text))
            {
                MessageBox.Show("Charge Name is already exist in other charges.");
                return;
            }

            Globals._salesOtherCharges.Add(new OtherCharge
            {
                ChargeName = txtChargeName.Text,
                Amount = quantity
            });
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
