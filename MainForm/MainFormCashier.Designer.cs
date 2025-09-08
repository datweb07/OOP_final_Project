using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace OOP_finalProject
{
    partial class MainFormCashier : Form
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
            this.btnInvoiceList = new System.Windows.Forms.Button();
            this.btnOrderList = new System.Windows.Forms.Button();
            this.btnAccount = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlRightContent = new System.Windows.Forms.Panel();
            this.pnlContentArea = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
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
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlLeftSidebar);
            this.splitContainer1.Panel1MinSize = 280;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlRightContent);
            this.splitContainer1.Size = new System.Drawing.Size(1187, 646);
            this.splitContainer1.SplitterDistance = 280;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            // 
            // pnlLeftSidebar
            // 
            this.pnlLeftSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.pnlLeftSidebar.Controls.Add(this.pnlMenuContainer);
            this.pnlLeftSidebar.Controls.Add(this.lblTitle);
            this.pnlLeftSidebar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftSidebar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlLeftSidebar.Name = "pnlLeftSidebar";
            this.pnlLeftSidebar.Size = new System.Drawing.Size(280, 646);
            this.pnlLeftSidebar.TabIndex = 0;
            // 
            // pnlMenuContainer
            // 
            this.pnlMenuContainer.AutoScroll = true;
            this.pnlMenuContainer.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnlMenuContainer.Controls.Add(this.btnInvoiceList);
            this.pnlMenuContainer.Controls.Add(this.btnOrderList);
            this.pnlMenuContainer.Controls.Add(this.btnAccount);
            this.pnlMenuContainer.Controls.Add(this.btnExit);
            this.pnlMenuContainer.Controls.Add(this.btnOrder);
            this.pnlMenuContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenuContainer.Location = new System.Drawing.Point(0, 52);
            this.pnlMenuContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMenuContainer.Name = "pnlMenuContainer";
            this.pnlMenuContainer.Padding = new System.Windows.Forms.Padding(9, 8, 9, 8);
            this.pnlMenuContainer.Size = new System.Drawing.Size(280, 594);
            this.pnlMenuContainer.TabIndex = 1;
            // 
            // btnInvoiceList
            // 
            this.btnInvoiceList.BackColor = System.Drawing.Color.Transparent;
            this.btnInvoiceList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInvoiceList.FlatAppearance.BorderSize = 0;
            this.btnInvoiceList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvoiceList.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnInvoiceList.ForeColor = System.Drawing.Color.White;
            this.btnInvoiceList.Location = new System.Drawing.Point(9, 48);
            this.btnInvoiceList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInvoiceList.Name = "btnInvoiceList";
            this.btnInvoiceList.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnInvoiceList.Size = new System.Drawing.Size(228, 34);
            this.btnInvoiceList.TabIndex = 10;
            this.btnInvoiceList.Text = "📋 Danh Sách Hoá Đơn";
            this.btnInvoiceList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInvoiceList.UseVisualStyleBackColor = false;
            // 
            // btnOrderList
            // 
            this.btnOrderList.BackColor = System.Drawing.Color.Transparent;
            this.btnOrderList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrderList.FlatAppearance.BorderSize = 0;
            this.btnOrderList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrderList.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnOrderList.ForeColor = System.Drawing.Color.White;
            this.btnOrderList.Location = new System.Drawing.Point(9, 89);
            this.btnOrderList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrderList.Name = "btnOrderList";
            this.btnOrderList.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnOrderList.Size = new System.Drawing.Size(228, 34);
            this.btnOrderList.TabIndex = 11;
            this.btnOrderList.Text = "📝 Danh Sách Đơn Hàng";
            this.btnOrderList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrderList.UseVisualStyleBackColor = false;
            // 
            // btnAccount
            // 
            this.btnAccount.BackColor = System.Drawing.Color.Transparent;
            this.btnAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccount.FlatAppearance.BorderSize = 0;
            this.btnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccount.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnAccount.ForeColor = System.Drawing.Color.White;
            this.btnAccount.Location = new System.Drawing.Point(9, 127);
            this.btnAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnAccount.Size = new System.Drawing.Size(228, 34);
            this.btnAccount.TabIndex = 12;
            this.btnAccount.Text = "👤 Tài Khoản";
            this.btnAccount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccount.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(9, 538);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnExit.Size = new System.Drawing.Size(228, 34);
            this.btnExit.TabIndex = 14;
            this.btnExit.Text = "🚪 Thoát";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.Transparent;
            this.btnOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnOrder.ForeColor = System.Drawing.Color.White;
            this.btnOrder.Location = new System.Drawing.Point(9, 10);
            this.btnOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.btnOrder.Size = new System.Drawing.Size(228, 34);
            this.btnOrder.TabIndex = 12;
            this.btnOrder.Text = "🛒 Tạo Đơn Hàng";
            this.btnOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrder.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.DodgerBlue;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 52);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ BÁN HÀNG\r\nSIÊU THỊ";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlRightContent
            // 
            this.pnlRightContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.pnlRightContent.Controls.Add(this.pnlContentArea);
            this.pnlRightContent.Controls.Add(this.lblWelcome);
            this.pnlRightContent.Controls.Add(this.statusStrip1);
            this.pnlRightContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightContent.Location = new System.Drawing.Point(0, 0);
            this.pnlRightContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlRightContent.Name = "pnlRightContent";
            this.pnlRightContent.Size = new System.Drawing.Size(906, 646);
            this.pnlRightContent.TabIndex = 0;
            // 
            // pnlContentArea
            // 
            this.pnlContentArea.BackColor = System.Drawing.Color.White;
            this.pnlContentArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContentArea.Location = new System.Drawing.Point(0, 45);
            this.pnlContentArea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlContentArea.Name = "pnlContentArea";
            this.pnlContentArea.Padding = new System.Windows.Forms.Padding(18, 15, 18, 15);
            this.pnlContentArea.Size = new System.Drawing.Size(906, 579);
            this.pnlContentArea.TabIndex = 1;
            // 
            // lblWelcome
            // 
            this.lblWelcome.BackColor = System.Drawing.Color.White;
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblWelcome.Location = new System.Drawing.Point(0, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.lblWelcome.Size = new System.Drawing.Size(906, 45);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Chào mừng đến với hệ thống quản lý bán hàng siêu thị";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 624);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(906, 22);
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
            this.lblTime.Size = new System.Drawing.Size(839, 17);
            this.lblTime.Spring = true;
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // MainFormCashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 646);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(877, 460);
            this.Name = "MainFormCashier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Quản Lý Bán Hàng Siêu Thị";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private Button btnInvoiceList;
        private Button btnOrderList;
        private Button btnOrder;
        private Button btnAccount;
        private Button btnExit;
    }
}