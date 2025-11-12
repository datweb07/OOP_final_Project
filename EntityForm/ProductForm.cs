using OOP_finalProject.Base;
using OOP_finalProject.Data;
using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        private ComboProductData comboProductData = new ComboProductData();
        private ClothingProductData clothingProductData = new ClothingProductData();
        private ElectronicProductData electronicProductData = new ElectronicProductData();

        // danh sách toàn bộ sản phẩm
        private List<Product> products = new List<Product>();
        private List<Product> filteredProducts = new List<Product>();

        BindingSource src = new BindingSource();

        private void FormProduct_Load(object sender, EventArgs e)
        {
            gridData.ReadOnly = true;
            gridData.DataSource = src;
            gridData.AutoGenerateColumns = false;

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

            cmbProductType.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;

            LoadProducts();
            ApplyFiltersAndSearch();
        }

        private void LoadProducts()
        {
            products.Clear();

            // thêm từng loại sản phẩm vào danh sách tổng quát
            List<DrinkProduct> drinkProducts = drinkProductData.GetData();
            List<FoodProduct> foodProducts = foodProductData.GetData();
            List<HouseholdProduct> householdProducts = householdProductData.GetData();
            List<ComboProduct> compositeProducts = comboProductData.GetData();
            List<ClothingProduct> clothingProducts = clothingProductData.GetData();
            List<ElectronicProduct> electronicProducts = electronicProductData.GetData();

            foreach (DrinkProduct product in drinkProducts)
            {
                products.Add(product);
            }

            foreach (FoodProduct product in foodProducts)
            {
                products.Add(product);
            }

            foreach (HouseholdProduct product in householdProducts)
            {
                products.Add(product);
            }

            foreach (ComboProduct product in compositeProducts)
            {
                products.Add(product);
            }

            foreach (ClothingProduct product in clothingProducts)
            {
                products.Add(product);
            }

            foreach (ElectronicProduct product in electronicProducts)
            {
                products.Add(product);
            }

            filteredProducts = new List<Product>();
            foreach (Product product in products)
            {
                filteredProducts.Add(product);
            }

            DisplayInGrid();
        }

        private void DisplayInGrid()
        {
            src.DataSource = filteredProducts;
            src.ResetBindings(true);
            UpdateStatistics();
        }

        // tìm kiếm sản phẩm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbProductType.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            chkLowStockOnly.Checked = false;

            filteredProducts = new List<Product>();
            foreach (Product product in products)
            {
                filteredProducts.Add(product);
            }

            ApplyFiltersAndSearch();
            statusLabel.Text = "Đã làm mới danh sách";
        }

        // lọc và tìm kiếm
        private void ApplyFiltersAndSearch()
        {
            // gắn danh sách đầy đủ
            filteredProducts = new List<Product>();
            foreach (Product product in products)
            {
                filteredProducts.Add(product);
            }

            // tìm kiếm
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                List<Product> tempList = new List<Product>();
                string searchText = txtSearch.Text.ToLower();

                foreach (Product p in filteredProducts)
                {
                    if (p.Id.ToLower().Contains(searchText) || p.Name.ToLower().Contains(searchText))
                    {
                        tempList.Add(p);
                    }
                }
                filteredProducts = tempList;
            }

            // lọc theo loại sản phẩm
            if (cmbProductType.SelectedIndex > 0)
            {
                string selectedType = cmbProductType.SelectedItem.ToString();
                List<Product> tempList = new List<Product>();

                foreach (Product p in filteredProducts)
                {
                    if (GetProductType(p) == selectedType)
                    {
                        tempList.Add(p);
                    }
                }
                filteredProducts = tempList;
            }

            // lọc tồn kho thấp
            if (chkLowStockOnly.Checked)
            {
                List<Product> tempList = new List<Product>();

                foreach (Product p in filteredProducts)
                {
                    if (p.Quantity <= 10)
                    {
                        tempList.Add(p);
                    }
                }
                filteredProducts = tempList;
            }

            // sắp xếp
            ApplySorting();

            DisplayInGrid();
            statusLabel.Text = $"Tìm thấy {filteredProducts.Count} sản phẩm";
        }

        // lấy loại sản phẩm để hiển thị
        private string GetProductType(Product product)
        {
            if (product is DrinkProduct) return "Đồ uống";
            if (product is FoodProduct) return "Thực phẩm";
            if (product is HouseholdProduct) return "Gia dụng";
            if (product is ComboProduct) return "Combo";
            if (product is ClothingProduct) return "Thời trang";
            if (product is ElectronicProduct) return "Điện tử";
            return "Khác";
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
                case 8: // Loại sản phẩm
                    filteredProducts.Sort((p1, p2) => GetProductType(p1).CompareTo(GetProductType(p2)));
                    break;
            }
        }

        // thống kê
        private void UpdateStatistics()
        {
            int totalProducts = filteredProducts.Count;

            decimal totalValue = 0;
            foreach (Product p in filteredProducts)
            {
                totalValue += p.Price * p.Quantity;
            }

            int lowStockCount = 0;
            foreach (Product p in filteredProducts)
            {
                if (p.Quantity <= 10)
                {
                    lowStockCount++;
                }
            }

            lblTotalProductsValue.Text = totalProducts.ToString();
            lblTotalValueValue.Text = $"{totalValue:N0} đ";
            lblLowStockValue.Text = lowStockCount.ToString();

            // đổi màu theo số lượng
            lblTotalProductsValue.ForeColor = totalProducts > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalValueValue.ForeColor = totalValue > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblLowStockValue.ForeColor = lowStockCount > 0 ? Color.Red : Color.FromArgb(46, 204, 113);
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }


        private void gridData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < filteredProducts.Count)
            {
                Product selectedProduct = filteredProducts[e.RowIndex];
                ShowProductDetails(selectedProduct);
            }
        }

        private void ShowProductDetails(Product product)
        {
            string productType = GetProductType(product);
            string details = $"Loại: {productType}\n";

            if (product is DrinkProduct)
            {
                DrinkProduct drink = (DrinkProduct)product;
                details += $"Có gas: {(drink.Carbonated ? "Có" : "Không")}";
            }
            else if (product is FoodProduct)
            {
                FoodProduct food = (FoodProduct)product;
                details += $"Hạn sử dụng: {food.ExpirationDate:dd/MM/yyyy}";
            }
            else if (product is HouseholdProduct)
            {
                HouseholdProduct household = (HouseholdProduct)product;
                details += $"Loại gia dụng: {household.Brand}";
            }
            else if (product is ComboProduct)
            {
                // ComboProduct composite = (ComboProduct)product;
                // details += $"Số sản phẩm trong combo: {composite.Components.Count}";
            }

            MessageBox.Show(details, $"Thông tin chi tiết - {product.Name}",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}