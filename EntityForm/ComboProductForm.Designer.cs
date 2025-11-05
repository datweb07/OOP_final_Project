//namespace OOP_finalProject.EntityForm
//{
//    partial class ComboProductForm
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.groupBox1 = new System.Windows.Forms.GroupBox();
//            this.gridComboList = new System.Windows.Forms.DataGridView();
//            this.colComboId = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colComboName = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colProductCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.groupBox2 = new System.Windows.Forms.GroupBox();
//            this.btnViewDetails = new System.Windows.Forms.Button();
//            this.lblSavings = new System.Windows.Forms.Label();
//            this.lblFinalPrice = new System.Windows.Forms.Label();
//            this.lblOriginalPrice = new System.Windows.Forms.Label();
//            this.numDiscount = new System.Windows.Forms.NumericUpDown();
//            this.label4 = new System.Windows.Forms.Label();
//            this.txtDescription = new System.Windows.Forms.TextBox();
//            this.label3 = new System.Windows.Forms.Label();
//            this.txtComboName = new System.Windows.Forms.TextBox();
//            this.label2 = new System.Windows.Forms.Label();
//            this.txtComboId = new System.Windows.Forms.TextBox();
//            this.label1 = new System.Windows.Forms.Label();
//            this.groupBox3 = new System.Windows.Forms.GroupBox();
//            this.btnRemoveFromCombo = new System.Windows.Forms.Button();
//            this.gridProductsInCombo = new System.Windows.Forms.DataGridView();
//            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colProductQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.groupBox4 = new System.Windows.Forms.GroupBox();
//            this.btnAddToCombo = new System.Windows.Forms.Button();
//            this.gridAvailableProducts = new System.Windows.Forms.DataGridView();
//            this.colAvailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colAvailName = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colAvailPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colAvailQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.panel1 = new System.Windows.Forms.Panel();
//            this.btnDeleteCombo = new System.Windows.Forms.Button();
//            this.btnSaveCombo = new System.Windows.Forms.Button();
//            this.btnNewCombo = new System.Windows.Forms.Button();
//            this.groupBox1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.gridComboList)).BeginInit();
//            this.groupBox2.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).BeginInit();
//            this.groupBox3.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.gridProductsInCombo)).BeginInit();
//            this.groupBox4.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.gridAvailableProducts)).BeginInit();
//            this.panel1.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // groupBox1
//            // 
//            this.groupBox1.Controls.Add(this.gridComboList);
//            this.groupBox1.Location = new System.Drawing.Point(12, 12);
//            this.groupBox1.Name = "groupBox1";
//            this.groupBox1.Size = new System.Drawing.Size(400, 250);
//            this.groupBox1.TabIndex = 0;
//            this.groupBox1.TabStop = false;
//            this.groupBox1.Text = "Danh sách Combo";
//            // 
//            // gridComboList
//            // 
//            this.gridComboList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.gridComboList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
//            this.colComboId,
//            this.colComboName,
//            this.colDiscount,
//            this.colPrice,
//            this.colProductCount});
//            this.gridComboList.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.gridComboList.Location = new System.Drawing.Point(3, 16);
//            this.gridComboList.Name = "gridComboList";
//            this.gridComboList.Size = new System.Drawing.Size(394, 231);
//            this.gridComboList.TabIndex = 0;
//            this.gridComboList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridComboList_CellClick);
//            // 
//            // colComboId
//            // 
//            this.colComboId.DataPropertyName = "Id";
//            this.colComboId.HeaderText = "Mã Combo";
//            this.colComboId.Name = "colComboId";
//            this.colComboId.Width = 80;
//            // 
//            // colComboName
//            // 
//            this.colComboName.DataPropertyName = "Name";
//            this.colComboName.HeaderText = "Tên Combo";
//            this.colComboName.Name = "colComboName";
//            this.colComboName.Width = 150;
//            // 
//            // colDiscount
//            // 
//            this.colDiscount.DataPropertyName = "DiscountPercentage";
//            this.colDiscount.HeaderText = "Giảm giá %";
//            this.colDiscount.Name = "colDiscount";
//            this.colDiscount.Width = 80;
//            // 
//            // colPrice
//            // 
//            this.colPrice.DataPropertyName = "Price";
//            this.colPrice.HeaderText = "Giá";
//            this.colPrice.Name = "colPrice";
//            // 
//            // colProductCount
//            // 
//            this.colProductCount.DataPropertyName = "ChildCount";
//            this.colProductCount.HeaderText = "Số SP";
//            this.colProductCount.Name = "colProductCount";
//            this.colProductCount.Width = 60;
//            // 
//            // groupBox2
//            // 
//            this.groupBox2.Controls.Add(this.btnViewDetails);
//            this.groupBox2.Controls.Add(this.lblSavings);
//            this.groupBox2.Controls.Add(this.lblFinalPrice);
//            this.groupBox2.Controls.Add(this.lblOriginalPrice);
//            this.groupBox2.Controls.Add(this.numDiscount);
//            this.groupBox2.Controls.Add(this.label4);
//            this.groupBox2.Controls.Add(this.txtDescription);
//            this.groupBox2.Controls.Add(this.label3);
//            this.groupBox2.Controls.Add(this.txtComboName);
//            this.groupBox2.Controls.Add(this.label2);
//            this.groupBox2.Controls.Add(this.txtComboId);
//            this.groupBox2.Controls.Add(this.label1);
//            this.groupBox2.Location = new System.Drawing.Point(418, 12);
//            this.groupBox2.Name = "groupBox2";
//            this.groupBox2.Size = new System.Drawing.Size(400, 250);
//            this.groupBox2.TabIndex = 1;
//            this.groupBox2.TabStop = false;
//            this.groupBox2.Text = "Thông tin Combo";
//            // 
//            // btnViewDetails
//            // 
//            this.btnViewDetails.Location = new System.Drawing.Point(280, 210);
//            this.btnViewDetails.Name = "btnViewDetails";
//            this.btnViewDetails.Size = new System.Drawing.Size(100, 30);
//            this.btnViewDetails.TabIndex = 11;
//            this.btnViewDetails.Text = "Xem chi tiết";
//            this.btnViewDetails.UseVisualStyleBackColor = true;
//            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
//            // 
//            // lblSavings
//            // 
//            this.lblSavings.AutoSize = true;
//            this.lblSavings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.lblSavings.ForeColor = System.Drawing.Color.Green;
//            this.lblSavings.Location = new System.Drawing.Point(15, 220);
//            this.lblSavings.Name = "lblSavings";
//            this.lblSavings.Size = new System.Drawing.Size(82, 15);
//            this.lblSavings.TabIndex = 10;
//            this.lblSavings.Text = "Tiết kiệm: 0";
//            // 
//            // lblFinalPrice
//            // 
//            this.lblFinalPrice.AutoSize = true;
//            this.lblFinalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.lblFinalPrice.ForeColor = System.Drawing.Color.Red;
//            this.lblFinalPrice.Location = new System.Drawing.Point(15, 200);
//            this.lblFinalPrice.Name = "lblFinalPrice";
//            this.lblFinalPrice.Size = new System.Drawing.Size(120, 15);
//            this.lblFinalPrice.TabIndex = 9;
//            this.lblFinalPrice.Text = "Giá sau giảm: 0 ₫";
//            // 
//            // lblOriginalPrice
//            // 
//            this.lblOriginalPrice.AutoSize = true;
//            this.lblOriginalPrice.Location = new System.Drawing.Point(15, 180);
//            this.lblOriginalPrice.Name = "lblOriginalPrice";
//            this.lblOriginalPrice.Size = new System.Drawing.Size(65, 13);
//            this.lblOriginalPrice.TabIndex = 8;
//            this.lblOriginalPrice.Text = "Giá gốc: 0 ₫";
//            // 
//            // numDiscount
//            // 
//            this.numDiscount.DecimalPlaces = 2;
//            this.numDiscount.Location = new System.Drawing.Point(100, 145);
//            this.numDiscount.Name = "numDiscount";
//            this.numDiscount.Size = new System.Drawing.Size(280, 20);
//            this.numDiscount.TabIndex = 7;
//            this.numDiscount.ValueChanged += new System.EventHandler(this.numDiscount_ValueChanged);
//            // 
//            // label4
//            // 
//            this.label4.AutoSize = true;
//            this.label4.Location = new System.Drawing.Point(15, 147);
//            this.label4.Name = "label4";
//            this.label4.Size = new System.Drawing.Size(68, 13);
//            this.label4.TabIndex = 6;
//            this.label4.Text = "Giảm giá (%):";
//            // 
//            // txtDescription
//            // 
//            this.txtDescription.Location = new System.Drawing.Point(100, 85);
//            this.txtDescription.Multiline = true;
//            this.txtDescription.Name = "txtDescription";
//            this.txtDescription.Size = new System.Drawing.Size(280, 50);
//            this.txtDescription.TabIndex = 5;
//            // 
//            // label3
//            // 
//            this.label3.AutoSize = true;
//            this.label3.Location = new System.Drawing.Point(15, 88);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(37, 13);
//            this.label3.TabIndex = 4;
//            this.label3.Text = "Mô tả:";
//            // 
//            // txtComboName
//            // 
//            this.txtComboName.Location = new System.Drawing.Point(100, 55);
//            this.txtComboName.Name = "txtComboName";
//            this.txtComboName.Size = new System.Drawing.Size(280, 20);
//            this.txtComboName.TabIndex = 3;
//            // 
//            // label2
//            // 
//            this.label2.AutoSize = true;
//            this.label2.Location = new System.Drawing.Point(15, 58);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(65, 13);
//            this.label2.TabIndex = 2;
//            this.label2.Text = "Tên Combo:";
//            // 
//            // txtComboId
//            // 
//            this.txtComboId.Location = new System.Drawing.Point(100, 25);
//            this.txtComboId.Name = "txtComboId";
//            this.txtComboId.Size = new System.Drawing.Size(280, 20);
//            this.txtComboId.TabIndex = 1;
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Location = new System.Drawing.Point(15, 28);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(61, 13);
//            this.label1.TabIndex = 0;
//            this.label1.Text = "Mã Combo:";
//            // 
//            // groupBox3
//            // 
//            this.groupBox3.Controls.Add(this.btnRemoveFromCombo);
//            this.groupBox3.Controls.Add(this.gridProductsInCombo);
//            this.groupBox3.Location = new System.Drawing.Point(12, 268);
//            this.groupBox3.Name = "groupBox3";
//            this.groupBox3.Size = new System.Drawing.Size(400, 250);
//            this.groupBox3.TabIndex = 2;
//            this.groupBox3.TabStop = false;
//            this.groupBox3.Text = "Sản phẩm trong Combo";
//            // 
//            // btnRemoveFromCombo
//            // 
//            this.btnRemoveFromCombo.Location = new System.Drawing.Point(280, 214);
//            this.btnRemoveFromCombo.Name = "btnRemoveFromCombo";
//            this.btnRemoveFromCombo.Size = new System.Drawing.Size(100, 30);
//            this.btnRemoveFromCombo.TabIndex = 1;
//            this.btnRemoveFromCombo.Text = "Xóa khỏi Combo";
//            this.btnRemoveFromCombo.UseVisualStyleBackColor = true;
//            this.btnRemoveFromCombo.Click += new System.EventHandler(this.btnRemoveFromCombo_Click);
//            // 
//            // gridProductsInCombo
//            // 
//            this.gridProductsInCombo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.gridProductsInCombo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
//            this.colProductId,
//            this.colProductName,
//            this.colProductPrice,
//            this.colProductQuantity});
//            this.gridProductsInCombo.Location = new System.Drawing.Point(6, 19);
//            this.gridProductsInCombo.Name = "gridProductsInCombo";
//            this.gridProductsInCombo.Size = new System.Drawing.Size(388, 189);
//            this.gridProductsInCombo.TabIndex = 0;
//            // 
//            // colProductId
//            // 
//            this.colProductId.DataPropertyName = "Id";
//            this.colProductId.HeaderText = "Mã SP";
//            this.colProductId.Name = "colProductId";
//            this.colProductId.Width = 80;
//            // 
//            // colProductName
//            // 
//            this.colProductName.DataPropertyName = "Name";
//            this.colProductName.HeaderText = "Tên SP";
//            this.colProductName.Name = "colProductName";
//            this.colProductName.Width = 150;
//            // 
//            // colProductPrice
//            // 
//            this.colProductPrice.DataPropertyName = "Price";
//            this.colProductPrice.HeaderText = "Giá";
//            this.colProductPrice.Name = "colProductPrice";
//            this.colProductPrice.Width = 80;
//            // 
//            // colProductQuantity
//            // 
//            this.colProductQuantity.DataPropertyName = "Quantity";
//            this.colProductQuantity.HeaderText = "SL";
//            this.colProductQuantity.Name = "colProductQuantity";
//            this.colProductQuantity.Width = 50;
//            // 
//            // groupBox4
//            // 
//            this.groupBox4.Controls.Add(this.btnAddToCombo);
//            this.groupBox4.Controls.Add(this.gridAvailableProducts);
//            this.groupBox4.Location = new System.Drawing.Point(418, 268);
//            this.groupBox4.Name = "groupBox4";
//            this.groupBox4.Size = new System.Drawing.Size(400, 250);
//            this.groupBox4.TabIndex = 3;
//            this.groupBox4.TabStop = false;
//            this.groupBox4.Text = "Sản phẩm có sẵn";
//            // 
//            // btnAddToCombo
//            // 
//            this.btnAddToCombo.Location = new System.Drawing.Point(280, 214);
//            this.btnAddToCombo.Name = "btnAddToCombo";
//            this.btnAddToCombo.Size = new System.Drawing.Size(100, 30);
//            this.btnAddToCombo.TabIndex = 1;
//            this.btnAddToCombo.Text = "Thêm vào Combo";
//            this.btnAddToCombo.UseVisualStyleBackColor = true;
//            this.btnAddToCombo.Click += new System.EventHandler(this.btnAddToCombo_Click);
//            // 
//            // gridAvailableProducts
//            // 
//            this.gridAvailableProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.gridAvailableProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
//            this.colAvailId,
//            this.colAvailName,
//            this.colAvailPrice,
//            this.colAvailQty});
//            this.gridAvailableProducts.Location = new System.Drawing.Point(6, 19);
//            this.gridAvailableProducts.Name = "gridAvailableProducts";
//            this.gridAvailableProducts.Size = new System.Drawing.Size(388, 189);
//            this.gridAvailableProducts.TabIndex = 0;
//            // 
//            // colAvailId
//            // 
//            this.colAvailId.DataPropertyName = "Id";
//            this.colAvailId.HeaderText = "Mã SP";
//            this.colAvailId.Name = "colAvailId";
//            this.colAvailId.Width = 80;
//            // 
//            // colAvailName
//            // 
//            this.colAvailName.DataPropertyName = "Name";
//            this.colAvailName.HeaderText = "Tên SP";
//            this.colAvailName.Name = "colAvailName";
//            this.colAvailName.Width = 150;
//            // 
//            // colAvailPrice
//            // 
//            this.colAvailPrice.DataPropertyName = "Price";
//            this.colAvailPrice.HeaderText = "Giá";
//            this.colAvailPrice.Name = "colAvailPrice";
//            this.colAvailPrice.Width = 80;
//            // 
//            // colAvailQty
//            // 
//            this.colAvailQty.DataPropertyName = "Quantity";
//            this.colAvailQty.HeaderText = "SL";
//            this.colAvailQty.Name = "colAvailQty";
//            this.colAvailQty.Width = 50;
//            // 
//            // panel1
//            // 
//            this.panel1.Controls.Add(this.btnDeleteCombo);
//            this.panel1.Controls.Add(this.btnSaveCombo);
//            this.panel1.Controls.Add(this.btnNewCombo);
//            this.panel1.Location = new System.Drawing.Point(12, 524);
//            this.panel1.Name = "panel1";
//            this.panel1.Size = new System.Drawing.Size(806, 50);
//            this.panel1.TabIndex = 4;
//            // 
//            // btnDeleteCombo
//            // 
//            this.btnDeleteCombo.Location = new System.Drawing.Point(270, 10);
//            this.btnDeleteCombo.Name = "btnDeleteCombo";
//            this.btnDeleteCombo.Size = new System.Drawing.Size(120, 35);
//            this.btnDeleteCombo.TabIndex = 2;
//            this.btnDeleteCombo.Text = "Xóa Combo";
//            this.btnDeleteCombo.UseVisualStyleBackColor = true;
//            this.btnDeleteCombo.Click += new System.EventHandler(this.btnDeleteCombo_Click);
//            // 
//            // btnSaveCombo
//            // 
//            this.btnSaveCombo.Location = new System.Drawing.Point(140, 10);
//            this.btnSaveCombo.Name = "btnSaveCombo";
//            this.btnSaveCombo.Size = new System.Drawing.Size(120, 35);
//            this.btnSaveCombo.TabIndex = 1;
//            this.btnSaveCombo.Text = "Lưu Combo";
//            this.btnSaveCombo.UseVisualStyleBackColor = true;
//            this.btnSaveCombo.Click += new System.EventHandler(this.btnSaveCombo_Click);
//            // 
//            // btnNewCombo
//            // 
//            this.btnNewCombo.Location = new System.Drawing.Point(10, 10);
//            this.btnNewCombo.Name = "btnNewCombo";
//            this.btnNewCombo.Size = new System.Drawing.Size(120, 35);
//            this.btnNewCombo.TabIndex = 0;
//            this.btnNewCombo.Text = "Tạo Combo Mới";
//            this.btnNewCombo.UseVisualStyleBackColor = true;
//            this.btnNewCombo.Click += new System.EventHandler(this.btnNewCombo_Click);
//            // 
//            // CompositeProductForm
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(966, 586);
//            this.Controls.Add(this.panel1);
//            this.Controls.Add(this.groupBox4);
//            this.Controls.Add(this.groupBox3);
//            this.Controls.Add(this.groupBox2);
//            this.Controls.Add(this.groupBox1);
//            this.Name = "CompositeProductForm";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
//            this.Text = "Quản lý Combo Sản phẩm (Composite Pattern)";
//            this.Load += new System.EventHandler(this.CompositeProductForm_Load);
//            this.groupBox1.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.gridComboList)).EndInit();
//            this.groupBox2.ResumeLayout(false);
//            this.groupBox2.PerformLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).EndInit();
//            this.groupBox3.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.gridProductsInCombo)).EndInit();
//            this.groupBox4.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.gridAvailableProducts)).EndInit();
//            this.panel1.ResumeLayout(false);
//            this.ResumeLayout(false);

//        }

//        #endregion

//        private System.Windows.Forms.GroupBox groupBox1;
//        private System.Windows.Forms.DataGridView gridComboList;
//        private System.Windows.Forms.GroupBox groupBox2;
//        private System.Windows.Forms.TextBox txtComboId;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.TextBox txtComboName;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.TextBox txtDescription;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.NumericUpDown numDiscount;
//        private System.Windows.Forms.Label label4;
//        private System.Windows.Forms.Label lblOriginalPrice;
//        private System.Windows.Forms.Label lblFinalPrice;
//        private System.Windows.Forms.Label lblSavings;
//        private System.Windows.Forms.GroupBox groupBox3;
//        private System.Windows.Forms.DataGridView gridProductsInCombo;
//        private System.Windows.Forms.GroupBox groupBox4;
//        private System.Windows.Forms.DataGridView gridAvailableProducts;
//        private System.Windows.Forms.Panel panel1;
//        private System.Windows.Forms.Button btnNewCombo;
//        private System.Windows.Forms.Button btnSaveCombo;
//        private System.Windows.Forms.Button btnDeleteCombo;
//        private System.Windows.Forms.Button btnAddToCombo;
//        private System.Windows.Forms.Button btnRemoveFromCombo;
//        private System.Windows.Forms.Button btnViewDetails;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colComboId;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colComboName;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscount;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colProductCount;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colProductPrice;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colProductQuantity;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailId;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailName;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailPrice;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailQty;
//    }
//}


//using System.Drawing;
//using System.Windows.Forms;

//namespace OOP_finalProject.EntityForm
//{
//    partial class ComboProductForm
//    {
//        private System.ComponentModel.IContainer components = null;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        private void InitializeComponent()
//        {
//            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
//            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
//            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
//            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
//            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
//            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
//            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
//            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
//            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
//            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
//            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
//            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
//            this.groupBox1 = new System.Windows.Forms.GroupBox();
//            this.gridComboList = new System.Windows.Forms.DataGridView();
//            this.colComboId = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colComboName = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colProductCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.groupBox2 = new System.Windows.Forms.GroupBox();
//            this.lblActiveCombosValue = new System.Windows.Forms.Label();
//            this.lblTotalValueValue = new System.Windows.Forms.Label();
//            this.lblTotalProductsValue = new System.Windows.Forms.Label();
//            this.lblTotalCombosValue = new System.Windows.Forms.Label();
//            this.lblActiveCombos = new System.Windows.Forms.Label();
//            this.lblTotalValue = new System.Windows.Forms.Label();
//            this.lblTotalProducts = new System.Windows.Forms.Label();
//            this.lblTotalCombos = new System.Windows.Forms.Label();
//            this.btnViewDetails = new System.Windows.Forms.Button();
//            this.lblSavings = new System.Windows.Forms.Label();
//            this.lblFinalPrice = new System.Windows.Forms.Label();
//            this.lblOriginalPrice = new System.Windows.Forms.Label();
//            this.numDiscount = new System.Windows.Forms.NumericUpDown();
//            this.numComboQuantity = new System.Windows.Forms.NumericUpDown();
//            this.label6 = new System.Windows.Forms.Label();
//            this.label4 = new System.Windows.Forms.Label();
//            this.txtDescription = new System.Windows.Forms.TextBox();
//            this.label3 = new System.Windows.Forms.Label();
//            this.txtComboName = new System.Windows.Forms.TextBox();
//            this.label2 = new System.Windows.Forms.Label();
//            this.txtComboId = new System.Windows.Forms.TextBox();
//            this.label1 = new System.Windows.Forms.Label();
//            this.groupBox3 = new System.Windows.Forms.GroupBox();
//            this.btnRemoveFromCombo = new System.Windows.Forms.Button();
//            this.gridProductsInCombo = new System.Windows.Forms.DataGridView();
//            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colProductQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.groupBox4 = new System.Windows.Forms.GroupBox();
//            this.lblSelectedProduct = new System.Windows.Forms.Label();
//            this.numQuantity = new System.Windows.Forms.NumericUpDown();
//            this.label5 = new System.Windows.Forms.Label();
//            this.btnRefreshProducts = new System.Windows.Forms.Button();
//            this.btnAddToCombo = new System.Windows.Forms.Button();
//            this.gridAvailableProducts = new System.Windows.Forms.DataGridView();
//            this.colAvailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colAvailName = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colAvailPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colAvailQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.panel1 = new System.Windows.Forms.Panel();
//            this.statusLabel = new System.Windows.Forms.Label();
//            this.btnDeleteCombo = new System.Windows.Forms.Button();
//            this.btnSaveCombo = new System.Windows.Forms.Button();
//            this.btnNewCombo = new System.Windows.Forms.Button();
//            this.groupBox1.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.gridComboList)).BeginInit();
//            this.groupBox2.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).BeginInit();
//            this.groupBox3.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.gridProductsInCombo)).BeginInit();
//            this.groupBox4.SuspendLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
//            ((System.ComponentModel.ISupportInitialize)(this.gridAvailableProducts)).BeginInit();
//            this.panel1.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // groupBox1
//            // 
//            this.groupBox1.Controls.Add(this.gridComboList);
//            this.groupBox1.Location = new System.Drawing.Point(12, 12);
//            this.groupBox1.Name = "groupBox1";
//            this.groupBox1.Size = new System.Drawing.Size(600, 250);
//            this.groupBox1.TabIndex = 0;
//            this.groupBox1.TabStop = false;
//            this.groupBox1.Text = "Danh sách Combo (Composite Pattern)";
//            // 
//            // gridComboList
//            // 
//            this.gridComboList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.gridComboList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
//            this.colComboId,
//            this.colComboName,
//            this.colDiscount,
//            this.colPrice,
//            this.colProductCount,
//            this.colComboQuantity});
//            this.gridComboList.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.gridComboList.Location = new System.Drawing.Point(3, 23);
//            this.gridComboList.Name = "gridComboList";
//            this.gridComboList.Size = new System.Drawing.Size(594, 224);
//            this.gridComboList.TabIndex = 0;
//            this.gridComboList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridComboList_CellClick);
//            // 
//            // colComboId
//            // 
//            this.colComboId.DataPropertyName = "Id";
//            this.colComboId.HeaderText = "Mã Combo";
//            this.colComboId.Name = "colComboId";
//            this.colComboId.Width = 120;
//            // 
//            // colComboName
//            // 
//            this.colComboName.DataPropertyName = "Name";
//            this.colComboName.HeaderText = "Tên Combo";
//            this.colComboName.Name = "colComboName";
//            this.colComboName.Width = 200;
//            // 
//            // colDiscount
//            // 
//            this.colDiscount.DataPropertyName = "DiscountPercentage";
//            dataGridViewCellStyle1.Format = "N2";
//            this.colDiscount.DefaultCellStyle = dataGridViewCellStyle1;
//            this.colDiscount.HeaderText = "Giảm giá %";
//            this.colDiscount.Name = "colDiscount";
//            this.colDiscount.Width = 80;
//            // 
//            // colPrice
//            // 
//            this.colPrice.DataPropertyName = "Price";
//            dataGridViewCellStyle2.Format = "N0";
//            this.colPrice.DefaultCellStyle = dataGridViewCellStyle2;
//            this.colPrice.HeaderText = "Giá bán";
//            this.colPrice.Name = "colPrice";
//            this.colPrice.Width = 120;
//            // 
//            // colProductCount
//            // 
//            this.colProductCount.DataPropertyName = "ChildCount";
//            this.colProductCount.HeaderText = "Số SP";
//            this.colProductCount.Name = "colProductCount";
//            this.colProductCount.Width = 60;
//            // 
//            // groupBox2
//            // 
//            this.groupBox2.Controls.Add(this.lblActiveCombosValue);
//            this.groupBox2.Controls.Add(this.lblTotalValueValue);
//            this.groupBox2.Controls.Add(this.lblTotalProductsValue);
//            this.groupBox2.Controls.Add(this.lblTotalCombosValue);
//            this.groupBox2.Controls.Add(this.lblActiveCombos);
//            this.groupBox2.Controls.Add(this.lblTotalValue);
//            this.groupBox2.Controls.Add(this.lblTotalProducts);
//            this.groupBox2.Controls.Add(this.lblTotalCombos);
//            this.groupBox2.Controls.Add(this.btnViewDetails);
//            this.groupBox2.Controls.Add(this.lblSavings);
//            this.groupBox2.Controls.Add(this.lblFinalPrice);
//            this.groupBox2.Controls.Add(this.lblOriginalPrice);
//            this.groupBox2.Controls.Add(this.numDiscount);
//            this.groupBox2.Controls.Add(this.numComboQuantity);
//            this.groupBox2.Controls.Add(this.label6);
//            this.groupBox2.Controls.Add(this.label4);
//            this.groupBox2.Controls.Add(this.txtDescription);
//            this.groupBox2.Controls.Add(this.label3);
//            this.groupBox2.Controls.Add(this.txtComboName);
//            this.groupBox2.Controls.Add(this.label2);
//            this.groupBox2.Controls.Add(this.txtComboId);
//            this.groupBox2.Controls.Add(this.label1);
//            this.groupBox2.Location = new System.Drawing.Point(618, 12);
//            this.groupBox2.Name = "groupBox2";
//            this.groupBox2.Size = new System.Drawing.Size(600, 250);
//            this.groupBox2.TabIndex = 1;
//            this.groupBox2.TabStop = false;
//            this.groupBox2.Text = "Thông tin Combo";
//            // 
//            // lblActiveCombosValue
//            // 
//            this.lblActiveCombosValue.AutoSize = true;
//            this.lblActiveCombosValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
//            this.lblActiveCombosValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
//            this.lblActiveCombosValue.Location = new System.Drawing.Point(500, 220);
//            this.lblActiveCombosValue.Name = "lblActiveCombosValue";
//            this.lblActiveCombosValue.Size = new System.Drawing.Size(14, 15);
//            this.lblActiveCombosValue.TabIndex = 19;
//            this.lblActiveCombosValue.Text = "0";
//            // 
//            // lblTotalValueValue
//            // 
//            this.lblTotalValueValue.AutoSize = true;
//            this.lblTotalValueValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
//            this.lblTotalValueValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
//            this.lblTotalValueValue.Location = new System.Drawing.Point(500, 200);
//            this.lblTotalValueValue.Name = "lblTotalValueValue";
//            this.lblTotalValueValue.Size = new System.Drawing.Size(20, 15);
//            this.lblTotalValueValue.TabIndex = 18;
//            this.lblTotalValueValue.Text = "0 đ";
//            // 
//            // lblTotalProductsValue
//            // 
//            this.lblTotalProductsValue.AutoSize = true;
//            this.lblTotalProductsValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
//            this.lblTotalProductsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
//            this.lblTotalProductsValue.Location = new System.Drawing.Point(500, 180);
//            this.lblTotalProductsValue.Name = "lblTotalProductsValue";
//            this.lblTotalProductsValue.Size = new System.Drawing.Size(14, 15);
//            this.lblTotalProductsValue.TabIndex = 17;
//            this.lblTotalProductsValue.Text = "0";
//            // 
//            // lblTotalCombosValue
//            // 
//            this.lblTotalCombosValue.AutoSize = true;
//            this.lblTotalCombosValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
//            this.lblTotalCombosValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
//            this.lblTotalCombosValue.Location = new System.Drawing.Point(500, 160);
//            this.lblTotalCombosValue.Name = "lblTotalCombosValue";
//            this.lblTotalCombosValue.Size = new System.Drawing.Size(14, 15);
//            this.lblTotalCombosValue.TabIndex = 16;
//            this.lblTotalCombosValue.Text = "0";
//            // 
//            // lblActiveCombos
//            // 
//            this.lblActiveCombos.AutoSize = true;
//            this.lblActiveCombos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
//            this.lblActiveCombos.Location = new System.Drawing.Point(400, 220);
//            this.lblActiveCombos.Name = "lblActiveCombos";
//            this.lblActiveCombos.Size = new System.Drawing.Size(94, 15);
//            this.lblActiveCombos.TabIndex = 15;
//            this.lblActiveCombos.Text = "Combo hoạt động:";
//            // 
//            // lblTotalValue
//            // 
//            this.lblTotalValue.AutoSize = true;
//            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
//            this.lblTotalValue.Location = new System.Drawing.Point(400, 200);
//            this.lblTotalValue.Name = "lblTotalValue";
//            this.lblTotalValue.Size = new System.Drawing.Size(58, 15);
//            this.lblTotalValue.TabIndex = 14;
//            this.lblTotalValue.Text = "Tổng giá trị:";
//            // 
//            // lblTotalProducts
//            // 
//            this.lblTotalProducts.AutoSize = true;
//            this.lblTotalProducts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
//            this.lblTotalProducts.Location = new System.Drawing.Point(400, 180);
//            this.lblTotalProducts.Name = "lblTotalProducts";
//            this.lblTotalProducts.Size = new System.Drawing.Size(82, 15);
//            this.lblTotalProducts.TabIndex = 13;
//            this.lblTotalProducts.Text = "Tổng sản phẩm:";
//            // 
//            // lblTotalCombos
//            // 
//            this.lblTotalCombos.AutoSize = true;
//            this.lblTotalCombos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
//            this.lblTotalCombos.Location = new System.Drawing.Point(400, 160);
//            this.lblTotalCombos.Name = "lblTotalCombos";
//            this.lblTotalCombos.Size = new System.Drawing.Size(82, 15);
//            this.lblTotalCombos.TabIndex = 12;
//            this.lblTotalCombos.Text = "Tổng combo:";
//            // 
//            // btnViewDetails
//            // 
//            this.btnViewDetails.Location = new System.Drawing.Point(480, 120);
//            this.btnViewDetails.Name = "btnViewDetails";
//            this.btnViewDetails.Size = new System.Drawing.Size(100, 30);
//            this.btnViewDetails.TabIndex = 11;
//            this.btnViewDetails.Text = "Xem chi tiết";
//            this.btnViewDetails.UseVisualStyleBackColor = true;
//            this.btnViewDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
//            this.btnViewDetails.ForeColor = System.Drawing.Color.White;
//            this.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
//            // 
//            // lblSavings
//            // 
//            this.lblSavings.AutoSize = true;
//            this.lblSavings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
//            this.lblSavings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
//            this.lblSavings.Location = new System.Drawing.Point(15, 220);
//            this.lblSavings.Name = "lblSavings";
//            this.lblSavings.Size = new System.Drawing.Size(75, 15);
//            this.lblSavings.TabIndex = 10;
//            this.lblSavings.Text = "Tiết kiệm: 0 đ";
//            // 
//            // lblFinalPrice
//            // 
//            this.lblFinalPrice.AutoSize = true;
//            this.lblFinalPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
//            this.lblFinalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
//            this.lblFinalPrice.Location = new System.Drawing.Point(15, 200);
//            this.lblFinalPrice.Name = "lblFinalPrice";
//            this.lblFinalPrice.Size = new System.Drawing.Size(113, 15);
//            this.lblFinalPrice.TabIndex = 9;
//            this.lblFinalPrice.Text = "Giá sau giảm: 0 đ";
//            // 
//            // lblOriginalPrice
//            // 
//            this.lblOriginalPrice.AutoSize = true;
//            this.lblOriginalPrice.Location = new System.Drawing.Point(15, 180);
//            this.lblOriginalPrice.Name = "lblOriginalPrice";
//            this.lblOriginalPrice.Size = new System.Drawing.Size(58, 15);
//            this.lblOriginalPrice.TabIndex = 8;
//            this.lblOriginalPrice.Text = "Giá gốc: 0 đ";
//            // 
//            // numDiscount
//            // 
//            this.numDiscount.DecimalPlaces = 2;
//            this.numDiscount.Location = new System.Drawing.Point(100, 145);
//            this.numDiscount.Name = "numDiscount";
//            this.numDiscount.Size = new System.Drawing.Size(280, 23);
//            this.numDiscount.TabIndex = 7;
//            this.numDiscount.ValueChanged += new System.EventHandler(this.numDiscount_ValueChanged);
//            this.numComboQuantity.Location = new System.Drawing.Point(100, 115);
//            this.numComboQuantity.Name = "numComboQuantity";
//            this.numComboQuantity.Size = new System.Drawing.Size(280, 23);
//            this.numComboQuantity.TabIndex = 8;
//            this.numComboQuantity.Minimum = 0;
//            this.numComboQuantity.Maximum = 1000;
//            this.numComboQuantity.ValueChanged += new System.EventHandler(this.numComboQuantity_ValueChanged);

//            this.label6.AutoSize = true;
//            this.label6.Location = new System.Drawing.Point(15, 117);
//            this.label6.Name = "label6";
//            this.label6.Size = new System.Drawing.Size(57, 15);
//            this.label6.TabIndex = 20;
//            this.label6.Text = "Số lượng:";
//            // 
//            // label4
//            // 
//            this.label4.AutoSize = true;
//            this.label4.Location = new System.Drawing.Point(15, 147);
//            this.label4.Name = "label4";
//            this.label4.Size = new System.Drawing.Size(68, 15);
//            this.label4.TabIndex = 6;
//            this.label4.Text = "Giảm giá (%):";
//            // 
//            // txtDescription
//            // 
//            this.txtDescription.Location = new System.Drawing.Point(100, 85);
//            this.txtDescription.Multiline = true;
//            this.txtDescription.Name = "txtDescription";
//            this.txtDescription.Size = new System.Drawing.Size(480, 50);
//            this.txtDescription.TabIndex = 5;
//            // 
//            // label3
//            // 
//            this.label3.AutoSize = true;
//            this.label3.Location = new System.Drawing.Point(15, 88);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(41, 15);
//            this.label3.TabIndex = 4;
//            this.label3.Text = "Mô tả:";
//            // 
//            // txtComboName
//            // 
//            this.txtComboName.Location = new System.Drawing.Point(100, 55);
//            this.txtComboName.Name = "txtComboName";
//            this.txtComboName.Size = new System.Drawing.Size(480, 23);
//            this.txtComboName.TabIndex = 3;
//            // 
//            // label2
//            // 
//            this.label2.AutoSize = true;
//            this.label2.Location = new System.Drawing.Point(15, 58);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(69, 15);
//            this.label2.TabIndex = 2;
//            this.label2.Text = "Tên Combo:";
//            // 
//            // txtComboId
//            // 
//            this.txtComboId.Location = new System.Drawing.Point(100, 25);
//            this.txtComboId.Name = "txtComboId";
//            this.txtComboId.Size = new System.Drawing.Size(480, 23);
//            this.txtComboId.TabIndex = 1;
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Location = new System.Drawing.Point(15, 28);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(65, 15);
//            this.label1.TabIndex = 0;
//            this.label1.Text = "Mã Combo:";
//            // 
//            // groupBox3
//            // 
//            this.groupBox3.Controls.Add(this.btnRemoveFromCombo);
//            this.groupBox3.Controls.Add(this.gridProductsInCombo);
//            this.groupBox3.Location = new System.Drawing.Point(12, 268);
//            this.groupBox3.Name = "groupBox3";
//            this.groupBox3.Size = new System.Drawing.Size(600, 250);
//            this.groupBox3.TabIndex = 2;
//            this.groupBox3.TabStop = false;
//            this.groupBox3.Text = "Sản phẩm trong Combo";
//            // 
//            // btnRemoveFromCombo
//            // 
//            this.btnRemoveFromCombo.Location = new System.Drawing.Point(480, 214);
//            this.btnRemoveFromCombo.Name = "btnRemoveFromCombo";
//            this.btnRemoveFromCombo.Size = new System.Drawing.Size(100, 30);
//            this.btnRemoveFromCombo.TabIndex = 1;
//            this.btnRemoveFromCombo.Text = "Xóa khỏi Combo";
//            this.btnRemoveFromCombo.UseVisualStyleBackColor = true;
//            this.btnRemoveFromCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
//            this.btnRemoveFromCombo.ForeColor = System.Drawing.Color.White;
//            this.btnRemoveFromCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnRemoveFromCombo.Click += new System.EventHandler(this.btnRemoveFromCombo_Click);
//            // 
//            // gridProductsInCombo
//            // 
//            this.gridProductsInCombo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.gridProductsInCombo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
//            this.colProductId,
//            this.colProductName,
//            this.colProductPrice,
//            this.colProductQuantity});
//            this.gridProductsInCombo.Location = new System.Drawing.Point(6, 19);
//            this.gridProductsInCombo.Name = "gridProductsInCombo";
//            this.gridProductsInCombo.Size = new System.Drawing.Size(588, 189);
//            this.gridProductsInCombo.TabIndex = 0;
//            // 
//            // colProductId
//            // 
//            this.colProductId.DataPropertyName = "Id";
//            this.colProductId.HeaderText = "Mã SP";
//            this.colProductId.Name = "colProductId";
//            this.colProductId.Width = 120;
//            // 
//            // colProductName
//            // 
//            this.colProductName.DataPropertyName = "Name";
//            this.colProductName.HeaderText = "Tên SP";
//            this.colProductName.Name = "colProductName";
//            this.colProductName.Width = 200;
//            // 
//            // colProductPrice
//            // 
//            this.colProductPrice.DataPropertyName = "Price";
//            dataGridViewCellStyle3.Format = "N0";
//            this.colProductPrice.DefaultCellStyle = dataGridViewCellStyle3;
//            this.colProductPrice.HeaderText = "Giá";
//            this.colProductPrice.Name = "colProductPrice";
//            this.colProductPrice.Width = 120;
//            // 
//            // colProductQuantity
//            // 
//            this.colProductQuantity.DataPropertyName = "Quantity";
//            this.colProductQuantity.HeaderText = "SL";
//            this.colProductQuantity.Name = "colProductQuantity";
//            this.colProductQuantity.Width = 80;
//            // 
//            // groupBox4
//            // 
//            this.groupBox4.Controls.Add(this.lblSelectedProduct);
//            this.groupBox4.Controls.Add(this.numQuantity);
//            this.groupBox4.Controls.Add(this.label5);
//            this.groupBox4.Controls.Add(this.btnRefreshProducts);
//            this.groupBox4.Controls.Add(this.btnAddToCombo);
//            this.groupBox4.Controls.Add(this.gridAvailableProducts);
//            this.groupBox4.Location = new System.Drawing.Point(618, 268);
//            this.groupBox4.Name = "groupBox4";
//            this.groupBox4.Size = new System.Drawing.Size(600, 250);
//            this.groupBox4.TabIndex = 3;
//            this.groupBox4.TabStop = false;
//            this.groupBox4.Text = "Sản phẩm có sẵn";
//            // 
//            // lblSelectedProduct
//            // 
//            this.lblSelectedProduct.AutoSize = true;
//            this.lblSelectedProduct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
//            this.lblSelectedProduct.Location = new System.Drawing.Point(15, 220);
//            this.lblSelectedProduct.Name = "lblSelectedProduct";
//            this.lblSelectedProduct.Size = new System.Drawing.Size(72, 15);
//            this.lblSelectedProduct.TabIndex = 5;
//            this.lblSelectedProduct.Text = "Đã chọn: ...";
//            // 
//            // numQuantity
//            // 
//            this.numQuantity.Location = new System.Drawing.Point(280, 217);
//            this.numQuantity.Minimum = new decimal(new int[] {
//            1,
//            0,
//            0,
//            0});
//            this.numQuantity.Name = "numQuantity";
//            this.numQuantity.Size = new System.Drawing.Size(80, 23);
//            this.numQuantity.TabIndex = 4;
//            this.numQuantity.Value = new decimal(new int[] {
//            1,
//            0,
//            0,
//            0});
//            // 
//            // label5
//            // 
//            this.label5.AutoSize = true;
//            this.label5.Location = new System.Drawing.Point(220, 220);
//            this.label5.Name = "label5";
//            this.label5.Size = new System.Drawing.Size(57, 15);
//            this.label5.TabIndex = 3;
//            this.label5.Text = "Số lượng:";
//            // 
//            // btnRefreshProducts
//            // 
//            this.btnRefreshProducts.Location = new System.Drawing.Point(370, 214);
//            this.btnRefreshProducts.Name = "btnRefreshProducts";
//            this.btnRefreshProducts.Size = new System.Drawing.Size(100, 30);
//            this.btnRefreshProducts.TabIndex = 2;
//            this.btnRefreshProducts.Text = "Làm mới";
//            this.btnRefreshProducts.UseVisualStyleBackColor = true;
//            this.btnRefreshProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
//            this.btnRefreshProducts.ForeColor = System.Drawing.Color.White;
//            this.btnRefreshProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnRefreshProducts.Click += new System.EventHandler(this.btnRefreshProducts_Click);
//            // 
//            // btnAddToCombo
//            // 
//            this.btnAddToCombo.Location = new System.Drawing.Point(480, 214);
//            this.btnAddToCombo.Name = "btnAddToCombo";
//            this.btnAddToCombo.Size = new System.Drawing.Size(100, 30);
//            this.btnAddToCombo.TabIndex = 1;
//            this.btnAddToCombo.Text = "Thêm vào Combo";
//            this.btnAddToCombo.UseVisualStyleBackColor = true;
//            this.btnAddToCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
//            this.btnAddToCombo.ForeColor = System.Drawing.Color.White;
//            this.btnAddToCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnAddToCombo.Click += new System.EventHandler(this.btnAddToCombo_Click);
//            // 
//            // gridAvailableProducts
//            // 
//            this.gridAvailableProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.gridAvailableProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
//            this.colAvailId,
//            this.colAvailName,
//            this.colAvailPrice,
//            this.colAvailQty});
//            this.gridAvailableProducts.Location = new System.Drawing.Point(6, 19);
//            this.gridAvailableProducts.Name = "gridAvailableProducts";
//            this.gridAvailableProducts.Size = new System.Drawing.Size(588, 189);
//            this.gridAvailableProducts.TabIndex = 0;
//            this.gridAvailableProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAvailableProducts_CellClick);
//            // 
//            // colAvailId
//            // 
//            this.colAvailId.DataPropertyName = "Id";
//            this.colAvailId.HeaderText = "Mã SP";
//            this.colAvailId.Name = "colAvailId";
//            this.colAvailId.Width = 120;
//            // 
//            // colAvailName
//            // 
//            this.colAvailName.DataPropertyName = "Name";
//            this.colAvailName.HeaderText = "Tên SP";
//            this.colAvailName.Name = "colAvailName";
//            this.colAvailName.Width = 200;
//            // 
//            // colAvailPrice
//            // 
//            this.colAvailPrice.DataPropertyName = "Price";
//            dataGridViewCellStyle4.Format = "N0";
//            this.colAvailPrice.DefaultCellStyle = dataGridViewCellStyle4;
//            this.colAvailPrice.HeaderText = "Giá";
//            this.colAvailPrice.Name = "colAvailPrice";
//            this.colAvailPrice.Width = 120;
//            // 
//            // colAvailQty
//            // 
//            this.colAvailQty.DataPropertyName = "Quantity";
//            this.colAvailQty.HeaderText = "SL Tồn";
//            this.colAvailQty.Name = "colAvailQty";
//            this.colAvailQty.Width = 80;
//            //
//            // colComboQuantity
//            //
//            this.colComboQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
//            this.colComboQuantity.DataPropertyName = "Quantity";
//            this.colComboQuantity.HeaderText = "SL Tồn";
//            this.colComboQuantity.Name = "colComboQuantity";
//            this.colComboQuantity.Width = 80;
//            // 
//            // panel1
//            // 
//            this.panel1.Controls.Add(this.statusLabel);
//            this.panel1.Controls.Add(this.btnDeleteCombo);
//            this.panel1.Controls.Add(this.btnSaveCombo);
//            this.panel1.Controls.Add(this.btnNewCombo);
//            this.panel1.Location = new System.Drawing.Point(12, 524);
//            this.panel1.Name = "panel1";
//            this.panel1.Size = new System.Drawing.Size(1206, 50);
//            this.panel1.TabIndex = 4;
//            // 
//            // statusLabel
//            // 
//            this.statusLabel.AutoSize = true;
//            this.statusLabel.Location = new System.Drawing.Point(400, 17);
//            this.statusLabel.Name = "statusLabel";
//            this.statusLabel.Size = new System.Drawing.Size(54, 15);
//            this.statusLabel.TabIndex = 3;
//            this.statusLabel.Text = "Sẵn sàng";
//            // 
//            // btnDeleteCombo
//            // 
//            this.btnDeleteCombo.Location = new System.Drawing.Point(270, 10);
//            this.btnDeleteCombo.Name = "btnDeleteCombo";
//            this.btnDeleteCombo.Size = new System.Drawing.Size(120, 35);
//            this.btnDeleteCombo.TabIndex = 2;
//            this.btnDeleteCombo.Text = "Xóa Combo";
//            this.btnDeleteCombo.UseVisualStyleBackColor = true;
//            this.btnDeleteCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
//            this.btnDeleteCombo.ForeColor = System.Drawing.Color.White;
//            this.btnDeleteCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnDeleteCombo.Click += new System.EventHandler(this.btnDeleteCombo_Click);
//            // 
//            // btnSaveCombo
//            // 
//            this.btnSaveCombo.Location = new System.Drawing.Point(140, 10);
//            this.btnSaveCombo.Name = "btnSaveCombo";
//            this.btnSaveCombo.Size = new System.Drawing.Size(120, 35);
//            this.btnSaveCombo.TabIndex = 1;
//            this.btnSaveCombo.Text = "Lưu Combo";
//            this.btnSaveCombo.UseVisualStyleBackColor = true;
//            this.btnSaveCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
//            this.btnSaveCombo.ForeColor = System.Drawing.Color.White;
//            this.btnSaveCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnSaveCombo.Click += new System.EventHandler(this.btnSaveCombo_Click);
//            // 
//            // btnNewCombo
//            // 
//            this.btnNewCombo.Location = new System.Drawing.Point(10, 10);
//            this.btnNewCombo.Name = "btnNewCombo";
//            this.btnNewCombo.Size = new System.Drawing.Size(120, 35);
//            this.btnNewCombo.TabIndex = 0;
//            this.btnNewCombo.Text = "Tạo Combo Mới";
//            this.btnNewCombo.UseVisualStyleBackColor = true;
//            this.btnNewCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
//            this.btnNewCombo.ForeColor = System.Drawing.Color.White;
//            this.btnNewCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnNewCombo.Click += new System.EventHandler(this.btnNewCombo_Click);
//            // 
//            // ComboProductForm
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(1230, 586);
//            this.Controls.Add(this.panel1);
//            this.Controls.Add(this.groupBox4);
//            this.Controls.Add(this.groupBox3);
//            this.Controls.Add(this.groupBox2);
//            this.Controls.Add(this.groupBox1);
//            this.Name = "ComboProductForm";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
//            this.Text = "QUẢN LÝ COMBO SẢN PHẨM (Composite Pattern)";
//            this.Load += new System.EventHandler(this.CompositeProductForm_Load);
//            this.groupBox1.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.gridComboList)).EndInit();
//            this.groupBox2.ResumeLayout(false);
//            this.groupBox2.PerformLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).EndInit();
//            this.groupBox3.ResumeLayout(false);
//            ((System.ComponentModel.ISupportInitialize)(this.gridProductsInCombo)).EndInit();
//            this.groupBox4.ResumeLayout(false);
//            this.groupBox4.PerformLayout();
//            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
//            ((System.ComponentModel.ISupportInitialize)(this.gridAvailableProducts)).EndInit();
//            this.panel1.ResumeLayout(false);
//            this.panel1.PerformLayout();
//            this.ResumeLayout(false);

//        }

//        #endregion

//        private System.Windows.Forms.GroupBox groupBox1;
//        private System.Windows.Forms.DataGridView gridComboList;
//        private System.Windows.Forms.GroupBox groupBox2;
//        private System.Windows.Forms.TextBox txtComboId;
//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.TextBox txtComboName;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.TextBox txtDescription;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.NumericUpDown numDiscount;
//        private System.Windows.Forms.NumericUpDown numComboQuantity;
//        private System.Windows.Forms.Label label6;
//        private System.Windows.Forms.Label label4;
//        private System.Windows.Forms.Label lblOriginalPrice;
//        private System.Windows.Forms.Label lblFinalPrice;
//        private System.Windows.Forms.Label lblSavings;
//        private System.Windows.Forms.GroupBox groupBox3;
//        private System.Windows.Forms.DataGridView gridProductsInCombo;
//        private System.Windows.Forms.GroupBox groupBox4;
//        private System.Windows.Forms.DataGridView gridAvailableProducts;
//        private System.Windows.Forms.Panel panel1;
//        private System.Windows.Forms.Button btnNewCombo;
//        private System.Windows.Forms.Button btnSaveCombo;
//        private System.Windows.Forms.Button btnDeleteCombo;
//        private System.Windows.Forms.Button btnAddToCombo;
//        private System.Windows.Forms.Button btnRemoveFromCombo;
//        private System.Windows.Forms.Button btnViewDetails;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colComboId;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colComboName;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscount;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colProductCount;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colProductPrice;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colProductQuantity;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailId;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailName;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailPrice;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailQty;
//        private System.Windows.Forms.Label lblTotalCombos;
//        private System.Windows.Forms.Label lblTotalProducts;
//        private System.Windows.Forms.Label lblTotalValue;
//        private System.Windows.Forms.Label lblActiveCombos;
//        private System.Windows.Forms.Label lblTotalCombosValue;
//        private System.Windows.Forms.Label lblTotalProductsValue;
//        private System.Windows.Forms.Label lblTotalValueValue;
//        private System.Windows.Forms.Label lblActiveCombosValue;
//        private System.Windows.Forms.Button btnRefreshProducts;
//        private System.Windows.Forms.NumericUpDown numQuantity;
//        private System.Windows.Forms.Label label5;
//        private System.Windows.Forms.Label lblSelectedProduct;
//        private System.Windows.Forms.Label statusLabel;
//        private System.Windows.Forms.DataGridViewTextBoxColumn colComboQuantity;
//    }
//}

using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject.EntityForm
{
    partial class ComboProductForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridComboList = new System.Windows.Forms.DataGridView();
            this.colComboId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComboName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComboQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblActiveCombosValue = new System.Windows.Forms.Label();
            this.lblTotalValueValue = new System.Windows.Forms.Label();
            this.lblTotalProductsValue = new System.Windows.Forms.Label();
            this.lblTotalCombosValue = new System.Windows.Forms.Label();
            this.lblActiveCombos = new System.Windows.Forms.Label();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblTotalProducts = new System.Windows.Forms.Label();
            this.lblTotalCombos = new System.Windows.Forms.Label();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.lblSavings = new System.Windows.Forms.Label();
            this.lblFinalPrice = new System.Windows.Forms.Label();
            this.lblOriginalPrice = new System.Windows.Forms.Label();
            this.numDiscount = new System.Windows.Forms.NumericUpDown();
            this.numComboQuantity = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtComboName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComboId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnRemoveFromCombo = new System.Windows.Forms.Button();
            this.gridProductsInCombo = new System.Windows.Forms.DataGridView();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblSelectedProduct = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRefreshProducts = new System.Windows.Forms.Button();
            this.btnAddToCombo = new System.Windows.Forms.Button();
            this.gridAvailableProducts = new System.Windows.Forms.DataGridView();
            this.colAvailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvailName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvailPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvailQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.btnDeleteCombo = new System.Windows.Forms.Button();
            this.btnSaveCombo = new System.Windows.Forms.Button();
            this.btnNewCombo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridComboList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numComboQuantity)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProductsInCombo)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAvailableProducts)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridComboList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 250);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách Combo (Composite Pattern)";
            // 
            // gridComboList
            // 
            this.gridComboList.AllowUserToAddRows = false;
            this.gridComboList.AllowUserToDeleteRows = false;
            this.gridComboList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridComboList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colComboId,
            this.colComboName,
            this.colDiscount,
            this.colPrice,
            this.colProductCount,
            this.colComboQuantity});
            this.gridComboList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridComboList.Location = new System.Drawing.Point(3, 23);
            this.gridComboList.Name = "gridComboList";
            this.gridComboList.ReadOnly = true;
            this.gridComboList.Size = new System.Drawing.Size(694, 224);
            this.gridComboList.TabIndex = 0;
            this.gridComboList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridComboList_CellClick);
            // 
            // colComboId
            // 
            this.colComboId.DataPropertyName = "Id";
            this.colComboId.HeaderText = "Mã Combo";
            this.colComboId.Name = "colComboId";
            this.colComboId.ReadOnly = true;
            this.colComboId.Width = 120;
            // 
            // colComboName
            // 
            this.colComboName.DataPropertyName = "Name";
            this.colComboName.HeaderText = "Tên Combo";
            this.colComboName.Name = "colComboName";
            this.colComboName.ReadOnly = true;
            this.colComboName.Width = 150;
            // 
            // colDiscount
            // 
            this.colDiscount.DataPropertyName = "DiscountPercentage";
            dataGridViewCellStyle1.Format = "N2";
            this.colDiscount.DefaultCellStyle = dataGridViewCellStyle1;
            this.colDiscount.HeaderText = "Giảm giá %";
            this.colDiscount.Name = "colDiscount";
            this.colDiscount.ReadOnly = true;
            this.colDiscount.Width = 80;
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "Price";
            dataGridViewCellStyle2.Format = "N0";
            this.colPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPrice.HeaderText = "Giá bán";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 120;
            // 
            // colProductCount
            // 
            this.colProductCount.DataPropertyName = "ChildCount";
            this.colProductCount.HeaderText = "Số SP";
            this.colProductCount.Name = "colProductCount";
            this.colProductCount.ReadOnly = true;
            this.colProductCount.Width = 60;
            // 
            // colComboQuantity
            // 
            this.colComboQuantity.DataPropertyName = "Quantity";
            this.colComboQuantity.HeaderText = "SL Tồn";
            this.colComboQuantity.Name = "colComboQuantity";
            this.colComboQuantity.ReadOnly = true;
            this.colComboQuantity.Width = 80;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblActiveCombosValue);
            this.groupBox2.Controls.Add(this.lblTotalValueValue);
            this.groupBox2.Controls.Add(this.lblTotalProductsValue);
            this.groupBox2.Controls.Add(this.lblTotalCombosValue);
            this.groupBox2.Controls.Add(this.lblActiveCombos);
            this.groupBox2.Controls.Add(this.lblTotalValue);
            this.groupBox2.Controls.Add(this.lblTotalProducts);
            this.groupBox2.Controls.Add(this.lblTotalCombos);
            this.groupBox2.Controls.Add(this.btnViewDetails);
            this.groupBox2.Controls.Add(this.lblSavings);
            this.groupBox2.Controls.Add(this.lblFinalPrice);
            this.groupBox2.Controls.Add(this.lblOriginalPrice);
            this.groupBox2.Controls.Add(this.numDiscount);
            this.groupBox2.Controls.Add(this.numComboQuantity);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtComboName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtComboId);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(620, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(590, 250);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin Combo";
            // 
            // lblActiveCombosValue
            // 
            this.lblActiveCombosValue.AutoSize = true;
            this.lblActiveCombosValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblActiveCombosValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblActiveCombosValue.Location = new System.Drawing.Point(530, 220);
            this.lblActiveCombosValue.Name = "lblActiveCombosValue";
            this.lblActiveCombosValue.Size = new System.Drawing.Size(14, 15);
            this.lblActiveCombosValue.TabIndex = 19;
            this.lblActiveCombosValue.Text = "0";
            // 
            // lblTotalValueValue
            // 
            this.lblTotalValueValue.AutoSize = true;
            this.lblTotalValueValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalValueValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblTotalValueValue.Location = new System.Drawing.Point(530, 200);
            this.lblTotalValueValue.Name = "lblTotalValueValue";
            this.lblTotalValueValue.Size = new System.Drawing.Size(20, 15);
            this.lblTotalValueValue.TabIndex = 18;
            this.lblTotalValueValue.Text = "0 đ";
            // 
            // lblTotalProductsValue
            // 
            this.lblTotalProductsValue.AutoSize = true;
            this.lblTotalProductsValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalProductsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblTotalProductsValue.Location = new System.Drawing.Point(530, 180);
            this.lblTotalProductsValue.Name = "lblTotalProductsValue";
            this.lblTotalProductsValue.Size = new System.Drawing.Size(14, 15);
            this.lblTotalProductsValue.TabIndex = 17;
            this.lblTotalProductsValue.Text = "0";
            // 
            // lblTotalCombosValue
            // 
            this.lblTotalCombosValue.AutoSize = true;
            this.lblTotalCombosValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalCombosValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblTotalCombosValue.Location = new System.Drawing.Point(530, 160);
            this.lblTotalCombosValue.Name = "lblTotalCombosValue";
            this.lblTotalCombosValue.Size = new System.Drawing.Size(14, 15);
            this.lblTotalCombosValue.TabIndex = 16;
            this.lblTotalCombosValue.Text = "0";
            // 
            // lblActiveCombos
            // 
            this.lblActiveCombos.AutoSize = true;
            this.lblActiveCombos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblActiveCombos.Location = new System.Drawing.Point(400, 220);
            this.lblActiveCombos.Name = "lblActiveCombos";
            this.lblActiveCombos.Size = new System.Drawing.Size(94, 15);
            this.lblActiveCombos.TabIndex = 15;
            this.lblActiveCombos.Text = "Combo hoạt động:";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.Location = new System.Drawing.Point(400, 200);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(58, 15);
            this.lblTotalValue.TabIndex = 14;
            this.lblTotalValue.Text = "Tổng giá trị:";
            // 
            // lblTotalProducts
            // 
            this.lblTotalProducts.AutoSize = true;
            this.lblTotalProducts.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalProducts.Location = new System.Drawing.Point(400, 180);
            this.lblTotalProducts.Name = "lblTotalProducts";
            this.lblTotalProducts.Size = new System.Drawing.Size(82, 15);
            this.lblTotalProducts.TabIndex = 13;
            this.lblTotalProducts.Text = "Tổng sản phẩm:";
            // 
            // lblTotalCombos
            // 
            this.lblTotalCombos.AutoSize = true;
            this.lblTotalCombos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalCombos.Location = new System.Drawing.Point(400, 160);
            this.lblTotalCombos.Name = "lblTotalCombos";
            this.lblTotalCombos.Size = new System.Drawing.Size(82, 15);
            this.lblTotalCombos.TabIndex = 12;
            this.lblTotalCombos.Text = "Tổng combo:";
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnViewDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewDetails.ForeColor = System.Drawing.Color.White;
            this.btnViewDetails.Location = new System.Drawing.Point(480, 120);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(100, 30);
            this.btnViewDetails.TabIndex = 11;
            this.btnViewDetails.Text = "Xem chi tiết";
            this.btnViewDetails.UseVisualStyleBackColor = false;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // lblSavings
            // 
            this.lblSavings.AutoSize = true;
            this.lblSavings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSavings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblSavings.Location = new System.Drawing.Point(15, 220);
            this.lblSavings.Name = "lblSavings";
            this.lblSavings.Size = new System.Drawing.Size(75, 15);
            this.lblSavings.TabIndex = 10;
            this.lblSavings.Text = "Tiết kiệm: 0 đ";
            // 
            // lblFinalPrice
            // 
            this.lblFinalPrice.AutoSize = true;
            this.lblFinalPrice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFinalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.lblFinalPrice.Location = new System.Drawing.Point(15, 200);
            this.lblFinalPrice.Name = "lblFinalPrice";
            this.lblFinalPrice.Size = new System.Drawing.Size(113, 15);
            this.lblFinalPrice.TabIndex = 9;
            this.lblFinalPrice.Text = "Giá sau giảm: 0 đ";
            // 
            // lblOriginalPrice
            // 
            this.lblOriginalPrice.AutoSize = true;
            this.lblOriginalPrice.Location = new System.Drawing.Point(15, 180);
            this.lblOriginalPrice.Name = "lblOriginalPrice";
            this.lblOriginalPrice.Size = new System.Drawing.Size(58, 15);
            this.lblOriginalPrice.TabIndex = 8;
            this.lblOriginalPrice.Text = "Giá gốc: 0 đ";
            // 
            // numDiscount
            // 
            this.numDiscount.DecimalPlaces = 2;
            this.numDiscount.Location = new System.Drawing.Point(100, 145);
            this.numDiscount.Name = "numDiscount";
            this.numDiscount.Size = new System.Drawing.Size(280, 23);
            this.numDiscount.TabIndex = 7;
            this.numDiscount.ValueChanged += new System.EventHandler(this.numDiscount_ValueChanged);
            // 
            // numComboQuantity
            // 
            this.numComboQuantity.Location = new System.Drawing.Point(100, 115);
            this.numComboQuantity.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numComboQuantity.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numComboQuantity.Name = "numComboQuantity";
            this.numComboQuantity.Size = new System.Drawing.Size(280, 23);
            this.numComboQuantity.TabIndex = 8;
            this.numComboQuantity.ValueChanged += new System.EventHandler(this.numComboQuantity_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Số lượng:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Giảm giá (%):";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(100, 85);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(480, 25);
            this.txtDescription.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mô tả:";
            // 
            // txtComboName
            // 
            this.txtComboName.Location = new System.Drawing.Point(100, 55);
            this.txtComboName.Name = "txtComboName";
            this.txtComboName.Size = new System.Drawing.Size(480, 23);
            this.txtComboName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Combo:";
            // 
            // txtComboId
            // 
            this.txtComboId.Location = new System.Drawing.Point(100, 25);
            this.txtComboId.Name = "txtComboId";
            this.txtComboId.Size = new System.Drawing.Size(480, 23);
            this.txtComboId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Combo:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRemoveFromCombo);
            this.groupBox3.Controls.Add(this.gridProductsInCombo);
            this.groupBox3.Location = new System.Drawing.Point(12, 268);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(600, 250);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sản phẩm trong Combo";
            // 
            // btnRemoveFromCombo
            // 
            this.btnRemoveFromCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnRemoveFromCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveFromCombo.ForeColor = System.Drawing.Color.White;
            this.btnRemoveFromCombo.Location = new System.Drawing.Point(450, 214);
            this.btnRemoveFromCombo.Name = "btnRemoveFromCombo";
            this.btnRemoveFromCombo.Size = new System.Drawing.Size(100, 30);
            this.btnRemoveFromCombo.TabIndex = 1;
            this.btnRemoveFromCombo.Text = "Xóa khỏi Combo";
            this.btnRemoveFromCombo.UseVisualStyleBackColor = false;
            this.btnRemoveFromCombo.Click += new System.EventHandler(this.btnRemoveFromCombo_Click);
            // 
            // gridProductsInCombo
            // 
            this.gridProductsInCombo.AllowUserToAddRows = false;
            this.gridProductsInCombo.AllowUserToDeleteRows = false;
            this.gridProductsInCombo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProductsInCombo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductId,
            this.colProductName,
            this.colProductPrice,
            this.colProductQuantity});
            this.gridProductsInCombo.Location = new System.Drawing.Point(6, 19);
            this.gridProductsInCombo.Name = "gridProductsInCombo";
            this.gridProductsInCombo.ReadOnly = true;
            this.gridProductsInCombo.Size = new System.Drawing.Size(688, 189);
            this.gridProductsInCombo.TabIndex = 0;
            // 
            // colProductId
            // 
            this.colProductId.DataPropertyName = "Id";
            this.colProductId.HeaderText = "Mã SP";
            this.colProductId.Name = "colProductId";
            this.colProductId.ReadOnly = true;
            this.colProductId.Width = 120;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "Name";
            this.colProductName.HeaderText = "Tên SP";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 200;
            // 
            // colProductPrice
            // 
            this.colProductPrice.DataPropertyName = "Price";
            dataGridViewCellStyle3.Format = "N0";
            this.colProductPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.colProductPrice.HeaderText = "Giá";
            this.colProductPrice.Name = "colProductPrice";
            this.colProductPrice.ReadOnly = true;
            this.colProductPrice.Width = 120;
            // 
            // colProductQuantity
            // 
            this.colProductQuantity.DataPropertyName = "Quantity";
            this.colProductQuantity.HeaderText = "SL";
            this.colProductQuantity.Name = "colProductQuantity";
            this.colProductQuantity.ReadOnly = true;
            this.colProductQuantity.Width = 80;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblSelectedProduct);
            this.groupBox4.Controls.Add(this.numQuantity);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.btnRefreshProducts);
            this.groupBox4.Controls.Add(this.btnAddToCombo);
            this.groupBox4.Controls.Add(this.gridAvailableProducts);
            this.groupBox4.Location = new System.Drawing.Point(620, 268);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(590, 250);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sản phẩm có sẵn";
            // 
            // lblSelectedProduct
            // 
            this.lblSelectedProduct.AutoSize = true;
            this.lblSelectedProduct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSelectedProduct.Location = new System.Drawing.Point(15, 220);
            this.lblSelectedProduct.Name = "lblSelectedProduct";
            this.lblSelectedProduct.Size = new System.Drawing.Size(72, 15);
            this.lblSelectedProduct.TabIndex = 5;
            this.lblSelectedProduct.Text = "Đã chọn: ...";
            // 
            // numQuantity
            // 
            this.numQuantity.Location = new System.Drawing.Point(280, 217);
            this.numQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(80, 23);
            this.numQuantity.TabIndex = 4;
            this.numQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Số lượng:";
            // 
            // btnRefreshProducts
            // 
            this.btnRefreshProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnRefreshProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshProducts.ForeColor = System.Drawing.Color.White;
            this.btnRefreshProducts.Location = new System.Drawing.Point(370, 214);
            this.btnRefreshProducts.Name = "btnRefreshProducts";
            this.btnRefreshProducts.Size = new System.Drawing.Size(100, 30);
            this.btnRefreshProducts.TabIndex = 2;
            this.btnRefreshProducts.Text = "Làm mới";
            this.btnRefreshProducts.UseVisualStyleBackColor = false;
            this.btnRefreshProducts.Click += new System.EventHandler(this.btnRefreshProducts_Click);
            // 
            // btnAddToCombo
            // 
            this.btnAddToCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnAddToCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToCombo.ForeColor = System.Drawing.Color.White;
            this.btnAddToCombo.Location = new System.Drawing.Point(480, 214);
            this.btnAddToCombo.Name = "btnAddToCombo";
            this.btnAddToCombo.Size = new System.Drawing.Size(100, 30);
            this.btnAddToCombo.TabIndex = 1;
            this.btnAddToCombo.Text = "Thêm vào Combo";
            this.btnAddToCombo.UseVisualStyleBackColor = false;
            this.btnAddToCombo.Click += new System.EventHandler(this.btnAddToCombo_Click);
            // 
            // gridAvailableProducts
            // 
            this.gridAvailableProducts.AllowUserToAddRows = false;
            this.gridAvailableProducts.AllowUserToDeleteRows = false;
            this.gridAvailableProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAvailableProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAvailId,
            this.colAvailName,
            this.colAvailPrice,
            this.colAvailQty});
            this.gridAvailableProducts.Location = new System.Drawing.Point(6, 19);
            this.gridAvailableProducts.Name = "gridAvailableProducts";
            this.gridAvailableProducts.ReadOnly = true;
            this.gridAvailableProducts.Size = new System.Drawing.Size(588, 189);
            this.gridAvailableProducts.TabIndex = 0;
            this.gridAvailableProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAvailableProducts_CellClick);
            // 
            // colAvailId
            // 
            this.colAvailId.DataPropertyName = "Id";
            this.colAvailId.HeaderText = "Mã SP";
            this.colAvailId.Name = "colAvailId";
            this.colAvailId.ReadOnly = true;
            this.colAvailId.Width = 120;
            // 
            // colAvailName
            // 
            this.colAvailName.DataPropertyName = "Name";
            this.colAvailName.HeaderText = "Tên SP";
            this.colAvailName.Name = "colAvailName";
            this.colAvailName.ReadOnly = true;
            this.colAvailName.Width = 200;
            // 
            // colAvailPrice
            // 
            this.colAvailPrice.DataPropertyName = "Price";
            dataGridViewCellStyle4.Format = "N0";
            this.colAvailPrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.colAvailPrice.HeaderText = "Giá";
            this.colAvailPrice.Name = "colAvailPrice";
            this.colAvailPrice.ReadOnly = true;
            this.colAvailPrice.Width = 120;
            // 
            // colAvailQty
            // 
            this.colAvailQty.DataPropertyName = "Quantity";
            this.colAvailQty.HeaderText = "SL Tồn";
            this.colAvailQty.Name = "colAvailQty";
            this.colAvailQty.ReadOnly = true;
            this.colAvailQty.Width = 80;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.statusLabel);
            this.panel1.Controls.Add(this.btnDeleteCombo);
            this.panel1.Controls.Add(this.btnSaveCombo);
            this.panel1.Controls.Add(this.btnNewCombo);
            this.panel1.Location = new System.Drawing.Point(12, 524);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1306, 50);
            this.panel1.TabIndex = 4;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(400, 17);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(54, 15);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.Text = "Sẵn sàng";
            // 
            // btnDeleteCombo
            // 
            this.btnDeleteCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDeleteCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCombo.ForeColor = System.Drawing.Color.White;
            this.btnDeleteCombo.Location = new System.Drawing.Point(270, 10);
            this.btnDeleteCombo.Name = "btnDeleteCombo";
            this.btnDeleteCombo.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteCombo.TabIndex = 2;
            this.btnDeleteCombo.Text = "Xóa Combo";
            this.btnDeleteCombo.UseVisualStyleBackColor = false;
            this.btnDeleteCombo.Click += new System.EventHandler(this.btnDeleteCombo_Click);
            // 
            // btnSaveCombo
            // 
            this.btnSaveCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSaveCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveCombo.ForeColor = System.Drawing.Color.White;
            this.btnSaveCombo.Location = new System.Drawing.Point(140, 10);
            this.btnSaveCombo.Name = "btnSaveCombo";
            this.btnSaveCombo.Size = new System.Drawing.Size(120, 35);
            this.btnSaveCombo.TabIndex = 1;
            this.btnSaveCombo.Text = "Lưu Combo";
            this.btnSaveCombo.UseVisualStyleBackColor = false;
            this.btnSaveCombo.Click += new System.EventHandler(this.btnSaveCombo_Click);
            // 
            // btnNewCombo
            // 
            this.btnNewCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnNewCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewCombo.ForeColor = System.Drawing.Color.White;
            this.btnNewCombo.Location = new System.Drawing.Point(10, 10);
            this.btnNewCombo.Name = "btnNewCombo";
            this.btnNewCombo.Size = new System.Drawing.Size(120, 35);
            this.btnNewCombo.TabIndex = 0;
            this.btnNewCombo.Text = "Tạo Combo Mới";
            this.btnNewCombo.UseVisualStyleBackColor = false;
            this.btnNewCombo.Click += new System.EventHandler(this.btnNewCombo_Click);
            // 
            // ComboProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 586);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ComboProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ COMBO SẢN PHẨM (Composite Pattern)";
            this.Load += new System.EventHandler(this.CompositeProductForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridComboList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numComboQuantity)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProductsInCombo)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridAvailableProducts)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridComboList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtComboId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComboName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numDiscount;
        private System.Windows.Forms.NumericUpDown numComboQuantity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblOriginalPrice;
        private System.Windows.Forms.Label lblFinalPrice;
        private System.Windows.Forms.Label lblSavings;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gridProductsInCombo;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView gridAvailableProducts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNewCombo;
        private System.Windows.Forms.Button btnSaveCombo;
        private System.Windows.Forms.Button btnDeleteCombo;
        private System.Windows.Forms.Button btnAddToCombo;
        private System.Windows.Forms.Button btnRemoveFromCombo;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComboId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComboName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComboQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailQty;
        private System.Windows.Forms.Label lblTotalCombos;
        private System.Windows.Forms.Label lblTotalProducts;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Label lblActiveCombos;
        private System.Windows.Forms.Label lblTotalCombosValue;
        private System.Windows.Forms.Label lblTotalProductsValue;
        private System.Windows.Forms.Label lblTotalValueValue;
        private System.Windows.Forms.Label lblActiveCombosValue;
        private System.Windows.Forms.Button btnRefreshProducts;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSelectedProduct;
        private System.Windows.Forms.Label statusLabel;
    }
}