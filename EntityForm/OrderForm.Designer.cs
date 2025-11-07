using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject
{
    partial class OrderForm
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
            btnDelete = new Button();
            btnSave = new Button();
            btnRefresh = new Button();
            lblPhone = new Label();
            label2 = new Label();
            txtCode = new TextBox();
            lblOrderCode = new Label();
            groupBox1 = new GroupBox();
            lblFinalTotalValue = new Label();
            lblDiscountValue = new Label();
            lblSubTotalValue = new Label();
            lblFinalTotal = new Label();
            lblDiscount = new Label();
            lblSubTotal = new Label();
            lblDiscountPercentValue = new Label();
            lblCustomerTypeValue = new Label();
            lblDiscountPercent = new Label();
            lblCustomerType = new Label();
            lblOrderValueValue = new Label();
            lblProductCountValue = new Label();
            lblItemCountValue = new Label();
            lblOrderValue = new Label();
            lblProductCount = new Label();
            lblItemCount = new Label();
            cboCustomer = new ComboBox();
            cboSeller = new ComboBox();
            dtCreateDate = new DateTimePicker();
            btnViewInvoice = new Button();
            label1 = new Label();
            statusLabel = new Label();
            groupBox2 = new GroupBox();
            gridDataDetail = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            groupBox3 = new GroupBox();
            txtQty = new NumericUpDown();
            cboProduct = new ComboBox();
            btnDeleteDetail = new Button();
            label3 = new Label();
            btnAddDetail = new Button();
            label4 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridDataDetail).BeginInit();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtQty).BeginInit();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(794, 200);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(158, 34);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(627, 200);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(146, 34);
            btnSave.TabIndex = 3;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += btnSave_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(460, 200);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(146, 34);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(31, 88);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(77, 20);
            lblPhone.TabIndex = 0;
            lblPhone.Text = "Nhân Viên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(475, 41);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 0;
            label2.Text = "Ngày Lập";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(113, 34);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(261, 27);
            txtCode.TabIndex = 1;
            // 
            // lblOrderCode
            // 
            lblOrderCode.AutoSize = true;
            lblOrderCode.Location = new Point(31, 41);
            lblOrderCode.Name = "lblOrderCode";
            lblOrderCode.Size = new Size(62, 20);
            lblOrderCode.TabIndex = 0;
            lblOrderCode.Text = "Mã Đơn";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblFinalTotalValue);
            groupBox1.Controls.Add(lblDiscountValue);
            groupBox1.Controls.Add(lblSubTotalValue);
            groupBox1.Controls.Add(lblFinalTotal);
            groupBox1.Controls.Add(lblDiscount);
            groupBox1.Controls.Add(lblSubTotal);
            groupBox1.Controls.Add(lblDiscountPercentValue);
            groupBox1.Controls.Add(lblCustomerTypeValue);
            groupBox1.Controls.Add(lblDiscountPercent);
            groupBox1.Controls.Add(lblCustomerType);
            groupBox1.Controls.Add(lblOrderValueValue);
            groupBox1.Controls.Add(lblProductCountValue);
            groupBox1.Controls.Add(lblItemCountValue);
            groupBox1.Controls.Add(lblOrderValue);
            groupBox1.Controls.Add(lblProductCount);
            groupBox1.Controls.Add(lblItemCount);
            groupBox1.Controls.Add(cboCustomer);
            groupBox1.Controls.Add(cboSeller);
            groupBox1.Controls.Add(dtCreateDate);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(btnViewInvoice);
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(lblPhone);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtCode);
            groupBox1.Controls.Add(lblOrderCode);
            groupBox1.Controls.Add(statusLabel);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1200, 270);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin đơn hàng";
            // 
            // lblFinalTotalValue
            // 
            lblFinalTotalValue.AutoSize = true;
            lblFinalTotalValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFinalTotalValue.ForeColor = Color.FromArgb(65, 105, 225);
            lblFinalTotalValue.Location = new Point(1060, 130);
            lblFinalTotalValue.Name = "lblFinalTotalValue";
            lblFinalTotalValue.Size = new Size(32, 20);
            lblFinalTotalValue.TabIndex = 30;
            lblFinalTotalValue.Text = "0 đ";
            // 
            // lblDiscountValue
            // 
            lblDiscountValue.AutoSize = true;
            lblDiscountValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDiscountValue.ForeColor = Color.FromArgb(255, 165, 0);
            lblDiscountValue.Location = new Point(1060, 100);
            lblDiscountValue.Name = "lblDiscountValue";
            lblDiscountValue.Size = new Size(32, 20);
            lblDiscountValue.TabIndex = 29;
            lblDiscountValue.Text = "0 đ";
            // 
            // lblSubTotalValue
            // 
            lblSubTotalValue.AutoSize = true;
            lblSubTotalValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSubTotalValue.ForeColor = Color.FromArgb(46, 204, 113);
            lblSubTotalValue.Location = new Point(1060, 70);
            lblSubTotalValue.Name = "lblSubTotalValue";
            lblSubTotalValue.Size = new Size(32, 20);
            lblSubTotalValue.TabIndex = 28;
            lblSubTotalValue.Text = "0 đ";
            // 
            // lblFinalTotal
            // 
            lblFinalTotal.AutoSize = true;
            lblFinalTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFinalTotal.Location = new Point(970, 130);
            lblFinalTotal.Name = "lblFinalTotal";
            lblFinalTotal.Size = new Size(88, 20);
            lblFinalTotal.TabIndex = 27;
            lblFinalTotal.Text = "Thành tiền:";
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDiscount.Location = new Point(970, 100);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(76, 20);
            lblDiscount.TabIndex = 26;
            lblDiscount.Text = "Giảm giá:";
            // 
            // lblSubTotal
            // 
            lblSubTotal.AutoSize = true;
            lblSubTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSubTotal.Location = new Point(970, 70);
            lblSubTotal.Name = "lblSubTotal";
            lblSubTotal.Size = new Size(74, 20);
            lblSubTotal.TabIndex = 25;
            lblSubTotal.Text = "Tổng tiền:";
            // 
            // lblDiscountPercentValue
            // 
            lblDiscountPercentValue.AutoSize = true;
            lblDiscountPercentValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDiscountPercentValue.ForeColor = Color.FromArgb(255, 165, 0);
            lblDiscountPercentValue.Location = new Point(1125, 40);
            lblDiscountPercentValue.Name = "lblDiscountPercentValue";
            lblDiscountPercentValue.Size = new Size(24, 20);
            lblDiscountPercentValue.TabIndex = 24;
            lblDiscountPercentValue.Text = "0%";
            // 
            // lblCustomerTypeValue
            // 
            lblCustomerTypeValue.AutoSize = true;
            lblCustomerTypeValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCustomerTypeValue.ForeColor = Color.FromArgb(46, 204, 113);
            lblCustomerTypeValue.Location = new Point(585, 135);
            lblCustomerTypeValue.Name = "lblCustomerTypeValue";
            lblCustomerTypeValue.Size = new Size(53, 20);
            lblCustomerTypeValue.TabIndex = 23;
            lblCustomerTypeValue.Text = "Thường";
            // 
            // lblDiscountPercent
            // 
            lblDiscountPercent.AutoSize = true;
            lblDiscountPercent.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDiscountPercent.Location = new Point(970, 40);
            lblDiscountPercent.Name = "lblDiscountPercent";
            lblDiscountPercent.Size = new Size(138, 20);
            lblDiscountPercent.TabIndex = 22;
            lblDiscountPercent.Text = "Phần trăm giảm giá:";
            // 
            // lblCustomerType
            // 
            lblCustomerType.AutoSize = true;
            lblCustomerType.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCustomerType.Location = new Point(474, 135);
            lblCustomerType.Name = "lblCustomerType";
            lblCustomerType.Size = new Size(94, 20);
            lblCustomerType.TabIndex = 21;
            lblCustomerType.Text = "Loại KH:";
            // 
            // lblOrderValueValue
            // 
            lblOrderValueValue.AutoSize = true;
            lblOrderValueValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblOrderValueValue.ForeColor = Color.FromArgb(46, 204, 113);
            lblOrderValueValue.Location = new Point(300, 180);
            lblOrderValueValue.Name = "lblOrderValueValue";
            lblOrderValueValue.Size = new Size(32, 20);
            lblOrderValueValue.TabIndex = 20;
            lblOrderValueValue.Text = "0 đ";
            // 
            // lblProductCountValue
            // 
            lblProductCountValue.AutoSize = true;
            lblProductCountValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProductCountValue.ForeColor = Color.FromArgb(46, 204, 113);
            lblProductCountValue.Location = new Point(150, 220);
            lblProductCountValue.Name = "lblProductCountValue";
            lblProductCountValue.Size = new Size(17, 20);
            lblProductCountValue.TabIndex = 19;
            lblProductCountValue.Text = "0";
            // 
            // lblItemCountValue
            // 
            lblItemCountValue.AutoSize = true;
            lblItemCountValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblItemCountValue.ForeColor = Color.FromArgb(46, 204, 113);
            lblItemCountValue.Location = new Point(150, 180);
            lblItemCountValue.Name = "lblItemCountValue";
            lblItemCountValue.Size = new Size(17, 20);
            lblItemCountValue.TabIndex = 18;
            lblItemCountValue.Text = "0";
            // 
            // lblOrderValue
            // 
            lblOrderValue.AutoSize = true;
            lblOrderValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblOrderValue.Location = new Point(200, 180);
            lblOrderValue.Name = "lblOrderValue";
            lblOrderValue.Size = new Size(44, 20);
            lblOrderValue.TabIndex = 17;
            lblOrderValue.Text = "Giá trị:";
            // 
            // lblProductCount
            // 
            lblProductCount.AutoSize = true;
            lblProductCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblProductCount.Location = new Point(30, 220);
            lblProductCount.Name = "lblProductCount";
            lblProductCount.Size = new Size(44, 20);
            lblProductCount.TabIndex = 16;
            lblProductCount.Text = "SP:";
            // 
            // lblItemCount
            // 
            lblItemCount.AutoSize = true;
            lblItemCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblItemCount.Location = new Point(30, 180);
            lblItemCount.Name = "lblItemCount";
            lblItemCount.Size = new Size(44, 20);
            lblItemCount.TabIndex = 15;
            lblItemCount.Text = "Mặt hàng:";
            // 
            // cboCustomer
            // 
            cboCustomer.FormattingEnabled = true;
            cboCustomer.Location = new Point(592, 81);
            cboCustomer.Name = "cboCustomer";
            cboCustomer.Size = new Size(360, 28);
            cboCustomer.TabIndex = 0;
            // 
            // cboSeller
            // 
            cboSeller.FormattingEnabled = true;
            cboSeller.Location = new Point(114, 81);
            cboSeller.Name = "cboSeller";
            cboSeller.Size = new Size(260, 28);
            cboSeller.TabIndex = 0;
            // 
            // dtCreateDate
            // 
            dtCreateDate.CustomFormat = "dd/MM/yyyy";
            dtCreateDate.Format = DateTimePickerFormat.Custom;
            dtCreateDate.Location = new Point(557, 36);
            dtCreateDate.Name = "dtCreateDate";
            dtCreateDate.Size = new Size(395, 27);
            dtCreateDate.TabIndex = 9;
            // 
            // btnViewInvoice
            // 
            btnViewInvoice.Location = new Point(29, 128);
            btnViewInvoice.Name = "btnViewInvoice";
            btnViewInvoice.Size = new Size(146, 34);
            btnViewInvoice.TabIndex = 3;
            btnViewInvoice.Text = "Xem Hoá Đơn";
            btnViewInvoice.UseVisualStyleBackColor = true;
            btnViewInvoice.BackColor = Color.FromArgb(155, 89, 182);
            btnViewInvoice.ForeColor = Color.White;
            btnViewInvoice.FlatStyle = FlatStyle.Flat;
            btnViewInvoice.FlatAppearance.BorderSize = 0;
            btnViewInvoice.Click += btnViewInvoice_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(475, 88);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 0;
            label1.Text = "Khách Hàng";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(200, 140);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(50, 20);
            statusLabel.TabIndex = 14;
            statusLabel.Text = "Sẵn sàng";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(gridDataDetail);
            groupBox2.Location = new Point(12, 400);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1200, 300);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách chi tiết đơn";
            // 
            // gridDataDetail
            // 
            gridDataDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridDataDetail.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            gridDataDetail.Dock = DockStyle.Fill;
            gridDataDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridDataDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gridDataDetail.Location = new Point(3, 23);
            gridDataDetail.Name = "gridDataDetail";
            gridDataDetail.RowHeadersWidth = 51;
            gridDataDetail.Size = new Size(1194, 274);
            gridDataDetail.TabIndex = 1;
            gridDataDetail.SelectionChanged += gridDataDetail_SelectionChanged;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "ProductId";
            Column1.HeaderText = "Mã Hàng";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.DataPropertyName = "ProductName";
            Column2.HeaderText = "Tên Hàng";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 250;
            // 
            // Column3
            // 
            Column3.DataPropertyName = "Quantity";
            Column3.HeaderText = "Số Lượng";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.DataPropertyName = "TotalPrice";
            Column4.HeaderText = "Thành Tiền";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 150;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtQty);
            groupBox3.Controls.Add(cboProduct);
            groupBox3.Controls.Add(btnDeleteDetail);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(btnAddDetail);
            groupBox3.Controls.Add(label4);
            groupBox3.Location = new Point(12, 295);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1200, 99);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Chi Tiết Đơn Hàng";
            // 
            // txtQty
            // 
            txtQty.Location = new Point(600, 43);
            txtQty.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            txtQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(211, 27);
            txtQty.TabIndex = 4;
            txtQty.ThousandsSeparator = true;
            txtQty.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cboProduct
            // 
            cboProduct.FormattingEnabled = true;
            cboProduct.Location = new Point(137, 42);
            cboProduct.Name = "cboProduct";
            cboProduct.Size = new Size(281, 28);
            cboProduct.TabIndex = 0;
            // 
            // btnDeleteDetail
            // 
            btnDeleteDetail.Location = new Point(1051, 38);
            btnDeleteDetail.Name = "btnDeleteDetail";
            btnDeleteDetail.Size = new Size(101, 34);
            btnDeleteDetail.TabIndex = 3;
            btnDeleteDetail.Text = "Xoá";
            btnDeleteDetail.UseVisualStyleBackColor = true;
            btnDeleteDetail.BackColor = Color.FromArgb(231, 76, 60);
            btnDeleteDetail.ForeColor = Color.White;
            btnDeleteDetail.FlatStyle = FlatStyle.Flat;
            btnDeleteDetail.FlatAppearance.BorderSize = 0;
            btnDeleteDetail.Click += btnDeleteDetail_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 45);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 0;
            label3.Text = "Sản phẩm";
            // 
            // btnAddDetail
            // 
            btnAddDetail.Location = new Point(928, 38);
            btnAddDetail.Name = "btnAddDetail";
            btnAddDetail.Size = new Size(102, 34);
            btnAddDetail.TabIndex = 3;
            btnAddDetail.Text = "Thêm";
            btnAddDetail.UseVisualStyleBackColor = true;
            btnAddDetail.BackColor = Color.FromArgb(46, 204, 113);
            btnAddDetail.ForeColor = Color.White;
            btnAddDetail.FlatStyle = FlatStyle.Flat;
            btnAddDetail.FlatAppearance.BorderSize = 0;
            btnAddDetail.Click += btnAddDetail_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(500, 49);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 0;
            label4.Text = "Số Lượng";
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1224, 615);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "OrderForm";
            Text = "QUẢN LÝ ĐƠN HÀNG";
            Load += FormOrder_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridDataDetail).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtQty).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnDelete;
        private Button btnSave;
        private Button btnRefresh;
        private Label lblPhone;
        private Label label2;
        private TextBox txtCode;
        private Label lblOrderCode;
        private GroupBox groupBox1;
        private DataGridView gridDataDetail;
        private GroupBox groupBox2;
        private DateTimePicker dtCreateDate;
        private Label label1;
        private GroupBox groupBox3;
        private ComboBox cboProduct;
        private Label label3;
        private Button btnDeleteDetail;
        private Button btnAddDetail;
        private Label label4;
        private ComboBox cboCustomer;
        private ComboBox cboSeller;
        private NumericUpDown txtQty;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Button btnViewInvoice;
        private Label statusLabel;
        private Label lblItemCount;
        private Label lblProductCount;
        private Label lblOrderValue;
        private Label lblItemCountValue;
        private Label lblProductCountValue;
        private Label lblOrderValueValue;
        private Label lblCustomerType;
        private Label lblDiscountPercent;
        private Label lblCustomerTypeValue;
        private Label lblDiscountPercentValue;
        private Label lblSubTotal;
        private Label lblDiscount;
        private Label lblFinalTotal;
        private Label lblSubTotalValue;
        private Label lblDiscountValue;
        private Label lblFinalTotalValue;
    }
}