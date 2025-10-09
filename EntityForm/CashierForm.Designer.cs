using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject
{
    partial class CashierForm
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
            // Các controls cũ
            groupBox2 = new GroupBox();
            gridData = new DataGridView();
            txtPhone = new TextBox();
            lblPhone = new Label();
            txtName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            lblCustomerCode = new Label();
            groupBox1 = new GroupBox();
            btnDelete = new Button();
            btnSave = new Button();
            btnRefresh = new Button();
            rdoFemale = new RadioButton();
            rdoMale = new RadioButton();
            txtAddress = new TextBox();
            label5 = new Label();
            txtCode = new TextBox();

            // Thêm các controls mới
            titlePanel = new Panel();
            titleLabel = new Label();
            searchPanel = new Panel();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnAddNew = new Button();
            statusStrip = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            pictureAvatar = new PictureBox();

            // Suspend layout
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridData).BeginInit();
            groupBox1.SuspendLayout();
            titlePanel.SuspendLayout();
            searchPanel.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();

            // 
            // titlePanel
            // 
            titlePanel.BackColor = Color.FromArgb(65, 105, 225);
            titlePanel.Dock = DockStyle.Top;
            titlePanel.Height = 60;
            titlePanel.Controls.Add(titleLabel);
            titlePanel.Controls.Add(pictureAvatar);
            // 
            // titleLabel
            // 
            titleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            titleLabel.ForeColor = Color.White;
            titleLabel.Text = "QUẢN LÝ NHÂN VIÊN BÁN HÀNG";
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(70, 18);
            // 
            // pictureAvatar
            // 
            //pictureAvatar.Image = Properties.Resources.cashier_icon; // Thêm icon phù hợp
            pictureAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureAvatar.Size = new Size(40, 40);
            pictureAvatar.Location = new Point(15, 10);
            // 
            // searchPanel
            // 
            searchPanel.BackColor = Color.FromArgb(245, 245, 250);
            searchPanel.Dock = DockStyle.Top;
            searchPanel.Height = 50;
            searchPanel.Padding = new Padding(10, 5, 10, 5);
            searchPanel.Controls.Add(txtSearch);
            searchPanel.Controls.Add(btnSearch);
            searchPanel.Controls.Add(btnAddNew);
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(15, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(300, 27);
            txtSearch.Font = new Font("Segoe UI", 10F);
            //txtSearch.PlaceholderText = "Tìm kiếm theo mã, tên, SĐT...";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(65, 105, 225);
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(325, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(80, 27);
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnAddNew
            // 
            btnAddNew.BackColor = Color.FromArgb(46, 204, 113);
            btnAddNew.FlatStyle = FlatStyle.Flat;
            btnAddNew.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAddNew.ForeColor = Color.White;
            btnAddNew.Location = new Point(415, 12);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(100, 27);
            btnAddNew.Text = "Thêm mới";
            btnAddNew.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            groupBox1.Font = new Font("Segoe UI", 10F);
            groupBox1.ForeColor = Color.FromArgb(40, 40, 50);
            groupBox1.Location = new Point(12, 120);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(920, 244);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin nhân viên";
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
            // 
            // lblCustomerCode
            // 
            lblCustomerCode.AutoSize = true;
            lblCustomerCode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCustomerCode.Location = new Point(31, 41);
            lblCustomerCode.Name = "lblCustomerCode";
            lblCustomerCode.Size = new Size(54, 19);
            lblCustomerCode.TabIndex = 0;
            lblCustomerCode.Text = "Mã NV";
            // 
            // txtCode
            // 
            txtCode.Font = new Font("Segoe UI", 10F);
            txtCode.Location = new Point(113, 34);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(261, 25);
            txtCode.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(475, 41);
            label2.Name = "label2";
            label2.Size = new Size(56, 19);
            label2.TabIndex = 0;
            label2.Text = "Họ Tên";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 10F);
            txtName.Location = new Point(557, 34);
            txtName.Name = "txtName";
            txtName.Size = new Size(333, 25);
            txtName.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(31, 90);
            label3.Name = "label3";
            label3.Size = new Size(37, 19);
            label3.TabIndex = 0;
            label3.Text = "Phái";
            // 
            // rdoMale
            // 
            rdoMale.AutoSize = true;
            rdoMale.Font = new Font("Segoe UI", 10F);
            rdoMale.Location = new Point(113, 86);
            rdoMale.Name = "rdoMale";
            rdoMale.Size = new Size(62, 23);
            rdoMale.TabIndex = 2;
            rdoMale.TabStop = true;
            rdoMale.Text = "Nam";
            rdoMale.UseVisualStyleBackColor = true;
            // 
            // rdoFemale
            // 
            rdoFemale.AutoSize = true;
            rdoFemale.Font = new Font("Segoe UI", 10F);
            rdoFemale.Location = new Point(257, 86);
            rdoFemale.Name = "rdoFemale";
            rdoFemale.Size = new Size(50, 23);
            rdoFemale.TabIndex = 2;
            rdoFemale.TabStop = true;
            rdoFemale.Text = "Nữ";
            rdoFemale.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(31, 136);
            label5.Name = "label5";
            label5.Size = new Size(57, 19);
            label5.TabIndex = 0;
            label5.Text = "Địa Chỉ";
            // 
            // txtAddress
            // 
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(113, 129);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(777, 25);
            txtAddress.TabIndex = 1;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPhone.Location = new Point(475, 92);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(49, 19);
            lblPhone.TabIndex = 0;
            lblPhone.Text = "Số ĐT";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 10F);
            txtPhone.Location = new Point(557, 85);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(333, 25);
            txtPhone.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(409, 183);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(146, 34);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(576, 183);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(146, 34);
            btnSave.TabIndex = 3;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(744, 183);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(146, 34);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(gridData);
            groupBox2.Font = new Font("Segoe UI", 10F);
            groupBox2.ForeColor = Color.FromArgb(40, 40, 50);
            groupBox2.Location = new Point(12, 380);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(923, 269);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách nhân viên";
            // 
            // gridData
            // 
            gridData.BackgroundColor = Color.White;
            gridData.BorderStyle = BorderStyle.None;
            gridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridData.Dock = DockStyle.Fill;
            gridData.Location = new Point(3, 23);
            gridData.Name = "gridData";
            gridData.ReadOnly = true;
            gridData.RowHeadersWidth = 51;
            gridData.RowTemplate.Height = 24;
            gridData.Size = new Size(917, 243);
            gridData.TabIndex = 1;
            gridData.CellEnter += gridData_CellEnter;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.FromArgb(65, 105, 225);
            statusStrip.Items.Add(statusLabel);
            statusStrip.Dock = DockStyle.Bottom;
            // 
            // statusLabel
            // 
            statusLabel.ForeColor = Color.White;
            statusLabel.Text = "Sẵn sàng";
            // 
            // CashierForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(946, 670);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(searchPanel);
            Controls.Add(titlePanel);
            Controls.Add(statusStrip);
            Name = "CashierForm";
            Text = "QUẢN LÝ NHÂN VIÊN BÁN HÀNG";
            Load += FormSeller_Load;
            titlePanel.ResumeLayout(false);
            titlePanel.PerformLayout();
            searchPanel.ResumeLayout(false);
            searchPanel.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridData).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel titlePanel;
        private Label titleLabel;
        private Panel searchPanel;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnAddNew;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLabel;
        private PictureBox pictureAvatar;

        // Các controls cũ
        private GroupBox groupBox2;
        private DataGridView gridData;
        private TextBox txtPhone;
        private Label lblPhone;
        private TextBox txtName;
        private Label label2;
        private Label label3;
        private Label lblCustomerCode;
        private GroupBox groupBox1;
        private Button btnDelete;
        private Button btnSave;
        private Button btnRefresh;
        private RadioButton rdoFemale;
        private RadioButton rdoMale;
        private TextBox txtAddress;
        private Label label5;
        private TextBox txtCode;
    }
}