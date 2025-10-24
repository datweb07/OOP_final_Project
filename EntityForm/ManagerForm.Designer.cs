using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject
{
    partial class ManagerForm
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
            rdoFemale = new RadioButton();
            rdoMale = new RadioButton();
            txtAddress = new TextBox();
            label5 = new Label();
            groupBox2 = new GroupBox();
            gridData = new DataGridView();
            txtPhone = new TextBox();
            lblPhone = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtCode = new TextBox();
            label3 = new Label();
            lblCustomerCode = new Label();
            lblTeamSize = new Label();
            txtTeamSize = new TextBox();
            groupBox1 = new GroupBox();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridData).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(744, 183);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(146, 34);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(576, 183);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(146, 34);
            btnSave.TabIndex = 3;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(409, 183);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(146, 34);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // rdoFemale
            // 
            rdoFemale.AutoSize = true;
            rdoFemale.Location = new Point(257, 86);
            rdoFemale.Name = "rdoFemale";
            rdoFemale.Size = new Size(50, 24);
            rdoFemale.TabIndex = 2;
            rdoFemale.TabStop = true;
            rdoFemale.Text = "Nữ";
            rdoFemale.UseVisualStyleBackColor = true;
            // 
            // rdoMale
            // 
            rdoMale.AutoSize = true;
            rdoMale.Location = new Point(113, 86);
            rdoMale.Name = "rdoMale";
            rdoMale.Size = new Size(62, 24);
            rdoMale.TabIndex = 2;
            rdoMale.TabStop = true;
            rdoMale.Text = "Nam";
            rdoMale.UseVisualStyleBackColor = true;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(113, 129);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(777, 27);
            txtAddress.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 136);
            label5.Name = "label5";
            label5.Size = new Size(57, 20);
            label5.TabIndex = 0;
            label5.Text = "Địa Chỉ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(gridData);
            groupBox2.Location = new Point(12, 273);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(923, 269);
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
            gridData.Size = new Size(917, 243);
            gridData.TabIndex = 1;
            gridData.CellEnter += gridData_CellEnter;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(557, 85);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(333, 27);
            txtPhone.TabIndex = 1;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(475, 92);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(49, 20);
            lblPhone.TabIndex = 0;
            lblPhone.Text = "Số ĐT";
            // 
            // txtName
            // 
            txtName.Location = new Point(557, 34);
            txtName.Name = "txtName";
            txtName.Size = new Size(333, 27);
            txtName.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(475, 41);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 0;
            label2.Text = "Họ Tên";
            // 
            // txtCode
            // 
            txtCode.Location = new Point(113, 34);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(261, 27);
            txtCode.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 90);
            label3.Name = "label3";
            label3.Size = new Size(37, 20);
            label3.TabIndex = 0;
            label3.Text = "Phái";
            // 
            // lblCustomerCode
            // 
            lblCustomerCode.AutoSize = true;
            lblCustomerCode.Location = new Point(31, 41);
            lblCustomerCode.Name = "lblCustomerCode";
            lblCustomerCode.Size = new Size(54, 20);
            lblCustomerCode.TabIndex = 0;
            lblCustomerCode.Text = "Mã NV";
            // 
            // lblTeamSize
            // 
            lblTeamSize.AutoSize = true;
            lblTeamSize.Location = new Point(31, 180);
            lblTeamSize.Name = "lblTeamSize";
            lblTeamSize.Size = new Size(76, 20);
            lblTeamSize.TabIndex = 0;
            lblTeamSize.Text = "Số nhân viên";
            // 
            // txtTeamSize
            // 
            txtTeamSize.Location = new Point(113, 173);
            txtTeamSize.Name = "txtTeamSize";
            txtTeamSize.ReadOnly = true;
            txtTeamSize.Size = new Size(100, 27);
            txtTeamSize.TabIndex = 1;
            txtTeamSize.Text = "0";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(rdoFemale);
            groupBox1.Controls.Add(rdoMale);
            groupBox1.Controls.Add(txtAddress);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtPhone);
            groupBox1.Controls.Add(lblPhone);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtCode);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(lblCustomerCode);
            groupBox1.Controls.Add(txtTeamSize);
            groupBox1.Controls.Add(lblTeamSize);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(920, 244);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chức năng";
            // 
            // FormManager
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 553);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FormManager";
            Text = "QUẢN LÝ NHÂN VIÊN QUẢN LÝ CỬA HÀNG";
            Load += FormManager_Load;
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridData).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btnDelete;
        private Button btnSave;
        private Button btnRefresh;
        private RadioButton rdoFemale;
        private RadioButton rdoMale;
        private TextBox txtAddress;
        private Label label5;
        private GroupBox groupBox2;
        private DataGridView gridData;
        private TextBox txtPhone;
        private Label lblPhone;
        private TextBox txtName;
        private Label label2;
        private TextBox txtCode;
        private Label label3;
        private Label lblCustomerCode;
        private Label lblTeamSize;
        private TextBox txtTeamSize;
        private GroupBox groupBox1;
    }
}