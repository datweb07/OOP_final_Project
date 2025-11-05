<<<<<<< HEAD
//using System.Drawing;
//using System.Windows.Forms;

//namespace OOP_finalProject
//{
//    partial class ProductForm
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.groupBox2 = new System.Windows.Forms.GroupBox();
//            this.gridData = new System.Windows.Forms.DataGridView();
//            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.groupBox2.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // groupBox2
//            // 
//            this.groupBox2.Controls.Add(this.gridData);
//            this.groupBox2.Location = new System.Drawing.Point(9, 8);
//            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
//            this.groupBox2.Name = "groupBox2";
//            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
//            this.groupBox2.Size = new System.Drawing.Size(820, 367);
//            this.groupBox2.TabIndex = 1;
//            this.groupBox2.TabStop = false;
//            this.groupBox2.Text = "Danh sách";
//            // 
//            // gridData
//            // 
//            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.gridData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
//            this.Column1,
//            this.Column2,
//            this.Column3,
//            this.Column4,
//            this.Column5});
//            this.gridData.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.gridData.Location = new System.Drawing.Point(2, 15);
//            this.gridData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
//            this.gridData.Name = "gridData";
//            this.gridData.RowHeadersWidth = 51;
//            this.gridData.Size = new System.Drawing.Size(816, 350);
//            this.gridData.TabIndex = 1;
//            // 
//            // Column1
//            // 
//            this.Column1.DataPropertyName = "Id";
//            this.Column1.HeaderText = "Mã Hàng";
//            this.Column1.MinimumWidth = 6;
//            this.Column1.Name = "Column1";
//            this.Column1.Width = 125;
//            // 
//            // Column2
//            // 
//            this.Column2.DataPropertyName = "Name";
//            this.Column2.HeaderText = "Tên Hàng";
//            this.Column2.MinimumWidth = 6;
//            this.Column2.Name = "Column2";
//            this.Column2.Width = 250;
//            // 
//            // Column3
//            // 
//            this.Column3.DataPropertyName = "Quantity";
//            this.Column3.HeaderText = "Số Lượng";
//            this.Column3.MinimumWidth = 6;
//            this.Column3.Name = "Column3";
//            this.Column3.Width = 125;
//            // 
//            // Column4
//            // 
//            this.Column4.DataPropertyName = "Price";
//            this.Column4.HeaderText = "Đơn Giá";
//            this.Column4.MinimumWidth = 6;
//            this.Column4.Name = "Column4";
//            this.Column4.Width = 125;
//            // 
//            // Column5
//            // 
//            this.Column5.DataPropertyName = "Display";
//            this.Column5.HeaderText = "Chi tiết sản phẩm";
//            this.Column5.MinimumWidth = 6;
//            this.Column5.Name = "Column5";
//            this.Column5.Width = 450;
//            // 
//            // ProductForm
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(838, 382);
//            this.Controls.Add(this.groupBox2);
//            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
//            this.Name = "ProductForm";
//            this.Text = "DANH SÁCH SẢN PHẨM";
//            this.Load += new System.EventHandler(this.FormProduct_Load);
//            this.groupBox2.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
//            this.ResumeLayout(false);

//        }

//        #endregion

//        private GroupBox groupBox2;
//        private DataGridView gridData;
//        private DataGridViewTextBoxColumn Column1;
//        private DataGridViewTextBoxColumn Column2;
//        private DataGridViewTextBoxColumn Column3;
//        private DataGridViewTextBoxColumn Column4;
//        private DataGridViewTextBoxColumn Column5;
//    }
//}


using System.Drawing;
=======
﻿using System.Drawing;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
using System.Windows.Forms;

namespace OOP_finalProject
{
    partial class ProductForm
    {
<<<<<<< HEAD
        private System.ComponentModel.IContainer components = null;

=======
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

<<<<<<< HEAD
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridData = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLowStockValue = new System.Windows.Forms.Label();
            this.lblLowStock = new System.Windows.Forms.Label();
            this.lblTotalValueValue = new System.Windows.Forms.Label();
            this.lblTotalProductsValue = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblTotalProducts = new System.Windows.Forms.Label();
            this.chkLowStockOnly = new System.Windows.Forms.CheckBox();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.lblSort = new System.Windows.Forms.Label();
            this.cmbProductType = new System.Windows.Forms.ComboBox();
            this.lblProductType = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();

            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();

            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridData);
            this.groupBox2.Location = new System.Drawing.Point(12, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1200, 450);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách sản phẩm";
            // 
            // gridData
            // 
            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.gridData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridData.Location = new System.Drawing.Point(3, 23);
            this.gridData.Name = "gridData";
            this.gridData.RowHeadersWidth = 51;
            this.gridData.Size = new System.Drawing.Size(1194, 424);
            this.gridData.TabIndex = 1;
            this.gridData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridData_CellClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Id";
            this.Column1.HeaderText = "Mã Hàng";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Name";
            this.Column2.HeaderText = "Tên Hàng";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 250;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Quantity";
            this.Column3.HeaderText = "Số Lượng";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Price";
            this.Column4.HeaderText = "Đơn Giá";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Display";
            this.Column5.HeaderText = "Chi tiết sản phẩm";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 450;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLowStockValue);
            this.groupBox1.Controls.Add(this.lblLowStock);
            this.groupBox1.Controls.Add(this.lblTotalValueValue);
            this.groupBox1.Controls.Add(this.lblTotalProductsValue);
            this.groupBox1.Controls.Add(this.lblTotalValue);
            this.groupBox1.Controls.Add(this.lblTotalProducts);
            this.groupBox1.Controls.Add(this.chkLowStockOnly);
            this.groupBox1.Controls.Add(this.cmbSort);
            this.groupBox1.Controls.Add(this.lblSort);
            this.groupBox1.Controls.Add(this.cmbProductType);
            this.groupBox1.Controls.Add(this.lblProductType);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.lblSearch);
            this.groupBox1.Controls.Add(this.statusLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1200, 150);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm & Lọc";
            // 
            // lblLowStockValue
            // 
            this.lblLowStockValue.AutoSize = true;
            this.lblLowStockValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLowStockValue.ForeColor = System.Drawing.Color.Red;
            this.lblLowStockValue.Location = new System.Drawing.Point(1050, 100);
            this.lblLowStockValue.Name = "lblLowStockValue";
            this.lblLowStockValue.Size = new System.Drawing.Size(17, 20);
            this.lblLowStockValue.TabIndex = 15;
            this.lblLowStockValue.Text = "0";
            // 
            // lblLowStock
            // 
            this.lblLowStock.AutoSize = true;
            this.lblLowStock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblLowStock.Location = new System.Drawing.Point(900, 100);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Size = new System.Drawing.Size(144, 20);
            this.lblLowStock.TabIndex = 14;
            this.lblLowStock.Text = "Tồn kho thấp (<10):";
            // 
            // lblTotalValueValue
            // 
            this.lblTotalValueValue.AutoSize = true;
            this.lblTotalValueValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalValueValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblTotalValueValue.Location = new System.Drawing.Point(1050, 70);
            this.lblTotalValueValue.Name = "lblTotalValueValue";
            this.lblTotalValueValue.Size = new System.Drawing.Size(32, 20);
            this.lblTotalValueValue.TabIndex = 13;
            this.lblTotalValueValue.Text = "0 đ";
            // 
            // lblTotalProductsValue
            // 
            this.lblTotalProductsValue.AutoSize = true;
            this.lblTotalProductsValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalProductsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblTotalProductsValue.Location = new System.Drawing.Point(1050, 40);
            this.lblTotalProductsValue.Name = "lblTotalProductsValue";
            this.lblTotalProductsValue.Size = new System.Drawing.Size(17, 20);
            this.lblTotalProductsValue.TabIndex = 12;
            this.lblTotalProductsValue.Text = "0";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.Location = new System.Drawing.Point(900, 70);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(88, 20);
            this.lblTotalValue.TabIndex = 11;
            this.lblTotalValue.Text = "Tổng giá trị:";
            // 
            // lblTotalProducts
            // 
            this.lblTotalProducts.AutoSize = true;
            this.lblTotalProducts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalProducts.Location = new System.Drawing.Point(900, 40);
            this.lblTotalProducts.Name = "lblTotalProducts";
            this.lblTotalProducts.Size = new Size(120, 20);
            this.lblTotalProducts.TabIndex = 10;
            this.lblTotalProducts.Text = "Tổng sản phẩm:";
            // 
            // chkLowStockOnly
            // 
            this.chkLowStockOnly.AutoSize = true;
            this.chkLowStockOnly.Location = new System.Drawing.Point(700, 45);
            this.chkLowStockOnly.Name = "chkLowStockOnly";
            this.chkLowStockOnly.Size = new System.Drawing.Size(174, 24);
            this.chkLowStockOnly.TabIndex = 9;
            this.chkLowStockOnly.Text = "Chỉ hiện tồn kho thấp";
            this.chkLowStockOnly.UseVisualStyleBackColor = true;
            this.chkLowStockOnly.CheckedChanged += new System.EventHandler(this.FilterChanged);
            // 
            // cmbSort
            // 
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Items.AddRange(new object[] {
            "Mã SP (A-Z)",
            "Mã SP (Z-A)",
            "Tên SP (A-Z)",
            "Tên SP (Z-A)",
            "Giá (Thấp-Cao)",
            "Giá (Cao-Thấp)",
            "Số lượng (Thấp-Cao)",
            "Số lượng (Cao-Thấp)",
            "Loại sản phẩm"});
            this.cmbSort.Location = new System.Drawing.Point(450, 40);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(200, 28);
            this.cmbSort.TabIndex = 8;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.FilterChanged);
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(380, 43);
            this.lblSort.Name = "lblSort";
            this.lblSort.Size = new System.Drawing.Size(64, 20);
            this.lblSort.TabIndex = 7;
            this.lblSort.Text = "Sắp xếp:";
            // 
            // cmbProductType
            // 
            this.cmbProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductType.FormattingEnabled = true;
            this.cmbProductType.Items.AddRange(new object[] {
            "Tất cả loại",
            "Đồ uống",
            "Thực phẩm",
            "Gia dụng",
            "Combo",
            "Thời trang",
            "Điện tử"});
            this.cmbProductType.Location = new System.Drawing.Point(450, 80);
            this.cmbProductType.Name = "cmbProductType";
            this.cmbProductType.Size = new System.Drawing.Size(200, 28);
            this.cmbProductType.TabIndex = 6;
            this.cmbProductType.SelectedIndexChanged += new System.EventHandler(this.FilterChanged);
            // 
            // lblProductType
            // 
            this.lblProductType.AutoSize = true;
            this.lblProductType.Location = new System.Drawing.Point(380, 83);
            this.lblProductType.Name = "lblProductType";
            this.lblProductType.Size = new System.Drawing.Size(40, 20);
            this.lblProductType.TabIndex = 5;
            this.lblProductType.Text = "Loại:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(280, 80);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(80, 35);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(280, 40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 35);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(80, 40);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(180, 27);
            this.txtSearch.TabIndex = 2;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(20, 43);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(54, 20);
            this.lblSearch.TabIndex = 1;
            this.lblSearch.Text = "Tìm:";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(20, 100);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(50, 20);
            this.statusLabel.TabIndex = 0;
            this.statusLabel.Text = "Sẵn sàng";
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 650);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "ProductForm";
            this.Text = "DANH SÁCH SẢN PHẨM";
            this.Load += new System.EventHandler(this.FormProduct_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

=======
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox2 = new GroupBox();
            gridData = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridData).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(gridData);
            groupBox2.Location = new Point(12, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1093, 564);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách";
            // 
            // gridData
            // 
            gridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridData.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            gridData.Dock = DockStyle.Fill;
            gridData.Location = new Point(3, 23);
            gridData.Name = "gridData";
            gridData.RowHeadersWidth = 51;
            gridData.Size = new Size(1087, 538);
            gridData.TabIndex = 1;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "Code";
            Column1.HeaderText = "Mã Hàng";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.DataPropertyName = "Name";
            Column2.HeaderText = "Tên Hàng";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 250;
            // 
            // Column3
            // 
            Column3.DataPropertyName = "Qty";
            Column3.HeaderText = "Số Lượng";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.DataPropertyName = "Price";
            Column4.HeaderText = "Đơn Giá";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 125;
            // 
            // Column5
            // 
            Column5.DataPropertyName = "Info";
            Column5.HeaderText = "Mô Tả (đa hình)";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 450;
            // 
            // FormProduct
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1117, 588);
            Controls.Add(groupBox2);
            Name = "FormProduct";
            Text = "DANH SÁCH SẢN PHẨM";
            Load += FormProduct_Load;
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridData).EndInit();
            ResumeLayout(false);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        }

        #endregion

        private GroupBox groupBox2;
        private DataGridView gridData;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
<<<<<<< HEAD
        private GroupBox groupBox1;
        private Button btnRefresh;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label lblSearch;
        private Label statusLabel;
        private ComboBox cmbProductType;
        private Label lblProductType;
        private ComboBox cmbSort;
        private Label lblSort;
        private CheckBox chkLowStockOnly;
        private Label lblTotalProducts;
        private Label lblTotalValue;
        private Label lblTotalProductsValue;
        private Label lblTotalValueValue;
        private Label lblLowStockValue;
        private Label lblLowStock;
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
    }
}