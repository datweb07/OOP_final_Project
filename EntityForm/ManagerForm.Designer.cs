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
            // Khởi tạo các controls
            groupBox1 = new GroupBox();
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

            // Thêm các controls cho chức năng tìm kiếm và lọc
            txtSearch = new TextBox();
            btnSearch = new Button();
            statusLabel = new Label();
            btnAddNew = new Button();
            lblSearch = new Label();

            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridData).BeginInit();
            SuspendLayout();

            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1200, 300);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chức năng";

            // 
            // Search controls
            // 
            txtSearch.Location = new Point(113, 34);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(261, 27);
            txtSearch.TabIndex = 1;

            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(31, 41);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(78, 20);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm";

            btnSearch.Location = new Point(380, 34);
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

            btnAddNew.Location = new Point(490, 34);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(100, 27);
            btnAddNew.TabIndex = 3;
            btnAddNew.Text = "Thêm mới";
            btnAddNew.UseVisualStyleBackColor = true;
            btnAddNew.BackColor = Color.FromArgb(46, 204, 113);
            btnAddNew.ForeColor = Color.White;
            btnAddNew.FlatStyle = FlatStyle.Flat;
            btnAddNew.FlatAppearance.BorderSize = 0;
            btnAddNew.Click += btnAddNew_Click;

            // 
            // txtCode
            // 
            txtCode.Location = new Point(113, 80);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(261, 27);
            txtCode.TabIndex = 1;

            // 
            // lblCustomerCode
            // 
            lblCustomerCode.AutoSize = true;
            lblCustomerCode.Location = new Point(31, 87);
            lblCustomerCode.Name = "lblCustomerCode";
            lblCustomerCode.Size = new Size(54, 20);
            lblCustomerCode.TabIndex = 0;
            lblCustomerCode.Text = "Mã NV";

            // 
            // txtName
            // 
            txtName.Location = new Point(557, 80);
            txtName.Name = "txtName";
            txtName.Size = new Size(333, 27);
            txtName.TabIndex = 1;

            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(475, 87);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 0;
            label2.Text = "Họ Tên";

            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 130);
            label3.Name = "label3";
            label3.Size = new Size(37, 20);
            label3.TabIndex = 0;
            label3.Text = "Phái";

            // 
            // rdoMale
            // 
            rdoMale.AutoSize = true;
            rdoMale.Location = new Point(113, 126);
            rdoMale.Name = "rdoMale";
            rdoMale.Size = new Size(62, 24);
            rdoMale.TabIndex = 2;
            rdoMale.TabStop = true;
            rdoMale.Text = "Nam";
            rdoMale.UseVisualStyleBackColor = true;

            // 
            // rdoFemale
            // 
            rdoFemale.AutoSize = true;
            rdoFemale.Location = new Point(257, 126);
            rdoFemale.Name = "rdoFemale";
            rdoFemale.Size = new Size(50, 24);
            rdoFemale.TabIndex = 2;
            rdoFemale.TabStop = true;
            rdoFemale.Text = "Nữ";
            rdoFemale.UseVisualStyleBackColor = true;

            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(557, 125);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(333, 27);
            txtPhone.TabIndex = 1;

            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(475, 132);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(49, 20);
            lblPhone.TabIndex = 0;
            lblPhone.Text = "Số ĐT";

            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(113, 170);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(777, 27);
            txtAddress.TabIndex = 1;

            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 177);
            label5.Name = "label5";
            label5.Size = new Size(57, 20);
            label5.TabIndex = 0;
            label5.Text = "Địa Chỉ";

            // 
            // lblTeamSize
            // 
            lblTeamSize.AutoSize = true;
            lblTeamSize.Location = new Point(31, 220);
            lblTeamSize.Name = "lblTeamSize";
            lblTeamSize.Size = new Size(76, 20);
            lblTeamSize.TabIndex = 0;
            lblTeamSize.Text = "Số nhân viên:";

            // 
            // txtTeamSize
            // 
            txtTeamSize.Location = new Point(113, 215);
            txtTeamSize.Name = "txtTeamSize";
            txtTeamSize.ReadOnly = true;
            txtTeamSize.Size = new Size(100, 27);
            txtTeamSize.TabIndex = 1;
            txtTeamSize.Text = "0";

            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(504, 220);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 34);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.BackColor = Color.FromArgb(52, 152, 219);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += btnRefresh_Click;

            // 
            // btnSave
            // 
            btnSave.Location = new Point(620, 220);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 34);
            btnSave.TabIndex = 3;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.BackColor = Color.FromArgb(46, 204, 113);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += btnSave_Click;

            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(736, 220);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 34);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.BackColor = Color.FromArgb(231, 76, 60);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Click += btnDelete_Click;

            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(700, 40);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(50, 20);
            statusLabel.TabIndex = 4;
            statusLabel.Text = "Sẵn sàng";

            // THÊM VÀO groupBox1.Controls
            groupBox1.Controls.Add(txtSearch);
            groupBox1.Controls.Add(lblSearch);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(btnAddNew);
            groupBox1.Controls.Add(statusLabel);

            // Add all controls to groupBox1
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

            // Tùy chỉnh giao diện DataGridView
            gridData.BorderStyle = BorderStyle.None;
            gridData.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 245);
            gridData.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridData.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 105, 225);
            gridData.DefaultCellStyle.SelectionForeColor = Color.White;
            gridData.BackgroundColor = Color.White;
            gridData.EnableHeadersVisualStyles = false;
            gridData.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridData.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(65, 105, 225);
            gridData.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridData.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(gridData);
            groupBox2.Location = new Point(12, 320);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1200, 300);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách quản lý";

            // 
            // ManagerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1224, 620);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "ManagerForm";
            Text = "QUẢN LÝ NHÂN VIÊN QUẢN LÝ";
            Load += ManagerForm_Load;

            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridData).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        // Khai báo các controls
        private GroupBox groupBox1;
        private DataGridView gridData;
        private GroupBox groupBox2;
        private RadioButton rdoFemale;
        private RadioButton rdoMale;
        private TextBox txtAddress;
        private Label label5;
        private TextBox txtPhone;
        private Label lblPhone;
        private TextBox txtName;
        private Label label2;
        private TextBox txtCode;
        private Label label3;
        private Label lblCustomerCode;
        private Button btnDelete;
        private Button btnSave;
        private Button btnRefresh;
        private Label lblTeamSize;
        private TextBox txtTeamSize;

        // Thêm các controls cho chức năng tìm kiếm và lọc
        private TextBox txtSearch;
        private Button btnSearch;
        private Label statusLabel;
        private Button btnAddNew;
        private Label lblSearch;
    }
}