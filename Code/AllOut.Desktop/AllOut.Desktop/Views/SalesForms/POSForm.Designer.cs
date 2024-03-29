﻿namespace AllOut.Desktop.Views.SalesForms
{
    partial class POSForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POSForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtRemarks = new Guna.UI2.WinForms.Guna2TextBox();
            this.OtherCharges = new Guna.UI2.WinForms.Guna2Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tblOtherChargeList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnAddOtherCharge = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Item = new Guna.UI2.WinForms.Guna2Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tblItemList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.btnAddItem = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Additional = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblAdditionals = new System.Windows.Forms.Label();
            this.Deductions = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDeductions = new System.Windows.Forms.Label();
            this.Total = new Guna.UI2.WinForms.Guna2Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCashier = new System.Windows.Forms.Label();
            this.btnPay = new Guna.UI2.WinForms.Guna2Button();
            this.lblSalesID = new System.Windows.Forms.Label();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnReset = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.OtherCharges.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblOtherChargeList)).BeginInit();
            this.Item.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblItemList)).BeginInit();
            this.Additional.SuspendLayout();
            this.Deductions.SuspendLayout();
            this.Total.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 169F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 221F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 221F));
            this.tableLayoutPanel1.Controls.Add(this.txtRemarks, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.OtherCharges, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Item, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Additional, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.Deductions, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.Total, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.guna2Panel1, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.guna2Panel2, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1580, 880);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderColor = System.Drawing.Color.Silver;
            this.txtRemarks.BorderRadius = 6;
            this.txtRemarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableLayoutPanel1.SetColumnSpan(this.txtRemarks, 2);
            this.txtRemarks.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRemarks.DefaultText = "";
            this.txtRemarks.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRemarks.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRemarks.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRemarks.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemarks.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRemarks.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtRemarks.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRemarks.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRemarks.Location = new System.Drawing.Point(1141, 675);
            this.txtRemarks.MaxLength = 100;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.PasswordChar = '\0';
            this.txtRemarks.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtRemarks.PlaceholderText = "Remarks";
            this.txtRemarks.SelectedText = "";
            this.txtRemarks.Size = new System.Drawing.Size(436, 150);
            this.txtRemarks.TabIndex = 1;
            // 
            // OtherCharges
            // 
            this.OtherCharges.BackColor = System.Drawing.Color.White;
            this.OtherCharges.BorderColor = System.Drawing.Color.Silver;
            this.OtherCharges.BorderRadius = 10;
            this.OtherCharges.BorderThickness = 1;
            this.tableLayoutPanel1.SetColumnSpan(this.OtherCharges, 2);
            this.OtherCharges.Controls.Add(this.tableLayoutPanel3);
            this.OtherCharges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OtherCharges.Location = new System.Drawing.Point(1141, 3);
            this.OtherCharges.Name = "OtherCharges";
            this.OtherCharges.Padding = new System.Windows.Forms.Padding(10);
            this.OtherCharges.Size = new System.Drawing.Size(436, 194);
            this.OtherCharges.TabIndex = 17;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124F));
            this.tableLayoutPanel3.Controls.Add(this.tblOtherChargeList, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnAddOtherCharge, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(416, 174);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tblOtherChargeList
            // 
            this.tblOtherChargeList.AllowUserToAddRows = false;
            this.tblOtherChargeList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tblOtherChargeList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblOtherChargeList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tblOtherChargeList.ColumnHeadersHeight = 30;
            this.tableLayoutPanel3.SetColumnSpan(this.tblOtherChargeList, 2);
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblOtherChargeList.DefaultCellStyle = dataGridViewCellStyle3;
            this.tblOtherChargeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblOtherChargeList.GridColor = System.Drawing.SystemColors.Control;
            this.tblOtherChargeList.Location = new System.Drawing.Point(3, 47);
            this.tblOtherChargeList.Name = "tblOtherChargeList";
            this.tblOtherChargeList.RowHeadersVisible = false;
            this.tblOtherChargeList.RowTemplate.Height = 30;
            this.tblOtherChargeList.Size = new System.Drawing.Size(410, 124);
            this.tblOtherChargeList.TabIndex = 9;
            this.tblOtherChargeList.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.LightGrid;
            this.tblOtherChargeList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tblOtherChargeList.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.tblOtherChargeList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.tblOtherChargeList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.tblOtherChargeList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.tblOtherChargeList.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.tblOtherChargeList.ThemeStyle.GridColor = System.Drawing.SystemColors.Control;
            this.tblOtherChargeList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.tblOtherChargeList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tblOtherChargeList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblOtherChargeList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tblOtherChargeList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tblOtherChargeList.ThemeStyle.HeaderStyle.Height = 30;
            this.tblOtherChargeList.ThemeStyle.ReadOnly = false;
            this.tblOtherChargeList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.tblOtherChargeList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tblOtherChargeList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblOtherChargeList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.tblOtherChargeList.ThemeStyle.RowsStyle.Height = 30;
            this.tblOtherChargeList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.Silver;
            this.tblOtherChargeList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.tblOtherChargeList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblOtherChargeList_CellContentClick);
            // 
            // btnAddOtherCharge
            // 
            this.btnAddOtherCharge.BorderRadius = 6;
            this.btnAddOtherCharge.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.btnAddOtherCharge.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnAddOtherCharge.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.btnAddOtherCharge.DisabledState.ForeColor = System.Drawing.Color.Gray;
            this.btnAddOtherCharge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddOtherCharge.FillColor = System.Drawing.Color.White;
            this.btnAddOtherCharge.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOtherCharge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddOtherCharge.HoverState.FillColor = System.Drawing.SystemColors.Control;
            this.btnAddOtherCharge.Image = ((System.Drawing.Image)(resources.GetObject("btnAddOtherCharge.Image")));
            this.btnAddOtherCharge.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddOtherCharge.ImageSize = new System.Drawing.Size(15, 15);
            this.btnAddOtherCharge.Location = new System.Drawing.Point(295, 3);
            this.btnAddOtherCharge.Name = "btnAddOtherCharge";
            this.btnAddOtherCharge.Size = new System.Drawing.Size(118, 38);
            this.btnAddOtherCharge.TabIndex = 6;
            this.btnAddOtherCharge.Text = "Add Charge";
            this.btnAddOtherCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddOtherCharge.Click += new System.EventHandler(this.btnAddOtherCharge_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label1.Size = new System.Drawing.Size(286, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "OTHER CHARGE(S):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Item
            // 
            this.Item.BackColor = System.Drawing.Color.White;
            this.Item.BorderColor = System.Drawing.Color.Silver;
            this.Item.BorderRadius = 10;
            this.Item.BorderThickness = 1;
            this.tableLayoutPanel1.SetColumnSpan(this.Item, 2);
            this.Item.Controls.Add(this.tableLayoutPanel2);
            this.Item.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Item.Location = new System.Drawing.Point(3, 3);
            this.Item.Name = "Item";
            this.Item.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.SetRowSpan(this.Item, 6);
            this.Item.Size = new System.Drawing.Size(1132, 822);
            this.Item.TabIndex = 16;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutPanel2.Controls.Add(this.tblItemList, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnAddItem, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1112, 802);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tblItemList
            // 
            this.tblItemList.AllowUserToAddRows = false;
            this.tblItemList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tblItemList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblItemList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.tblItemList.ColumnHeadersHeight = 30;
            this.tableLayoutPanel2.SetColumnSpan(this.tblItemList, 2);
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblItemList.DefaultCellStyle = dataGridViewCellStyle6;
            this.tblItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblItemList.GridColor = System.Drawing.SystemColors.Control;
            this.tblItemList.Location = new System.Drawing.Point(3, 47);
            this.tblItemList.Name = "tblItemList";
            this.tblItemList.RowHeadersVisible = false;
            this.tblItemList.RowTemplate.Height = 30;
            this.tblItemList.Size = new System.Drawing.Size(1106, 752);
            this.tblItemList.TabIndex = 8;
            this.tblItemList.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.LightGrid;
            this.tblItemList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tblItemList.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.tblItemList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.tblItemList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.tblItemList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.tblItemList.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.tblItemList.ThemeStyle.GridColor = System.Drawing.SystemColors.Control;
            this.tblItemList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.tblItemList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tblItemList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblItemList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tblItemList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tblItemList.ThemeStyle.HeaderStyle.Height = 30;
            this.tblItemList.ThemeStyle.ReadOnly = false;
            this.tblItemList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.tblItemList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tblItemList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblItemList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.tblItemList.ThemeStyle.RowsStyle.Height = 30;
            this.tblItemList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.Silver;
            this.tblItemList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.tblItemList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblItemList_CellContentClick);
            // 
            // btnAddItem
            // 
            this.btnAddItem.BorderRadius = 6;
            this.btnAddItem.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.btnAddItem.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnAddItem.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.btnAddItem.DisabledState.ForeColor = System.Drawing.Color.Gray;
            this.btnAddItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddItem.FillColor = System.Drawing.Color.White;
            this.btnAddItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddItem.HoverState.FillColor = System.Drawing.SystemColors.Control;
            this.btnAddItem.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItem.Image")));
            this.btnAddItem.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddItem.ImageSize = new System.Drawing.Size(15, 15);
            this.btnAddItem.Location = new System.Drawing.Point(1002, 3);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(107, 38);
            this.btnAddItem.TabIndex = 5;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.label3.Size = new System.Drawing.Size(993, 44);
            this.label3.TabIndex = 0;
            this.label3.Text = "ITEMS(S):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Additional
            // 
            this.Additional.BorderRadius = 10;
            this.Additional.Controls.Add(this.label2);
            this.Additional.Controls.Add(this.label4);
            this.Additional.Controls.Add(this.lblAdditionals);
            this.Additional.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Additional.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.Additional.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.Additional.FillColor3 = System.Drawing.Color.Green;
            this.Additional.FillColor4 = System.Drawing.Color.Gainsboro;
            this.Additional.Location = new System.Drawing.Point(1141, 203);
            this.Additional.Name = "Additional";
            this.Additional.Padding = new System.Windows.Forms.Padding(10);
            this.Additional.Size = new System.Drawing.Size(215, 76);
            this.Additional.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.label2.Location = new System.Drawing.Point(181, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 30);
            this.label2.TabIndex = 13;
            this.label2.Text = "+";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.label4.Location = new System.Drawing.Point(15, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "ADDITIONAL(S):";
            // 
            // lblAdditionals
            // 
            this.lblAdditionals.BackColor = System.Drawing.Color.Transparent;
            this.lblAdditionals.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdditionals.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lblAdditionals.Location = new System.Drawing.Point(13, 27);
            this.lblAdditionals.Name = "lblAdditionals";
            this.lblAdditionals.Size = new System.Drawing.Size(189, 42);
            this.lblAdditionals.TabIndex = 11;
            this.lblAdditionals.Text = "₱ 0.00";
            this.lblAdditionals.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Deductions
            // 
            this.Deductions.BorderRadius = 10;
            this.Deductions.Controls.Add(this.label6);
            this.Deductions.Controls.Add(this.label9);
            this.Deductions.Controls.Add(this.lblDeductions);
            this.Deductions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Deductions.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.Deductions.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.Deductions.FillColor3 = System.Drawing.Color.Red;
            this.Deductions.FillColor4 = System.Drawing.Color.Gainsboro;
            this.Deductions.Location = new System.Drawing.Point(1362, 203);
            this.Deductions.Name = "Deductions";
            this.Deductions.Padding = new System.Windows.Forms.Padding(10);
            this.Deductions.Size = new System.Drawing.Size(215, 76);
            this.Deductions.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.label6.Location = new System.Drawing.Point(181, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 30);
            this.label6.TabIndex = 14;
            this.label6.Text = "-";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.label9.Location = new System.Drawing.Point(15, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 17);
            this.label9.TabIndex = 10;
            this.label9.Text = "DEDUCTION(S):";
            // 
            // lblDeductions
            // 
            this.lblDeductions.BackColor = System.Drawing.Color.Transparent;
            this.lblDeductions.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeductions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.lblDeductions.Location = new System.Drawing.Point(13, 26);
            this.lblDeductions.Name = "lblDeductions";
            this.lblDeductions.Size = new System.Drawing.Size(189, 42);
            this.lblDeductions.TabIndex = 12;
            this.lblDeductions.Text = "₱ 0.00";
            this.lblDeductions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Total
            // 
            this.Total.BackColor = System.Drawing.Color.White;
            this.Total.BorderColor = System.Drawing.Color.Silver;
            this.Total.BorderRadius = 10;
            this.Total.BorderThickness = 1;
            this.tableLayoutPanel1.SetColumnSpan(this.Total, 2);
            this.Total.Controls.Add(this.label8);
            this.Total.Controls.Add(this.lblTotal);
            this.Total.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Total.Location = new System.Drawing.Point(1141, 285);
            this.Total.Name = "Total";
            this.Total.Padding = new System.Windows.Forms.Padding(10);
            this.Total.Size = new System.Drawing.Size(436, 124);
            this.Total.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(23, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 21);
            this.label8.TabIndex = 8;
            this.label8.Text = "TOTAL:";
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTotal.Location = new System.Drawing.Point(16, 36);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(405, 73);
            this.lblTotal.TabIndex = 15;
            this.lblTotal.Text = "₱ 0.00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel4, 4);
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel4.Controls.Add(this.lblCashier, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnPay, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblSalesID, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnCancel, 2, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnReset, 3, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 831);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1574, 46);
            this.tableLayoutPanel4.TabIndex = 26;
            // 
            // lblCashier
            // 
            this.lblCashier.AutoSize = true;
            this.lblCashier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCashier.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashier.Location = new System.Drawing.Point(3, 0);
            this.lblCashier.Name = "lblCashier";
            this.lblCashier.Size = new System.Drawing.Size(511, 46);
            this.lblCashier.TabIndex = 17;
            this.lblCashier.Text = "Cashier: Vincent M. Pantia";
            this.lblCashier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPay
            // 
            this.btnPay.BorderRadius = 6;
            this.btnPay.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.btnPay.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnPay.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.btnPay.DisabledState.ForeColor = System.Drawing.Color.Gray;
            this.btnPay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPay.Enabled = false;
            this.btnPay.FillColor = System.Drawing.Color.White;
            this.btnPay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPay.HoverState.FillColor = System.Drawing.SystemColors.Control;
            this.btnPay.Image = global::AllOut.Desktop.Properties.Resources.dg_payment;
            this.btnPay.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnPay.ImageSize = new System.Drawing.Size(30, 30);
            this.btnPay.Location = new System.Drawing.Point(1397, 3);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(174, 40);
            this.btnPay.TabIndex = 2;
            this.btnPay.Text = "Pay";
            this.btnPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // lblSalesID
            // 
            this.lblSalesID.AutoSize = true;
            this.lblSalesID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSalesID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesID.Location = new System.Drawing.Point(520, 0);
            this.lblSalesID.Name = "lblSalesID";
            this.lblSalesID.Size = new System.Drawing.Size(511, 46);
            this.lblSalesID.TabIndex = 17;
            this.lblSalesID.Text = "Sales ID: SL2023012400005";
            this.lblSalesID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 6;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.Gray;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FillColor = System.Drawing.Color.White;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancel.HoverState.FillColor = System.Drawing.SystemColors.Control;
            this.btnCancel.Image = global::AllOut.Desktop.Properties.Resources.dg_close;
            this.btnCancel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCancel.ImageSize = new System.Drawing.Size(30, 30);
            this.btnCancel.Location = new System.Drawing.Point(1037, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(174, 40);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReset
            // 
            this.btnReset.BorderRadius = 6;
            this.btnReset.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.btnReset.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnReset.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.btnReset.DisabledState.ForeColor = System.Drawing.Color.Gray;
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReset.FillColor = System.Drawing.Color.White;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnReset.HoverState.FillColor = System.Drawing.SystemColors.Control;
            this.btnReset.Image = global::AllOut.Desktop.Properties.Resources.dg_reset;
            this.btnReset.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnReset.ImageSize = new System.Drawing.Size(30, 30);
            this.btnReset.Location = new System.Drawing.Point(1217, 3);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(174, 40);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel1.BorderRadius = 10;
            this.guna2Panel1.BorderThickness = 1;
            this.tableLayoutPanel1.SetColumnSpan(this.guna2Panel1, 2);
            this.guna2Panel1.Controls.Add(this.txtPayment);
            this.guna2Panel1.Controls.Add(this.label5);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(1141, 415);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Padding = new System.Windows.Forms.Padding(10);
            this.guna2Panel1.Size = new System.Drawing.Size(436, 124);
            this.guna2Panel1.TabIndex = 25;
            // 
            // txtPayment
            // 
            this.txtPayment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPayment.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold);
            this.txtPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPayment.Location = new System.Drawing.Point(18, 39);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(405, 64);
            this.txtPayment.TabIndex = 0;
            this.txtPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPayment.TextChanged += new System.EventHandler(this.txtPayment_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(23, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "PAYMENT (₱):";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BackColor = System.Drawing.Color.White;
            this.guna2Panel2.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel2.BorderRadius = 10;
            this.guna2Panel2.BorderThickness = 1;
            this.tableLayoutPanel1.SetColumnSpan(this.guna2Panel2, 2);
            this.guna2Panel2.Controls.Add(this.label10);
            this.guna2Panel2.Controls.Add(this.lblChange);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(1141, 545);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.guna2Panel2.Size = new System.Drawing.Size(436, 124);
            this.guna2Panel2.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(23, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 21);
            this.label10.TabIndex = 6;
            this.label10.Text = "CHANGE:";
            // 
            // lblChange
            // 
            this.lblChange.BackColor = System.Drawing.Color.Transparent;
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblChange.Location = new System.Drawing.Point(16, 36);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(405, 73);
            this.lblChange.TabIndex = 16;
            this.lblChange.Text = "₱ 0.00";
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // POSForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "POSForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "POSForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.OtherCharges.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblOtherChargeList)).EndInit();
            this.Item.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblItemList)).EndInit();
            this.Additional.ResumeLayout(false);
            this.Additional.PerformLayout();
            this.Deductions.ResumeLayout(false);
            this.Deductions.PerformLayout();
            this.Total.ResumeLayout(false);
            this.Total.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Panel Item;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Button btnAddItem;
        private Guna.UI2.WinForms.Guna2Panel OtherCharges;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Guna.UI2.WinForms.Guna2Button btnAddOtherCharge;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2DataGridView tblItemList;
        private Guna.UI2.WinForms.Guna2DataGridView tblOtherChargeList;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel Additional;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel Deductions;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDeductions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblAdditionals;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Panel Total;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotal;
        private Guna.UI2.WinForms.Guna2Button btnPay;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2TextBox txtRemarks;
        private System.Windows.Forms.Label lblSalesID;
        private System.Windows.Forms.Label lblCashier;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Guna.UI2.WinForms.Guna2Button btnReset;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.TextBox txtPayment;
    }
}