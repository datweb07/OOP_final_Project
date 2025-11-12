using OOP_finalProject.Products;
using System.Collections.Generic;
using System.Drawing;
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
        private bool isFresh = false;

        BindingSource _src = new BindingSource();

        private void ClothingProductForm_Load(object sender, System.EventArgs e)
        {
            ClothingProductData.CreateSampleData();

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
            gridData.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);

            gridData.Dock = DockStyle.Fill;
            gridData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // khởi tạo danh sách size
            InitializeSizes();

            cmbSort.SelectedIndex = 0;
            cmbSizeFilter.SelectedIndex = 0;

            // lấy dữ liệu
            clothingProducts = clothingProductData.GetData();
            filteredProducts = new List<ClothingProduct>(clothingProducts);
            DisplayInGrid();
        }

        private void InitializeSizes()
        {
            string[] sizes = new string[] {
                "XS", "S", "M", "L", "XL", "XXL", "XXXL"
            };

            // thêm size vào comboBox
            cboSize.Items.Clear();
            cboSize.Items.AddRange(sizes);
            cboSize.SelectedIndex = 0;

            // lọc size
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
            statusLabel.Text = "Tìm thấy " + filteredProducts.Count + " sản phẩm";
        }

        private void btnRefresh_Click(object sender, System.EventArgs e)
        {
            isFresh = true;

            txtCode.Text = "";
            txtName.Text = "";
            txtPrice.Value = 0;
            txtQty.Value = 0;
            txtSearch.Text = "";
            cboSize.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            cmbSizeFilter.SelectedIndex = 0;
            chkLowStockOnly.Checked = false;

            filteredProducts = new List<ClothingProduct>(clothingProducts);
            ApplyFiltersAndSearch();
            statusLabel.Text = "Đã làm mới danh sách";
            isFresh = false;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (!ValidateInput())
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

            if (clothingProduct == null)
            {
                clothingProduct = new ClothingProduct(
                    txtCode.Text,
                    txtName.Text,
                    txtPrice.Value,
                    txtQty.Value,
                    (string)cboSize.SelectedItem);
                clothingProducts.Add(clothingProduct);
            }
            else
            {
                clothingProduct.Name = txtName.Text;
                clothingProduct.Price = txtPrice.Value;
                clothingProduct.Quantity = txtQty.Value;
                clothingProduct.Size = (string)cboSize.SelectedItem;
            }

            ApplyFiltersAndSearch();

            // lưu dữ liệu
            clothingProductData.SaveData(clothingProducts);

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

        private void btnDelete_Click(object sender, System.EventArgs e)
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
            if (isFresh) return;
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

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        private void btnAddNew_Click(object sender, System.EventArgs e)
        {
            btnRefresh_Click(null, null);
            txtCode.Focus();
            statusLabel.Text = "Nhập thông tin sản phẩm mới";
        }

        private void ApplyFiltersAndSearch()
        {
            // gắn biến cho toàn bộ danh sách
            filteredProducts = new List<ClothingProduct>(clothingProducts);

            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                List<ClothingProduct> searchResults = new List<ClothingProduct>();
                string searchText = txtSearch.Text.ToLower();

                for (int i = 0; i < filteredProducts.Count; i++)
                {
                    ClothingProduct product = filteredProducts[i];
                    if (product.Id.ToLower().Contains(searchText) || product.Name.ToLower().Contains(searchText) || product.Size.ToLower().Contains(searchText))
                    {
                        searchResults.Add(product);
                    }
                }
                filteredProducts = searchResults;
            }

            // lọc size
            if (cmbSizeFilter.SelectedIndex > 0)
            {
                string selectedSize = cmbSizeFilter.SelectedItem.ToString();
                List<ClothingProduct> sizeResults = new List<ClothingProduct>();

                for (int i = 0; i < filteredProducts.Count; i++)
                {
                    if (filteredProducts[i].Size == selectedSize)
                    {
                        sizeResults.Add(filteredProducts[i]);
                    }
                }
                filteredProducts = sizeResults;
            }

            //  lọc tồn kho thấp
            if (chkLowStockOnly.Checked)
            {
                List<ClothingProduct> lowStockResults = new List<ClothingProduct>();

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
                case 8: // Size (A-Z)
                    filteredProducts.Sort((p1, p2) => p1.Size.CompareTo(p2.Size));
                    break;
                case 9: // Size (Z-A)
                    filteredProducts.Sort((p1, p2) => p2.Size.CompareTo(p1.Size));
                    break;
            }
        }

        // cập nhật label thống kê
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

            List<string> distinctSizes = new List<string>();
            for (int i = 0; i < filteredProducts.Count; i++)
            {
                string size = filteredProducts[i].Size;
                if (!distinctSizes.Contains(size))
                {
                    distinctSizes.Add(size);
                }
            }
            int sizeCount = distinctSizes.Count;

            lblTotalProductsValue.Text = totalProducts.ToString();
            lblTotalValueValue.Text = totalValue.ToString("N0") + " đ";
            lblLowStockValue.Text = lowStockCount.ToString();
            lblSizeCountValue.Text = sizeCount.ToString();

            // đổi màu theo số lượng
            lblTotalProductsValue.ForeColor = totalProducts > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalValueValue.ForeColor = totalValue > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblLowStockValue.ForeColor = lowStockCount > 0 ? Color.Red : Color.FromArgb(46, 204, 113);
            lblSizeCountValue.ForeColor = sizeCount > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
        }

        private void FilterChanged(object sender, System.EventArgs e)
        {
            ApplyFiltersAndSearch();
        }
    }
}