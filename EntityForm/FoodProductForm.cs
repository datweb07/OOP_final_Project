using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class FoodProductForm : Form
    {
        public FoodProductForm()
        {
            InitializeComponent();
        }

        private FoodProductData foodProductData = new FoodProductData();
        private List<FoodProduct> foodProducts = new List<FoodProduct>();
        private List<FoodProduct> filteredProducts = new List<FoodProduct>();

        BindingSource _src = new BindingSource();

        private void FormFood_Load(object sender, EventArgs e)
        {
            FoodProductData.CreateSampleData();

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

            // Thiết lập mặc định
            cmbSort.SelectedIndex = 0;
            cmbExpiryFilter.SelectedIndex = 0;
            dtExpirationDate.Value = DateTime.Now.AddDays(30); // Mặc định 30 ngày

            foodProducts = foodProductData.GetData();
            filteredProducts = foodProducts.ToList();
            DisplayInGrid();
        }

        private void DisplayInGrid()
        {
            _src.DataSource = filteredProducts;
            _src.ResetBindings(true);
            UpdateStatistics();
            UpdateExpiryWarnings();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtPrice.Value = 0;
            txtQty.Value = 0;
            txtSearch.Text = "";
            dtExpirationDate.Value = DateTime.Now.AddDays(30);
            cmbSort.SelectedIndex = 0;
            cmbExpiryFilter.SelectedIndex = 0;
            chkLowStockOnly.Checked = false;

            filteredProducts = foodProducts.ToList();
            ApplyFiltersAndSearch();
            statusLabel.Text = "Đã làm mới danh sách";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            // Mặc định hết hạn vào cuối ngày
            DateTime expirationDateTime = dtExpirationDate.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            FoodProduct foodProduct = null;

            for (int i = 0; i < foodProducts.Count; i++)
            {
                if (foodProducts[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    foodProduct = foodProducts[i];
                    break;
                }
            }

            if (foodProduct == null)
            {
                foodProduct = new FoodProduct(txtCode.Text, txtName.Text, txtPrice.Value, txtQty.Value, expirationDateTime);
                foodProducts.Add(foodProduct);
            }
            else
            {
                foodProduct.Name = txtName.Text;
                foodProduct.Price = txtPrice.Value;
                foodProduct.Quantity = txtQty.Value;
                foodProduct.ExpirationDate = expirationDateTime;
            }

            ApplyFiltersAndSearch();
            foodProductData.SaveData(foodProducts);

            MessageBox.Show("Cập nhật thông tin thực phẩm thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            statusLabel.Text = "Đã lưu thông tin thành công";
            statusLabel.ForeColor = Color.FromArgb(46, 204, 113);
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã thực phẩm không được để trống !"
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

            if (dtExpirationDate.Value <= DateTime.Now)
            {
                DialogResult result = MessageBox.Show(
                    "Ngày hết hạn đã qua hoặc là ngày hiện tại. Bạn có chắc chắn muốn tiếp tục?",
                    "Cảnh báo ngày hết hạn",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    dtExpirationDate.Focus();
                    return false;
                }
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

            FoodProduct foodProduct = null;

            for (int i = 0; i < foodProducts.Count; i++)
            {
                if (foodProducts[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    foodProduct = foodProducts[i];
                    break;
                }
            }

            if (foodProduct != null)
            {
                foodProducts.Remove(foodProduct);
                ApplyFiltersAndSearch();
                foodProductData.SaveData(foodProducts);

                MessageBox.Show("Xoá thông tin thực phẩm thành công !"
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

            FoodProduct foodProduct = (FoodProduct)gridData.CurrentRow.DataBoundItem;

            if (foodProduct == null)
                return;

            Display(foodProduct);
        }

        public void Display(FoodProduct foodProduct)
        {
            txtCode.Text = foodProduct.Id;
            txtName.Text = foodProduct.Name;
            txtPrice.Value = foodProduct.Price;
            txtQty.Value = foodProduct.Quantity;

            // Kiểm tra trước khi gán
            if (foodProduct.ExpirationDate < dtExpirationDate.MinDate || foodProduct.ExpirationDate > dtExpirationDate.MaxDate)
                dtExpirationDate.Value = DateTime.Now.AddDays(30);
            else
                dtExpirationDate.Value = foodProduct.ExpirationDate;
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
            filteredProducts = foodProducts.ToList();

            // Áp dụng tìm kiếm
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                filteredProducts = filteredProducts.Where(p =>
                    p.Id.ToLower().Contains(txtSearch.Text.ToLower()) ||
                    p.Name.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            }

            // Áp dụng lọc tồn kho thấp
            if (chkLowStockOnly.Checked)
            {
                filteredProducts = filteredProducts.Where(p => p.Quantity <= 10).ToList();
            }

            // Áp dụng lọc hạn sử dụng
            ApplyExpiryFilter();

            // Áp dụng sắp xếp
            ApplySorting();

            DisplayInGrid();
            statusLabel.Text = $"Tìm thấy {filteredProducts.Count} sản phẩm";
        }

        /// <summary>
        /// Lọc theo hạn sử dụng
        /// </summary>
        private void ApplyExpiryFilter()
        {
            if (cmbExpiryFilter.SelectedIndex == -1) return;

            DateTime today = DateTime.Today;

            switch (cmbExpiryFilter.SelectedIndex)
            {
                case 0: // Tất cả
                    break;
                case 1: // Còn hạn (> 7 ngày)
                    filteredProducts = filteredProducts.Where(p => p.ExpirationDate > today.AddDays(7)).ToList();
                    break;
                case 2: // Sắp hết hạn (1-7 ngày)
                    filteredProducts = filteredProducts.Where(p =>
                        p.ExpirationDate > today && p.ExpirationDate <= today.AddDays(7)).ToList();
                    break;
                case 3: // Đã hết hạn
                    filteredProducts = filteredProducts.Where(p => p.ExpirationDate <= today).ToList();
                    break;
                case 4: // Hạn trong 30 ngày
                    filteredProducts = filteredProducts.Where(p =>
                        p.ExpirationDate > today && p.ExpirationDate <= today.AddDays(30)).ToList();
                    break;
            }
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
                case 8: // Hạn sử dụng (Gần nhất)
                    filteredProducts = filteredProducts.OrderBy(p => p.ExpirationDate).ToList();
                    break;
                case 9: // Hạn sử dụng (Xa nhất)
                    filteredProducts = filteredProducts.OrderByDescending(p => p.ExpirationDate).ToList();
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
            int expiredCount = filteredProducts.Count(p => p.ExpirationDate <= DateTime.Today);
            int expiringSoonCount = filteredProducts.Count(p =>
                p.ExpirationDate > DateTime.Today && p.ExpirationDate <= DateTime.Today.AddDays(7));

            lblTotalProductsValue.Text = totalProducts.ToString();
            lblTotalValueValue.Text = $"{totalValue:N0} đ";
            lblLowStockValue.Text = lowStockCount.ToString();
            lblExpiredValue.Text = expiredCount.ToString();
            lblExpiringSoonValue.Text = expiringSoonCount.ToString();

            // Đổi màu theo trạng thái
            lblTotalProductsValue.ForeColor = totalProducts > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalValueValue.ForeColor = totalValue > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblLowStockValue.ForeColor = lowStockCount > 0 ? Color.Red : Color.FromArgb(46, 204, 113);
            lblExpiredValue.ForeColor = expiredCount > 0 ? Color.Red : Color.FromArgb(46, 204, 113);
            lblExpiringSoonValue.ForeColor = expiringSoonCount > 0 ? Color.Orange : Color.FromArgb(46, 204, 113);
        }

        /// <summary>
        /// Cập nhật cảnh báo hạn sử dụng
        /// </summary>
        private void UpdateExpiryWarnings()
        {
            DateTime today = DateTime.Today;
            var expiredProducts = foodProducts.Where(p => p.ExpirationDate <= today).ToList();
            var expiringSoonProducts = foodProducts.Where(p =>
                p.ExpirationDate > today && p.ExpirationDate <= today.AddDays(7)).ToList();

            if (expiredProducts.Count > 0 || expiringSoonProducts.Count > 0)
            {
                string warningMessage = "";

                if (expiredProducts.Count > 0)
                {
                    warningMessage += $"- Có {expiredProducts.Count} sản phẩm đã hết hạn\n";
                }

                if (expiringSoonProducts.Count > 0)
                {
                    warningMessage += $"- Có {expiringSoonProducts.Count} sản phẩm sắp hết hạn (trong 7 ngày tới)\n";
                }

                lblExpiryWarning.Text = warningMessage.Trim();
                lblExpiryWarning.Visible = true;
            }
            else
            {
                lblExpiryWarning.Visible = false;
            }
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