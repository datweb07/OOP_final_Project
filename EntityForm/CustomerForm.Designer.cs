<<<<<<< HEAD
using System.Drawing;
=======
﻿using System.Drawing;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
using System.Windows.Forms;

namespace OOP_finalProject
{
    partial class CustomerForm
    {
<<<<<<< HEAD
        private System.ComponentModel.IContainer components = null;

=======
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

<<<<<<< HEAD
=======
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            btnDelete = new Button();
            btnSave = new Button();
            btnRefresh = new Button();
            rdoFemale = new RadioButton();
            rdoMale = new RadioButton();
            txtAddress = new TextBox();
            label5 = new Label();
            txtPhone = new TextBox();
            lblPhone = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtCode = new TextBox();
            label3 = new Label();
            lblCustomerCode = new Label();
            gridData = new DataGridView();
            groupBox2 = new GroupBox();
<<<<<<< HEAD
            groupBoxCustomerType = new GroupBox();
            rbRegular = new RadioButton();
            rbVIP = new RadioButton();
            lblDiscountInfo = new Label();
            lblCustomerTypeTitle = new Label();
            btnShowAll = new Button();
            btnShowRegular = new Button();
            btnShowVIP = new Button();

            // Thêm các controls cho chức năng tìm kiếm
            txtSearch = new TextBox();
            btnSearch = new Button();
            statusLabel = new Label();
            btnAddNew = new Button();

=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridData).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
<<<<<<< HEAD

            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1300, 500);
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

            lblSearch = new Label();
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
            btnSearch.Click += btnSearch_Click;
            btnSearch.BackColor = Color.FromArgb(65, 105, 225);
            btnSearch.ForeColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.FlatAppearance.BorderSize = 0;

            btnAddNew.Location = new Point(490, 34);
            btnAddNew.Name = "btnAddNew";
            btnAddNew.Size = new Size(100, 27);
            btnAddNew.TabIndex = 3;
            btnAddNew.Text = "Thêm mới";
            btnAddNew.UseVisualStyleBackColor = true;
            btnAddNew.Click += btnAddNew_Click;
            btnAddNew.BackColor = Color.FromArgb(46, 204, 113);
            btnAddNew.ForeColor = Color.White;
            btnAddNew.FlatStyle = FlatStyle.Flat;
            btnAddNew.FlatAppearance.BorderSize = 0;

            // Di chuyển các controls hiện tại xuống dưới
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
            lblCustomerCode.Size = new Size(78, 20);
            lblCustomerCode.TabIndex = 0;
            lblCustomerCode.Text = "Mã Khách ";

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
            label2.Size = new Size(76, 20);
            label2.TabIndex = 0;
            label2.Text = "Tên Khách";

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
            // groupBoxCustomerType
            // 
            groupBoxCustomerType.Text = "Loại khách hàng";
            groupBoxCustomerType.Location = new Point(31, 230);
            groupBoxCustomerType.Size = new Size(280, 60);

            rbRegular.Text = "Regular";
            rbRegular.Location = new Point(10, 22);
            rbRegular.AutoSize = true;
            rbRegular.Checked = true;

            rbVIP.Text = "VIP";
            rbVIP.Location = new Point(120, 22);
            rbVIP.AutoSize = true;

            groupBoxCustomerType.Controls.Add(rbRegular);
            groupBoxCustomerType.Controls.Add(rbVIP);
            groupBox1.Controls.Add(groupBoxCustomerType);

            // 
            // lblCustomerTypeTitle
            // 
            lblCustomerTypeTitle.Text = "Giảm giá:";
            lblCustomerTypeTitle.Location = new Point(500, 250);
            lblCustomerTypeTitle.AutoSize = true;

            lblDiscountInfo.Text = "Không có giảm giá";
            lblDiscountInfo.Location = new Point(570, 250);
            lblDiscountInfo.AutoSize = true;
            lblDiscountInfo.ForeColor = Color.Black;

            groupBox1.Controls.Add(lblCustomerTypeTitle);
            groupBox1.Controls.Add(lblDiscountInfo);

            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(504, 310);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 34);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;

            // 
            // btnSave
            // 
            btnSave.Location = new Point(620, 310);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 34);
            btnSave.TabIndex = 3;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;

            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(736, 310);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 34);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;

            // 
            // btnShowAll
            // 
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Text = "Hiển thị tất cả";
            btnShowAll.Location = new Point(31, 310);
            btnShowAll.Size = new Size(120, 32);
            btnShowAll.BackColor = Color.FromArgb(65, 105, 225);
            btnShowAll.ForeColor = Color.White;
            btnShowAll.FlatStyle = FlatStyle.Flat;
            btnShowAll.FlatAppearance.BorderSize = 0;
            btnShowAll.Cursor = Cursors.Hand;

            // 
            // btnShowRegular
            // 
            btnShowRegular.Name = "btnShowRegular";
            btnShowRegular.Text = "Chỉ Regular";
            btnShowRegular.Location = new Point(161, 310);
            btnShowRegular.Size = new Size(120, 32);
            btnShowRegular.BackColor = Color.FromArgb(52, 152, 219);
            btnShowRegular.ForeColor = Color.White;
            btnShowRegular.FlatStyle = FlatStyle.Flat;
            btnShowRegular.FlatAppearance.BorderSize = 0;
            btnShowRegular.Cursor = Cursors.Hand;

            // 
            // btnShowVIP
            // 
            btnShowVIP.Name = "btnShowVIP";
            btnShowVIP.Text = "Chỉ VIP";
            btnShowVIP.Location = new Point(291, 310);
            btnShowVIP.Size = new Size(120, 32);
            btnShowVIP.BackColor = Color.Gold;
            btnShowVIP.ForeColor = Color.Black;
            btnShowVIP.FlatStyle = FlatStyle.Flat;
            btnShowVIP.FlatAppearance.BorderSize = 0;
            btnShowVIP.Cursor = Cursors.Hand;

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
            groupBox1.Controls.Add(btnShowAll);
            groupBox1.Controls.Add(btnShowRegular);
            groupBox1.Controls.Add(btnShowVIP);
            groupBox1.Controls.Add(txtSearch);
            groupBox1.Controls.Add(lblSearch);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(btnAddNew);
            groupBox1.Controls.Add(statusLabel);

            // Add all controls to groupBox1
=======
            // 
            // groupBox1
            // 
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
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
<<<<<<< HEAD

=======
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(920, 245);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Chức năng";
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(672, 179);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(146, 34);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Xoá";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(504, 179);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(146, 34);
            btnSave.TabIndex = 3;
            btnSave.Text = "Lưu";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(337, 179);
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
            label2.Size = new Size(76, 20);
            label2.TabIndex = 0;
            label2.Text = "Tên Khách";
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
            lblCustomerCode.Size = new Size(78, 20);
            lblCustomerCode.TabIndex = 0;
            lblCustomerCode.Text = "Mã Khách ";
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            // 
            // gridData
            // 
            gridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridData.Dock = DockStyle.Fill;
<<<<<<< HEAD
            gridData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            gridData.Location = new Point(3, 23);
            gridData.Name = "gridData";
            gridData.RowHeadersWidth = 51;
            gridData.Size = new Size(917, 178);
            gridData.TabIndex = 1;
            gridData.CellEnter += gridData_CellEnter;
<<<<<<< HEAD

=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(gridData);
<<<<<<< HEAD
            groupBox2.Location = new Point(12, 400);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1300, 300);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách";

            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1224, 620); // Tăng kích thước form
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "CustomerForm";
            Text = "QUẢN LÝ KHÁCH HÀNG";
            Load += FormCustomer_Load;

=======
            groupBox2.Location = new Point(12, 263);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(923, 204);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách";
            // 
            // FormCustomer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(947, 479);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FormCustomer";
            Text = "QUẢN LÝ KHÁCH HÀNG";
            Load += FormCustomer_Load;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridData).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

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
<<<<<<< HEAD
        private GroupBox groupBoxCustomerType;
        private RadioButton rbVIP;
        private RadioButton rbRegular;
        private Label lblDiscountInfo;
        private Label lblCustomerTypeTitle;
        private Button btnShowAll;
        private Button btnShowRegular;
        private Button btnShowVIP;

        // Thêm các controls cho chức năng tìm kiếm
        private TextBox txtSearch;
        private Button btnSearch;
        private Label statusLabel;
        private Button btnAddNew;
        private Label lblSearch;
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
    }
}