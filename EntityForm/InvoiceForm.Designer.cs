using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject
{
    partial class InvoiceForm
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
            groupBox1 = new GroupBox();
            btnSave = new Button();
            lblSumTotal = new Label();
            lblCustomerName = new Label();
            lblSellerName = new Label();
            lblCreatedDate = new Label();
            lblCode = new Label();
            gridData = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            label3 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridData).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(lblSumTotal);
            groupBox1.Controls.Add(lblCustomerName);
            groupBox1.Controls.Add(lblSellerName);
            groupBox1.Controls.Add(lblCreatedDate);
            groupBox1.Controls.Add(lblCode);
            groupBox1.Controls.Add(gridData);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(890, 644);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(612, 583);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(223, 38);
            btnSave.TabIndex = 4;
            btnSave.Text = "Lưu Hoá Đơn";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // lblSumTotal
            // 
            lblSumTotal.AutoSize = true;
            lblSumTotal.Location = new Point(154, 251);
            lblSumTotal.Name = "lblSumTotal";
            lblSumTotal.Size = new Size(60, 20);
            lblSumTotal.TabIndex = 3;
            lblSumTotal.Text = "350,000";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Location = new Point(154, 195);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(147, 20);
            lblCustomerName.TabIndex = 3;
            lblCustomerName.Text = "Hoai Thi Thu Phuong";
            // 
            // lblSellerName
            // 
            lblSellerName.AutoSize = true;
            lblSellerName.Location = new Point(154, 148);
            lblSellerName.Name = "lblSellerName";
            lblSellerName.Size = new Size(102, 20);
            lblSellerName.TabIndex = 3;
            lblSellerName.Text = "Nguyen Van A";
            // 
            // lblCreatedDate
            // 
            lblCreatedDate.AutoSize = true;
            lblCreatedDate.Location = new Point(680, 82);
            lblCreatedDate.Name = "lblCreatedDate";
            lblCreatedDate.Size = new Size(85, 20);
            lblCreatedDate.TabIndex = 3;
            lblCreatedDate.Text = "10/10/2024";
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Location = new Point(154, 82);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(55, 20);
            lblCode.TabIndex = 3;
            lblCode.Text = "HD000";
            // 
            // gridData
            // 
            gridData.BackgroundColor = SystemColors.Control;
            gridData.BorderStyle = BorderStyle.None;
            gridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridData.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            gridData.Location = new Point(29, 336);
            gridData.Name = "gridData";
            gridData.ReadOnly = true;
            gridData.RowHeadersVisible = false;
            gridData.RowHeadersWidth = 51;
            gridData.Size = new Size(814, 209);
            gridData.TabIndex = 2;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "ProductCode";
            Column1.HeaderText = "Mã Hàng";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.DataPropertyName = "ProductName";
            Column2.HeaderText = "Tên Hàng";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 250;
            // 
            // Column3
            // 
            Column3.DataPropertyName = "Qty";
            Column3.HeaderText = "Số Lượng";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.DataPropertyName = "Price";
            Column4.HeaderText = "Đơn Giá";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 125;
            // 
            // Column5
            // 
            Column5.DataPropertyName = "Total";
            Column5.HeaderText = "Thành Tiền";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 125;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(582, 93);
            label3.Name = "label3";
            label3.Size = new Size(263, 20);
            label3.TabIndex = 1;
            label3.Text = "Ngày Lập : ______________________________";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(29, 262);
            label6.Name = "label6";
            label6.Size = new Size(818, 20);
            label6.TabIndex = 1;
            label6.Text = "Tổng Tiền : __________________________________________________________________________________________________________________________";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 206);
            label5.Name = "label5";
            label5.Size = new Size(814, 20);
            label5.TabIndex = 1;
            label5.Text = "Khách Hàng : _______________________________________________________________________________________________________________________";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 159);
            label4.Name = "label4";
            label4.Size = new Size(806, 20);
            label4.TabIndex = 1;
            label4.Text = "Nhân Viên  : _______________________________________________________________________________________________________________________";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 93);
            label2.Name = "label2";
            label2.Size = new Size(417, 20);
            label2.TabIndex = 1;
            label2.Text = "Số HĐ : ___________________________________________________________";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(306, 34);
            label1.Name = "label1";
            label1.Size = new Size(239, 31);
            label1.TabIndex = 0;
            label1.Text = "HOÁ ĐƠN BÁN HÀNG";
            // 
            // FormInvoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 668);
            Controls.Add(groupBox1);
            Name = "FormInvoice";
            Text = "HOÁ ĐƠN";
            Load += FormInvoice_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridData).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label6;
        private Label label5;
        private Label label4;
        private DataGridView gridData;
        private Label lblSumTotal;
        private Label lblCustomerName;
        private Label lblSellerName;
        private Label lblCreatedDate;
        private Label lblCode;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private Button btnSave;
    }
}