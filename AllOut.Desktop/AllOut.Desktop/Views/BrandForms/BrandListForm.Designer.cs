﻿namespace AllOut.Desktop.Views.BrandForms
{
    partial class BrandListForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.tblBrandList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnUncheckAll = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.btnCheckAll = new Guna.UI2.WinForms.Guna2Button();
            this.btnDisable = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddBrand = new Guna.UI2.WinForms.Guna2Button();
            this.btnEnable = new Guna.UI2.WinForms.Guna2Button();
            this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
            this.btnSearchToolTip = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            this.txtBrandName = new Guna.UI2.WinForms.Guna2TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblBrandList)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 948F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.guna2Panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1179, 525);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.tblBrandList);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(3, 110);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1173, 412);
            this.guna2Panel1.TabIndex = 6;
            // 
            // tblBrandList
            // 
            this.tblBrandList.AllowUserToAddRows = false;
            this.tblBrandList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tblBrandList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblBrandList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tblBrandList.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblBrandList.DefaultCellStyle = dataGridViewCellStyle3;
            this.tblBrandList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblBrandList.GridColor = System.Drawing.SystemColors.Control;
            this.tblBrandList.Location = new System.Drawing.Point(0, 0);
            this.tblBrandList.Name = "tblBrandList";
            this.tblBrandList.RowHeadersVisible = false;
            this.tblBrandList.RowTemplate.Height = 30;
            this.tblBrandList.Size = new System.Drawing.Size(1173, 412);
            this.tblBrandList.TabIndex = 5;
            this.tblBrandList.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.LightGrid;
            this.tblBrandList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tblBrandList.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.tblBrandList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.tblBrandList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.tblBrandList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.tblBrandList.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.tblBrandList.ThemeStyle.GridColor = System.Drawing.SystemColors.Control;
            this.tblBrandList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.White;
            this.tblBrandList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tblBrandList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblBrandList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tblBrandList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tblBrandList.ThemeStyle.HeaderStyle.Height = 30;
            this.tblBrandList.ThemeStyle.ReadOnly = false;
            this.tblBrandList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.tblBrandList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tblBrandList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblBrandList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.tblBrandList.ThemeStyle.RowsStyle.Height = 30;
            this.tblBrandList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.Silver;
            this.tblBrandList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.tblBrandList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblBrandList_CellContentClick);
            this.tblBrandList.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.tblBrandList_RowPrePaint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.guna2PictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1173, 54);
            this.panel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(54, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(429, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "In this page you will see the list of all brands that is saved on the system";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(53, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Brands";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::AllOut.Desktop.Properties.Resources.icons8_branding_90;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(7, 7);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(40, 40);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 3;
            this.guna2PictureBox1.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 9;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 277F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel2.Controls.Add(this.btnUncheckAll, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDelete, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnCheckAll, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDisable, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAddBrand, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnEnable, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSearch, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtBrandName, 7, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 63);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1173, 41);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // btnUncheckAll
            // 
            this.btnUncheckAll.BorderRadius = 6;
            this.btnUncheckAll.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUncheckAll.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUncheckAll.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUncheckAll.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUncheckAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUncheckAll.FillColor = System.Drawing.Color.White;
            this.btnUncheckAll.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUncheckAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUncheckAll.HoverState.FillColor = System.Drawing.SystemColors.Control;
            this.btnUncheckAll.Image = global::AllOut.Desktop.Properties.Resources.icons8_indeterminate_checkbox_96;
            this.btnUncheckAll.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUncheckAll.ImageSize = new System.Drawing.Size(15, 15);
            this.btnUncheckAll.Location = new System.Drawing.Point(200, 3);
            this.btnUncheckAll.Name = "btnUncheckAll";
            this.btnUncheckAll.Size = new System.Drawing.Size(114, 35);
            this.btnUncheckAll.TabIndex = 9;
            this.btnUncheckAll.Text = "Uncheck All";
            this.btnUncheckAll.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnUncheckAll.Click += new System.EventHandler(this.btnUncheckAll_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BorderRadius = 6;
            this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.FillColor = System.Drawing.Color.White;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDelete.HoverState.FillColor = System.Drawing.SystemColors.Control;
            this.btnDelete.Image = global::AllOut.Desktop.Properties.Resources.icons8_trash_90;
            this.btnDelete.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDelete.ImageSize = new System.Drawing.Size(15, 15);
            this.btnDelete.Location = new System.Drawing.Point(500, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 35);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCheckAll
            // 
            this.btnCheckAll.BorderRadius = 6;
            this.btnCheckAll.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCheckAll.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCheckAll.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCheckAll.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCheckAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCheckAll.FillColor = System.Drawing.Color.White;
            this.btnCheckAll.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCheckAll.HoverState.FillColor = System.Drawing.SystemColors.Control;
            this.btnCheckAll.Image = global::AllOut.Desktop.Properties.Resources.icons8_checkmark_90;
            this.btnCheckAll.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCheckAll.ImageSize = new System.Drawing.Size(15, 15);
            this.btnCheckAll.Location = new System.Drawing.Point(93, 3);
            this.btnCheckAll.Name = "btnCheckAll";
            this.btnCheckAll.Size = new System.Drawing.Size(101, 35);
            this.btnCheckAll.TabIndex = 8;
            this.btnCheckAll.Text = "Check All";
            this.btnCheckAll.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCheckAll.Click += new System.EventHandler(this.btnCheckAll_Click);
            // 
            // btnDisable
            // 
            this.btnDisable.BorderRadius = 6;
            this.btnDisable.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDisable.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDisable.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDisable.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDisable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDisable.FillColor = System.Drawing.Color.White;
            this.btnDisable.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDisable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnDisable.HoverState.FillColor = System.Drawing.SystemColors.Control;
            this.btnDisable.Image = global::AllOut.Desktop.Properties.Resources.icons8_disable_toggle_slider_isolated_in_white_background_96;
            this.btnDisable.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDisable.ImageSize = new System.Drawing.Size(15, 15);
            this.btnDisable.Location = new System.Drawing.Point(410, 3);
            this.btnDisable.Name = "btnDisable";
            this.btnDisable.Size = new System.Drawing.Size(84, 35);
            this.btnDisable.TabIndex = 6;
            this.btnDisable.Text = "Disable";
            this.btnDisable.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnDisable.Click += new System.EventHandler(this.btnDisable_Click);
            // 
            // btnAddBrand
            // 
            this.btnAddBrand.BorderRadius = 6;
            this.btnAddBrand.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddBrand.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddBrand.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddBrand.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddBrand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddBrand.FillColor = System.Drawing.Color.White;
            this.btnAddBrand.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAddBrand.HoverState.FillColor = System.Drawing.SystemColors.Control;
            this.btnAddBrand.Image = global::AllOut.Desktop.Properties.Resources.icons8_plus_math_90;
            this.btnAddBrand.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddBrand.ImageSize = new System.Drawing.Size(15, 15);
            this.btnAddBrand.Location = new System.Drawing.Point(3, 3);
            this.btnAddBrand.Name = "btnAddBrand";
            this.btnAddBrand.Size = new System.Drawing.Size(84, 35);
            this.btnAddBrand.TabIndex = 0;
            this.btnAddBrand.Text = "Add";
            this.btnAddBrand.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnAddBrand.Click += new System.EventHandler(this.btnAddBrand_Click);
            // 
            // btnEnable
            // 
            this.btnEnable.BorderRadius = 6;
            this.btnEnable.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEnable.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEnable.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEnable.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEnable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEnable.FillColor = System.Drawing.Color.White;
            this.btnEnable.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnEnable.HoverState.FillColor = System.Drawing.SystemColors.Control;
            this.btnEnable.Image = global::AllOut.Desktop.Properties.Resources.icons8_enable_toggle_slider_isolated_in_white_background_96;
            this.btnEnable.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnEnable.ImageSize = new System.Drawing.Size(15, 15);
            this.btnEnable.Location = new System.Drawing.Point(320, 3);
            this.btnEnable.Name = "btnEnable";
            this.btnEnable.Size = new System.Drawing.Size(84, 35);
            this.btnEnable.TabIndex = 0;
            this.btnEnable.Text = "Enable";
            this.btnEnable.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnEnable.Click += new System.EventHandler(this.btnEnable_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BorderRadius = 6;
            this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSearch.FillColor = System.Drawing.Color.White;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSearch.HoverState.FillColor = System.Drawing.SystemColors.Control;
            this.btnSearch.Image = global::AllOut.Desktop.Properties.Resources.icons8_search_50;
            this.btnSearch.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSearch.Location = new System.Drawing.Point(1130, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(40, 35);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnSearchToolTip
            // 
            this.btnSearchToolTip.AllowLinksHandling = true;
            this.btnSearchToolTip.MaximumSize = new System.Drawing.Size(0, 0);
            // 
            // txtBrandName
            // 
            this.txtBrandName.BorderColor = System.Drawing.Color.Silver;
            this.txtBrandName.BorderRadius = 6;
            this.txtBrandName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtBrandName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBrandName.DefaultText = "";
            this.txtBrandName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBrandName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBrandName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBrandName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBrandName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBrandName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBrandName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrandName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBrandName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBrandName.Location = new System.Drawing.Point(853, 3);
            this.txtBrandName.MaxLength = 50;
            this.txtBrandName.Name = "txtBrandName";
            this.txtBrandName.PasswordChar = '\0';
            this.txtBrandName.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtBrandName.PlaceholderText = "Search Brand";
            this.txtBrandName.SelectedText = "";
            this.txtBrandName.Size = new System.Drawing.Size(271, 35);
            this.txtBrandName.TabIndex = 11;
            // 
            // BrandListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1179, 525);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BrandListForm";
            this.Text = "BrandListForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblBrandList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2DataGridView tblBrandList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Guna.UI2.WinForms.Guna2Button btnUncheckAll;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnCheckAll;
        private Guna.UI2.WinForms.Guna2Button btnDisable;
        private Guna.UI2.WinForms.Guna2Button btnAddBrand;
        private Guna.UI2.WinForms.Guna2Button btnEnable;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2HtmlToolTip btnSearchToolTip;
        private Guna.UI2.WinForms.Guna2TextBox txtBrandName;
    }
}