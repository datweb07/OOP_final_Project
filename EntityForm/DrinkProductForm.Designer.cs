using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject
{
    partial class DrinkProductForm
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
            txtSearch = new TextBox();
            btnSearch = new Button();
            statusLabel = new Label();
            btnAddNew = new Button();
            groupBoxFilter = new GroupBox();
            rdoAll = new RadioButton();
            rdoWithGas = new RadioButton();
            rdoWithoutGas = new RadioButton();
            groupBoxSort = new GroupBox();
            cmbSort = new ComboBox();
            lblTotalProducts = new Label();
            lblTotalValue = new Label();
            lblTotalProductsValue = new Label();
            lblTotalValueValue = new Label();

            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridData).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtQty).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPrice).BeginInit();
            groupBoxFilter.SuspendLayout();
            groupBoxSort.SuspendLayout();
            SuspendLayout();

            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1200, 500);
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
            // lblProductCode
            // 
            lblProductCode.AutoSize = true;
            lblProductCode.Location = new Point(31, 87);
            lblProductCode.Name = "lblProductCode";
            lblProductCode.Size = new Size(50, 20);
            lblProductCode.TabIndex = 0;
            lblProductCode.Text = "Mã SP";

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
            label2.Size = new Size(52, 20);
            label2.TabIndex = 0;
            label2.Text = "Tên SP";

            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(31, 130);
            label5.Name = "label5";
            label5.Size = new Size(31, 20);
            label5.TabIndex = 0;
            label5.Text = "Giá";

            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(113, 125);
            txtPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(261, 27);
            txtPrice.TabIndex = 5;

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(475, 130);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 0;
            label1.Text = "Số Lượng";

            // 
            // txtQty
            // 
            txtQty.Location = new Point(557, 125);
            txtQty.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(333, 27);
            txtQty.TabIndex = 5;

            // 
            // chkIsAlcoholic
            // 
            chkIsAlcoholic.AutoSize = true;
            chkIsAlcoholic.Location = new Point(113, 170);
            chkIsAlcoholic.Name = "chkIsAlcoholic";
            chkIsAlcoholic.Size = new Size(113, 24);
            chkIsAlcoholic.TabIndex = 6;
            chkIsAlcoholic.Text = "Có gas";
            chkIsAlcoholic.UseVisualStyleBackColor = true;

            // 
            // groupBoxFilter
            // 
            groupBoxFilter.Controls.Add(rdoWithoutGas);
            groupBoxFilter.Controls.Add(rdoWithGas);
            groupBoxFilter.Controls.Add(rdoAll);
            groupBoxFilter.Location = new Point(31, 210);
            groupBoxFilter.Name = "groupBoxFilter";
            groupBoxFilter.Size = new Size(300, 80);
            groupBoxFilter.TabIndex = 7;
            groupBoxFilter.TabStop = false;
            groupBoxFilter.Text = "Lọc theo gas";

            // 
            // rdoAll
            // 
            rdoAll.AutoSize = true;
            rdoAll.Checked = true;
            rdoAll.Location = new Point(20, 30);
            rdoAll.Name = "rdoAll";
            rdoAll.Size = new Size(73, 24);
            rdoAll.TabIndex = 0;
            rdoAll.TabStop = true;
            rdoAll.Text = "Tất cả";
            rdoAll.UseVisualStyleBackColor = true;
            rdoAll.CheckedChanged += FilterProducts;

            // 
            // rdoWithGas
            // 
            rdoWithGas.AutoSize = true;
            rdoWithGas.Location = new Point(110, 30);
            rdoWithGas.Name = "rdoWithGas";
            rdoWithGas.Size = new Size(73, 24);
            rdoWithGas.TabIndex = 0;
            rdoWithGas.Text = "Có gas";
            rdoWithGas.UseVisualStyleBackColor = true;
            rdoWithGas.CheckedChanged += FilterProducts;

            // 
            // rdoWithoutGas
            // 
            rdoWithoutGas.AutoSize = true;
            rdoWithoutGas.Location = new Point(200, 30);
            rdoWithoutGas.Name = "rdoWithoutGas";
            rdoWithoutGas.Size = new Size(85, 24);
            rdoWithoutGas.TabIndex = 0;
            rdoWithoutGas.Text = "Không gas";
            rdoWithoutGas.UseVisualStyleBackColor = true;
            rdoWithoutGas.CheckedChanged += FilterProducts;

            // 
            // groupBoxSort
            // 
            groupBoxSort.Controls.Add(cmbSort);
            groupBoxSort.Location = new Point(500, 210);
            groupBoxSort.Name = "groupBoxSort";
            groupBoxSort.Size = new Size(250, 80);
            groupBoxSort.TabIndex = 8;
            groupBoxSort.TabStop = false;
            groupBoxSort.Text = "Sắp xếp";

            // 
            // cmbSort
            // 
            cmbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSort.FormattingEnabled = true;
            cmbSort.Items.AddRange(new object[] {
            "Mã SP (A-Z)",
            "Mã SP (Z-A)",
            "Tên SP (A-Z)",
            "Tên SP (Z-A)",
            "Giá (Thấp-Cao)",
            "Giá (Cao-Thấp)",
            "Số lượng (Thấp-Cao)",
            "Số lượng (Cao-Thấp)"});
            cmbSort.Location = new Point(20, 30);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(200, 28);
            cmbSort.TabIndex = 0;
            cmbSort.SelectedIndexChanged += SortProducts;

            // 
            // lblTotalProducts
            // 
            lblTotalProducts.AutoSize = true;
            lblTotalProducts.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalProducts.Location = new Point(900, 230);
            lblTotalProducts.Name = "lblTotalProducts";
            lblTotalProducts.Size = new Size(120, 20);
            lblTotalProducts.TabIndex = 9;
            lblTotalProducts.Text = "Tổng sản phẩm:";

            // 
            // lblTotalProductsValue
            // 
            lblTotalProductsValue.AutoSize = true;
            lblTotalProductsValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalProductsValue.ForeColor = Color.FromArgb(46, 204, 113);
            lblTotalProductsValue.Location = new Point(1050, 230);
            lblTotalProductsValue.Name = "lblTotalProductsValue";
            lblTotalProductsValue.Size = new Size(17, 20);
            lblTotalProductsValue.TabIndex = 9;
            lblTotalProductsValue.Text = "0";

            // 
            // lblTotalValue
            // 
            lblTotalValue.AutoSize = true;
            lblTotalValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalValue.Location = new Point(900, 260);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(120, 20);
            lblTotalValue.TabIndex = 9;
            lblTotalValue.Text = "Tổng giá trị:";

            // 
            // lblTotalValueValue
            // 
            lblTotalValueValue.AutoSize = true;
            lblTotalValueValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTotalValueValue.ForeColor = Color.FromArgb(46, 204, 113);
            lblTotalValueValue.Location = new Point(1050, 260);
            lblTotalValueValue.Name = "lblTotalValueValue";
            lblTotalValueValue.Size = new Size(44, 20);
            lblTotalValueValue.TabIndex = 9;
            lblTotalValueValue.Text = "0 đ";

            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(768, 310);
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
            btnSave.Location = new Point(884, 310);
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
            btnDelete.Location = new Point(1000, 310);
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


            groupBox1.Controls.Add(txtSearch);
            groupBox1.Controls.Add(lblSearch);
            groupBox1.Controls.Add(btnSearch);
            groupBox1.Controls.Add(btnAddNew);
            groupBox1.Controls.Add(statusLabel);
            groupBox1.Controls.Add(lblTotalValueValue);
            groupBox1.Controls.Add(lblTotalProductsValue);
            groupBox1.Controls.Add(lblTotalValue);
            groupBox1.Controls.Add(lblTotalProducts);
            groupBox1.Controls.Add(groupBoxSort);
            groupBox1.Controls.Add(groupBoxFilter);
            groupBox1.Controls.Add(btnDelete);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(btnRefresh);
            groupBox1.Controls.Add(chkIsAlcoholic);
            groupBox1.Controls.Add(txtQty);
            groupBox1.Controls.Add(txtPrice);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(txtName);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtCode);
            groupBox1.Controls.Add(lblProductCode);

            // 
            // gridData
            // 
            gridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridData.Dock = DockStyle.Fill;
            gridData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gridData.Location = new Point(3, 23);
            gridData.Name = "gridData";
            gridData.RowHeadersWidth = 51;
            gridData.Size = new Size(1194, 274);
            gridData.TabIndex = 1;
            gridData.CellEnter += gridData_CellEnter;
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
            groupBox2.Location = new Point(12, 400);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(1200, 300);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh sách đồ uống";

            // 
            // DrinkProductForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1224, 720);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "DrinkProductForm";
            Text = "QUẢN LÝ ĐỒ UỐNG";
            Load += FormBeverage_Load;

            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridData).EndInit();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)txtQty).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPrice).EndInit();
            groupBoxFilter.ResumeLayout(false);
            groupBoxFilter.PerformLayout();
            groupBoxSort.ResumeLayout(false);
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
        private TextBox txtSearch;
        private Button btnSearch;
        private Label statusLabel;
        private Button btnAddNew;
        private Label lblSearch;
        private GroupBox groupBoxFilter;
        private RadioButton rdoWithoutGas;
        private RadioButton rdoWithGas;
        private RadioButton rdoAll;
        private GroupBox groupBoxSort;
        private ComboBox cmbSort;
        private Label lblTotalProducts;
        private Label lblTotalValue;
        private Label lblTotalProductsValue;
        private Label lblTotalValueValue;
    }
}