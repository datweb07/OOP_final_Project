//using System.Drawing;
//using System.Windows.Forms;

//namespace OOP_finalProject
//{
//    partial class InvoiceForm
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
//            groupBox1 = new GroupBox();
//            btnSave = new Button();
//            lblSumTotal = new Label();
//            lblCustomerName = new Label();
//            lblSellerName = new Label();
//            lblCreatedDate = new Label();
//            lblCode = new Label();
//            gridData = new DataGridView();
//            Column1 = new DataGridViewTextBoxColumn();
//            Column2 = new DataGridViewTextBoxColumn();
//            Column3 = new DataGridViewTextBoxColumn();
//            Column4 = new DataGridViewTextBoxColumn();
//            Column5 = new DataGridViewTextBoxColumn();
//            label3 = new Label();
//            label6 = new Label();
//            label5 = new Label();
//            label4 = new Label();
//            label2 = new Label();
//            label1 = new Label();
//            groupBox1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)gridData).BeginInit();
//            SuspendLayout();
//            // 
//            // groupBox1
//            // 
//            groupBox1.Controls.Add(btnSave);
//            groupBox1.Controls.Add(lblSumTotal);
//            groupBox1.Controls.Add(lblCustomerName);
//            groupBox1.Controls.Add(lblSellerName);
//            groupBox1.Controls.Add(lblCreatedDate);
//            groupBox1.Controls.Add(lblCode);
//            groupBox1.Controls.Add(gridData);
//            groupBox1.Controls.Add(label3);
//            groupBox1.Controls.Add(label6);
//            groupBox1.Controls.Add(label5);
//            groupBox1.Controls.Add(label4);
//            groupBox1.Controls.Add(label2);
//            groupBox1.Controls.Add(label1);
//            groupBox1.Location = new Point(12, 12);
//            groupBox1.Name = "groupBox1";
//            groupBox1.Size = new Size(890, 644);
//            groupBox1.TabIndex = 0;
//            groupBox1.TabStop = false;
//            // 
//            // btnSave
//            // 
//            btnSave.Location = new Point(612, 583);
//            btnSave.Name = "btnSave";
//            btnSave.Size = new Size(223, 38);
//            btnSave.TabIndex = 4;
//            btnSave.Text = "Lưu Hoá Đơn";
//            btnSave.UseVisualStyleBackColor = true;
//            btnSave.Click += btnSave_Click;
//            // 
//            // lblSumTotal
//            // 
//            lblSumTotal.AutoSize = true;
//            lblSumTotal.Location = new Point(154, 251);
//            lblSumTotal.Name = "lblSumTotal";
//            lblSumTotal.Size = new Size(60, 20);
//            lblSumTotal.TabIndex = 3;
//            lblSumTotal.Text = "350,000";
//            // 
//            // lblCustomerName
//            // 
//            lblCustomerName.AutoSize = true;
//            lblCustomerName.Location = new Point(154, 195);
//            lblCustomerName.Name = "lblCustomerName";
//            lblCustomerName.Size = new Size(147, 20);
//            lblCustomerName.TabIndex = 3;
//            lblCustomerName.Text = "Hoai Thi Thu Phuong";
//            // 
//            // lblSellerName
//            // 
//            lblSellerName.AutoSize = true;
//            lblSellerName.Location = new Point(154, 148);
//            lblSellerName.Name = "lblSellerName";
//            lblSellerName.Size = new Size(102, 20);
//            lblSellerName.TabIndex = 3;
//            lblSellerName.Text = "Nguyen Van A";
//            // 
//            // lblCreatedDate
//            // 
//            lblCreatedDate.AutoSize = true;
//            lblCreatedDate.Location = new Point(680, 82);
//            lblCreatedDate.Name = "lblCreatedDate";
//            lblCreatedDate.Size = new Size(85, 20);
//            lblCreatedDate.TabIndex = 3;
//            lblCreatedDate.Text = "10/10/2024";
//            // 
//            // lblCode
//            // 
//            lblCode.AutoSize = true;
//            lblCode.Location = new Point(154, 82);
//            lblCode.Name = "lblCode";
//            lblCode.Size = new Size(55, 20);
//            lblCode.TabIndex = 3;
//            lblCode.Text = "HD000";
//            // 
//            // gridData
//            // 
//            gridData.BackgroundColor = SystemColors.Control;
//            gridData.BorderStyle = BorderStyle.None;
//            gridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            gridData.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
//            gridData.Location = new Point(29, 336);
//            gridData.Name = "gridData";
//            gridData.ReadOnly = true;
//            gridData.RowHeadersVisible = false;
//            gridData.RowHeadersWidth = 51;
//            gridData.Size = new Size(814, 209);
//            gridData.TabIndex = 2;
//            // 
//            // Column1
//            // 
//            Column1.DataPropertyName = "ProductId";
//            Column1.HeaderText = "Mã Hàng";
//            Column1.MinimumWidth = 6;
//            Column1.Name = "Column1";
//            Column1.ReadOnly = true;
//            Column1.Width = 125;
//            // 
//            // Column2
//            // 
//            Column2.DataPropertyName = "ProductName";
//            Column2.HeaderText = "Tên Hàng";
//            Column2.MinimumWidth = 6;
//            Column2.Name = "Column2";
//            Column2.ReadOnly = true;
//            Column2.Width = 250;
//            // 
//            // Column3
//            // 
//            Column3.DataPropertyName = "Quantity";
//            Column3.HeaderText = "Số Lượng";
//            Column3.MinimumWidth = 6;
//            Column3.Name = "Column3";
//            Column3.ReadOnly = true;
//            Column3.Width = 125;
//            // 
//            // Column4
//            // 
//            Column4.DataPropertyName = "UnitPrice";
//            Column4.HeaderText = "Đơn Giá";
//            Column4.MinimumWidth = 6;
//            Column4.Name = "Column4";
//            Column4.ReadOnly = true;
//            Column4.Width = 125;
//            // 
//            // Column5
//            // 
//            Column5.DataPropertyName = "TotalPrice";
//            Column5.HeaderText = "Thành Tiền";
//            Column5.MinimumWidth = 6;
//            Column5.Name = "Column5";
//            Column5.ReadOnly = true;
//            Column5.Width = 125;
//            // 
//            // label3
//            // 
//            label3.AutoSize = true;
//            label3.Location = new Point(582, 93);
//            label3.Name = "label3";
//            label3.Size = new Size(263, 20);
//            label3.TabIndex = 1;
//            label3.Text = "Ngày Lập : ______________________________";
//            // 
//            // label6
//            // 
//            label6.AutoSize = true;
//            label6.Location = new Point(29, 262);
//            label6.Name = "label6";
//            label6.Size = new Size(818, 20);
//            label6.TabIndex = 1;
//            label6.Text = "Tổng Tiền : __________________________________________________________________________________________________________________________";
//            // 
//            // label5
//            // 
//            label5.AutoSize = true;
//            label5.Location = new Point(29, 206);
//            label5.Name = "label5";
//            label5.Size = new Size(814, 20);
//            label5.TabIndex = 1;
//            label5.Text = "Khách Hàng : _______________________________________________________________________________________________________________________";
//            // 
//            // label4
//            // 
//            label4.AutoSize = true;
//            label4.Location = new Point(29, 159);
//            label4.Name = "label4";
//            label4.Size = new Size(806, 20);
//            label4.TabIndex = 1;
//            label4.Text = "Nhân Viên  : _______________________________________________________________________________________________________________________";
//            // 
//            // label2
//            // 
//            label2.AutoSize = true;
//            label2.Location = new Point(43, 93);
//            label2.Name = "label2";
//            label2.Size = new Size(417, 20);
//            label2.TabIndex = 1;
//            label2.Text = "Số HĐ : ___________________________________________________________";
//            // 
//            // label1
//            // 
//            label1.AutoSize = true;
//            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
//            label1.ForeColor = Color.Red;
//            label1.Location = new Point(306, 34);
//            label1.Name = "label1";
//            label1.Size = new Size(239, 31);
//            label1.TabIndex = 0;
//            label1.Text = "HOÁ ĐƠN BÁN HÀNG";
//            // 
//            // FormInvoice
//            // 
//            AutoScaleDimensions = new SizeF(8F, 20F);
//            AutoScaleMode = AutoScaleMode.Font;
//            ClientSize = new Size(921, 668);
//            Controls.Add(groupBox1);
//            Name = "FormInvoice";
//            Text = "HOÁ ĐƠN";
//            Load += FormInvoice_Load;
//            groupBox1.ResumeLayout(false);
//            groupBox1.PerformLayout();
//            ((System.ComponentModel.ISupportInitialize)gridData).EndInit();
//            ResumeLayout(false);
//        }

//        #endregion

//        private GroupBox groupBox1;
//        private Label label3;
//        private Label label2;
//        private Label label1;
//        private Label label6;
//        private Label label5;
//        private Label label4;
//        private DataGridView gridData;
//        private Label lblSumTotal;
//        private Label lblCustomerName;
//        private Label lblSellerName;
//        private Label lblCreatedDate;
//        private Label lblCode;
//        private DataGridViewTextBoxColumn Column1;
//        private DataGridViewTextBoxColumn Column2;
//        private DataGridViewTextBoxColumn Column3;
//        private DataGridViewTextBoxColumn Column4;
//        private DataGridViewTextBoxColumn Column5;
//        private Button btnSave;
//    }
//}


using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject
{
    partial class InvoiceForm
    {
        

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceForm));
            groupBox1 = new GroupBox();
            panelFooter = new Panel();
            lblFinalTotal = new Label();
            label8 = new Label();
            lblDiscount = new Label();
            label7 = new Label();
            lblSumTotal = new Label();
            label6 = new Label();
            btnPrint = new Button();
            btnSave = new Button();
            gridData = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            panelHeader = new Panel();
            lblCustomerName = new Label();
            lblSellerName = new Label();
            lblCreatedDate = new Label();
            lblCode = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridData).BeginInit();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(panelFooter);
            groupBox1.Controls.Add(gridData);
            groupBox1.Controls.Add(panelHeader);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(984, 761);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.FromArgb(245, 245, 245);
            panelFooter.BorderStyle = BorderStyle.FixedSingle;
            panelFooter.Controls.Add(lblFinalTotal);
            panelFooter.Controls.Add(label8);
            panelFooter.Controls.Add(lblDiscount);
            panelFooter.Controls.Add(label7);
            panelFooter.Controls.Add(lblSumTotal);
            panelFooter.Controls.Add(label6);
            panelFooter.Controls.Add(btnPrint);
            panelFooter.Controls.Add(btnSave);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(3, 611);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(978, 147);
            panelFooter.TabIndex = 5;
            // 
            // lblFinalTotal
            // 
            lblFinalTotal.AutoSize = true;
            lblFinalTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFinalTotal.ForeColor = Color.FromArgb(192, 0, 0);
            lblFinalTotal.Location = new Point(150, 85);
            lblFinalTotal.Name = "lblFinalTotal";
            lblFinalTotal.Size = new Size(106, 28);
            lblFinalTotal.TabIndex = 7;
            lblFinalTotal.Text = "1,000,000";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(29, 88);
            label8.Name = "label8";
            label8.Size = new Size(115, 23);
            label8.TabIndex = 6;
            label8.Text = "Thành tiền:";
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDiscount.ForeColor = Color.FromArgb(255, 128, 0);
            lblDiscount.Location = new Point(150, 52);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(52, 23);
            lblDiscount.TabIndex = 5;
            lblDiscount.Text = "0 đ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(29, 52);
            label7.Name = "label7";
            label7.Size = new Size(84, 23);
            label7.TabIndex = 4;
            label7.Text = "Giảm giá:";
            // 
            // lblSumTotal
            // 
            lblSumTotal.AutoSize = true;
            lblSumTotal.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSumTotal.Location = new Point(150, 19);
            lblSumTotal.Name = "lblSumTotal";
            lblSumTotal.Size = new Size(52, 23);
            lblSumTotal.TabIndex = 3;
            lblSumTotal.Text = "0 đ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(29, 19);
            label6.Name = "label6";
            label6.Size = new Size(93, 23);
            label6.TabIndex = 2;
            label6.Text = "Tổng tiền:";
            // 
            // btnPrint
            // 
            btnPrint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrint.BackColor = Color.FromArgb(52, 152, 219);
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrint.ForeColor = Color.White;
            //btnPrint.Image = (Image)resources.GetObject("btnPrint.Image");
            btnPrint.ImageAlign = ContentAlignment.MiddleLeft;
            btnPrint.Location = new Point(750, 85);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(200, 45);
            btnPrint.TabIndex = 1;
            btnPrint.Text = "In Hóa Đơn";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.White;
            //btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(750, 19);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 45);
            btnSave.TabIndex = 0;
            btnSave.Text = "Lưu Hóa Đơn";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // gridData
            // 
            gridData.AllowUserToAddRows = false;
            gridData.AllowUserToDeleteRows = false;
            gridData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridData.BackgroundColor = Color.White;
            gridData.BorderStyle = BorderStyle.None;
            gridData.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridData.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(65, 105, 225);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(65, 105, 225);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            gridData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            gridData.ColumnHeadersHeight = 30;
            gridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            gridData.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(240, 240, 245);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            gridData.DefaultCellStyle = dataGridViewCellStyle2;
            gridData.Dock = DockStyle.Fill;
            gridData.EnableHeadersVisualStyles = false;
            gridData.GridColor = Color.FromArgb(240, 240, 240);
            gridData.Location = new Point(3, 193);
            gridData.Name = "gridData";
            gridData.ReadOnly = true;
            gridData.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            gridData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            gridData.RowHeadersVisible = false;
            gridData.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(250, 250, 250);
            gridData.RowsDefaultCellStyle = dataGridViewCellStyle4;
            gridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridData.Size = new Size(978, 418);
            gridData.TabIndex = 4;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "ProductID";
            Column1.FillWeight = 80F;
            Column1.HeaderText = "MÃ SP";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.DataPropertyName = "ProductName";
            Column2.FillWeight = 150F;
            Column2.HeaderText = "TÊN SẢN PHẨM";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.DataPropertyName = "Quantity";
            Column3.FillWeight = 70F;
            Column3.HeaderText = "SỐ LƯỢNG";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.DataPropertyName = "UnitPrice";
            Column4.FillWeight = 90F;
            Column4.HeaderText = "ĐƠN GIÁ";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.DataPropertyName = "TotalPrice";
            Column5.FillWeight = 100F;
            Column5.HeaderText = "THÀNH TIỀN";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.BorderStyle = BorderStyle.FixedSingle;
            panelHeader.Controls.Add(lblCustomerName);
            panelHeader.Controls.Add(lblSellerName);
            panelHeader.Controls.Add(lblCreatedDate);
            panelHeader.Controls.Add(lblCode);
            panelHeader.Controls.Add(label5);
            panelHeader.Controls.Add(label4);
            panelHeader.Controls.Add(label3);
            panelHeader.Controls.Add(label2);
            panelHeader.Controls.Add(label1);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(3, 23);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(978, 170);
            panelHeader.TabIndex = 3;
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCustomerName.Location = new Point(150, 125);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(129, 23);
            lblCustomerName.TabIndex = 8;
            lblCustomerName.Text = "Khách hàng...";
            // 
            // lblSellerName
            // 
            lblSellerName.AutoSize = true;
            lblSellerName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSellerName.Location = new Point(150, 95);
            lblSellerName.Name = "lblSellerName";
            lblSellerName.Size = new Size(108, 23);
            lblSellerName.TabIndex = 7;
            lblSellerName.Text = "Nhân viên...";
            // 
            // lblCreatedDate
            // 
            lblCreatedDate.AutoSize = true;
            lblCreatedDate.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCreatedDate.Location = new Point(650, 65);
            lblCreatedDate.Name = "lblCreatedDate";
            lblCreatedDate.Size = new Size(101, 23);
            lblCreatedDate.TabIndex = 6;
            lblCreatedDate.Text = "01/01/2024";
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCode.Location = new Point(150, 65);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(68, 23);
            lblCode.TabIndex = 5;
            lblCode.Text = "HD000";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(29, 125);
            label5.Name = "label5";
            label5.Size = new Size(115, 23);
            label5.TabIndex = 4;
            label5.Text = "Khách hàng:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(29, 95);
            label4.Name = "label4";
            label4.Size = new Size(97, 23);
            label4.TabIndex = 3;
            label4.Text = "Nhân viên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(550, 65);
            label3.Name = "label3";
            label3.Size = new Size(94, 23);
            label3.TabIndex = 2;
            label3.Text = "Ngày lập:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 65);
            label2.Name = "label2";
            label2.Size = new Size(115, 23);
            label2.TabIndex = 1;
            label2.Text = "Số hóa đơn:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(192, 0, 0);
            label1.Location = new Point(350, 15);
            label1.Name = "label1";
            label1.Size = new Size(278, 38);
            label1.TabIndex = 0;
            label1.Text = "HÓA ĐƠN BÁN HÀNG";
            // 
            // InvoiceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(984, 761);
            Controls.Add(groupBox1);
            //Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InvoiceForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HÓA ĐƠN BÁN HÀNG";
            Load += FormInvoice_Load;
            groupBox1.ResumeLayout(false);
            panelFooter.ResumeLayout(false);
            panelFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridData).EndInit();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }


        private System.ComponentModel.IContainer components = null;
        private GroupBox groupBox1;
        private Button btnSave;
        private Button btnPrint;
        private Label lblSumTotal;
        private Label lblCustomerName;
        private Label lblSellerName;
        private Label lblCreatedDate;
        private Label lblCode;
        private DataGridView gridData;
        private Label label3;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label1;
        private Label lblDiscount;
        private Label lblFinalTotal;
        private Label label7;
        private Label label8;
        private Panel panelHeader;
        private Panel panelFooter;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
    }
}