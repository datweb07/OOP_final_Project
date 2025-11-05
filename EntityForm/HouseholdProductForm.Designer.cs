<<<<<<< HEAD
﻿//using System.Drawing;
//using System.Windows.Forms;

//namespace OOP_finalProject
//{
//    partial class HouseholdProductForm
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
//            txtQty = new NumericUpDown();
//            cboBrand = new ComboBox();
//            groupBox1 = new GroupBox();
//            txtPrice = new NumericUpDown();
//            btnDelete = new Button();
//            btnSave = new Button();
//            label1 = new Label();
//            btnRefresh = new Button();
//            label5 = new Label();
//            lblPhone = new Label();
//            txtName = new TextBox();
//            label2 = new Label();
//            txtCode = new TextBox();
//            lblProductCode = new Label();
//            gridData = new DataGridView();
//            groupBox2 = new GroupBox();
//            ((System.ComponentModel.ISupportInitialize)txtQty).BeginInit();
//            groupBox1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)txtPrice).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)gridData).BeginInit();
//            groupBox2.SuspendLayout();
//            SuspendLayout();
//            // 
//            // txtQty
//            // 
//            txtQty.Location = new Point(731, 79);
//            txtQty.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
//            txtQty.Name = "txtQty";
//            txtQty.Size = new Size(333, 27);
//            txtQty.TabIndex = 5;
//            // 
//            // cboBrand
//            // 
//            cboBrand.FormattingEnabled = true;
//            cboBrand.Location = new Point(161, 125);
//            cboBrand.Name = "cboBrand";
//            cboBrand.Size = new Size(404, 28);
//            cboBrand.TabIndex = 4;
//            // 
//            // groupBox1
//            // 
//            groupBox1.Controls.Add(txtQty);
//            groupBox1.Controls.Add(txtPrice);
//            groupBox1.Controls.Add(cboBrand);
//            groupBox1.Controls.Add(btnDelete);
//            groupBox1.Controls.Add(btnSave);
//            groupBox1.Controls.Add(label1);
//            groupBox1.Controls.Add(btnRefresh);
//            groupBox1.Controls.Add(label5);
//            groupBox1.Controls.Add(lblPhone);
//            groupBox1.Controls.Add(txtName);
//            groupBox1.Controls.Add(label2);
//            groupBox1.Controls.Add(txtCode);
//            groupBox1.Controls.Add(lblProductCode);
//            groupBox1.Location = new Point(12, 12);
//            groupBox1.Name = "groupBox1";
//            groupBox1.Size = new Size(1093, 250);
//            groupBox1.TabIndex = 6;
//            groupBox1.TabStop = false;
//            groupBox1.Text = "Chức năng";
//            // 
//            // txtPrice
//            // 
//            txtPrice.Location = new Point(113, 79);
//            txtPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
//            txtPrice.Name = "txtPrice";
//            txtPrice.Size = new Size(452, 27);
//            txtPrice.TabIndex = 5;
//            // 
//            // btnDelete
//            // 
//            btnDelete.Location = new Point(918, 192);
//            btnDelete.Name = "btnDelete";
//            btnDelete.Size = new Size(146, 34);
//            btnDelete.TabIndex = 3;
//            btnDelete.Text = "Xoá";
//            btnDelete.UseVisualStyleBackColor = true;
//            btnDelete.Click += btnDelete_Click;
//            // 
//            // btnSave
//            // 
//            btnSave.Location = new Point(750, 192);
//            btnSave.Name = "btnSave";
//            btnSave.Size = new Size(146, 34);
//            btnSave.TabIndex = 3;
//            btnSave.Text = "Lưu";
//            btnSave.UseVisualStyleBackColor = true;
//            btnSave.Click += btnSave_Click;
//            // 
//            // label1
//            // 
//            label1.AutoSize = true;
//            label1.Location = new Point(650, 86);
//            label1.Name = "label1";
//            label1.Size = new Size(72, 20);
//            label1.TabIndex = 0;
//            label1.Text = "Số Lượng";
//            // 
//            // btnRefresh
//            // 
//            btnRefresh.Location = new Point(583, 192);
//            btnRefresh.Name = "btnRefresh";
//            btnRefresh.Size = new Size(146, 34);
//            btnRefresh.TabIndex = 3;
//            btnRefresh.Text = "Làm mới";
//            btnRefresh.UseVisualStyleBackColor = true;
//            btnRefresh.Click += btnRefresh_Click;
//            // 
//            // label5
//            // 
//            label5.AutoSize = true;
//            label5.Location = new Point(32, 86);
//            label5.Name = "label5";
//            label5.Size = new Size(31, 20);
//            label5.TabIndex = 0;
//            label5.Text = "Giá";
//            // 
//            // lblPhone
//            // 
//            lblPhone.AutoSize = true;
//            lblPhone.Location = new Point(32, 133);
//            lblPhone.Name = "lblPhone";
//            lblPhone.Size = new Size(95, 20);
//            lblPhone.TabIndex = 0;
//            lblPhone.Text = "Thương Hiệu";
//            // 
//            // txtName
//            // 
//            txtName.Location = new Point(731, 34);
//            txtName.Name = "txtName";
//            txtName.Size = new Size(333, 27);
//            txtName.TabIndex = 1;
//            // 
//            // label2
//            // 
//            label2.AutoSize = true;
//            label2.Location = new Point(649, 41);
//            label2.Name = "label2";
//            label2.Size = new Size(52, 20);
//            label2.TabIndex = 0;
//            label2.Text = "Tên SP";
//            // 
//            // txtCode
//            // 
//            txtCode.Location = new Point(113, 34);
//            txtCode.Name = "txtCode";
//            txtCode.Size = new Size(452, 27);
//            txtCode.TabIndex = 1;
//            // 
//            // lblProductCode
//            // 
//            lblProductCode.AutoSize = true;
//            lblProductCode.Location = new Point(31, 41);
//            lblProductCode.Name = "lblProductCode";
//            lblProductCode.Size = new Size(50, 20);
//            lblProductCode.TabIndex = 0;
//            lblProductCode.Text = "Mã SP";
//            // 
//            // gridData
//            // 
//            gridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            gridData.Dock = DockStyle.Fill;
//            gridData.Location = new Point(3, 23);
//            gridData.Name = "gridData";
//            gridData.RowHeadersWidth = 51;
//            gridData.Size = new Size(1087, 266);
//            gridData.TabIndex = 1;
//            gridData.CellEnter += gridData_CellEnter;
//            // 
//            // groupBox2
//            // 
//            groupBox2.Controls.Add(gridData);
//            groupBox2.Location = new Point(12, 284);
//            groupBox2.Name = "groupBox2";
//            groupBox2.Size = new Size(1093, 292);
//            groupBox2.TabIndex = 5;
//            groupBox2.TabStop = false;
//            groupBox2.Text = "Danh sách";
//            // 
//            // FormHouseHoldItem
//            // 
//            AutoScaleDimensions = new SizeF(8F, 20F);
//            AutoScaleMode = AutoScaleMode.Font;
//            ClientSize = new Size(1121, 589);
//            Controls.Add(groupBox1);
//            Controls.Add(groupBox2);
//            Name = "FormHouseHoldItem";
//            Text = "ĐỒ GIA DỤNG";
//            Load += FormHouseHoldItem_Load;
//            ((System.ComponentModel.ISupportInitialize)txtQty).EndInit();
//            groupBox1.ResumeLayout(false);
//            groupBox1.PerformLayout();
//            ((System.ComponentModel.ISupportInitialize)txtPrice).EndInit();
//            ((System.ComponentModel.ISupportInitialize)gridData).EndInit();
//            groupBox2.ResumeLayout(false);
//            ResumeLayout(false);
//        }

//        #endregion
//        private NumericUpDown txtQty;
//        private ComboBox cboBrand;
//        private GroupBox groupBox1;
//        private NumericUpDown txtPrice;
//        private Button btnDelete;
//        private Button btnSave;
//        private Label label1;
//        private Button btnRefresh;
//        private Label label5;
//        private Label lblPhone;
//        private TextBox txtName;
//        private Label label2;
//        private TextBox txtCode;
//        private Label lblProductCode;
//        private DataGridView gridData;
//        private GroupBox groupBox2;
//    }
//}

using System.Drawing;
=======
﻿using System.Drawing;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
using System.Windows.Forms;

namespace OOP_finalProject
{
    partial class HouseholdProductForm
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
=======
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        private void InitializeComponent()
        {
            txtQty = new NumericUpDown();
            cboBrand = new ComboBox();
            groupBox1 = new GroupBox();
<<<<<<< HEAD
            lblBrandCountValue = new Label();
            lblLowStockValue = new Label();
            lblTotalValueValue = new Label();
            lblTotalProductsValue = new Label();
            lblBrandCount = new Label();
            lblLowStock = new Label();
            lblTotalValue = new Label();
            lblTotalProducts = new Label();
            chkLowStockOnly = new CheckBox();
            cmbBrandFilter = new ComboBox();
            lblBrandFilter = new Label();
            groupBoxSort = new GroupBox();
            cmbSort = new ComboBox();
            btnAddNew = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            statusLabel = new Label();
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            txtPrice = new NumericUpDown();
            btnDelete = new Button();
            btnSave = new Button();
            label1 = new Label();
            btnRefresh = new Button();
            label5 = new Label();
<<<<<<< HEAD
            lblBrand = new Label();
=======
            lblPhone = new Label();
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            txtName = new TextBox();
            label2 = new Label();
            txtCode = new TextBox();
            lblProductCode = new Label();
            gridData = new DataGridView();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)txtQty).BeginInit();
            groupBox1.SuspendLayout();
<<<<<<< HEAD
            groupBoxSort.SuspendLayout();
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            ((System.ComponentModel.ISupportInitialize)txtPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridData).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // txtQty
            // 
<<<<<<< HEAD
            txtQty.Location = new Point(557, 125);
=======
            txtQty.Location = new Point(731, 79);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            txtQty.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(333, 27);
            txtQty.TabIndex = 5;
            // 
            // cboBrand
            // 
            cboBrand.FormattingEnabled = true;
<<<<<<< HEAD
            cboBrand.Location = new Point(157, 170);
            cboBrand.Name = "cboBrand";
            cboBrand.Size = new Size(200, 28);
=======
            cboBrand.Location = new Point(161, 125);
            cboBrand.Name = "cboBrand";
            cboBrand.Size = new Size(404, 28);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            cboBrand.TabIndex = 4;
            // 
            // groupBox1
            // 
<<<<<<< HEAD
            groupBox1.Controls.Add(lblBrandCountValue);
            groupBox1.Controls.Add(lblLowStockValue);
            groupBox1.Controls.Add(lblTotalValueValue);
            groupBox1.Controls.Add(lblTotalProductsValue);
            groupBox1.Controls.Add(lblBrandCount);
            groupBox1.Controls.Add(lblLowStock);
            groupBox1.Controls.Add(lblTotalValue);
            groupBox1.Controls.Add(lblTotalProducts);
            groupBox1.Controls.Add(chkLowStockOnly);
            groupBox1.Controls.Add(cmbBrandFilter);
            groupBox1.Controls.Add(lblBrandFilter);
            groupBox1.Controls.Add(groupBoxSort);
            groupBox1.Controls.Add(btnAddNew);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(txtSearch);
            groupBox1.Controls.Add(lblSearch);
            groupBox1.Controls.Add(statusLabel);
            groupBox1.Controls.Add(txtQty);
            groupBox1.Controls.Add(cboBrand);
            groupBox1.Controls.Add(txtPrice);
=======
            groupBox1.Controls.Add(txtQty);
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(cboBrand);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(label5);
<<<<<<< HEAD
            groupBox1.Controls.Add(lblBrand);
=======
            groupBox1.Controls.Add(lblPhone);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtCode);
            groupBox1.Controls.Add(lblProductCode);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
<<<<<<< HEAD
            groupBox1.Size = new Size(1200, 350);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin đồ gia dụng";
            // 
            // lblBrandCountValue
            // 
            lblBrandCountValue.AutoSize = true;
            lblBrandCountValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBrandCountValue.ForeColor = Color.FromArgb(46, 204, 113);
            lblBrandCountValue.Location = new Point(1060, 130);
            lblBrandCountValue.Name = "lblBrandCountValue";
            lblBrandCountValue.Size = new Size(17, 20);
            lblBrandCountValue.TabIndex = 30;
            lblBrandCountValue.Text = "0";
            // 
            // lblLowStockValue
            // 
            lblLowStockValue.AutoSize = true;
            lblLowStockValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLowStockValue.ForeColor = Color.Red;
            lblLowStockValue.Location = new Point(1060, 100);
            lblLowStockValue.Name = "lblLowStockValue";
            lblLowStockValue.Size = new Size(17, 20);
            lblLowStockValue.TabIndex = 29;
            lblLowStockValue.Text = "0";
            // 
            // lblTotalValueValue
            // 
            lblTotalValueValue.AutoSize = true;
            lblTotalValueValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalValueValue.ForeColor = Color.FromArgb(46, 204, 113);
            lblTotalValueValue.Location = new Point(1060, 70);
            lblTotalValueValue.Name = "lblTotalValueValue";
            lblTotalValueValue.Size = new Size(32, 20);
            lblTotalValueValue.TabIndex = 28;
            lblTotalValueValue.Text = "0 đ";
            // 
            // lblTotalProductsValue
            // 
            lblTotalProductsValue.AutoSize = true;
            lblTotalProductsValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalProductsValue.ForeColor = Color.FromArgb(46, 204, 113);
            lblTotalProductsValue.Location = new Point(1060, 40);
            lblTotalProductsValue.Name = "lblTotalProductsValue";
            lblTotalProductsValue.Size = new Size(17, 20);
            lblTotalProductsValue.TabIndex = 27;
            lblTotalProductsValue.Text = "0";
            // 
            // lblBrandCount
            // 
            lblBrandCount.AutoSize = true;
            lblBrandCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBrandCount.Location = new Point(900, 130);
            lblBrandCount.Name = "lblBrandCount";
            lblBrandCount.Size = new Size(144, 20);
            lblBrandCount.TabIndex = 26;
            lblBrandCount.Text = "Số thương hiệu:";
            // 
            // lblLowStock
            // 
            lblLowStock.AutoSize = true;
            lblLowStock.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLowStock.Location = new Point(900, 100);
            lblLowStock.Name = "lblLowStock";
            lblLowStock.Size = new Size(144, 20);
            lblLowStock.TabIndex = 25;
            lblLowStock.Text = "Tồn kho thấp (<10):";
            // 
            // lblTotalValue
            // 
            lblTotalValue.AutoSize = true;
            lblTotalValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalValue.Location = new Point(900, 70);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(88, 20);
            lblTotalValue.TabIndex = 24;
            lblTotalValue.Text = "Tổng giá trị:";
            // 
            // lblTotalProducts
            // 
            lblTotalProducts.AutoSize = true;
            lblTotalProducts.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalProducts.Location = new Point(900, 40);
            lblTotalProducts.Name = "lblTotalProducts";
            lblTotalProducts.Size = new Size(120, 20);
            lblTotalProducts.TabIndex = 23;
            lblTotalProducts.Text = "Tổng sản phẩm:";
            // 
            // chkLowStockOnly
            // 
            chkLowStockOnly.AutoSize = true;
            chkLowStockOnly.Location = new Point(900, 230);
            chkLowStockOnly.Name = "chkLowStockOnly";
            chkLowStockOnly.Size = new Size(174, 24);
            chkLowStockOnly.TabIndex = 22;
            chkLowStockOnly.Text = "Chỉ hiện tồn kho thấp";
            chkLowStockOnly.UseVisualStyleBackColor = true;
            chkLowStockOnly.CheckedChanged += FilterChanged;
            // 
            // cmbBrandFilter
            // 
            cmbBrandFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBrandFilter.FormattingEnabled = true;
            cmbBrandFilter.Location = new Point(157, 230);
            cmbBrandFilter.Name = "cmbBrandFilter";
            cmbBrandFilter.Size = new Size(200, 28);
            cmbBrandFilter.TabIndex = 21;
            cmbBrandFilter.SelectedIndexChanged += FilterChanged;
            // 
            // lblBrandFilter
            // 
            lblBrandFilter.AutoSize = true;
            lblBrandFilter.Location = new Point(31, 233);
            lblBrandFilter.Name = "lblBrandFilter";
            lblBrandFilter.Size = new Size(120, 20);
            lblBrandFilter.TabIndex = 20;
            lblBrandFilter.Text = "Lọc thương hiệu:";
            // 
            // groupBoxSort
            // 
            groupBoxSort.Controls.Add(cmbSort);
            groupBoxSort.Location = new Point(500, 210);
            groupBoxSort.Name = "groupBoxSort";
            groupBoxSort.Size = new Size(250, 80);
            groupBoxSort.TabIndex = 19;
            groupBoxSort.TabStop = false;
            groupBoxSort.Text = "Sắp xếp";
            // 
            // cmbSort
            // 
            cmbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSort.FormattingEnabled = true;
            cmbSort.Items.AddRange(new object[] {
            "Mã SP (A-Z)",
            "Mã SP (Z-A)",
            "Tên SP (A-Z)",
            "Tên SP (Z-A)",
            "Giá (Thấp-Cao)",
            "Giá (Cao-Thấp)",
            "Số lượng (Thấp-Cao)",
            "Số lượng (Cao-Thấp)",
            "Thương hiệu (A-Z)",
            "Thương hiệu (Z-A)"});
            cmbSort.Location = new Point(15, 30);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(220, 28);
            cmbSort.TabIndex = 15;
            cmbSort.SelectedIndexChanged += FilterChanged;
            // 
            // btnAddNew
            // 
            btnAddNew.Location = new Point(490, 34);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(100, 27);
            btnAddNew.TabIndex = 3;
            btnAddNew.Text = "Thêm mới";
            btnAddNew.UseVisualStyleBackColor = true;
            btnAddNew.BackColor = Color.FromArgb(46, 204, 113);
            btnAddNew.ForeColor = Color.White;
            btnAddNew.FlatStyle = FlatStyle.Flat;
            btnAddNew.FlatAppearance.BorderSize = 0;
            btnAddNew.Click += btnAddNew_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(380, 34);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 27);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.BackColor = Color.FromArgb(65, 105, 225);
            btnSearch.ForeColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(113, 34);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(261, 27);
            txtSearch.TabIndex = 16;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(31, 41);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(78, 20);
            lblSearch.TabIndex = 15;
            lblSearch.Text = "Tìm kiếm:";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(700, 40);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(50, 20);
            statusLabel.TabIndex = 14;
            statusLabel.Text = "Sẵn sàng";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(113, 125);
            txtPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(261, 27);
=======
            groupBox1.Size = new Size(1093, 250);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chức năng";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(113, 79);
            txtPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(452, 27);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            txtPrice.TabIndex = 5;
            // 
            // btnDelete
            // 
<<<<<<< HEAD
            btnDelete.Location = new Point(1000, 310);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 34);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
=======
            btnDelete.Location = new Point(918, 192);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(146, 34);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = true;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
<<<<<<< HEAD
            btnSave.Location = new Point(884, 310);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 34);
            btnSave.TabIndex = 3;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
=======
            btnSave.Location = new Point(750, 192);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(146, 34);
            btnSave.TabIndex = 3;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
<<<<<<< HEAD
            label1.Location = new Point(475, 130);
=======
            label1.Location = new Point(650, 86);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 0;
            label1.Text = "Số Lượng";
            // 
            // btnRefresh
            // 
<<<<<<< HEAD
            btnRefresh.Location = new Point(768, 310);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 34);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;
=======
            btnRefresh.Location = new Point(583, 192);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(146, 34);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            btnRefresh.Click += btnRefresh_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
<<<<<<< HEAD
            label5.Location = new Point(31, 130);
=======
            label5.Location = new Point(32, 86);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            label5.Name = "label5";
            label5.Size = new Size(31, 20);
            label5.TabIndex = 0;
            label5.Text = "Giá";
            // 
<<<<<<< HEAD
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Location = new Point(31, 173);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(95, 20);
            lblBrand.TabIndex = 0;
            lblBrand.Text = "Thương Hiệu";
            // 
            // txtName
            // 
            txtName.Location = new Point(557, 80);
=======
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(32, 133);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(95, 20);
            lblPhone.TabIndex = 0;
            lblPhone.Text = "Thương Hiệu";
            // 
            // txtName
            // 
            txtName.Location = new Point(731, 34);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            txtName.Name = "txtName";
            txtName.Size = new Size(333, 27);
            txtName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
<<<<<<< HEAD
            label2.Location = new Point(475, 87);
=======
            label2.Location = new Point(649, 41);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 0;
            label2.Text = "Tên SP";
            // 
            // txtCode
            // 
<<<<<<< HEAD
            txtCode.Location = new Point(113, 80);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(261, 27);
=======
            txtCode.Location = new Point(113, 34);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(452, 27);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            txtCode.TabIndex = 1;
            // 
            // lblProductCode
            // 
            lblProductCode.AutoSize = true;
<<<<<<< HEAD
            lblProductCode.Location = new Point(31, 87);
=======
            lblProductCode.Location = new Point(31, 41);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            lblProductCode.Name = "lblProductCode";
            lblProductCode.Size = new Size(50, 20);
            lblProductCode.TabIndex = 0;
            lblProductCode.Text = "Mã SP";
            // 
            // gridData
            // 
            gridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridData.Dock = DockStyle.Fill;
            gridData.Location = new Point(3, 23);
            gridData.Name = "gridData";
            gridData.RowHeadersWidth = 51;
<<<<<<< HEAD
            gridData.Size = new Size(1194, 274);
=======
            gridData.Size = new Size(1087, 266);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            gridData.TabIndex = 1;
            gridData.CellEnter += gridData_CellEnter;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(gridData);
<<<<<<< HEAD
            groupBox2.Location = new Point(12, 368);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1200, 300);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách đồ gia dụng";
            // 
            // HouseholdProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1224, 680);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "HouseholdProductForm";
            Text = "QUẢN LÝ ĐỒ GIA DỤNG";
=======
            groupBox2.Location = new Point(12, 284);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1093, 292);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách";
            // 
            // FormHouseHoldItem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1121, 589);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "FormHouseHoldItem";
            Text = "ĐỒ GIA DỤNG";
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            Load += FormHouseHoldItem_Load;
            ((System.ComponentModel.ISupportInitialize)txtQty).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
<<<<<<< HEAD
            groupBoxSort.ResumeLayout(false);
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            ((System.ComponentModel.ISupportInitialize)txtPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridData).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private NumericUpDown txtQty;
        private ComboBox cboBrand;
        private GroupBox groupBox1;
        private NumericUpDown txtPrice;
        private Button btnDelete;
        private Button btnSave;
        private Label label1;
        private Button btnRefresh;
        private Label label5;
<<<<<<< HEAD
        private Label lblBrand;
=======
        private Label lblPhone;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        private TextBox txtName;
        private Label label2;
        private TextBox txtCode;
        private Label lblProductCode;
        private DataGridView gridData;
        private GroupBox groupBox2;
<<<<<<< HEAD
        private Label statusLabel;
        private TextBox txtSearch;
        private Label lblSearch;
        private Button btnSearch;
        private Button btnAddNew;
        private GroupBox groupBoxSort;
        private ComboBox cmbSort;
        private ComboBox cmbBrandFilter;
        private Label lblBrandFilter;
        private CheckBox chkLowStockOnly;
        private Label lblTotalProducts;
        private Label lblTotalValue;
        private Label lblLowStock;
        private Label lblBrandCount;
        private Label lblTotalProductsValue;
        private Label lblTotalValueValue;
        private Label lblLowStockValue;
        private Label lblBrandCountValue;
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
    }
}