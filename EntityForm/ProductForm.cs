//using OOP_finalProject.Base;
//using OOP_finalProject.Data;
//using OOP_finalProject.Products;
//using System;
//using System.Collections.Generic;
//using System.Windows.Forms;

//namespace OOP_finalProject
//{
//    public partial class ProductForm : Form
//    {
//        public ProductForm()
//        {
//            InitializeComponent();
//        }

//        private DrinkProductData drinkProductData = new DrinkProductData();
//        private FoodProductData foodProductData = new FoodProductData();
//        private HouseholdProductData householdProductData = new HouseholdProductData();
//        private CompositeProductData compositeProductData = new CompositeProductData();

//        // Danh sách toàn bộ sản phẩm
//        private List<Product> products = new List<Product>();

//        BindingSource src = new BindingSource();
//        private void FormProduct_Load(object sender, EventArgs e)
//        {
//            gridData.ReadOnly = true;
//            gridData.DataSource = src;
//            gridData.AutoGenerateColumns = false;
//            LoadProducts();
//        }

//        private void LoadProducts()
//        {
//            // lấy ra danh sách sản phẩm cụ thể và thêm vào danh sách tổng quát
//            List<DrinkProduct> drinkProducts = drinkProductData.GetData();
//            List<FoodProduct> foodProducts = foodProductData.GetData();
//            List<HouseholdProduct> householdProducts = householdProductData.GetData();
//            List<CompositeProduct> compositeProducts = compositeProductData.GetData();

//            for (int i = 0; i < drinkProducts.Count; i++)
//            {
//                products.Add(drinkProducts[i]);
//            }

//            for (int i = 0; i < foodProducts.Count; i++)
//            {
//                products.Add(foodProducts[i]);
//            }

//            for (int i = 0; i < householdProducts.Count; i++)
//            {
//                products.Add(householdProducts[i]);
//            }

//            // Thêm composite products (Combo)
//            for (int i = 0; i < compositeProducts.Count; i++)
//            {
//                products.Add(compositeProducts[i]);
//            }

//            // Gán dữ liệu danh sách tổng quát vào BindingSource để hiển thị ra lưới
//            src.DataSource = products;
//            // Làm tươi lưới dữ liệu
//            src.ResetBindings(true);
//        }
//    }
//}


using OOP_finalProject.Base;
using OOP_finalProject.Data;
using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private DrinkProductData drinkProductData = new DrinkProductData();
        private FoodProductData foodProductData = new FoodProductData();
        private HouseholdProductData householdProductData = new HouseholdProductData();
        private CompositeProductData compositeProductData = new CompositeProductData();

        // Danh sách toàn bộ sản phẩm
        private List<Product> products = new List<Product>();
        private List<Product> filteredProducts = new List<Product>();

        BindingSource src = new BindingSource();

        private void FormProduct_Load(object sender, EventArgs e)
        {
            // Cấu hình gridData
            gridData.ReadOnly = true;
            gridData.DataSource = src;
            gridData.AutoGenerateColumns = false;

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

            // Thiết lập mặc định cho các controls
            cmbProductType.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;

            LoadProducts();
            ApplyFiltersAndSearch();
        }

        private void LoadProducts()
        {
            products.Clear();

            // Lấy ra danh sách sản phẩm cụ thể và thêm vào danh sách tổng quát
            List<DrinkProduct> drinkProducts = drinkProductData.GetData();
            List<FoodProduct> foodProducts = foodProductData.GetData();
            List<HouseholdProduct> householdProducts = householdProductData.GetData();
            List<CompositeProduct> compositeProducts = compositeProductData.GetData();

            products.AddRange(drinkProducts);
            products.AddRange(foodProducts);
            products.AddRange(householdProducts);
            products.AddRange(compositeProducts);

            filteredProducts = products.ToList();
            DisplayInGrid();
        }

        private void DisplayInGrid()
        {
            src.DataSource = filteredProducts;
            src.ResetBindings(true);
            UpdateStatistics();
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
        /// Làm mới form
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbProductType.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            chkLowStockOnly.Checked = false;

            filteredProducts = products.ToList();
            ApplyFiltersAndSearch();
            statusLabel.Text = "Đã làm mới danh sách";
        }

        /// <summary>
        /// Áp dụng tất cả bộ lọc và tìm kiếm
        /// </summary>
        private void ApplyFiltersAndSearch()
        {
            // Bắt đầu từ danh sách đầy đủ
            filteredProducts = products.ToList();

            // Áp dụng tìm kiếm
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                filteredProducts = filteredProducts.Where(p =>
                    p.Id.ToLower().Contains(txtSearch.Text.ToLower()) ||
                    p.Name.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            }

            // Áp dụng lọc loại sản phẩm
            if (cmbProductType.SelectedIndex > 0)
            {
                string selectedType = cmbProductType.SelectedItem.ToString();
                filteredProducts = filteredProducts.Where(p => GetProductType(p) == selectedType).ToList();
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
        /// Lấy loại sản phẩm để hiển thị
        /// </summary>
        private string GetProductType(Product product)
        {
            if (product is DrinkProduct) return "Đồ uống";
            if (product is FoodProduct) return "Thực phẩm";
            if (product is HouseholdProduct) return "Gia dụng";
            if (product is CompositeProduct) return "Combo";
            return "Khác";
        }

        /// <summary>
        /// Áp dụng sắp xếp theo lựa chọn trong comboBox
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
                case 8: // Loại sản phẩm
                    filteredProducts = filteredProducts.OrderBy(p => GetProductType(p)).ToList();
                    break;
            }
        }

        /// <summary>
        /// Cập nhật thống kê tổng sản phẩm và giá trị
        /// </summary>
        private void UpdateStatistics()
        {
            int totalProducts = filteredProducts.Count;
            decimal totalValue = filteredProducts.Sum(p => p.Price * p.Quantity);
            int lowStockCount = filteredProducts.Count(p => p.Quantity <= 10);

            lblTotalProductsValue.Text = totalProducts.ToString();
            lblTotalValueValue.Text = $"{totalValue:N0} đ";
            lblLowStockValue.Text = lowStockCount.ToString();

            // Đổi màu theo số lượng
            lblTotalProductsValue.ForeColor = totalProducts > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalValueValue.ForeColor = totalValue > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblLowStockValue.ForeColor = lowStockCount > 0 ? Color.Red : Color.FromArgb(46, 204, 113);
        }

        /// <summary>
        /// Sự kiện khi thay đổi lựa chọn lọc
        /// </summary>
        private void FilterChanged(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        /// <summary>
        /// Hiển thị chi tiết sản phẩm khi click vào grid
        /// </summary>
        private void gridData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < filteredProducts.Count)
            {
                Product selectedProduct = filteredProducts[e.RowIndex];
                ShowProductDetails(selectedProduct);
            }
        }

        /// <summary>
        /// Hiển thị thông tin chi tiết sản phẩm
        /// </summary>
        private void ShowProductDetails(Product product)
        {
            string productType = GetProductType(product);
            string details = $"Loại: {productType}\n";

            if (product is DrinkProduct drink)
            {
                details += $"Có gas: {(drink.Carbonated ? "Có" : "Không")}";
            }
            else if (product is FoodProduct food)
            {
                details += $"Hạn sử dụng: {food.ExpirationDate:dd/MM/yyyy}";
            }
            else if (product is HouseholdProduct household)
            {
                details += $"Loại gia dụng: {household.Brand}";
            }
            else if (product is CompositeProduct composite)
            {
                //details += $"Số sản phẩm trong combo: {composite.Components.Count}";
            }

            MessageBox.Show(details, $"Thông tin chi tiết - {product.Name}",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}