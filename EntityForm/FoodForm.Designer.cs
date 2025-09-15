using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject
{
    partial class FoodForm
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
            txtQty = new NumericUpDown();
            groupBox1 = new GroupBox();
            dtExpirationDate = new DateTimePicker();
            txtPrice = new NumericUpDown();
            btnDelete = new Button();
            btnSave = new Button();
            label1 = new Label();
            btnRefresh = new Button();
            label3 = new Label();
            label5 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtCode = new TextBox();
            lblProductCode = new Label();
            gridData = new DataGridView();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)txtQty).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridData).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // txtQty
            // 
            txtQty.Location = new Point(731, 79);
            txtQty.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(333, 27);
            txtQty.TabIndex = 5;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtExpirationDate);
            groupBox1.Controls.Add(txtQty);
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtCode);
            groupBox1.Controls.Add(lblProductCode);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1093, 250);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chức năng";
            // 
            // dtExpirationDate
            // 
            dtExpirationDate.CustomFormat = "dd/MM/yyyy";
            dtExpirationDate.Format = DateTimePickerFormat.Custom;
            dtExpirationDate.Location = new Point(157, 128);
            dtExpirationDate.Name = "dtExpirationDate";
            dtExpirationDate.Size = new Size(408, 27);
            dtExpirationDate.TabIndex = 6;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(113, 79);
            txtPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(452, 27);
            txtPrice.TabIndex = 5;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(918, 192);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(146, 34);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(750, 192);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(146, 34);
            btnSave.TabIndex = 3;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(650, 86);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 0;
            label1.Text = "Số Lượng";
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(583, 192);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(146, 34);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 135);
            label3.Name = "label3";
            label3.Size = new Size(103, 20);
            label3.TabIndex = 0;
            label3.Text = "Ngày Hết Hạn";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 86);
            label5.Name = "label5";
            label5.Size = new Size(31, 20);
            label5.TabIndex = 0;
            label5.Text = "Giá";
            // 
            // txtName
            // 
            txtName.Location = new Point(731, 34);
            txtName.Name = "txtName";
            txtName.Size = new Size(333, 27);
            txtName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(649, 41);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 0;
            label2.Text = "Tên SP";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(113, 34);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(452, 27);
            txtCode.TabIndex = 1;
            // 
            // lblProductCode
            // 
            lblProductCode.AutoSize = true;
            lblProductCode.Location = new Point(31, 41);
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
            gridData.Size = new Size(1087, 266);
            gridData.TabIndex = 1;
            gridData.CellEnter += gridData_CellEnter;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(gridData);
            groupBox2.Location = new Point(12, 284);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1093, 292);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách";
            // 
            // FormFood
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1120, 583);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Name = "FormFood";
            Text = "THỰC PHẨM";
            Load += FormFood_Load;
            ((System.ComponentModel.ISupportInitialize)txtQty).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridData).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private NumericUpDown txtQty;
        private GroupBox groupBox1;
        private NumericUpDown txtPrice;
        private Button btnDelete;
        private Button btnSave;
        private Label label1;
        private Button btnRefresh;
        private Label label5;
        private TextBox txtName;
        private Label label2;
        private TextBox txtCode;
        private Label lblProductCode;
        private DataGridView gridData;
        private GroupBox groupBox2;
        private DateTimePicker dtExpirationDate;
        private Label label3;
    }
}