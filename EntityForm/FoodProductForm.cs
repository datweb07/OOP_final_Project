using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        private bool isFresh = false;

        BindingSource _src = new BindingSource();

        private void FormFood_Load(object sender, EventArgs e)
        {
            FoodProductData.CreateSampleData();

            gridData.DataSource = _src;
            gridData.AllowUserToAddRows = false;
            gridData.ReadOnly = true;

            // tùy chỉnh giao diện DataGridView
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

            gridData.Dock = DockStyle.Fill;
            gridData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            cmbSort.SelectedIndex = 0;
            cmbExpiryFilter.SelectedIndex = 0;
            dtExpirationDate.Value = DateTime.Now.AddDays(30);

            foodProducts = foodProductData.GetData();
            filteredProducts = new List<FoodProduct>(foodProducts);
            DisplayInGrid();
        }

        private void DisplayInGrid()
        {
            _src.DataSource = filteredProducts;
            _src.ResetBindings(true);
            UpdateStatistics();
            UpdateExpiryWarnings();
            statusLabel.Text = "Tìm thấy " + filteredProducts.Count + " sản phẩm";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            isFresh = true;

            txtCode.Text = "";
            txtName.Text = "";
            txtPrice.Value = 0;
            txtQty.Value = 0;
            txtSearch.Text = "";
            dtExpirationDate.Value = DateTime.Now.AddDays(30);
            cmbSort.SelectedIndex = 0;
            cmbExpiryFilter.SelectedIndex = 0;
            chkLowStockOnly.Checked = false;

            filteredProducts = new List<FoodProduct>(foodProducts);
            ApplyFiltersAndSearch();
            statusLabel.Text = "Đã làm mới danh sách";
            isFresh = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            // hết hạn vào cuối ngày
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
                "Bạn có chắc chắn muốn xóa sản phẩm '" + txtName.Text + "'?",
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
            if (isFresh) return;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
            txtCode.Focus();
            statusLabel.Text = "Nhập thông tin sản phẩm mới";
        }

        // lọc và tìm kiếm
        private void ApplyFiltersAndSearch()
        {
            // gắn từ danh sách ban đầu
            filteredProducts = new List<FoodProduct>(foodProducts);

            // tìm kiếm
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                List<FoodProduct> searchResults = new List<FoodProduct>();
                string searchText = txtSearch.Text.ToLower();

                for (int i = 0; i < filteredProducts.Count; i++)
                {
                    FoodProduct product = filteredProducts[i];
                    if (product.Id.ToLower().Contains(searchText) || product.Name.ToLower().Contains(searchText))
                    {
                        searchResults.Add(product);
                    }
                }
                filteredProducts = searchResults;
            }

            // lọc tồn kho thấp
            if (chkLowStockOnly.Checked)
            {
                List<FoodProduct> lowStockResults = new List<FoodProduct>();

                for (int i = 0; i < filteredProducts.Count; i++)
                {
                    if (filteredProducts[i].Quantity <= 10)
                    {
                        lowStockResults.Add(filteredProducts[i]);
                    }
                }
                filteredProducts = lowStockResults;
            }

            // lọc hạn sử dụng
            ApplyExpiryFilter();

            // sắp xếp
            ApplySorting();

            DisplayInGrid();
            statusLabel.Text = "Tìm thấy " + filteredProducts.Count + " kết quả";
        }

        private void ApplyExpiryFilter()
        {
            if (cmbExpiryFilter.SelectedIndex == -1) return;

            DateTime today = DateTime.Today;

            switch (cmbExpiryFilter.SelectedIndex)
            {
                case 0: // Tất cả
                    break;
                case 1: // Còn hạn (> 7 ngày)
                    List<FoodProduct> validResults = new List<FoodProduct>();
                    for (int i = 0; i < filteredProducts.Count; i++)
                    {
                        if (filteredProducts[i].ExpirationDate > today.AddDays(7))
                        {
                            validResults.Add(filteredProducts[i]);
                        }
                    }
                    filteredProducts = validResults;
                    break;
                case 2: // Sắp hết hạn (1-7 ngày)
                    List<FoodProduct> expiringResults = new List<FoodProduct>();
                    for (int i = 0; i < filteredProducts.Count; i++)
                    {
                        FoodProduct product = filteredProducts[i];
                        if (product.ExpirationDate > today && product.ExpirationDate <= today.AddDays(7))
                        {
                            expiringResults.Add(product);
                        }
                    }
                    filteredProducts = expiringResults;
                    break;
                case 3: // Đã hết hạn
                    List<FoodProduct> expiredResults = new List<FoodProduct>();
                    for (int i = 0; i < filteredProducts.Count; i++)
                    {
                        if (filteredProducts[i].ExpirationDate <= today)
                        {
                            expiredResults.Add(filteredProducts[i]);
                        }
                    }
                    filteredProducts = expiredResults;
                    break;
                case 4: // Hạn trong 30 ngày
                    List<FoodProduct> monthResults = new List<FoodProduct>();
                    for (int i = 0; i < filteredProducts.Count; i++)
                    {
                        FoodProduct product = filteredProducts[i];
                        if (product.ExpirationDate > today && product.ExpirationDate <= today.AddDays(30))
                        {
                            monthResults.Add(product);
                        }
                    }
                    filteredProducts = monthResults;
                    break;
            }
        }

        private void ApplySorting()
        {
            if (cmbSort.SelectedIndex == -1) return;

            switch (cmbSort.SelectedIndex)
            {
                case 0: // Mã SP (A-Z)
                    filteredProducts.Sort((p1, p2) => p1.Id.CompareTo(p2.Id));
                    break;
                case 1: // Mã SP (Z-A)
                    filteredProducts.Sort((p1, p2) => p2.Id.CompareTo(p1.Id));
                    break;
                case 2: // Tên SP (A-Z)
                    filteredProducts.Sort((p1, p2) => p1.Name.CompareTo(p2.Name));
                    break;
                case 3: // Tên SP (Z-A)
                    filteredProducts.Sort((p1, p2) => p2.Name.CompareTo(p1.Name));
                    break;
                case 4: // Giá (Thấp-Cao)
                    filteredProducts.Sort((p1, p2) => p1.Price.CompareTo(p2.Price));
                    break;
                case 5: // Giá (Cao-Thấp)
                    filteredProducts.Sort((p1, p2) => p2.Price.CompareTo(p1.Price));
                    break;
                case 6: // Số lượng (Thấp-Cao)
                    filteredProducts.Sort((p1, p2) => p1.Quantity.CompareTo(p2.Quantity));
                    break;
                case 7: // Số lượng (Cao-Thấp)
                    filteredProducts.Sort((p1, p2) => p2.Quantity.CompareTo(p1.Quantity));
                    break;
                case 8: // Hạn sử dụng (Gần nhất)
                    filteredProducts.Sort((p1, p2) => p1.ExpirationDate.CompareTo(p2.ExpirationDate));
                    break;
                case 9: // Hạn sử dụng (Xa nhất)
                    filteredProducts.Sort((p1, p2) => p2.ExpirationDate.CompareTo(p1.ExpirationDate));
                    break;
            }
        }

        // thống kê
        private void UpdateStatistics()
        {
            int totalProducts = filteredProducts.Count;

            decimal totalValue = 0;
            for (int i = 0; i < filteredProducts.Count; i++)
            {
                totalValue += filteredProducts[i].Price * filteredProducts[i].Quantity;
            }

            int lowStockCount = 0;
            for (int i = 0; i < filteredProducts.Count; i++)
            {
                if (filteredProducts[i].Quantity <= 10)
                {
                    lowStockCount++;
                }
            }

            int expiredCount = 0;
            for (int i = 0; i < filteredProducts.Count; i++)
            {
                if (filteredProducts[i].ExpirationDate <= DateTime.Today)
                {
                    expiredCount++;
                }
            }

            int expiringSoonCount = 0;
            for (int i = 0; i < filteredProducts.Count; i++)
            {
                FoodProduct product = filteredProducts[i];
                if (product.ExpirationDate > DateTime.Today && product.ExpirationDate <= DateTime.Today.AddDays(7))
                {
                    expiringSoonCount++;
                }
            }

            lblTotalProductsValue.Text = totalProducts.ToString();
            lblTotalValueValue.Text = totalValue.ToString("N0") + " đ";
            lblLowStockValue.Text = lowStockCount.ToString();
            lblExpiredValue.Text = expiredCount.ToString();
            lblExpiringSoonValue.Text = expiringSoonCount.ToString();

            // màu theo trạng thái
            lblTotalProductsValue.ForeColor = totalProducts > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalValueValue.ForeColor = totalValue > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblLowStockValue.ForeColor = lowStockCount > 0 ? Color.Red : Color.FromArgb(46, 204, 113);
            lblExpiredValue.ForeColor = expiredCount > 0 ? Color.Red : Color.FromArgb(46, 204, 113);
            lblExpiringSoonValue.ForeColor = expiringSoonCount > 0 ? Color.Orange : Color.FromArgb(46, 204, 113);
        }

        // cảnh báo hạn sử dụng
        private void UpdateExpiryWarnings()
        {
            DateTime today = DateTime.Today;

            List<FoodProduct> expiredProducts = new List<FoodProduct>();
            for (int i = 0; i < foodProducts.Count; i++)
            {
                if (foodProducts[i].ExpirationDate <= today)
                {
                    expiredProducts.Add(foodProducts[i]);
                }
            }

            List<FoodProduct> expiringSoonProducts = new List<FoodProduct>();
            for (int i = 0; i < foodProducts.Count; i++)
            {
                FoodProduct product = foodProducts[i];
                if (product.ExpirationDate > today && product.ExpirationDate <= today.AddDays(7))
                {
                    expiringSoonProducts.Add(product);
                }
            }

            if (expiredProducts.Count > 0 || expiringSoonProducts.Count > 0)
            {
                string warningMessage = "";

                if (expiredProducts.Count > 0)
                {
                    warningMessage += "- Có " + expiredProducts.Count + " sản phẩm đã hết hạn\n";
                }

                if (expiringSoonProducts.Count > 0)
                {
                    warningMessage += "- Có " + expiringSoonProducts.Count + " sản phẩm sắp hết hạn (trong 7 ngày tới)\n";
                }

                lblExpiryWarning.Text = warningMessage.Trim();
                lblExpiryWarning.Visible = true;
            }
            else
            {
                lblExpiryWarning.Visible = false;
            }
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }
    }
}