namespace OOP_finalProject
{
    partial class PaymentForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInvoiceId = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.cboPaymentMethod = new System.Windows.Forms.ComboBox();
            //this.lblQRCode = new System.Windows.Forms.Label();
            //this.txtQRCode = new System.Windows.Forms.TextBox();
            //this.btnGenerateQR = new System.Windows.Forms.Button();
            //this.lblScannedQR = new System.Windows.Forms.Label();
            //this.txtScannedQR = new System.Windows.Forms.TextBox();
            //this.btnScanQR = new System.Windows.Forms.Button();
            this.lblReceivedAmount = new System.Windows.Forms.Label();
            this.txtReceivedAmount = new System.Windows.Forms.TextBox();
            this.lblChange = new System.Windows.Forms.Label();
            this.lblChangeAmount = new System.Windows.Forms.Label();
            //this.lblCardNumber = new System.Windows.Forms.Label();
            //this.txtCardNumber = new System.Windows.Forms.TextBox();
            //this.lblCardHolder = new System.Windows.Forms.Label();
            //this.txtCardHolder = new System.Windows.Forms.TextBox();
            //this.lblExpiryDate = new System.Windows.Forms.Label();
            //this.txtExpiryDate = new System.Windows.Forms.TextBox();
            //this.lblCVV = new System.Windows.Forms.Label();
            //this.txtCVV = new System.Windows.Forms.TextBox();
            this.lblComingSoon = new System.Windows.Forms.Label();
            this.btnProcessPayment = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBoxPayment = new System.Windows.Forms.GroupBox();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.panelMain.SuspendLayout();
            this.groupBoxPayment.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(245, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THANH TOÁN";
            // 
            // lblInvoiceId
            // 
            this.lblInvoiceId.AutoSize = true;
            this.lblInvoiceId.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceId.Location = new System.Drawing.Point(20, 70);
            this.lblInvoiceId.Name = "lblInvoiceId";
            this.lblInvoiceId.Size = new System.Drawing.Size(107, 25);
            this.lblInvoiceId.TabIndex = 1;
            this.lblInvoiceId.Text = "Hóa đơn: HD001";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAmount.Location = new System.Drawing.Point(20, 105);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(152, 32);
            this.lblAmount.TabIndex = 2;
            this.lblAmount.Text = "Số tiền: 0 đ";
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentMethod.Location = new System.Drawing.Point(20, 155);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(178, 23);
            this.lblPaymentMethod.TabIndex = 3;
            this.lblPaymentMethod.Text = "Phương thức thanh toán:";
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPaymentMethod.FormattingEnabled = true;
            this.cboPaymentMethod.Location = new System.Drawing.Point(250, 152);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(250, 31);
            this.cboPaymentMethod.TabIndex = 4;
            this.cboPaymentMethod.SelectedIndexChanged += new System.EventHandler(this.cboPaymentMethod_SelectedIndexChanged);
            // 
            // groupBoxPayment
            // 
            //this.groupBoxPayment.Controls.Add(this.lblCVV);
            //this.groupBoxPayment.Controls.Add(this.txtCVV);
            //this.groupBoxPayment.Controls.Add(this.lblExpiryDate);
            //this.groupBoxPayment.Controls.Add(this.txtExpiryDate);
            //this.groupBoxPayment.Controls.Add(this.lblCardHolder);
            //this.groupBoxPayment.Controls.Add(this.txtCardHolder);
            //this.groupBoxPayment.Controls.Add(this.lblCardNumber);
            //this.groupBoxPayment.Controls.Add(this.txtCardNumber);
            this.groupBoxPayment.Controls.Add(this.lblChangeAmount);
            this.groupBoxPayment.Controls.Add(this.lblChange);
            this.groupBoxPayment.Controls.Add(this.txtReceivedAmount);
            this.groupBoxPayment.Controls.Add(this.lblReceivedAmount);
            this.groupBoxPayment.Controls.Add(this.lblComingSoon);
            //this.groupBoxPayment.Controls.Add(this.btnScanQR);
            //this.groupBoxPayment.Controls.Add(this.txtScannedQR);
            //this.groupBoxPayment.Controls.Add(this.lblScannedQR);
            //this.groupBoxPayment.Controls.Add(this.btnGenerateQR);
            //this.groupBoxPayment.Controls.Add(this.txtQRCode);
            //this.groupBoxPayment.Controls.Add(this.lblQRCode);
            this.groupBoxPayment.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxPayment.Location = new System.Drawing.Point(20, 200);
            this.groupBoxPayment.Name = "groupBoxPayment";
            this.groupBoxPayment.Size = new System.Drawing.Size(740, 350);
            this.groupBoxPayment.TabIndex = 5;
            this.groupBoxPayment.TabStop = false;
            this.groupBoxPayment.Text = "Thông tin thanh toán";
            //// 
            //// lblQRCode
            //// 
            //this.lblQRCode.AutoSize = true;
            //this.lblQRCode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.lblQRCode.Location = new System.Drawing.Point(20, 40);
            //this.lblQRCode.Name = "lblQRCode";
            //this.lblQRCode.Size = new System.Drawing.Size(74, 23);
            //this.lblQRCode.TabIndex = 0;
            //this.lblQRCode.Text = "Mã QR:";
            //// 
            //// txtQRCode
            //// 
            //this.txtQRCode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.txtQRCode.Location = new System.Drawing.Point(120, 37);
            //this.txtQRCode.Multiline = true;
            //this.txtQRCode.Name = "txtQRCode";
            //this.txtQRCode.ReadOnly = true;
            //this.txtQRCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            //this.txtQRCode.Size = new System.Drawing.Size(500, 60);
            //this.txtQRCode.TabIndex = 1;
            //// 
            //// btnGenerateQR
            //// 
            //this.btnGenerateQR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            //this.btnGenerateQR.FlatAppearance.BorderSize = 0;
            //this.btnGenerateQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //this.btnGenerateQR.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.btnGenerateQR.ForeColor = System.Drawing.Color.White;
            //this.btnGenerateQR.Location = new System.Drawing.Point(640, 37);
            //this.btnGenerateQR.Name = "btnGenerateQR";
            //this.btnGenerateQR.Size = new System.Drawing.Size(80, 60);
            //this.btnGenerateQR.TabIndex = 2;
            //this.btnGenerateQR.Text = "Tạo QR";
            //this.btnGenerateQR.UseVisualStyleBackColor = false;
            //this.btnGenerateQR.Click += new System.EventHandler(this.btnGenerateQR_Click);
            //// 
            //// lblScannedQR
            //// 
            //this.lblScannedQR.AutoSize = true;
            //this.lblScannedQR.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.lblScannedQR.Location = new System.Drawing.Point(20, 120);
            //this.lblScannedQR.Name = "lblScannedQR";
            //this.lblScannedQR.Size = new System.Drawing.Size(124, 23);
            //this.lblScannedQR.TabIndex = 3;
            //this.lblScannedQR.Text = "Mã QR đã quét:";
            //// 
            //// txtScannedQR
            //// 
            //this.txtScannedQR.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.txtScannedQR.Location = new System.Drawing.Point(150, 117);
            //this.txtScannedQR.Multiline = true;
            //this.txtScannedQR.Name = "txtScannedQR";
            //this.txtScannedQR.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            //this.txtScannedQR.Size = new System.Drawing.Size(470, 60);
            //this.txtScannedQR.TabIndex = 4;
            //// 
            //// btnScanQR
            //// 
            //this.btnScanQR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            //this.btnScanQR.FlatAppearance.BorderSize = 0;
            //this.btnScanQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //this.btnScanQR.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.btnScanQR.ForeColor = System.Drawing.Color.White;
            //this.btnScanQR.Location = new System.Drawing.Point(640, 117);
            //this.btnScanQR.Name = "btnScanQR";
            //this.btnScanQR.Size = new System.Drawing.Size(80, 60);
            //this.btnScanQR.TabIndex = 5;
            //this.btnScanQR.Text = "Quét QR";
            //this.btnScanQR.UseVisualStyleBackColor = false;
            //this.btnScanQR.Enabled = false;
            //this.btnScanQR.Click += new System.EventHandler(this.btnScanQR_Click);
            // 
            // lblReceivedAmount
            // 
            this.lblReceivedAmount.AutoSize = true;
            this.lblReceivedAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceivedAmount.Location = new System.Drawing.Point(20, 40);
            this.lblReceivedAmount.Name = "lblReceivedAmount";
            this.lblReceivedAmount.Size = new System.Drawing.Size(159, 23);
            this.lblReceivedAmount.TabIndex = 6;
            this.lblReceivedAmount.Text = "Số tiền khách đưa:";
            this.lblReceivedAmount.Visible = false;
            // 
            // txtReceivedAmount
            // 
            this.txtReceivedAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceivedAmount.Location = new System.Drawing.Point(185, 37);
            this.txtReceivedAmount.Name = "txtReceivedAmount";
            this.txtReceivedAmount.Size = new System.Drawing.Size(200, 30);
            this.txtReceivedAmount.TabIndex = 7;
            this.txtReceivedAmount.Visible = false;
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.Location = new System.Drawing.Point(10, 85);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(108, 23);
            this.lblChange.TabIndex = 8;
            this.lblChange.Text = "Tiền thối lại:";
            this.lblChange.Visible = false;
            // 
            // lblChangeAmount
            // 
            this.lblChangeAmount.AutoSize = true;
            this.lblChangeAmount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeAmount.ForeColor = System.Drawing.Color.Green;
            this.lblChangeAmount.Location = new System.Drawing.Point(134, 82);
            this.lblChangeAmount.Name = "lblChangeAmount";
            this.lblChangeAmount.Size = new System.Drawing.Size(46, 28);
            this.lblChangeAmount.TabIndex = 9;
            this.lblChangeAmount.Text = "0 đ";
            this.lblChangeAmount.Visible = false;
            // 
            // lblComingSoon
            // 
            this.lblComingSoon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblComingSoon.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComingSoon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblComingSoon.Location = new System.Drawing.Point(3, 24);
            this.lblComingSoon.Name = "lblComingSoon";
            this.lblComingSoon.Size = new System.Drawing.Size(734, 323);
            this.lblComingSoon.TabIndex = 100;
            this.lblComingSoon.Text = "Chức năng đang được phát triển";
            this.lblComingSoon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblComingSoon.Visible = false;
            //// 
            //// lblCardNumber
            //// 
            //this.lblCardNumber.AutoSize = true;
            //this.lblCardNumber.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.lblCardNumber.Location = new System.Drawing.Point(20, 40);
            //this.lblCardNumber.Name = "lblCardNumber";
            //this.lblCardNumber.Size = new System.Drawing.Size(79, 23);
            //this.lblCardNumber.TabIndex = 10;
            //this.lblCardNumber.Text = "Số thẻ:";
            //this.lblCardNumber.Visible = false;
            //// 
            //// txtCardNumber
            //// 
            //this.txtCardNumber.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.txtCardNumber.Location = new System.Drawing.Point(105, 37);
            //this.txtCardNumber.Name = "txtCardNumber";
            //this.txtCardNumber.Size = new System.Drawing.Size(280, 30);
            //this.txtCardNumber.TabIndex = 11;
            //this.txtCardNumber.Visible = false;
            //// 
            //// lblCardHolder
            //// 
            //this.lblCardHolder.AutoSize = true;
            //this.lblCardHolder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.lblCardHolder.Location = new System.Drawing.Point(20, 85);
            //this.lblCardHolder.Name = "lblCardHolder";
            //this.lblCardHolder.Size = new System.Drawing.Size(102, 23);
            //this.lblCardHolder.TabIndex = 12;
            //this.lblCardHolder.Text = "Tên chủ thẻ:";
            //this.lblCardHolder.Visible = false;
            //// 
            //// txtCardHolder
            //// 
            //this.txtCardHolder.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.txtCardHolder.Location = new System.Drawing.Point(128, 82);
            //this.txtCardHolder.Name = "txtCardHolder";
            //this.txtCardHolder.Size = new System.Drawing.Size(257, 30);
            //this.txtCardHolder.TabIndex = 13;
            //this.txtCardHolder.Visible = false;
            //// 
            //// lblExpiryDate
            //// 
            //this.lblExpiryDate.AutoSize = true;
            //this.lblExpiryDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.lblExpiryDate.Location = new System.Drawing.Point(20, 130);
            //this.lblExpiryDate.Name = "lblExpiryDate";
            //this.lblExpiryDate.Size = new System.Drawing.Size(116, 23);
            //this.lblExpiryDate.TabIndex = 14;
            //this.lblExpiryDate.Text = "Ngày hết hạn:";
            //this.lblExpiryDate.Visible = false;
            //// 
            //// txtExpiryDate
            //// 
            //this.txtExpiryDate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.txtExpiryDate.Location = new System.Drawing.Point(142, 127);
            //this.txtExpiryDate.Name = "txtExpiryDate";
            ////this.txtExpiryDate.PlaceholderText = "MM/YY";
            //this.txtExpiryDate.Size = new System.Drawing.Size(100, 30);
            //this.txtExpiryDate.TabIndex = 15;
            //this.txtExpiryDate.Visible = false;
            //// 
            //// lblCVV
            //// 
            //this.lblCVV.AutoSize = true;
            //this.lblCVV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.lblCVV.Location = new System.Drawing.Point(260, 130);
            //this.lblCVV.Name = "lblCVV";
            //this.lblCVV.Size = new System.Drawing.Size(50, 23);
            //this.lblCVV.TabIndex = 16;
            //this.lblCVV.Text = "CVV:";
            //this.lblCVV.Visible = false;
            //// 
            //// txtCVV
            //// 
            //this.txtCVV.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.txtCVV.Location = new System.Drawing.Point(316, 127);
            //this.txtCVV.Name = "txtCVV";
            //this.txtCVV.Size = new System.Drawing.Size(100, 30);
            //this.txtCVV.TabIndex = 16;
            //this.txtCVV.Visible = false;
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.panelFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFooter.Controls.Add(this.lblStatus);
            this.panelFooter.Controls.Add(this.btnCancel);
            this.panelFooter.Controls.Add(this.btnProcessPayment);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 560);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(780, 90);
            this.panelFooter.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(20, 15);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(166, 23);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Trạng thái: Chưa thanh toán";
            // 
            // btnProcessPayment
            // 
            this.btnProcessPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcessPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnProcessPayment.FlatAppearance.BorderSize = 0;
            this.btnProcessPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessPayment.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessPayment.ForeColor = System.Drawing.Color.White;
            this.btnProcessPayment.Location = new System.Drawing.Point(490, 25);
            this.btnProcessPayment.Name = "btnProcessPayment";
            this.btnProcessPayment.Size = new System.Drawing.Size(140, 40);
            this.btnProcessPayment.TabIndex = 0;
            this.btnProcessPayment.Text = "Thanh Toán";
            this.btnProcessPayment.UseVisualStyleBackColor = false;
            this.btnProcessPayment.Click += new System.EventHandler(this.btnProcessPayment_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(650, 25);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.groupBoxPayment);
            this.panelMain.Controls.Add(this.cboPaymentMethod);
            this.panelMain.Controls.Add(this.lblPaymentMethod);
            this.panelMain.Controls.Add(this.lblAmount);
            this.panelMain.Controls.Add(this.lblInvoiceId);
            this.panelMain.Controls.Add(this.lblTitle);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(20);
            this.panelMain.Size = new System.Drawing.Size(780, 560);
            this.panelMain.TabIndex = 7;
            // 
            // QRPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 650);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QRPaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thanh Toán";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.groupBoxPayment.ResumeLayout(false);
            this.groupBoxPayment.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInvoiceId;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cboPaymentMethod;

        private System.Windows.Forms.Label lblReceivedAmount;
        private System.Windows.Forms.TextBox txtReceivedAmount;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Label lblChangeAmount;

        private System.Windows.Forms.Label lblComingSoon;

        private System.Windows.Forms.Button btnProcessPayment;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.GroupBox groupBoxPayment;
    }
}