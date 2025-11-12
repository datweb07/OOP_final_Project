using OOP_finalProject.Base;
using OOP_finalProject.Data;
using OOP_finalProject.Interfaces;
using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject.EntityForm
{
    public partial class ComboProductForm : Form
    {
        private ComboProductData compositeProductData = new ComboProductData();
        private List<ComboProduct> compositeProducts = new List<ComboProduct>();
        private List<Product> availableProducts = new List<Product>();
        private ComboProduct currentComposite = null;
        private List<Product> allAvailableProducts = new List<Product>();

        BindingSource comboBindingSource = new BindingSource();
        BindingSource productsInComboBindingSource = new BindingSource();
        BindingSource availableProductsBindingSource = new BindingSource();

        public ComboProductForm()
        {
            InitializeComponent();
        }

        private void CompositeProductForm_Load(object sender, EventArgs e)
        {
            // tùy chỉnh hiển thị DataGridView
            gridComboList.DataSource = comboBindingSource;
            gridComboList.AllowUserToAddRows = false;
            gridComboList.ReadOnly = true;

            gridProductsInCombo.DataSource = productsInComboBindingSource;
            gridProductsInCombo.AllowUserToAddRows = false;
            gridProductsInCombo.ReadOnly = true;

            gridAvailableProducts.DataSource = availableProductsBindingSource;
            gridAvailableProducts.AllowUserToAddRows = false;
            gridAvailableProducts.ReadOnly = true;

            CustomizeDataGridView(gridComboList);
            CustomizeDataGridView(gridProductsInCombo);
            CustomizeDataGridView(gridAvailableProducts);

            // load dữ liệu của combo và product
            LoadCompositeProducts();
            LoadAvailableProducts();

            numQuantity.Value = 1;
            numComboQuantity.Value = 1; // mặc định là 1 combo
            statusLabel.Text = "Sẵn sàng";
        }

        private void CustomizeDataGridView(DataGridView gridView)
        {
            gridView.BorderStyle = BorderStyle.None;
            gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 245);
            gridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 105, 225);
            gridView.DefaultCellStyle.SelectionForeColor = Color.White;
            gridView.BackgroundColor = Color.White;
            gridView.EnableHeadersVisualStyles = false;
            gridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(65, 105, 225);
            gridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        // lấy dữ liệu combo từ database
        private void LoadCompositeProducts()
        {
            compositeProducts = compositeProductData.GetData();
            comboBindingSource.DataSource = compositeProducts;
            comboBindingSource.ResetBindings(true);
            UpdateStatistics();
        }

        // lấy dữ liệu sản phẩm từ database
        private void LoadAvailableProducts()
        {
            availableProducts.Clear();
            allAvailableProducts.Clear();

            // Load từ các data source khác nhau
            DrinkProductData drinkData = new DrinkProductData();
            FoodProductData foodData = new FoodProductData();
            HouseholdProductData householdData = new HouseholdProductData();
            ElectronicProductData electronicData = new ElectronicProductData();
            ClothingProductData clothingData = new ClothingProductData();

            List<DrinkProduct> drinkProducts = drinkData.GetData();
            for (int i = 0; i < drinkProducts.Count; i++)
            {
                allAvailableProducts.Add(drinkProducts[i]);
            }

            List<FoodProduct> foodProducts = foodData.GetData();
            for (int i = 0; i < foodProducts.Count; i++)
            {
                allAvailableProducts.Add(foodProducts[i]);
            }

            List<HouseholdProduct> householdProducts = householdData.GetData();
            for (int i = 0; i < householdProducts.Count; i++)
            {
                allAvailableProducts.Add(householdProducts[i]);
            }

            List<ElectronicProduct> electronicProducts = electronicData.GetData();
            for (int i = 0; i < electronicProducts.Count; i++)
            {
                allAvailableProducts.Add(electronicProducts[i]);
            }

            List<ClothingProduct> clothingProducts = clothingData.GetData();
            for (int i = 0; i < clothingProducts.Count; i++)
            {
                allAvailableProducts.Add(clothingProducts[i]);
            }

            List<Product> filteredProducts = new List<Product>();
            for (int i = 0; i < allAvailableProducts.Count; i++)
            {
                // thêm những sản phẩm có số lượng > 0
                if (allAvailableProducts[i].Quantity > 0)
                {
                    filteredProducts.Add(allAvailableProducts[i]);
                }
            }
            allAvailableProducts = filteredProducts;

            // gắn sang availableProducts để hiển thị
            availableProducts = new List<Product>(allAvailableProducts);

            availableProductsBindingSource.DataSource = availableProducts;
            availableProductsBindingSource.ResetBindings(true);
        }

        private void btnNewCombo_Click(object sender, EventArgs e)
        {
            txtComboId.Text = "";
            txtComboName.Text = "";
            txtDescription.Text = "";
            numDiscount.Value = 0;
            numComboQuantity.Value = 1;
            numQuantity.Value = 1;

            currentComposite = new ComboProduct();
            productsInComboBindingSource.DataSource = new List<IProductComponent>();
            productsInComboBindingSource.ResetBindings(true);

            UpdatePriceDisplay();
            statusLabel.Text = "Đã tạo combo mới";
        }

        private void btnSaveCombo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtComboId.Text))
            {
                MessageBox.Show("Mã combo không được để trống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtComboId.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtComboName.Text))
            {
                MessageBox.Show("Tên combo không được để trống!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtComboName.Focus();
                return;
            }

            if (currentComposite == null || currentComposite.GetChildCount() == 0)
            {
                MessageBox.Show("Combo phải có ít nhất 1 sản phẩm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numComboQuantity.Value < 0)
            {
                MessageBox.Show("Số lượng combo không được âm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numComboQuantity.Focus();
                return;
            }

            // kiểm tra trùng mã
            bool isNew = string.IsNullOrEmpty(currentComposite.Id);
            bool exists = false;
            for (int i = 0; i < compositeProducts.Count; i++)
            {
                if (compositeProducts[i].Id.ToLower() == txtComboId.Text.ToLower())
                {
                    exists = true;
                    break;
                }
            }

            if (isNew && exists)
            {
                MessageBox.Show("Mã combo đã tồn tại! Vui lòng chọn mã khác.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtComboId.Focus();
                return;
            }

            // tạo mới hoặc cập nhật combo
            currentComposite.Id = txtComboId.Text;
            currentComposite.Name = txtComboName.Text;
            currentComposite.Description = txtDescription.Text;
            currentComposite.DiscountPercentage = numDiscount.Value;
            currentComposite.Quantity = (int)numComboQuantity.Value; 

            bool success;
            if (isNew)
            {
                success = compositeProductData.AddCompositeProduct(currentComposite);
                if (success)
                {
                    compositeProducts.Add(currentComposite);
                }
            }
            else
            {
                success = compositeProductData.UpdateCompositeProduct(currentComposite);
            }

            if (success)
            {
                MessageBox.Show("Lưu combo thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadCompositeProducts();
                statusLabel.Text = "Đã lưu combo thành công";
                statusLabel.ForeColor = Color.FromArgb(46, 204, 113);
            }
            else
            {
                MessageBox.Show("Lỗi khi lưu combo!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Lỗi khi lưu combo";
                statusLabel.ForeColor = Color.Red;
            }
        }

        private void btnDeleteCombo_Click(object sender, EventArgs e)
        {
            if (currentComposite == null || string.IsNullOrEmpty(currentComposite.Id))
            {
                MessageBox.Show("Vui lòng chọn combo cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa combo '" + currentComposite.Name + "'?\n\nThao tác này không thể hoàn tác!",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (compositeProductData.DeleteCompositeProduct(currentComposite.Id))
                {
                    compositeProducts.Remove(currentComposite);
                    MessageBox.Show("Xóa combo thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCompositeProducts();
                    btnNewCombo_Click(sender, e); // Reset form
                    statusLabel.Text = "Đã xóa combo thành công";
                    statusLabel.ForeColor = Color.FromArgb(46, 204, 113);
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa combo!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = "Lỗi khi xóa combo";
                    statusLabel.ForeColor = Color.Red;
                }
            }
        }

        // thêm sản phẩm vào combo
        private void btnAddToCombo_Click(object sender, EventArgs e)
        {
            if (currentComposite == null)
            {
                MessageBox.Show("Vui lòng tạo combo mới hoặc chọn combo cần chỉnh sửa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (gridAvailableProducts.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần thêm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numQuantity.Focus();
                return;
            }

            Product selectedProduct = (Product)gridAvailableProducts.CurrentRow.DataBoundItem;
            if (selectedProduct != null)
            {
                
                List<IProductComponent> children = currentComposite.GetChildren();
                Product existingProduct = null;

                for (int i = 0; i < children.Count; i++)
                {
                    // kiểm tra xem sản phẩm đã có trong combo chưa
                    if (children[i] is Product product && product.Id == selectedProduct.Id)
                    {
                        existingProduct = product;
                        break;
                    }
                }

                if (existingProduct != null)
                {
                    // cập nhật lại số lượng nếu đã có
                    for (int i = 0; i < children.Count; i++)
                    {
                        if (children[i].Id == selectedProduct.Id && children[i] is Product product)
                        {
                            product.Quantity += (int)numQuantity.Value;
                            break;
                        }
                    }
                }
                else
                {
                    // tạo bản sao sản phẩm với số lượng mới và thêm vào combo
                    Product productToAdd = CloneProductWithQuantity(selectedProduct, (int)numQuantity.Value);
                    currentComposite.Add(productToAdd);
                }

                RefreshProductsInCombo();
                UpdatePriceDisplay();

                statusLabel.Text = "Đã thêm " + numQuantity.Value + " " + selectedProduct.Name + " vào combo";
            }
        }

        // tạo bản sao của tất cả các sản phẩm với số lượng mới
        private Product CloneProductWithQuantity(Product original, int quantity)
        {
            Product cloned = null;

            if (original is DrinkProduct drink)
            {
                cloned = new DrinkProduct(drink.Id, drink.Name, drink.Price, quantity, drink.Carbonated);
            }
            else if (original is FoodProduct food)
            {
                cloned = new FoodProduct(food.Id, food.Name, food.Price, quantity, food.ExpirationDate);
            }
            else if (original is HouseholdProduct household)
            {
                cloned = new HouseholdProduct(household.Id, household.Name, household.Price, quantity, household.Brand);
            }
            else if (original is ElectronicProduct electronic)
            {
                cloned = new ElectronicProduct(electronic.Id, electronic.Name, electronic.Price, quantity, electronic.WarrantyPeriod);
            }
            else if (original is ClothingProduct clothing)
            {
                cloned = new ClothingProduct(clothing.Id, clothing.Name, clothing.Price, quantity, clothing.Size);
            }

            return cloned;
        }

        private void btnRemoveFromCombo_Click(object sender, EventArgs e)
        {
            if (currentComposite == null)
            {
                MessageBox.Show("Không có combo nào đang được chỉnh sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (gridProductsInCombo.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IProductComponent selectedComponent = (IProductComponent)gridProductsInCombo.CurrentRow.DataBoundItem;
            if (selectedComponent != null)
            {
                string productName = selectedComponent.Name;
                currentComposite.Remove(selectedComponent);
                RefreshProductsInCombo();
                UpdatePriceDisplay();

                statusLabel.Text = "Đã xóa " + productName + " khỏi combo";
            }
        }

        private void RefreshProductsInCombo()
        {
            if (currentComposite != null)
            {
                List<IProductComponent> children = currentComposite.GetChildren();
                productsInComboBindingSource.DataSource = children;
                productsInComboBindingSource.ResetBindings(true);
            }
        }

        // cập nhật hiển thị giá
        private void UpdatePriceDisplay()
        {
            if (currentComposite != null)
            {
                decimal originalPrice = currentComposite.GetOriginalPrice();
                decimal finalPrice = currentComposite.Price;
                decimal savings = originalPrice - finalPrice;
                decimal inventoryValue = currentComposite.GetInventoryValue();

                lblOriginalPrice.Text = "Giá gốc: " + originalPrice.ToString("N0") + " đ";
                lblFinalPrice.Text = "Giá sau giảm: " + finalPrice.ToString("N0") + " đ";
                lblSavings.Text = "Tiết kiệm: " + savings.ToString("N0") + " đ";

                // hàng tồn
                if (currentComposite.Quantity > 0)
                {
                    lblSavings.Text += "\nTồn kho: " + currentComposite.Quantity + " combo\nGiá trị tồn kho: " + inventoryValue.ToString("N0") + " đ";
                }

                // đổi màu theo giá trị
                lblOriginalPrice.ForeColor = originalPrice > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
                lblFinalPrice.ForeColor = finalPrice > 0 ? Color.FromArgb(65, 105, 225) : Color.Red;
                lblSavings.ForeColor = savings > 0 ? Color.FromArgb(46, 204, 113) : Color.Gray;
            }
            else
            {
                lblOriginalPrice.Text = "Giá gốc: 0 đ";
                lblFinalPrice.Text = "Giá sau giảm: 0 đ";
                lblSavings.Text = "Tiết kiệm: 0 đ";

                lblOriginalPrice.ForeColor = Color.Gray;
                lblFinalPrice.ForeColor = Color.Gray;
                lblSavings.ForeColor = Color.Gray;
            }
        }

        private void gridComboList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridComboList.CurrentRow == null || gridComboList.CurrentRow.IsNewRow)
                return;

            currentComposite = (ComboProduct)gridComboList.CurrentRow.DataBoundItem;
            if (currentComposite != null)
            {
                DisplayComposite(currentComposite);
                statusLabel.Text = "Đang chỉnh sửa combo: " + currentComposite.Name;
            }
        }

        private void DisplayComposite(ComboProduct composite)
        {
            txtComboId.Text = composite.Id;
            txtComboName.Text = composite.Name;
            txtDescription.Text = composite.Description;
            numDiscount.Value = composite.DiscountPercentage;
            numComboQuantity.Value = composite.Quantity; 

            RefreshProductsInCombo();
            UpdatePriceDisplay();
        }

        // thay đổi phần trăm giảm giá
        private void numDiscount_ValueChanged(object sender, EventArgs e)
        {
            if (currentComposite != null)
            {
                currentComposite.DiscountPercentage = numDiscount.Value;
                UpdatePriceDisplay();
            }
        }

        // thay đổi số lượng combo
        private void numComboQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (currentComposite != null)
            {
                currentComposite.Quantity = (int)numComboQuantity.Value;
                UpdatePriceDisplay();

                // cập nhật lại trạng thái
                if (currentComposite.Quantity == 0)
                {
                    statusLabel.Text = "Combo đã hết hàng";
                    statusLabel.ForeColor = Color.Red;
                }
                else if (currentComposite.Quantity < 10)
                {
                    statusLabel.Text = "Cảnh báo: Chỉ còn " + currentComposite.Quantity + " combo";
                    statusLabel.ForeColor = Color.Orange;
                }
                else
                {
                    statusLabel.Text = "Số lượng combo: " + currentComposite.Quantity;
                    statusLabel.ForeColor = Color.FromArgb(46, 204, 113);
                }
            }
        }

        // chi tiết combo
        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (currentComposite == null)
            {
                MessageBox.Show("Vui lòng chọn combo!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string details = currentComposite.Info();
            MessageBox.Show(details, "Chi tiết Combo - Composite Pattern",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // thống kê
        private void UpdateStatistics()
        {
            int totalCombos = compositeProducts.Count;

            int totalProductsInCombos = 0;
            for (int i = 0; i < compositeProducts.Count; i++)
            {
                totalProductsInCombos += compositeProducts[i].GetChildCount();
            }

            decimal totalValue = 0;
            for (int i = 0; i < compositeProducts.Count; i++)
            {
                totalValue += compositeProducts[i].GetInventoryValue();
            }

            int activeCombos = 0;
            for (int i = 0; i < compositeProducts.Count; i++)
            {
                if (compositeProducts[i].GetChildCount() > 0)
                {
                    activeCombos++;
                }
            }

            decimal totalComboQuantity = 0;
            for (int i = 0; i < compositeProducts.Count; i++)
            {
                totalComboQuantity += compositeProducts[i].Quantity;
            }

            lblTotalCombosValue.Text = totalCombos.ToString();
            lblTotalProductsValue.Text = totalProductsInCombos.ToString();
            lblTotalValueValue.Text = totalValue.ToString("N0") + " đ";
            lblActiveCombosValue.Text = activeCombos.ToString();


            if (totalComboQuantity > 0)
            {
                lblActiveCombosValue.Text += "\nTổng SL: " + totalComboQuantity;  // tống số combo
            }

            lblTotalCombosValue.ForeColor = totalCombos > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalProductsValue.ForeColor = totalProductsInCombos > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalValueValue.ForeColor = totalValue > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblActiveCombosValue.ForeColor = activeCombos > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
        }

        private void btnRefreshProducts_Click(object sender, EventArgs e)
        {
            LoadAvailableProducts();
            statusLabel.Text = "Đã làm mới danh sách sản phẩm";
        }

        private void gridAvailableProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridAvailableProducts.CurrentRow != null)
            {
                Product selectedProduct = (Product)gridAvailableProducts.CurrentRow.DataBoundItem;
                if (selectedProduct != null)
                {
                    lblSelectedProduct.Text = "Đã chọn: " + selectedProduct.Name + " (Tồn: " + selectedProduct.Quantity + ")";
                    numQuantity.Maximum = selectedProduct.Quantity;
                    numQuantity.Value = Math.Min(1, selectedProduct.Quantity);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadCompositeProducts();
            statusLabel.Text = "Đã xóa bộ lọc tìm kiếm";
        }

        // tìm kiếm combo
        private void PerformSearch()
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                // hiển thị tất cả
                LoadCompositeProducts();
                return;
            }

            // Gọi SearchByName từ ComboProductData
            List<ComboProduct> searchResults = compositeProductData.SearchByName(keyword);

            if (searchResults.Count == 0)
            {
                comboBindingSource.DataSource = new List<ComboProduct>();
                comboBindingSource.ResetBindings(true);
                statusLabel.Text = "Không tìm thấy combo nào với từ khóa '" + keyword + "'";
            }
            else
            {
                comboBindingSource.DataSource = searchResults;
                comboBindingSource.ResetBindings(true);
                statusLabel.Text = "Tìm thấy " + searchResults.Count + " combo";
            }
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            PerformProductSearch();
        }

        private void btnClearSearchProduct_Click(object sender, EventArgs e)
        {
            txtSearchProduct.Text = "";
            availableProducts = new List<Product>(allAvailableProducts);
            availableProductsBindingSource.DataSource = availableProducts;
            availableProductsBindingSource.ResetBindings(true);
            statusLabel.Text = "Đã xóa bộ lọc tìm kiếm sản phẩm";
        }

        // tìm kiếm sản phẩm
        private void PerformProductSearch()
        {
            string keyword = txtSearchProduct.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                // Nếu không có từ khóa, hiển thị tất cả
                availableProducts = new List<Product>(allAvailableProducts);
                availableProductsBindingSource.DataSource = availableProducts;
                availableProductsBindingSource.ResetBindings(true);
                statusLabel.Text = "Hiển thị tất cả sản phẩm";
                return;
            }


            List<Product> searchResults = new List<Product>();
            for (int i = 0; i < allAvailableProducts.Count; i++)
            {
                Product product = allAvailableProducts[i];
                if (product.Name.ToLower().Contains(keyword) || product.Id.ToLower().Contains(keyword))
                {
                    searchResults.Add(product);
                }
            }

            if (searchResults.Count == 0)
            {
                availableProducts.Clear();
                availableProductsBindingSource.DataSource = availableProducts;
                availableProductsBindingSource.ResetBindings(true);
                statusLabel.Text = "Không tìm thấy sản phẩm nào với từ khóa '" + keyword + "'";
                statusLabel.ForeColor = Color.Red;
            }
            else
            {
                availableProducts = searchResults;
                availableProductsBindingSource.DataSource = availableProducts;
                availableProductsBindingSource.ResetBindings(true);
                statusLabel.Text = "Tìm thấy " + searchResults.Count + " sản phẩm";
                statusLabel.ForeColor = Color.FromArgb(46, 204, 113);
            }
        }
    }
}