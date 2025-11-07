using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject
{
    partial class ListOrderForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            lblCustomerCountValue = new Label();
            lblTotalDiscountValue = new Label();
            lblTotalRevenueValue = new Label();
            lblTotalOrdersValue = new Label();
            lblCustomerCount = new Label();
            lblTotalDiscount = new Label();
            lblTotalRevenue = new Label();
            lblTotalOrders = new Label();
            groupBoxSort = new GroupBox();
            cmbSort = new ComboBox();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            statusLabel = new Label();
            btnRefresh = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnXemHoaDon = new Button();
            btnAdd = new Button();
            groupBox2 = new GroupBox();
            gridData = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            groupBoxSort.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridData).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblCustomerCountValue);
            groupBox1.Controls.Add(lblTotalDiscountValue);
            groupBox1.Controls.Add(lblTotalRevenueValue);
            groupBox1.Controls.Add(lblTotalOrdersValue);
            groupBox1.Controls.Add(lblCustomerCount);
            groupBox1.Controls.Add(lblTotalDiscount);
            groupBox1.Controls.Add(lblTotalRevenue);
            groupBox1.Controls.Add(lblTotalOrders);
            groupBox1.Controls.Add(groupBoxSort);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(txtSearch);
            groupBox1.Controls.Add(lblSearch);
            groupBox1.Controls.Add(statusLabel);
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnEdit);
            groupBox1.Controls.Add(btnXemHoaDon);
            groupBox1.Controls.Add(btnAdd);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1300, 270);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin đơn hàng";
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
            // lblTotalOrdersValue
            // 
            lblTotalOrdersValue.AutoSize = true;
            lblTotalOrdersValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalOrdersValue.ForeColor = Color.FromArgb(46, 204, 113);
            lblTotalOrdersValue.Location = new Point(1060, 40);
            lblTotalOrdersValue.Name = "lblTotalOrdersValue";
            lblTotalOrdersValue.Size = new Size(17, 20);
            lblTotalOrdersValue.TabIndex = 27;
            lblTotalOrdersValue.Text = "0";
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
            // lblTotalOrders
            // 
            lblTotalOrders.AutoSize = true;
            lblTotalOrders.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalOrders.Location = new Point(900, 40);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new Size(120, 20);
            lblTotalOrders.TabIndex = 23;
            lblTotalOrders.Text = "Tổng đơn hàng:";
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
            "Mã ĐH (A-Z)",
            "Mã ĐH (Z-A)",
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
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(158, 34);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(881, 200);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(146, 34);
            btnEdit.TabIndex = 5;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.BackColor = Color.FromArgb(241, 196, 15);
            btnEdit.ForeColor = Color.White;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnXemHoaDon
            // 
            btnXemHoaDon.Location = new Point(547, 200);
            btnXemHoaDon.Name = "btnXemHoaDon";
            btnXemHoaDon.Size = new Size(146, 34);
            btnXemHoaDon.TabIndex = 6;
            btnXemHoaDon.Text = "Xem Hoá Đơn";
            btnXemHoaDon.UseVisualStyleBackColor = true;
            btnXemHoaDon.BackColor = Color.FromArgb(155, 89, 182);
            btnXemHoaDon.ForeColor = Color.White;
            btnXemHoaDon.FlatStyle = FlatStyle.Flat;
            btnXemHoaDon.FlatAppearance.BorderSize = 0;
            btnXemHoaDon.Click += btnXemHoaDon_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(714, 200);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(146, 34);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.BackColor = Color.FromArgb(46, 204, 113);
            btnAdd.ForeColor = Color.White;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Click += btnAdd_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(gridData);
            groupBox2.Location = new Point(12, 300);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1300, 456);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách đơn hàng";
            // 
            // gridData
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            gridData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            gridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridData.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column10, Column6, Column8, Column7, Column5, Column9 });
            gridData.Dock = DockStyle.Fill;
            gridData.Location = new Point(3, 23);
            gridData.Name = "gridData";
            gridData.RowHeadersWidth = 51;
            gridData.Size = new Size(1230, 430);
            gridData.TabIndex = 2;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "OrderId";
            Column1.HeaderText = "Mã ĐH";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.DataPropertyName = "OrderDate";
            Column2.HeaderText = "Ngày Lập";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.DataPropertyName = "CashierName";
            Column3.HeaderText = "Nhân Viên";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 250;
            // 
            // Column4
            // 
            Column4.DataPropertyName = "CustomerName";
            Column4.HeaderText = "KH";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 250;
            // 
            // Column5
            // 
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
            Column6.DataPropertyName = "SumTotal";
            Column6.DefaultCellStyle = dataGridViewCellStyle2;
            Column6.HeaderText = "Tổng Tiền";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.Width = 180;
            //
            // Column7
            //
            Column7.DataPropertyName = "DiscountPercentage";
            Column7.HeaderText = "Phần Trăm";
            Column7.MinimumWidth = 6;
            Column7.Name = "Column7";
            Column7.Width = 180;
            //
            // Column8
            //
            Column8.DataPropertyName = "DiscountAmount";
            Column8.DefaultCellStyle = dataGridViewCellStyle2;
            Column8.HeaderText = "Giảm Giá";
            Column8.MinimumWidth = 6;
            Column8.Name = "Column8";
            Column8.Width = 180;
            //
            // Column9
            //
            Column9.DataPropertyName = "DiscountInfo";
            Column9.HeaderText = "Thông Tin";
            Column9.MinimumWidth = 6;
            Column9.Name = "Column9";
            Column9.Width = 200;
            //
            // Column10
            //
            Column10.DataPropertyName = "CustomerTypeDisplay";
            Column10.HeaderText = "Loại KH";
            Column10.MinimumWidth = 6;
            Column10.Name = "Column10";
            Column10.Width = 150;
            // 
            // ListOrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1260, 666);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "ListOrderForm";
            Text = "QUẢN LÝ ĐƠN HÀNG";
            Load += FormOrderList_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBoxSort.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;
        private DataGridView gridData;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private Button btnXemHoaDon;
        private Button btnRefresh;
        private Label statusLabel;
        private TextBox txtSearch;
        private Label lblSearch;
        private Button btnSearch;
        private GroupBox groupBoxSort;
        private ComboBox cmbSort;
        private Label lblTotalOrders;
        private Label lblTotalRevenue;
        private Label lblTotalDiscount;
        private Label lblCustomerCount;
        private Label lblTotalOrdersValue;
        private Label lblTotalRevenueValue;
        private Label lblTotalDiscountValue;
        private Label lblCustomerCountValue;
    }
}