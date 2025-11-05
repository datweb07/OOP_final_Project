using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class ClothingProductForm : Form
    {
        public ClothingProductForm()
        {
            InitializeComponent();
        }

        private ClothingProductData clothingProductData = new ClothingProductData();
        private List<ClothingProduct> clothingProducts = new List<ClothingProduct>();
        private List<ClothingProduct> filteredProducts = new List<ClothingProduct>();

        BindingSource _src = new BindingSource();

        private void ClothingProductForm_Load(object sender, EventArgs e)
        {
            ClothingProductData.CreateSampleData();

            gridData.DataSource = _src;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;

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

            // Cấu hình để gridData rộng hết cỡ
            gridData.Dock = DockStyle.Fill;
            gridData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Khởi tạo danh sách size
            InitializeSizes();

            // Thiết lập mặc định
            cmbSort.SelectedIndex = 0;
            cmbSizeFilter.SelectedIndex = 0;

            clothingProducts = clothingProductData.GetData();
            filteredProducts = clothingProducts.ToList();
            DisplayInGrid();
        }

        private void InitializeSizes()
        {
            string[] sizes = new string[] {
                "XS", "S", "M", "L", "XL", "XXL", "XXXL"
            };

            // ComboBox size cho sản phẩm mới
            cboSize.Items.Clear();
            cboSize.Items.AddRange(sizes);
            cboSize.SelectedIndex = 0;

            // ComboBox lọc size
            cmbSizeFilter.Items.Clear();
            cmbSizeFilter.Items.Add("Tất cả size");
            cmbSizeFilter.Items.AddRange(sizes);
            cmbSizeFilter.SelectedIndex = 0;
        }

        private void DisplayInGrid()
        {
            _src.DataSource = filteredProducts;
            _src.ResetBindings(true);
            UpdateStatistics();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtPrice.Value = 0;
            txtQty.Value = 0;
            txtSearch.Text = "";
            cboSize.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            cmbSizeFilter.SelectedIndex = 0;
            chkLowStockOnly.Checked = false;

            filteredProducts = clothingProducts.ToList();
            ApplyFiltersAndSearch();
            statusLabel.Text = "Đã làm mới danh sách";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            ClothingProduct clothingProduct = null;
            bool isNewProduct = false;

            for (int i = 0; i < clothingProducts.Count; i++)
            {
                if (clothingProducts[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    clothingProduct = clothingProducts[i];
                    break;
                }
            }

            if (clothingProduct == null)
            {
                clothingProduct = new ClothingProduct(
                    txtCode.Text,
                    txtName.Text,
                    txtPrice.Value,
                    txtQty.Value,
                    (string)cboSize.SelectedItem);
                clothingProducts.Add(clothingProduct);
                isNewProduct = true;
            }
            else
            {
                clothingProduct.Name = txtName.Text;
                clothingProduct.Price = txtPrice.Value;
                clothingProduct.Quantity = txtQty.Value;
                clothingProduct.Size = (string)cboSize.SelectedItem;
            }

            // Lưu dữ liệu
            clothingProductData.SaveData(clothingProducts);

            // Nếu là sản phẩm mới, hiển thị toàn bộ danh sách không sắp xếp
            if (isNewProduct)
            {
                // Reset về trạng thái mặc định để sản phẩm mới xuất hiện ở cuối
                cmbSort.SelectedIndex = -1;
                filteredProducts = clothingProducts.ToList();
                DisplayInGrid();
                cmbSort.SelectedIndex = 0; // Reset lại sắp xếp mặc định
            }
            else
            {
                // Nếu là cập nhật, áp dụng bộ lọc hiện tại
                ApplyFiltersAndSearch();
            }

            MessageBox.Show("Cập nhật thông tin quần áo thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            statusLabel.Text = "Đã lưu thông tin thành công";
            statusLabel.ForeColor = Color.FromArgb(46, 204, 113);
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã quần áo không được để trống !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống !",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }

            if (txtPrice.Value < 0)
            {
                MessageBox.Show("Giá sản phẩm không được bé hơn 0 !",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                return false;
            }

            if (txtQty.Value < 0)
            {
                MessageBox.Show("Số lượng sản phẩm không được bé hơn 0 !",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQty.Focus();
                return false;
            }

            if (cboSize.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn size !"
                   , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboSize.Focus();
                return false;
            }

            return true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sản phẩm '{txtName.Text}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            ClothingProduct clothingProduct = null;

            for (int i = 0; i < clothingProducts.Count; i++)
            {
                if (clothingProducts[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    clothingProduct = clothingProducts[i];
                    break;
                }
            }

            if (clothingProduct != null)
            {
                clothingProducts.Remove(clothingProduct);
                ApplyFiltersAndSearch();
                clothingProductData.SaveData(clothingProducts);

                MessageBox.Show("Xoá thông tin quần áo thành công !"
                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnRefresh_Click(null, null);
                statusLabel.Text = "Đã xóa sản phẩm thành công";
                statusLabel.ForeColor = Color.FromArgb(46, 204, 113);
            }
        }

        private void gridData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            ClothingProduct clothingProduct = (ClothingProduct)gridData.CurrentRow.DataBoundItem;

            if (clothingProduct == null)
                return;

            Display(clothingProduct);
        }

        public void Display(ClothingProduct clothingProduct)
        {
            txtCode.Text = clothingProduct.Id;
            txtName.Text = clothingProduct.Name;
            txtPrice.Value = clothingProduct.Price;
            txtQty.Value = clothingProduct.Quantity;
            cboSize.SelectedItem = clothingProduct.Size;
        }

        #region Các chức năng mới

        /// <summary>
        /// Tìm kiếm sản phẩm
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        /// <summary>
        /// Thêm mới sản phẩm
        /// </summary>
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
            txtCode.Focus();
            statusLabel.Text = "Nhập thông tin sản phẩm mới";
        }

        /// <summary>
        /// Áp dụng tất cả bộ lọc và tìm kiếm
        /// </summary>
        private void ApplyFiltersAndSearch()
        {
            // Bắt đầu từ danh sách đầy đủ
            filteredProducts = clothingProducts.ToList();

            // Áp dụng tìm kiếm
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                filteredProducts = filteredProducts.Where(p =>
                    p.Id.ToLower().Contains(txtSearch.Text.ToLower()) ||
                    p.Name.ToLower().Contains(txtSearch.Text.ToLower()) ||
                    p.Size.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            }

            // Áp dụng lọc size
            if (cmbSizeFilter.SelectedIndex > 0)
            {
                string selectedSize = cmbSizeFilter.SelectedItem.ToString();
                filteredProducts = filteredProducts.Where(p => p.Size == selectedSize).ToList();
            }

            // Áp dụng lọc tồn kho thấp
            if (chkLowStockOnly.Checked)
            {
                filteredProducts = filteredProducts.Where(p => p.Quantity <= 10).ToList();
            }

            // Áp dụng sắp xếp
            ApplySorting();

            DisplayInGrid();
            statusLabel.Text = $"Tìm thấy {filteredProducts.Count} sản phẩm";
        }

        /// <summary>
        /// Áp dụng sắp xếp
        /// </summary>
        private void ApplySorting()
        {
            if (cmbSort.SelectedIndex == -1) return;

            switch (cmbSort.SelectedIndex)
            {
                case 0: // Mã SP (A-Z)
                    filteredProducts = filteredProducts.OrderBy(p => p.Id).ToList();
                    break;
                case 1: // Mã SP (Z-A)
                    filteredProducts = filteredProducts.OrderByDescending(p => p.Id).ToList();
                    break;
                case 2: // Tên SP (A-Z)
                    filteredProducts = filteredProducts.OrderBy(p => p.Name).ToList();
                    break;
                case 3: // Tên SP (Z-A)
                    filteredProducts = filteredProducts.OrderByDescending(p => p.Name).ToList();
                    break;
                case 4: // Giá (Thấp-Cao)
                    filteredProducts = filteredProducts.OrderBy(p => p.Price).ToList();
                    break;
                case 5: // Giá (Cao-Thấp)
                    filteredProducts = filteredProducts.OrderByDescending(p => p.Price).ToList();
                    break;
                case 6: // Số lượng (Thấp-Cao)
                    filteredProducts = filteredProducts.OrderBy(p => p.Quantity).ToList();
                    break;
                case 7: // Số lượng (Cao-Thấp)
                    filteredProducts = filteredProducts.OrderByDescending(p => p.Quantity).ToList();
                    break;
                case 8: // Size (A-Z)
                    filteredProducts = filteredProducts.OrderBy(p => p.Size).ToList();
                    break;
                case 9: // Size (Z-A)
                    filteredProducts = filteredProducts.OrderByDescending(p => p.Size).ToList();
                    break;
            }
        }

        /// <summary>
        /// Cập nhật thống kê
        /// </summary>
        private void UpdateStatistics()
        {
            int totalProducts = filteredProducts.Count;
            decimal totalValue = filteredProducts.Sum(p => p.Price * p.Quantity);
            int lowStockCount = filteredProducts.Count(p => p.Quantity <= 10);
            int sizeCount = filteredProducts.Select(p => p.Size).Distinct().Count();

            lblTotalProductsValue.Text = totalProducts.ToString();
            lblTotalValueValue.Text = $"{totalValue:N0} đ";
            lblLowStockValue.Text = lowStockCount.ToString();
            lblSizeCountValue.Text = sizeCount.ToString();

            // Đổi màu theo số lượng
            lblTotalProductsValue.ForeColor = totalProducts > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalValueValue.ForeColor = totalValue > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblLowStockValue.ForeColor = lowStockCount > 0 ? Color.Red : Color.FromArgb(46, 204, 113);
            lblSizeCountValue.ForeColor = sizeCount > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
        }

        /// <summary>
        /// Sự kiện khi thay đổi lựa chọn lọc
        /// </summary>
        private void FilterChanged(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        #endregion
    }
}