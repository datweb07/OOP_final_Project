using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace OOP_finalProject
{
    partial class MainFormAdmin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlLeftSidebar = new System.Windows.Forms.Panel();
            this.pnlMenuContainer = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAccount = new System.Windows.Forms.Button();
            this.btnOrderList = new System.Windows.Forms.Button();
            this.btnInvoiceList = new System.Windows.Forms.Button();
            this.btnElectronic = new System.Windows.Forms.Button();
            this.btnHouseHold = new System.Windows.Forms.Button();
            this.btnFood = new System.Windows.Forms.Button();
            this.btnBeverage = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnSeller = new System.Windows.Forms.Button();
            this.btnManager = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlRightContent = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pnlContentArea = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlLeftSidebar.SuspendLayout();
            this.pnlMenuContainer.SuspendLayout();
            this.pnlRightContent.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlLeftSidebar);
            this.splitContainer1.Panel1MinSize = 250;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlRightContent);
            this.splitContainer1.Size = new System.Drawing.Size(1200, 700);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // pnlLeftSidebar
            // 
            this.pnlLeftSidebar.Controls.Add(this.pnlMenuContainer);
            this.pnlLeftSidebar.Controls.Add(this.lblTitle);
            this.pnlLeftSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftSidebar.Name = "pnlLeftSidebar";
            this.pnlLeftSidebar.Size = new System.Drawing.Size(1200, 250);
            this.pnlLeftSidebar.TabIndex = 0;
            // 
            // pnlMenuContainer
            // 
            this.pnlMenuContainer.AutoScroll = true;
            this.pnlMenuContainer.Controls.Add(this.btnExit);
            this.pnlMenuContainer.Controls.Add(this.btnAccount);
            this.pnlMenuContainer.Controls.Add(this.btnOrderList);
            this.pnlMenuContainer.Controls.Add(this.btnInvoiceList);
            this.pnlMenuContainer.Controls.Add(this.btnElectronic);
            this.pnlMenuContainer.Controls.Add(this.btnHouseHold);
            this.pnlMenuContainer.Controls.Add(this.btnFood);
            this.pnlMenuContainer.Controls.Add(this.btnBeverage);
            this.pnlMenuContainer.Controls.Add(this.btnProduct);
            this.pnlMenuContainer.Controls.Add(this.btnSeller);
            this.pnlMenuContainer.Controls.Add(this.btnManager);
            this.pnlMenuContainer.Controls.Add(this.btnCustomer);
            this.pnlMenuContainer.Controls.Add(this.btnDashboard);
            this.pnlMenuContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenuContainer.Location = new System.Drawing.Point(0, 60);
            this.pnlMenuContainer.Name = "pnlMenuContainer";
            this.pnlMenuContainer.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.pnlMenuContainer.Size = new System.Drawing.Size(1200, 190);
            this.pnlMenuContainer.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(10, 540);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(230, 45);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "  🚪 Thoát";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnAccount
            // 
            this.btnAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccount.FlatAppearance.BorderSize = 0;
            this.btnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccount.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAccount.ForeColor = System.Drawing.Color.White;
            this.btnAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccount.Location = new System.Drawing.Point(10, 490);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(230, 45);
            this.btnAccount.TabIndex = 11;
            this.btnAccount.Tag = typeof(AccountForm);
            this.btnAccount.Text = "  👤 Tài Khoản";
            this.btnAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccount.UseVisualStyleBackColor = true;
            // 
            // btnOrderList
            // 
            this.btnOrderList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOrderList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrderList.FlatAppearance.BorderSize = 0;
            this.btnOrderList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOrderList.ForeColor = System.Drawing.Color.White;
            this.btnOrderList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrderList.Location = new System.Drawing.Point(10, 440);
            this.btnOrderList.Name = "btnOrderList";
            this.btnOrderList.Size = new System.Drawing.Size(230, 45);
            this.btnOrderList.TabIndex = 10;
            this.btnOrderList.Tag = typeof(ListOrderForm);
            this.btnOrderList.Text = "  📝 Danh Sách Đơn Hàng";
            this.btnOrderList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrderList.UseVisualStyleBackColor = true;
            // 
            // btnInvoiceList
            // 
            this.btnInvoiceList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvoiceList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInvoiceList.FlatAppearance.BorderSize = 0;
            this.btnInvoiceList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvoiceList.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnInvoiceList.ForeColor = System.Drawing.Color.White;
            this.btnInvoiceList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInvoiceList.Location = new System.Drawing.Point(10, 390);
            this.btnInvoiceList.Name = "btnInvoiceList";
            this.btnInvoiceList.Size = new System.Drawing.Size(230, 45);
            this.btnInvoiceList.TabIndex = 9;
            this.btnInvoiceList.Tag = typeof(ListInvoiceForm);
            this.btnInvoiceList.Text = "  📋 Danh Sách Hoá Đơn";
            this.btnInvoiceList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInvoiceList.UseVisualStyleBackColor = true;
            // 
            // btnElectronic
            // 
            this.btnElectronic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
            this.btnElectronic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnElectronic.FlatAppearance.BorderSize = 0;
            this.btnElectronic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnElectronic.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnElectronic.ForeColor = System.Drawing.Color.White;
            this.btnElectronic.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnElectronic.Location = new System.Drawing.Point(10, 340);
            this.btnElectronic.Name = "btnElectronic";
            this.btnElectronic.Size = new System.Drawing.Size(230, 45);
            this.btnElectronic.TabIndex = 8;
            this.btnElectronic.Tag = typeof(ElectronicProductForm);
            this.btnElectronic.Text = "  💻 Đồ Điện Tử";
            this.btnElectronic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnElectronic.UseVisualStyleBackColor = true;
            // 
            // btnHouseHold
            // 
            this.btnHouseHold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHouseHold.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHouseHold.FlatAppearance.BorderSize = 0;
            this.btnHouseHold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHouseHold.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnHouseHold.ForeColor = System.Drawing.Color.White;
            this.btnHouseHold.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHouseHold.Location = new System.Drawing.Point(10, 290);
            this.btnHouseHold.Name = "btnHouseHold";
            this.btnHouseHold.Size = new System.Drawing.Size(230, 45);
            this.btnHouseHold.TabIndex = 7;
            this.btnHouseHold.Tag = typeof(HouseholdProductForm);
            this.btnHouseHold.Text = "  🏠 Đồ Gia Dụng";
            this.btnHouseHold.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHouseHold.UseVisualStyleBackColor = true;
            // 
            // btnFood
            // 
            this.btnFood.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFood.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFood.FlatAppearance.BorderSize = 0;
            this.btnFood.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFood.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFood.ForeColor = System.Drawing.Color.White;
            this.btnFood.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFood.Location = new System.Drawing.Point(10, 240);
            this.btnFood.Name = "btnFood";
            this.btnFood.Size = new System.Drawing.Size(230, 45);
            this.btnFood.TabIndex = 6;
            this.btnFood.Tag = typeof(FoodProductForm);
            this.btnFood.Text = "  🍔 Thực Phẩm";
            this.btnFood.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFood.UseVisualStyleBackColor = true;
            // 
            // btnBeverage
            // 
            this.btnBeverage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBeverage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBeverage.FlatAppearance.BorderSize = 0;
            this.btnBeverage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBeverage.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBeverage.ForeColor = System.Drawing.Color.White;
            this.btnBeverage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBeverage.Location = new System.Drawing.Point(10, 190);
            this.btnBeverage.Name = "btnBeverage";
            this.btnBeverage.Size = new System.Drawing.Size(230, 45);
            this.btnBeverage.TabIndex = 5;
            this.btnBeverage.Tag = typeof(DrinkProductForm);
            this.btnBeverage.Text = "  🥤 Đồ Uống";
            this.btnBeverage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBeverage.UseVisualStyleBackColor = true;
            // 
            // btnProduct
            // 
            this.btnProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnProduct.ForeColor = System.Drawing.Color.White;
            this.btnProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.Location = new System.Drawing.Point(10, 140);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(230, 45);
            this.btnProduct.TabIndex = 4;
            this.btnProduct.Tag = typeof(ProductForm);
            this.btnProduct.Text = "  📦 Sản Phẩm";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.UseVisualStyleBackColor = true;
            // 
            // btnSeller
            // 
            this.btnSeller.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeller.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeller.FlatAppearance.BorderSize = 0;
            this.btnSeller.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeller.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSeller.ForeColor = System.Drawing.Color.White;
            this.btnSeller.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeller.Location = new System.Drawing.Point(10, 90);
            this.btnSeller.Name = "btnSeller";
            this.btnSeller.Size = new System.Drawing.Size(230, 45);
            this.btnSeller.TabIndex = 3;
            this.btnSeller.Tag = typeof(CashierForm);
            this.btnSeller.Text = "  👨‍💻 Nhân Viên Bán Hàng";
            this.btnSeller.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeller.UseVisualStyleBackColor = true;
            // 
            // btnManager
            // 
            this.btnManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManager.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManager.FlatAppearance.BorderSize = 0;
            this.btnManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManager.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnManager.ForeColor = System.Drawing.Color.White;
            this.btnManager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManager.Location = new System.Drawing.Point(10, 140);
            this.btnManager.Name = "btnManager";
            this.btnManager.Size = new System.Drawing.Size(230, 45);
            this.btnManager.TabIndex = 2;
            this.btnManager.Tag = typeof(ManagerForm);
            this.btnManager.Text = "  👨‍💼 Quản Lý";
            this.btnManager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManager.UseVisualStyleBackColor = true;
            // 
            // btnCustomer
            // 
            this.btnCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomer.FlatAppearance.BorderSize = 0;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCustomer.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomer.Location = new System.Drawing.Point(10, 90);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(230, 45);
            this.btnCustomer.TabIndex = 1;
            this.btnCustomer.Tag = typeof(CustomerForm);
            this.btnCustomer.Text = "  👥 Khách Hàng";
            this.btnCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomer.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            this.btnDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(10, 10);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(230, 45);
            this.btnDashboard.TabIndex = 0;
            this.btnDashboard.Text = "  🏠 Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.lblTitle.Size = new System.Drawing.Size(1200, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ BÁN HÀNG SIÊU THỊ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRightContent
            // 
            this.pnlRightContent.Controls.Add(this.lblWelcome);
            this.pnlRightContent.Controls.Add(this.pnlContentArea);
            this.pnlRightContent.Controls.Add(this.statusStrip1);
            this.pnlRightContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightContent.Location = new System.Drawing.Point(0, 0);
            this.pnlRightContent.Name = "pnlRightContent";
            this.pnlRightContent.Size = new System.Drawing.Size(1200, 448);
            this.pnlRightContent.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWelcome.Location = new System.Drawing.Point(0, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Padding = new System.Windows.Forms.Padding(25, 15, 0, 15);
            this.lblWelcome.Size = new System.Drawing.Size(1200, 55);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Chào mừng đến với hệ thống quản lý bán hàng siêu thị";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlContentArea
            // 
            this.pnlContentArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentArea.Location = new System.Drawing.Point(0, 55);
            this.pnlContentArea.Name = "pnlContentArea";
            this.pnlContentArea.Padding = new System.Windows.Forms.Padding(20);
            this.pnlContentArea.Size = new System.Drawing.Size(1200, 371);
            this.pnlContentArea.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
    this.lblStatus,
    this.lblTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 426);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1200, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(54, 17);
            this.lblStatus.Text = "Sẵn sàng";
            // 
            // lblTime
            // 
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(1128, 17);
            this.lblTime.Spring = true;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // MainFormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.splitContainer1);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MainFormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Quản Lý Bán Hàng Siêu Thị";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainFormAdmin_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlLeftSidebar.ResumeLayout(false);
            this.pnlMenuContainer.ResumeLayout(false);
            this.pnlRightContent.ResumeLayout(false);
            this.pnlRightContent.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel pnlLeftSidebar;
        private Label lblTitle;
        private Panel pnlMenuContainer;
        private Panel pnlRightContent;
        private Label lblWelcome;
        private Panel pnlContentArea;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
        private ToolStripStatusLabel lblTime;
        private System.Windows.Forms.Timer timer1;

        // Menu buttons
        private Button btnDashboard;
        private Button btnCustomer;
        private Button btnManager;
        private Button btnSeller;
        private Button btnProduct;
        private Button btnBeverage;
        private Button btnFood;
        private Button btnHouseHold;
        private Button btnInvoiceList;
        private Button btnOrderList;
        private Button btnAccount;
        private Button btnExit;
        private Button btnElectronic;
    }
}