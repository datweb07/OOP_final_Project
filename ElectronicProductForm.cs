using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class ElectronicProductForm : Form
    {
        public ElectronicProductForm()
    {
        InitializeComponent();
        ApplyTheme();
    }

    private void ApplyTheme()
    {
        this.BackColor = Color.FromArgb(240, 240, 245);
        this.ForeColor = Color.FromArgb(40, 40, 50);
        this.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
    }

    #region Data and Members
    private ElectronicProductData productData = new ElectronicProductData();
    private List<ElectronicProduct> products = new List<ElectronicProduct>();
    private BindingSource _src = new BindingSource();
    #endregion

    #region Event Handlers
    private void ElectronicForm_Load(object sender, EventArgs e)
    {
        CreateSampleData();

        gridData.DataSource = _src;
        gridData.AllowUserToAddRows = false;
        gridData.ReadOnly = true;
        gridData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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

        products = productData.GetData();
        DisplayInGrid();

        // Đăng ký sự kiện
        btnSearch.Click += BtnSearch_Click;
        btnAddNew.Click += BtnAddNew_Click;
        txtSearch.TextChanged += (s, _) => BtnSearch_Click(null, null);
    }

    private void BtnSearch_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtSearch.Text))
        {
            var filteredProducts = products.Where(p =>
                p.Id.ToLower().Contains(txtSearch.Text.ToLower()) ||
                p.Name.ToLower().Contains(txtSearch.Text.ToLower()) ||
                p.WarrantyPeriod.ToLower().Contains(txtSearch.Text.ToLower())).ToList();

            _src.DataSource = filteredProducts;
            _src.ResetBindings(false);
            statusLabel.Text = $"Tìm thấy {filteredProducts.Count} kết quả";
        }
        else
        {
            DisplayInGrid();
            statusLabel.Text = "Sẵn sàng";
        }
    }

    private void BtnAddNew_Click(object sender, EventArgs e)
    {
        ClearInputs();
        txtId.Focus();
        statusLabel.Text = "Nhập thông tin sản phẩm mới";
    }

    private void btnRefresh_Click(object sender, EventArgs e)
    {
        ClearInputs();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        // --- Validation ---
        if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtName.Text) ||
            string.IsNullOrWhiteSpace(txtPrice.Text) || string.IsNullOrWhiteSpace(txtQuantity.Text) ||
            string.IsNullOrWhiteSpace(txtWarranty.Text))
        {
            MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
        {
            MessageBox.Show("Giá sản phẩm không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtPrice.Focus();
            return;
        }

        if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity < 0)
        {
            MessageBox.Show("Số lượng sản phẩm không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtQuantity.Focus();
            return;
        }

        // --- Logic ---
        ElectronicProduct product = products.FirstOrDefault(p => p.Id.Equals(txtId.Text, StringComparison.OrdinalIgnoreCase));

        if (product == null)
        {
            product = new ElectronicProduct(txtId.Text, txtName.Text,price, quantity, txtWarranty.Text);
            products.Add(product);
        }

        product.Id = txtId.Text;
        product.Name = txtName.Text;
        product.Price = price;
        product.Quantity = quantity;
        product.WarrantyPeriod = txtWarranty.Text;

        // --- Save and Refresh ---
        productData.SaveData(products);
        DisplayInGrid();
        MessageBox.Show("Lưu thông tin sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        statusLabel.Text = $"Đã lưu sản phẩm: {product.Name}";
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtId.Text))
        {
            MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var productToDelete = products.FirstOrDefault(p => p.Id.Equals(txtId.Text, StringComparison.OrdinalIgnoreCase));
        if (productToDelete != null)
        {
            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm '{productToDelete.Name}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                products.Remove(productToDelete);
                productData.SaveData(products);
                DisplayInGrid();
                ClearInputs();
                MessageBox.Show("Xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusLabel.Text = $"Đã xóa sản phẩm: {productToDelete.Name}";
            }
        }
        else
        {
            MessageBox.Show("Không tìm thấy sản phẩm để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
    {
        if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow) return;

        ElectronicProduct product = gridData.CurrentRow.DataBoundItem as ElectronicProduct;
        if (product != null)
        {
            Display(product);
        }
    }
    #endregion

    #region Helper Methods
    private void CreateSampleData()
    {
        string filePath = Path.Combine(GetPath.path, nameof(ElectronicProduct) + ".dat");
        if (!File.Exists(filePath))
        {
            List<ElectronicProduct> sampleProducts = new List<ElectronicProduct>
            {
                new ElectronicProduct("DT001", "iPhone 15 Pro Max", 32990000, 10, "12 tháng"),
                new ElectronicProduct("LT002", "MacBook Air M2", 28990000, 5, "12 tháng"),
                new ElectronicProduct("TK003", "Samsung Galaxy Watch 6", 7990000, 15, "12 tháng")
            };
            productData.SaveData(sampleProducts);
        }
    }

    private void DisplayInGrid()
    {
        _src.DataSource = null;
        _src.DataSource = products;
        _src.ResetBindings(false);
    }

    public void Display(ElectronicProduct product)
    {
        txtId.Text = product.Id;
        txtName.Text = product.Name;
        txtPrice.Text = product.Price.ToString("N0"); // Hiển thị định dạng số có dấu phẩy
        txtQuantity.Text = product.Quantity.ToString();
        txtWarranty.Text = product.WarrantyPeriod;
    }

    private void ClearInputs()
    {
        txtId.Text = "";
        txtName.Text = "";
        txtPrice.Text = "";
        txtQuantity.Text = "";
        txtWarranty.Text = "";
    }
    #endregion
    }
}
