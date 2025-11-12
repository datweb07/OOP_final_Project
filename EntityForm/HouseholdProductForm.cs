using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class HouseholdProductForm : Form
    {
        public HouseholdProductForm()
        {
            InitializeComponent();
        }

        private HouseholdProductData householdProductData = new HouseholdProductData();
        private List<HouseholdProduct> householdProducts = new List<HouseholdProduct>();
        private List<HouseholdProduct> filteredProducts = new List<HouseholdProduct>();
        private bool isFresh;

        BindingSource _src = new BindingSource();

        private void FormHouseHoldItem_Load(object sender, EventArgs e)
        {
            HouseholdProductData.CreateSampleData();

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

            // khởi tạo danh sách các thương hiệu
            InitializeBrands();

            cmbSort.SelectedIndex = 0;
            cmbBrandFilter.SelectedIndex = 0;

            householdProducts = householdProductData.GetData();
            filteredProducts = new List<HouseholdProduct>(householdProducts);
            DisplayInGrid();
        }

        private void InitializeBrands()
        {
            string[] brands = new string[] {
                "Sony", "Samsung", "Apple", "Nature Hike", "IKIA",
                "LG", "Toshiba", "Panasonic", "Philips", "Electrolux",
                "Midea", "Aqua", "Sunhouse", "Kangaroo", "Lock&Lock"
            };

            // thêm thương hiệu vào comboBox
            cboBrand.Items.Clear();
            cboBrand.Items.AddRange(brands);
            cboBrand.SelectedIndex = 0;

            // lọc theo theo thương hiệu
            cmbBrandFilter.Items.Clear();
            cmbBrandFilter.Items.Add("Tất cả thương hiệu");
            cmbBrandFilter.Items.AddRange(brands);
            cmbBrandFilter.SelectedIndex = 0;
        }

        private void DisplayInGrid()
        {
            _src.DataSource = filteredProducts;
            _src.ResetBindings(true);
            UpdateStatistics();
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
            cboBrand.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            cmbBrandFilter.SelectedIndex = 0;
            chkLowStockOnly.Checked = false;

            filteredProducts = new List<HouseholdProduct>(householdProducts);
            ApplyFiltersAndSearch();
            statusLabel.Text = "Đã làm mới danh sách";
            isFresh = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            HouseholdProduct householdProduct = null;

            for (int i = 0; i < householdProducts.Count; i++)
            {
                if (householdProducts[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    householdProduct = householdProducts[i];
                    break;
                }
            }

            if (householdProduct == null)
            {
                householdProduct = new HouseholdProduct(
                    txtCode.Text,
                    txtName.Text,
                    txtPrice.Value,
                    txtQty.Value,
                    (string)cboBrand.SelectedItem);
                householdProducts.Add(householdProduct);
            }
            else
            {
                householdProduct.Name = txtName.Text;
                householdProduct.Price = txtPrice.Value;
                householdProduct.Quantity = txtQty.Value;
                householdProduct.Brand = (string)cboBrand.SelectedItem;
            }

            ApplyFiltersAndSearch();
            householdProductData.SaveData(householdProducts);

            MessageBox.Show("Cập nhật thông tin đồ gia dụng thành công !"
                , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            statusLabel.Text = "Đã lưu thông tin thành công";
            statusLabel.ForeColor = Color.FromArgb(46, 204, 113);
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã đồ gia dụng không được để trống !"
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

            if (cboBrand.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn thương hiệu !"
                   , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboBrand.Focus();
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
                "Bạn có chắc chắn muốn xóa sản phẩm '" + txtName.Text + "'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            HouseholdProduct householdProduct = null;

            for (int i = 0; i < householdProducts.Count; i++)
            {
                if (householdProducts[i].Id.ToLower() == txtCode.Text.ToLower())
                {
                    householdProduct = householdProducts[i];
                    break;
                }
            }

            if (householdProduct != null)
            {
                householdProducts.Remove(householdProduct);
                ApplyFiltersAndSearch();
                householdProductData.SaveData(householdProducts);

                MessageBox.Show("Xoá thông tin đồ gia dụng thành công !"
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

            HouseholdProduct householdProduct = (HouseholdProduct)gridData.CurrentRow.DataBoundItem;

            if (householdProduct == null)
                return;

            Display(householdProduct);
        }

        public void Display(HouseholdProduct householdProduct)
        {
            txtCode.Text = householdProduct.Id;
            txtName.Text = householdProduct.Name;
            txtPrice.Value = householdProduct.Price;
            txtQty.Value = householdProduct.Quantity;
            cboBrand.SelectedItem = householdProduct.Brand;
        }

        // tìm kiếm sản phẩm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        // thêm mới
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
            txtCode.Focus();
            statusLabel.Text = "Nhập thông tin sản phẩm mới";
        }

        // lọc và tìm kiếm
        private void ApplyFiltersAndSearch()
        {
            // gắn vào danh sách đầy đủ
            filteredProducts = new List<HouseholdProduct>(householdProducts);

            // tìm kiếm
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                List<HouseholdProduct> searchResults = new List<HouseholdProduct>();
                string searchText = txtSearch.Text.ToLower();

                for (int i = 0; i < filteredProducts.Count; i++)
                {
                    HouseholdProduct product = filteredProducts[i];
                    if (product.Id.ToLower().Contains(searchText) ||
                        product.Name.ToLower().Contains(searchText) ||
                        product.Brand.ToLower().Contains(searchText))
                    {
                        searchResults.Add(product);
                    }
                }
                filteredProducts = searchResults;
            }

            // lọc thương hiệu
            if (cmbBrandFilter.SelectedIndex > 0)
            {
                string selectedBrand = cmbBrandFilter.SelectedItem.ToString();
                List<HouseholdProduct> brandResults = new List<HouseholdProduct>();

                for (int i = 0; i < filteredProducts.Count; i++)
                {
                    if (filteredProducts[i].Brand == selectedBrand)
                    {
                        brandResults.Add(filteredProducts[i]);
                    }
                }
                filteredProducts = brandResults;
            }

            // lọc tồn kho thấp
            if (chkLowStockOnly.Checked)
            {
                List<HouseholdProduct> lowStockResults = new List<HouseholdProduct>();

                for (int i = 0; i < filteredProducts.Count; i++)
                {
                    if (filteredProducts[i].Quantity <= 10)
                    {
                        lowStockResults.Add(filteredProducts[i]);
                    }
                }
                filteredProducts = lowStockResults;
            }

            // sắp xếp
            ApplySorting();

            DisplayInGrid();
            statusLabel.Text = "Tìm thấy " + filteredProducts.Count + " kết quả";
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
                case 8: // Thương hiệu (A-Z)
                    filteredProducts.Sort((p1, p2) => p1.Brand.CompareTo(p2.Brand));
                    break;
                case 9: // Thương hiệu (Z-A)
                    filteredProducts.Sort((p1, p2) => p2.Brand.CompareTo(p1.Brand));
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

            List<string> distinctBrands = new List<string>();
            for (int i = 0; i < filteredProducts.Count; i++)
            {
                string brand = filteredProducts[i].Brand;
                if (!distinctBrands.Contains(brand))
                {
                    distinctBrands.Add(brand);
                }
            }
            int brandCount = distinctBrands.Count;

            lblTotalProductsValue.Text = totalProducts.ToString();
            lblTotalValueValue.Text = totalValue.ToString("N0") + " đ";
            lblLowStockValue.Text = lowStockCount.ToString();
            lblBrandCountValue.Text = brandCount.ToString();

            // đổi màu theo số lượng
            lblTotalProductsValue.ForeColor = totalProducts > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalValueValue.ForeColor = totalValue > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblLowStockValue.ForeColor = lowStockCount > 0 ? Color.Red : Color.FromArgb(46, 204, 113);
            lblBrandCountValue.ForeColor = brandCount > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }
    }
}