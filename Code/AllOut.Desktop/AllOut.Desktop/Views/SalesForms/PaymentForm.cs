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

namespace AllOut.Desktop.Views.SalesForms
{
    public partial class PaymentForm : Form
    {
        public PaymentForm(SaveSalesRequest request)
        {
            InitializeComponent();
            PopulateSalesSummary(request);
        }

        private void PopulateSalesSummary(SaveSalesRequest request)
        {
            var totalItems = request.inputSalesItems.Sum(data => data.Total);
            var totalAdditionals = request.inputOtherCharges.Where(data => data.Amount > 0).Sum(data => data.Amount);
            var totalDeductions = request.inputOtherCharges.Where(data => data.Amount < 0).Sum(data => data.Amount);

            txtAdditionals.Text = string.Format(Constants.PESO_FORMAT, Math.Round(totalAdditionals, 2).ToString(Constants.N0_FORMAT));
            txtDeductions.Text = string.Format(Constants.PESO_FORMAT, Math.Round(totalDeductions, 2).ToString(Constants.N0_FORMAT));

            var total = totalItems + totalAdditionals + totalDeductions;
            txtTotal.Text = string.Format(Constants.PESO_FORMAT, Math.Round(total, 2).ToString(Constants.N0_FORMAT));

            txtRemarks.Text = request.inputSales.Remarks;
        }
    }
}
