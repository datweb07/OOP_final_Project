using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject
{
    partial class ListInvoiceForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            gridData = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            groupBox1 = new GroupBox();
            btnDelete = new Button();
            btnXemHoaDon = new Button();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)gridData).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // gridData
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            gridData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            gridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridData.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            gridData.Dock = DockStyle.Fill;
            gridData.Location = new Point(3, 23);
            gridData.Name = "gridData";
            gridData.RowHeadersWidth = 51;
            gridData.Size = new Size(1230, 430);
            gridData.TabIndex = 2;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "Code";
            Column1.HeaderText = "Mã HĐ";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.DataPropertyName = "CreatedDate";
            Column2.HeaderText = "Ngày Lập";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.DataPropertyName = "SellerName";
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
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnXemHoaDon);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1236, 83);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chức năng";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1048, 26);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(158, 34);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnXemHoaDon
            // 
            btnXemHoaDon.Location = new Point(864, 26);
            btnXemHoaDon.Name = "btnXemHoaDon";
            btnXemHoaDon.Size = new Size(146, 34);
            btnXemHoaDon.TabIndex = 6;
            btnXemHoaDon.Text = "Xem Hoá Đơn";
            btnXemHoaDon.UseVisualStyleBackColor = true;
            btnXemHoaDon.Click += btnXemHoaDon_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(gridData);
            groupBox2.Location = new Point(12, 101);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1236, 456);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách hoá đơn";
            // 
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
    }
}