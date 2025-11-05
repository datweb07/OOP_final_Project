using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject
{
    partial class DrinkForm
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
            txtCode = new TextBox();
            groupBox2 = new GroupBox();
            gridData = new DataGridView();
            btnDelete = new Button();
            btnSave = new Button();
            btnRefresh = new Button();
            label5 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            lblProductCode = new Label();
            groupBox1 = new GroupBox();
            chkIsAlcoholic = new CheckBox();
            txtQty = new NumericUpDown();
            txtPrice = new NumericUpDown();
            label1 = new Label();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridData).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPrice).BeginInit();
            SuspendLayout();
            // 
            // txtCode
            // 
            txtCode.Location = new Point(113, 34);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(452, 27);
            txtCode.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(gridData);
            groupBox2.Location = new Point(12, 284);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1093, 292);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách";
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
            // lblProductCode
            // 
            lblProductCode.AutoSize = true;
            lblProductCode.Location = new Point(31, 41);
            lblProductCode.Name = "lblProductCode";
            lblProductCode.Size = new Size(50, 20);
            lblProductCode.TabIndex = 0;
            lblProductCode.Text = "Mã SP";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkIsAlcoholic);
            groupBox1.Controls.Add(txtQty);
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtCode);
            groupBox1.Controls.Add(lblProductCode);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1093, 250);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chức năng";
            // 
            // chkIsAlcoholic
            // 
            chkIsAlcoholic.AutoSize = true;
            chkIsAlcoholic.Location = new Point(113, 132);
            chkIsAlcoholic.Name = "chkIsAlcoholic";
            chkIsAlcoholic.Size = new Size(113, 24);
            chkIsAlcoholic.TabIndex = 6;
            chkIsAlcoholic.Text = "Có gas";
            chkIsAlcoholic.UseVisualStyleBackColor = true;
            // 
            // txtQty
            // 
            txtQty.Location = new Point(731, 79);
            txtQty.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(333, 27);
            txtQty.TabIndex = 5;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(113, 79);
            txtPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(452, 27);
            txtPrice.TabIndex = 5;
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
            // FormBeverage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1117, 591);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FormBeverage";
            Text = "ĐỒ UỐNG";
            Load += FormBeverage_Load;
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridData).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPrice).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtCode;
        private GroupBox groupBox2;
        private DataGridView gridData;
        private Button btnDelete;
        private Button btnSave;
        private Button btnRefresh;
        private Label label5;
        private TextBox txtName;
        private Label label2;
        private Label lblProductCode;
        private GroupBox groupBox1;
        private NumericUpDown txtQty;
        private NumericUpDown txtPrice;
        private Label label1;
        private CheckBox chkIsAlcoholic;
    }
}