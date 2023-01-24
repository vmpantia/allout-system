using AllOut.Desktop.Common;
using AllOut.Desktop.Controllers;
using AllOut.Desktop.Models;
using AllOut.Desktop.Models.enums;
using AllOut.Desktop.Views.ProductForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllOut.Desktop.Views.SalesForms
{
    public partial class POSForm : Form
    {
        private bool _isAdd = true;
        private const int ID_COL_IDX = 0;
        private const int BUTTON_ITEMS_COL_IDX = 5;
        private const int BUTTON_OTHERCHARGES_COL_IDX = 2;

        public POSForm(string salesID = null)
        {
            InitializeComponent();
            ResetSalesGlobalValue();

            _isAdd = string.IsNullOrEmpty(salesID);

            lblCashier.Text = string.Format(Constants.CASHIER_POS_FORMAT, Globals.ClientInformation.Name);
            lblSalesID.Text = string.Format(Constants.CASHIER_POS_FORMAT, _isAdd ? Constants.NA : salesID);
            PopulateSales(salesID);
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            var addItemFrm = new AddItemForm();
            addItemFrm.ShowDialog();
            PopulateTables();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetSalesGlobalValue();
        }

        private void ResetSalesGlobalValue()
        {
            Globals._salesInfo = new Sales();
            Globals._salesItems = new List<SalesItemFullInformation>();
            Globals._salesOtherCharges = new List<OtherCharge>();

            PopulateTables();
        }

        private void ComputeAll()
        {
            var totalItems = Globals._salesItems.Sum(data => data.Total);
            var totalAdditionals = Globals._salesOtherCharges.Where(data => data.Amount > 0).Sum(data => data.Amount);
            var totalDeductions = Globals._salesOtherCharges.Where(data => data.Amount < 0).Sum(data => data.Amount);

            lblAdditional.Text = string.Format(Constants.PESO_FORMAT, Math.Round(totalAdditionals, 2).ToString(Constants.N0_FORMAT));
            lblDeductions.Text = string.Format(Constants.PESO_FORMAT, Math.Round(totalDeductions, 2).ToString(Constants.N0_FORMAT));

            var total = totalItems + totalAdditionals + totalDeductions;
            lblTotal.Text = string.Format(Constants.PESO_FORMAT, Math.Round(total, 2).ToString(Constants.N0_FORMAT));
        }

        private void PopulateSales(string salesID)
        {
            if(!_isAdd)
            {
                //Get Sales based on the given ID
                var response = HttpController.GetSalesByIDAsync(Globals.ClientInformation.ClientID, salesID);
                if (response.Result != ResponseResult.SUCCESS)
                {
                    MessageBox.Show((string)response.Data,
                                    string.Format(Constants.TITLE_EDIT, Constants.OBJECT_SALES),
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
                var salesFullInfo = response.Data as SalesFullInformation;
                PopulateSalesByFullInfo(salesFullInfo);
            }
            PopulateTables();
        }

        private void PopulateSalesByFullInfo(SalesFullInformation salesFullInfo)
        {
            Globals._salesInfo = new Sales
            {
                SalesID = salesFullInfo.SalesID,
                UserID = salesFullInfo.UserID,
                AmountPaid = salesFullInfo.AmountPaid,
                Change = salesFullInfo.Change,
                Remarks = salesFullInfo.Remarks,
                Status = salesFullInfo.Status,
                CreatedDate = salesFullInfo.CreatedDate,
                ModifiedDate = salesFullInfo.ModifiedDate
            };
            Globals._salesItems = salesFullInfo.salesItems.ToList();
            Globals._salesOtherCharges = salesFullInfo.otherCharges.ToList();
        }

        private void PopulateTables()
        {
            PopulateItems();
            PopulateOtherCharges();
            ComputeAll();
        }

        private void PopulateItems()
        {
            tblItemList.DataSource = null;
            tblItemList.Rows.Clear();
            tblItemList.Columns.Clear();

            tblItemList.DataSource = Globals._salesItems.Select(data => new
            {
                Id = data.ProductID,
                Product = data.ProductName,
                UnitPrice = data.Price,
                Quantity = data.Quantity,
                Total = data.Total
            }).ToList();

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn
            {
                Name = Constants.BUTTON_NAME_DELETE,
                HeaderText = Constants.BUTTON_HEADER_ACTION,
                Text = Constants.BUTTON_NAME_DELETE,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
                UseColumnTextForButtonValue = true
            };
            tblItemList.Columns.Insert(BUTTON_ITEMS_COL_IDX, deleteButton);
            tblItemList.Columns[ID_COL_IDX].Visible = false;
        }
        private void PopulateOtherCharges()
        {
            tblOtherChargeList.DataSource = null;
            tblOtherChargeList.Rows.Clear();
            tblOtherChargeList.Columns.Clear();

            tblOtherChargeList.DataSource = Globals._salesOtherCharges.Select(data => new
            {
                Name = data.ChargeName,
                Amount = data.Amount
            }).ToList();

            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn
            {
                Name = Constants.BUTTON_NAME_DELETE,
                HeaderText = Constants.BUTTON_HEADER_ACTION,
                Text = Constants.BUTTON_NAME_DELETE,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader,
                UseColumnTextForButtonValue = true
            };
            tblOtherChargeList.Columns.Insert(BUTTON_OTHERCHARGES_COL_IDX, deleteButton);
        }
    }
}
