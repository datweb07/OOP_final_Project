using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject
{
    partial class OrderForm
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
            btnDelete = new Button();
            btnSave = new Button();
            btnRefresh = new Button();
            lblPhone = new Label();
            label2 = new Label();
            txtCode = new TextBox();
            lblOrderCode = new Label();
            groupBox1 = new GroupBox();
            cboCustomer = new ComboBox();
            cboSeller = new ComboBox();
            dtCreateDate = new DateTimePicker();
            btnViewInvoice = new Button();
            label1 = new Label();
            gridDataDetail = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            groupBox2 = new GroupBox();
            groupBox3 = new GroupBox();
            txtQty = new NumericUpDown();
            cboProduct = new ComboBox();
            btnDeleteDetail = new Button();
            label3 = new Label();
            btnAddDetail = new Button();
            label4 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridDataDetail).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtQty).BeginInit();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(794, 128);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(158, 34);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(627, 128);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(146, 34);
            btnSave.TabIndex = 3;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(460, 128);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(146, 34);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
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
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(980, 180);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chức năng";
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
            // gridDataDetail
            // 
            gridDataDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridDataDetail.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            gridDataDetail.Dock = DockStyle.Fill;
            gridDataDetail.Location = new Point(3, 23);
            gridDataDetail.Name = "gridDataDetail";
            gridDataDetail.RowHeadersWidth = 51;
            gridDataDetail.Size = new Size(971, 213);
            gridDataDetail.TabIndex = 1;
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
            Column4.DataPropertyName = "Total";
            Column4.HeaderText = "Thành Tiền";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.Width = 125;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(gridDataDetail);
            groupBox2.Location = new Point(12, 303);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(977, 239);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách chi tiết đơn";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtQty);
            groupBox3.Controls.Add(cboProduct);
            groupBox3.Controls.Add(btnDeleteDetail);
            groupBox3.Controls.Add(label3);
            groupBox3.Controls.Add(btnAddDetail);
            groupBox3.Controls.Add(label4);
            groupBox3.Location = new Point(12, 198);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(977, 99);
            groupBox3.TabIndex = 9;
            groupBox3.TabStop = false;
            groupBox3.Text = "Chi Tiết Đơn Hàng";
            // 
            // txtQty
            // 
            txtQty.Location = new Point(460, 43);
            txtQty.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(211, 27);
            txtQty.TabIndex = 4;
            txtQty.ThousandsSeparator = true;
            // 
            // cboProduct
            // 
            cboProduct.FormattingEnabled = true;
            cboProduct.Location = new Point(137, 42);
            cboProduct.Name = "cboProduct";
            cboProduct.Size = new Size(181, 28);
            cboProduct.TabIndex = 0;
            // 
            // btnDeleteDetail
            // 
            btnDeleteDetail.Location = new Point(851, 38);
            btnDeleteDetail.Name = "btnDeleteDetail";
            btnDeleteDetail.Size = new Size(101, 34);
            btnDeleteDetail.TabIndex = 3;
            btnDeleteDetail.Text = "Xoá";
            btnDeleteDetail.UseVisualStyleBackColor = true;
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
            btnAddDetail.Location = new Point(728, 38);
            btnAddDetail.Name = "btnAddDetail";
            btnAddDetail.Size = new Size(102, 34);
            btnAddDetail.TabIndex = 3;
            btnAddDetail.Text = "Thêm";
            btnAddDetail.UseVisualStyleBackColor = true;
            btnAddDetail.Click += btnAddDetail_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(364, 49);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 0;
            label4.Text = "Số Lượng";
            // 
            // FormOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1015, 564);
            Controls.Add(groupBox3);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "FormOrder";
            Text = "ĐƠN HÀNG";
            Load += FormOrder_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridDataDetail).EndInit();
            groupBox2.ResumeLayout(false);
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

        // Strategy Pattern: Discount Display
        //private GroupBox groupBoxDiscount;
        //private Label lblCustomerTypeLabel;
        //private Label lblCustomerType;
        //private Label lblSubTotalLabel;
        //private Label lblSubTotal;
        //private Label lblDiscountLabel;
        //private Label lblDiscount;
        //private Label lblFinalTotalLabel;
        //private Label lblFinalTotal;
    }
}