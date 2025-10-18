namespace OOP_finalProject.EntityForm
{
    partial class CompositeProductForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridComboList = new System.Windows.Forms.DataGridView();
            this.colComboId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComboName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.lblSavings = new System.Windows.Forms.Label();
            this.lblFinalPrice = new System.Windows.Forms.Label();
            this.lblOriginalPrice = new System.Windows.Forms.Label();
            this.numDiscount = new System.Windows.Forms.NumericUpDown();
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
            this.btnAddToCombo = new System.Windows.Forms.Button();
            this.gridAvailableProducts = new System.Windows.Forms.DataGridView();
            this.colAvailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvailName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvailPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAvailQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDeleteCombo = new System.Windows.Forms.Button();
            this.btnSaveCombo = new System.Windows.Forms.Button();
            this.btnNewCombo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridComboList)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProductsInCombo)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAvailableProducts)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridComboList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 250);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách Combo";
            // 
            // gridComboList
            // 
            this.gridComboList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridComboList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colComboId,
            this.colComboName,
            this.colDiscount,
            this.colPrice,
            this.colProductCount});
            this.gridComboList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridComboList.Location = new System.Drawing.Point(3, 16);
            this.gridComboList.Name = "gridComboList";
            this.gridComboList.Size = new System.Drawing.Size(394, 231);
            this.gridComboList.TabIndex = 0;
            this.gridComboList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridComboList_CellClick);
            // 
            // colComboId
            // 
            this.colComboId.DataPropertyName = "Id";
            this.colComboId.HeaderText = "Mã Combo";
            this.colComboId.Name = "colComboId";
            this.colComboId.Width = 80;
            // 
            // colComboName
            // 
            this.colComboName.DataPropertyName = "Name";
            this.colComboName.HeaderText = "Tên Combo";
            this.colComboName.Name = "colComboName";
            this.colComboName.Width = 150;
            // 
            // colDiscount
            // 
            this.colDiscount.DataPropertyName = "DiscountPercentage";
            this.colDiscount.HeaderText = "Giảm giá %";
            this.colDiscount.Name = "colDiscount";
            this.colDiscount.Width = 80;
            // 
            // colPrice
            // 
            this.colPrice.DataPropertyName = "Price";
            this.colPrice.HeaderText = "Giá";
            this.colPrice.Name = "colPrice";
            this.colPrice.Width = 100;
            // 
            // colProductCount
            // 
            this.colProductCount.DataPropertyName = "ChildCount";
            this.colProductCount.HeaderText = "Số SP";
            this.colProductCount.Name = "colProductCount";
            this.colProductCount.Width = 60;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnViewDetails);
            this.groupBox2.Controls.Add(this.lblSavings);
            this.groupBox2.Controls.Add(this.lblFinalPrice);
            this.groupBox2.Controls.Add(this.lblOriginalPrice);
            this.groupBox2.Controls.Add(this.numDiscount);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtComboName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtComboId);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(418, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 250);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin Combo";
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Location = new System.Drawing.Point(280, 210);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(100, 30);
            this.btnViewDetails.TabIndex = 11;
            this.btnViewDetails.Text = "Xem chi tiết";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // lblSavings
            // 
            this.lblSavings.AutoSize = true;
            this.lblSavings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSavings.ForeColor = System.Drawing.Color.Green;
            this.lblSavings.Location = new System.Drawing.Point(15, 220);
            this.lblSavings.Name = "lblSavings";
            this.lblSavings.Size = new System.Drawing.Size(85, 15);
            this.lblSavings.TabIndex = 10;
            this.lblSavings.Text = "Tiết kiệm: 0";
            // 
            // lblFinalPrice
            // 
            this.lblFinalPrice.AutoSize = true;
            this.lblFinalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFinalPrice.ForeColor = System.Drawing.Color.Red;
            this.lblFinalPrice.Location = new System.Drawing.Point(15, 200);
            this.lblFinalPrice.Name = "lblFinalPrice";
            this.lblFinalPrice.Size = new System.Drawing.Size(127, 15);
            this.lblFinalPrice.TabIndex = 9;
            this.lblFinalPrice.Text = "Giá sau giảm: 0 ₫";
            // 
            // lblOriginalPrice
            // 
            this.lblOriginalPrice.AutoSize = true;
            this.lblOriginalPrice.Location = new System.Drawing.Point(15, 180);
            this.lblOriginalPrice.Name = "lblOriginalPrice";
            this.lblOriginalPrice.Size = new System.Drawing.Size(66, 13);
            this.lblOriginalPrice.TabIndex = 8;
            this.lblOriginalPrice.Text = "Giá gốc: 0 ₫";
            // 
            // numDiscount
            // 
            this.numDiscount.DecimalPlaces = 2;
            this.numDiscount.Location = new System.Drawing.Point(100, 145);
            this.numDiscount.Name = "numDiscount";
            this.numDiscount.Size = new System.Drawing.Size(280, 20);
            this.numDiscount.TabIndex = 7;
            this.numDiscount.ValueChanged += new System.EventHandler(this.numDiscount_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Giảm giá (%):";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(100, 85);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(280, 50);
            this.txtDescription.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mô tả:";
            // 
            // txtComboName
            // 
            this.txtComboName.Location = new System.Drawing.Point(100, 55);
            this.txtComboName.Name = "txtComboName";
            this.txtComboName.Size = new System.Drawing.Size(280, 20);
            this.txtComboName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Combo:";
            // 
            // txtComboId
            // 
            this.txtComboId.Location = new System.Drawing.Point(100, 25);
            this.txtComboId.Name = "txtComboId";
            this.txtComboId.Size = new System.Drawing.Size(280, 20);
            this.txtComboId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Combo:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnRemoveFromCombo);
            this.groupBox3.Controls.Add(this.gridProductsInCombo);
            this.groupBox3.Location = new System.Drawing.Point(12, 268);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(400, 250);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sản phẩm trong Combo";
            // 
            // btnRemoveFromCombo
            // 
            this.btnRemoveFromCombo.Location = new System.Drawing.Point(280, 214);
            this.btnRemoveFromCombo.Name = "btnRemoveFromCombo";
            this.btnRemoveFromCombo.Size = new System.Drawing.Size(100, 30);
            this.btnRemoveFromCombo.TabIndex = 1;
            this.btnRemoveFromCombo.Text = "Xóa khỏi Combo";
            this.btnRemoveFromCombo.UseVisualStyleBackColor = true;
            this.btnRemoveFromCombo.Click += new System.EventHandler(this.btnRemoveFromCombo_Click);
            // 
            // gridProductsInCombo
            // 
            this.gridProductsInCombo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridProductsInCombo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductId,
            this.colProductName,
            this.colProductPrice,
            this.colProductQuantity});
            this.gridProductsInCombo.Location = new System.Drawing.Point(6, 19);
            this.gridProductsInCombo.Name = "gridProductsInCombo";
            this.gridProductsInCombo.Size = new System.Drawing.Size(388, 189);
            this.gridProductsInCombo.TabIndex = 0;
            // 
            // colProductId
            // 
            this.colProductId.DataPropertyName = "Id";
            this.colProductId.HeaderText = "Mã SP";
            this.colProductId.Name = "colProductId";
            this.colProductId.Width = 80;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "Name";
            this.colProductName.HeaderText = "Tên SP";
            this.colProductName.Name = "colProductName";
            this.colProductName.Width = 150;
            // 
            // colProductPrice
            // 
            this.colProductPrice.DataPropertyName = "Price";
            this.colProductPrice.HeaderText = "Giá";
            this.colProductPrice.Name = "colProductPrice";
            this.colProductPrice.Width = 80;
            // 
            // colProductQuantity
            // 
            this.colProductQuantity.DataPropertyName = "Quantity";
            this.colProductQuantity.HeaderText = "SL";
            this.colProductQuantity.Name = "colProductQuantity";
            this.colProductQuantity.Width = 50;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnAddToCombo);
            this.groupBox4.Controls.Add(this.gridAvailableProducts);
            this.groupBox4.Location = new System.Drawing.Point(418, 268);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(400, 250);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sản phẩm có sẵn";
            // 
            // btnAddToCombo
            // 
            this.btnAddToCombo.Location = new System.Drawing.Point(280, 214);
            this.btnAddToCombo.Name = "btnAddToCombo";
            this.btnAddToCombo.Size = new System.Drawing.Size(100, 30);
            this.btnAddToCombo.TabIndex = 1;
            this.btnAddToCombo.Text = "Thêm vào Combo";
            this.btnAddToCombo.UseVisualStyleBackColor = true;
            this.btnAddToCombo.Click += new System.EventHandler(this.btnAddToCombo_Click);
            // 
            // gridAvailableProducts
            // 
            this.gridAvailableProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAvailableProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAvailId,
            this.colAvailName,
            this.colAvailPrice,
            this.colAvailQty});
            this.gridAvailableProducts.Location = new System.Drawing.Point(6, 19);
            this.gridAvailableProducts.Name = "gridAvailableProducts";
            this.gridAvailableProducts.Size = new System.Drawing.Size(388, 189);
            this.gridAvailableProducts.TabIndex = 0;
            // 
            // colAvailId
            // 
            this.colAvailId.DataPropertyName = "Id";
            this.colAvailId.HeaderText = "Mã SP";
            this.colAvailId.Name = "colAvailId";
            this.colAvailId.Width = 80;
            // 
            // colAvailName
            // 
            this.colAvailName.DataPropertyName = "Name";
            this.colAvailName.HeaderText = "Tên SP";
            this.colAvailName.Name = "colAvailName";
            this.colAvailName.Width = 150;
            // 
            // colAvailPrice
            // 
            this.colAvailPrice.DataPropertyName = "Price";
            this.colAvailPrice.HeaderText = "Giá";
            this.colAvailPrice.Name = "colAvailPrice";
            this.colAvailPrice.Width = 80;
            // 
            // colAvailQty
            // 
            this.colAvailQty.DataPropertyName = "Quantity";
            this.colAvailQty.HeaderText = "SL";
            this.colAvailQty.Name = "colAvailQty";
            this.colAvailQty.Width = 50;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnDeleteCombo);
            this.panel1.Controls.Add(this.btnSaveCombo);
            this.panel1.Controls.Add(this.btnNewCombo);
            this.panel1.Location = new System.Drawing.Point(12, 524);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 50);
            this.panel1.TabIndex = 4;
            // 
            // btnDeleteCombo
            // 
            this.btnDeleteCombo.Location = new System.Drawing.Point(270, 10);
            this.btnDeleteCombo.Name = "btnDeleteCombo";
            this.btnDeleteCombo.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteCombo.TabIndex = 2;
            this.btnDeleteCombo.Text = "Xóa Combo";
            this.btnDeleteCombo.UseVisualStyleBackColor = true;
            this.btnDeleteCombo.Click += new System.EventHandler(this.btnDeleteCombo_Click);
            // 
            // btnSaveCombo
            // 
            this.btnSaveCombo.Location = new System.Drawing.Point(140, 10);
            this.btnSaveCombo.Name = "btnSaveCombo";
            this.btnSaveCombo.Size = new System.Drawing.Size(120, 35);
            this.btnSaveCombo.TabIndex = 1;
            this.btnSaveCombo.Text = "Lưu Combo";
            this.btnSaveCombo.UseVisualStyleBackColor = true;
            this.btnSaveCombo.Click += new System.EventHandler(this.btnSaveCombo_Click);
            // 
            // btnNewCombo
            // 
            this.btnNewCombo.Location = new System.Drawing.Point(10, 10);
            this.btnNewCombo.Name = "btnNewCombo";
            this.btnNewCombo.Size = new System.Drawing.Size(120, 35);
            this.btnNewCombo.TabIndex = 0;
            this.btnNewCombo.Text = "Tạo Combo Mới";
            this.btnNewCombo.UseVisualStyleBackColor = true;
            this.btnNewCombo.Click += new System.EventHandler(this.btnNewCombo_Click);
            // 
            // CompositeProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 586);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CompositeProductForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Combo Sản phẩm (Composite Pattern)";
            this.Load += new System.EventHandler(this.CompositeProductForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridComboList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProductsInCombo)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAvailableProducts)).EndInit();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAvailQty;
    }
}
