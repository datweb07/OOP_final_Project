<<<<<<< HEAD
//using System.Drawing;
//using System.Windows.Forms;

//namespace OOP_finalProject
//{
//    partial class ListInvoiceForm
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
//            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
//            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
//            gridData = new DataGridView();
//            Column1 = new DataGridViewTextBoxColumn();
//            Column2 = new DataGridViewTextBoxColumn();
//            Column3 = new DataGridViewTextBoxColumn();
//            Column4 = new DataGridViewTextBoxColumn();
//            Column5 = new DataGridViewTextBoxColumn();
//            groupBox1 = new GroupBox();
//            btnDelete = new Button();
//            btnXemHoaDon = new Button();
//            groupBox2 = new GroupBox();
//            ((System.ComponentModel.ISupportInitialize)gridData).BeginInit();
//            groupBox1.SuspendLayout();
//            groupBox2.SuspendLayout();
//            SuspendLayout();
//            // 
//            // gridData
//            // 
//            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
//            gridData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
//            gridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            gridData.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
//            gridData.Dock = DockStyle.Fill;
//            gridData.Location = new Point(3, 23);
//            gridData.Name = "gridData";
//            gridData.RowHeadersWidth = 51;
//            gridData.Size = new Size(1230, 430);
//            gridData.TabIndex = 2;
//            // 
//            // Column1
//            // 
//            Column1.DataPropertyName = "Id";
//            Column1.HeaderText = "Mã HĐ";
//            Column1.MinimumWidth = 6;
//            Column1.Name = "Column1";
//            Column1.Width = 125;
//            // 
//            // Column2
//            // 
//            Column2.DataPropertyName = "DateCreated";
//            Column2.HeaderText = "Ngày Lập";
//            Column2.MinimumWidth = 6;
//            Column2.Name = "Column2";
//            Column2.Width = 125;
//            // 
//            // Column3
//            // 
//            Column3.DataPropertyName = "CashierName";
//            Column3.HeaderText = "Nhân Viên";
//            Column3.MinimumWidth = 6;
//            Column3.Name = "Column3";
//            Column3.Width = 250;
//            // 
//            // Column4
//            // 
//            Column4.DataPropertyName = "CustomerName";
//            Column4.HeaderText = "Khách Hàng";
//            Column4.MinimumWidth = 6;
//            Column4.Name = "Column4";
//            Column4.Width = 250;
//            // 
//            // Column5
//            // 
//            Column5.DataPropertyName = "FinalTotal";
//            dataGridViewCellStyle2.Format = "#,###";
//            Column5.DefaultCellStyle = dataGridViewCellStyle2;
//            Column5.HeaderText = "Thành Tiền (sau giảm)";
//            Column5.MinimumWidth = 6;
//            Column5.Name = "Column5";
//            Column5.Width = 125;
//            // 
//            // groupBox1
//            // 
//            groupBox1.Controls.Add(btnDelete);
//            groupBox1.Controls.Add(btnXemHoaDon);
//            groupBox1.Location = new Point(12, 12);
//            groupBox1.Name = "groupBox1";
//            groupBox1.Size = new Size(1236, 83);
//            groupBox1.TabIndex = 1;
//            groupBox1.TabStop = false;
//            groupBox1.Text = "Chức năng";
//            // 
//            // btnDelete
//            // 
//            btnDelete.Location = new Point(1048, 26);
//            btnDelete.Name = "btnDelete";
//            btnDelete.Size = new Size(158, 34);
//            btnDelete.TabIndex = 4;
//            btnDelete.Text = "Xoá";
//            btnDelete.UseVisualStyleBackColor = true;
//            btnDelete.Click += btnDelete_Click;
//            // 
//            // btnXemHoaDon
//            // 
//            btnXemHoaDon.Location = new Point(864, 26);
//            btnXemHoaDon.Name = "btnXemHoaDon";
//            btnXemHoaDon.Size = new Size(146, 34);
//            btnXemHoaDon.TabIndex = 6;
//            btnXemHoaDon.Text = "Xem Hoá Đơn";
//            btnXemHoaDon.UseVisualStyleBackColor = true;
//            btnXemHoaDon.Click += btnXemHoaDon_Click;
//            // 
//            // groupBox2
//            // 
//            groupBox2.Controls.Add(gridData);
//            groupBox2.Location = new Point(12, 101);
//            groupBox2.Name = "groupBox2";
//            groupBox2.Size = new Size(1236, 456);
//            groupBox2.TabIndex = 2;
//            groupBox2.TabStop = false;
//            groupBox2.Text = "Danh sách hoá đơn";
//            // 
//            // FormInvoiceList
//            // 
//            AutoScaleDimensions = new SizeF(8F, 20F);
//            AutoScaleMode = AutoScaleMode.Font;
//            ClientSize = new Size(1266, 572);
//            Controls.Add(groupBox1);
//            Controls.Add(groupBox2);
//            Name = "FormInvoiceList";
//            Text = "DANH SÁCH HOÁ ĐƠN";
//            Load += FormInvoiceList_Load;
//            ((System.ComponentModel.ISupportInitialize)gridData).EndInit();
//            groupBox1.ResumeLayout(false);
//            groupBox2.ResumeLayout(false);
//            ResumeLayout(false);
//        }

//        #endregion

//        private DataGridView gridData;
//        private GroupBox groupBox1;
//        private Button btnDelete;
//        private Button btnXemHoaDon;
//        private GroupBox groupBox2;
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
    partial class ListInvoiceForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            gridData = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
<<<<<<< HEAD
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            lblCustomerCountValue = new Label();
            lblTotalDiscountValue = new Label();
            lblTotalRevenueValue = new Label();
            lblTotalInvoicesValue = new Label();
            lblCustomerCount = new Label();
            lblTotalDiscount = new Label();
            lblTotalRevenue = new Label();
            lblTotalInvoices = new Label();
            groupBoxSort = new GroupBox();
            cmbSort = new ComboBox();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            statusLabel = new Label();
            btnRefresh = new Button();
=======
            groupBox1 = new GroupBox();
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            btnDelete = new Button();
            btnXemHoaDon = new Button();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)gridData).BeginInit();
            groupBox1.SuspendLayout();
<<<<<<< HEAD
            groupBoxSort.SuspendLayout();
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // gridData
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            gridData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            gridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
<<<<<<< HEAD
            gridData.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column8, Column6, Column7, Column5, Column9 });
=======
            gridData.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            gridData.Dock = DockStyle.Fill;
            gridData.Location = new Point(3, 23);
            gridData.Name = "gridData";
            gridData.RowHeadersWidth = 51;
            gridData.Size = new Size(1230, 430);
            gridData.TabIndex = 2;
            // 
            // Column1
            // 
<<<<<<< HEAD
            Column1.DataPropertyName = "Id";
=======
            Column1.DataPropertyName = "Code";
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            Column1.HeaderText = "Mã HĐ";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // Column2
            // 
<<<<<<< HEAD
            Column2.DataPropertyName = "DateCreated";
=======
            Column2.DataPropertyName = "CreatedDate";
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            Column2.HeaderText = "Ngày Lập";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // Column3
            // 
<<<<<<< HEAD
            Column3.DataPropertyName = "CashierName";
=======
            Column3.DataPropertyName = "SellerName";
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            Column3.HeaderText = "Nhân Viên";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 250;
            // 
            // Column4
            // 
            Column4.DataPropertyName = "CustomerName";
            Column4.HeaderText = "Khách Hàng";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 250;
            // 
            // Column5
            // 
<<<<<<< HEAD
            Column5.DataPropertyName = "FinalTotal";
            dataGridViewCellStyle2.Format = "#,###";
            Column5.DefaultCellStyle = dataGridViewCellStyle2;
            Column5.HeaderText = "Thành Tiền";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 125;
            //
            // Column6
            //
            Column6.DataPropertyName = "DiscountAmount";
            Column6.DefaultCellStyle = dataGridViewCellStyle2;
            Column6.HeaderText = "Giảm Giá";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.Width = 125;
            //
            // Column7
            //
            Column7.DataPropertyName = "DiscountPercentage";
            Column7.HeaderText = "Phần Trăm";
            Column7.MinimumWidth = 6;
            Column7.Name = "Column7";
            Column7.Width = 125;
            //
            // Column8
            //
            Column8.DataPropertyName = "SumTotal";
            Column8.DefaultCellStyle = dataGridViewCellStyle2;
            Column8.HeaderText = "Tổng Tiền";
            Column8.MinimumWidth = 6;
            Column8.Name = "Column8";
            Column8.Width = 125;
            //
            // Column9
            //
            Column9.DataPropertyName = "DiscountInfo";
            Column9.HeaderText = "Thông Tin";
            Column9.MinimumWidth = 6;
            Column9.Name = "Column9";
            Column9.Width = 200;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblCustomerCountValue);
            groupBox1.Controls.Add(lblTotalDiscountValue);
            groupBox1.Controls.Add(lblTotalRevenueValue);
            groupBox1.Controls.Add(lblTotalInvoicesValue);
            groupBox1.Controls.Add(lblCustomerCount);
            groupBox1.Controls.Add(lblTotalDiscount);
            groupBox1.Controls.Add(lblTotalRevenue);
            groupBox1.Controls.Add(lblTotalInvoices);
            groupBox1.Controls.Add(groupBoxSort);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(txtSearch);
            groupBox1.Controls.Add(lblSearch);
            groupBox1.Controls.Add(statusLabel);
            groupBox1.Controls.Add(btnRefresh);
=======
            Column5.DataPropertyName = "SumTotal";
            dataGridViewCellStyle2.Format = "#,###";
            Column5.DefaultCellStyle = dataGridViewCellStyle2;
            Column5.HeaderText = "Tổng Tiền";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.Width = 125;
            // 
            // groupBox1
            // 
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnXemHoaDon);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
<<<<<<< HEAD
            groupBox1.Size = new Size(1300, 270);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin hoá đơn";
            // 
            // lblCustomerCountValue
            // 
            lblCustomerCountValue.AutoSize = true;
            lblCustomerCountValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCustomerCountValue.ForeColor = Color.FromArgb(46, 204, 113);
            lblCustomerCountValue.Location = new Point(1060, 130);
            lblCustomerCountValue.Name = "lblCustomerCountValue";
            lblCustomerCountValue.Size = new Size(17, 20);
            lblCustomerCountValue.TabIndex = 30;
            lblCustomerCountValue.Text = "0";
            // 
            // lblTotalDiscountValue
            // 
            lblTotalDiscountValue.AutoSize = true;
            lblTotalDiscountValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalDiscountValue.ForeColor = Color.FromArgb(255, 165, 0);
            lblTotalDiscountValue.Location = new Point(1060, 100);
            lblTotalDiscountValue.Name = "lblTotalDiscountValue";
            lblTotalDiscountValue.Size = new Size(32, 20);
            lblTotalDiscountValue.TabIndex = 29;
            lblTotalDiscountValue.Text = "0 đ";
            // 
            // lblTotalRevenueValue
            // 
            lblTotalRevenueValue.AutoSize = true;
            lblTotalRevenueValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalRevenueValue.ForeColor = Color.FromArgb(46, 204, 113);
            lblTotalRevenueValue.Location = new Point(1060, 70);
            lblTotalRevenueValue.Name = "lblTotalRevenueValue";
            lblTotalRevenueValue.Size = new Size(32, 20);
            lblTotalRevenueValue.TabIndex = 28;
            lblTotalRevenueValue.Text = "0 đ";
            // 
            // lblTotalInvoicesValue
            // 
            lblTotalInvoicesValue.AutoSize = true;
            lblTotalInvoicesValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalInvoicesValue.ForeColor = Color.FromArgb(46, 204, 113);
            lblTotalInvoicesValue.Location = new Point(1060, 40);
            lblTotalInvoicesValue.Name = "lblTotalInvoicesValue";
            lblTotalInvoicesValue.Size = new Size(17, 20);
            lblTotalInvoicesValue.TabIndex = 27;
            lblTotalInvoicesValue.Text = "0";
            // 
            // lblCustomerCount
            // 
            lblCustomerCount.AutoSize = true;
            lblCustomerCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCustomerCount.Location = new Point(900, 130);
            lblCustomerCount.Name = "lblCustomerCount";
            lblCustomerCount.Size = new Size(120, 20);
            lblCustomerCount.TabIndex = 26;
            lblCustomerCount.Text = "Số khách hàng:";
            // 
            // lblTotalDiscount
            // 
            lblTotalDiscount.AutoSize = true;
            lblTotalDiscount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalDiscount.Location = new Point(900, 100);
            lblTotalDiscount.Name = "lblTotalDiscount";
            lblTotalDiscount.Size = new Size(124, 20);
            lblTotalDiscount.TabIndex = 25;
            lblTotalDiscount.Text = "Tổng giảm giá:";
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalRevenue.Location = new Point(900, 70);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(100, 20);
            lblTotalRevenue.TabIndex = 24;
            lblTotalRevenue.Text = "Tổng doanh thu:";
            // 
            // lblTotalInvoices
            // 
            lblTotalInvoices.AutoSize = true;
            lblTotalInvoices.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalInvoices.Location = new Point(900, 40);
            lblTotalInvoices.Name = "lblTotalInvoices";
            lblTotalInvoices.Size = new Size(120, 20);
            lblTotalInvoices.TabIndex = 23;
            lblTotalInvoices.Text = "Tổng hoá đơn:";
            // 
            // groupBoxSort
            // 
            groupBoxSort.Controls.Add(cmbSort);
            groupBoxSort.Location = new Point(31, 100);
            groupBoxSort.Name = "groupBoxSort";
            groupBoxSort.Size = new Size(250, 70);
            groupBoxSort.TabIndex = 19;
            groupBoxSort.TabStop = false;
            groupBoxSort.Text = "Sắp xếp";
            // 
            // cmbSort
            // 
            cmbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSort.FormattingEnabled = true;
            cmbSort.Items.AddRange(new object[] {
            "Mã HĐ (A-Z)",
            "Mã HĐ (Z-A)",
            "Ngày lập (Cũ-Nhất)",
            "Ngày lập (Mới-Nhất)",
            "Nhân viên (A-Z)",
            "Nhân viên (Z-A)",
            "Khách hàng (A-Z)",
            "Khách hàng (Z-A)",
            "Thành tiền (Thấp-Cao)",
            "Thành tiền (Cao-Thấp)"});
            cmbSort.Location = new Point(15, 30);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(220, 28);
            cmbSort.TabIndex = 15;
            cmbSort.SelectedIndexChanged += FilterChanged;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(380, 40);
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
            txtSearch.Location = new Point(113, 40);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(261, 27);
            txtSearch.TabIndex = 16;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(31, 47);
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
            // btnRefresh
            // 
            btnRefresh.Location = new Point(490, 40);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 27);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1048, 200);
=======
            groupBox1.Size = new Size(1236, 83);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chức năng";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1048, 26);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(158, 34);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = true;
<<<<<<< HEAD
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            btnDelete.Click += btnDelete_Click;
            // 
            // btnXemHoaDon
            // 
<<<<<<< HEAD
            btnXemHoaDon.Location = new Point(864, 200);
=======
            btnXemHoaDon.Location = new Point(864, 26);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            btnXemHoaDon.Name = "btnXemHoaDon";
            btnXemHoaDon.Size = new Size(146, 34);
            btnXemHoaDon.TabIndex = 6;
            btnXemHoaDon.Text = "Xem Hoá Đơn";
            btnXemHoaDon.UseVisualStyleBackColor = true;
<<<<<<< HEAD
            btnXemHoaDon.BackColor = Color.FromArgb(155, 89, 182);
            btnXemHoaDon.ForeColor = Color.White;
            btnXemHoaDon.FlatStyle = FlatStyle.Flat;
            btnXemHoaDon.FlatAppearance.BorderSize = 0;
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            btnXemHoaDon.Click += btnXemHoaDon_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(gridData);
<<<<<<< HEAD
            groupBox2.Location = new Point(12, 300);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1300, 456);
=======
            groupBox2.Location = new Point(12, 101);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1236, 456);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách hoá đơn";
            // 
<<<<<<< HEAD
            // ListInvoiceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1260, 666);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "ListInvoiceForm";
            Text = "QUẢN LÝ HOÁ ĐƠN";
            Load += FormInvoiceList_Load;
            ((System.ComponentModel.ISupportInitialize)gridData).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBoxSort.ResumeLayout(false);
=======
            // FormInvoiceList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1266, 572);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "FormInvoiceList";
            Text = "DANH SÁCH HOÁ ĐƠN";
            Load += FormInvoiceList_Load;
            ((System.ComponentModel.ISupportInitialize)gridData).EndInit();
            groupBox1.ResumeLayout(false);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridData;
        private GroupBox groupBox1;
        private Button btnDelete;
        private Button btnXemHoaDon;
        private GroupBox groupBox2;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
<<<<<<< HEAD
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private Button btnRefresh;
        private Label statusLabel;
        private TextBox txtSearch;
        private Label lblSearch;
        private Button btnSearch;
        private GroupBox groupBoxSort;
        private ComboBox cmbSort;
        private Label lblTotalInvoices;
        private Label lblTotalRevenue;
        private Label lblTotalDiscount;
        private Label lblCustomerCount;
        private Label lblTotalInvoicesValue;
        private Label lblTotalRevenueValue;
        private Label lblTotalDiscountValue;
        private Label lblCustomerCountValue;
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
    }
}