//using OOP_finalProject.Base;
//using OOP_finalProject.Data;
//using OOP_finalProject.Interfaces;
//using OOP_finalProject.Products;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Windows.Forms;

//namespace OOP_finalProject.EntityForm
//{
//    public partial class ComboProductForm : Form
//    {
//        private ComboProductData compositeProductData = new ComboProductData();
//        private List<ComboProduct> compositeProducts = new List<ComboProduct>();

//        // Danh sách tất cả sản phẩm có sẵn để thêm vào combo
//        private List<Product> availableProducts = new List<Product>();

//        // Combo hiện tại đang chỉnh sửa
//        private ComboProduct currentComposite = null;

//        BindingSource comboBindingSource = new BindingSource();
//        BindingSource productsInComboBindingSource = new BindingSource();
//        BindingSource availableProductsBindingSource = new BindingSource();

//        public ComboProductForm()
//        {
//            InitializeComponent();
//        }

//        private void CompositeProductForm_Load(object sender, EventArgs e)
//        {
//            // Cấu hình DataGridView
//            gridComboList.DataSource = comboBindingSource;
//            gridComboList.AllowUserToAddRows = false;
//            gridComboList.ReadOnly = true;

//            gridProductsInCombo.DataSource = productsInComboBindingSource;
//            gridProductsInCombo.AllowUserToAddRows = false;
//            gridProductsInCombo.ReadOnly = true;

//            gridAvailableProducts.DataSource = availableProductsBindingSource;
//            gridAvailableProducts.AllowUserToAddRows = false;
//            gridAvailableProducts.ReadOnly = true;

//            // Load dữ liệu
//            LoadCompositeProducts();
//            LoadAvailableProducts();
//        }

//        /// <summary>
//        /// Load danh sách composite products
//        /// </summary>
//        private void LoadCompositeProducts()
//        {
//            compositeProducts = compositeProductData.GetData();
//            comboBindingSource.DataSource = compositeProducts;
//            comboBindingSource.ResetBindings(true);
//        }

//        /// <summary>
//        /// Load danh sách sản phẩm có sẵn từ tất cả các loại
//        /// </summary>
//        private void LoadAvailableProducts()
//        {
//            availableProducts.Clear();

//            // Load từ các data source khác nhau
//            DrinkProductData drinkData = new DrinkProductData();
//            FoodProductData foodData = new FoodProductData();
//            HouseholdProductData householdData = new HouseholdProductData();
//            ElectronicProductData electronicData = new ElectronicProductData();
//            ClothingProductData clothingData = new ClothingProductData();

//            availableProducts.AddRange(drinkData.GetData());
//            availableProducts.AddRange(foodData.GetData());
//            availableProducts.AddRange(householdData.GetData());
//            availableProducts.AddRange(electronicData.GetData());
//            availableProducts.AddRange(clothingData.GetData());

//            availableProductsBindingSource.DataSource = availableProducts;
//            availableProductsBindingSource.ResetBindings(true);
//        }

//        /// <summary>
//        /// Tạo combo mới
//        /// </summary>
//        private void btnNewCombo_Click(object sender, EventArgs e)
//        {
//            txtComboId.Text = "";
//            txtComboName.Text = "";
//            txtDescription.Text = "";
//            numDiscount.Value = 0;

//            currentComposite = new ComboProduct();
//            productsInComboBindingSource.DataSource = new List<IProductComponent>();
//            productsInComboBindingSource.ResetBindings(true);

//            UpdatePriceDisplay();
//        }

//        /// <summary>
//        /// Lưu combo
//        /// </summary>
//        private void btnSaveCombo_Click(object sender, EventArgs e)
//        {
//            // Validation
//            if (string.IsNullOrWhiteSpace(txtComboId.Text))
//            {
//                MessageBox.Show("Mã combo không được để trống!", "Thông báo", 
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            if (string.IsNullOrWhiteSpace(txtComboName.Text))
//            {
//                MessageBox.Show("Tên combo không được để trống!", "Thông báo", 
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            if (currentComposite == null || currentComposite.GetChildCount() == 0)
//            {
//                MessageBox.Show("Combo phải có ít nhất 1 sản phẩm!", "Thông báo", 
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            // Tạo hoặc cập nhật composite
//            bool isNew = string.IsNullOrEmpty(currentComposite.Id);

//            currentComposite.Id = txtComboId.Text;
//            currentComposite.Name = txtComboName.Text;
//            currentComposite.Description = txtDescription.Text;
//            currentComposite.DiscountPercentage = numDiscount.Value;

//            bool success;
//            if (isNew || !compositeProducts.Exists(c => c.Id == currentComposite.Id))
//            {
//                success = compositeProductData.AddCompositeProduct(currentComposite);
//            }
//            else
//            {
//                success = compositeProductData.UpdateCompositeProduct(currentComposite);
//            }

//            if (success)
//            {
//                MessageBox.Show("Lưu combo thành công!", "Thông báo", 
//                    MessageBoxButtons.OK, MessageBoxIcon.Information);
//                LoadCompositeProducts();
//            }
//            else
//            {
//                MessageBox.Show("Lỗi khi lưu combo!", "Thông báo", 
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        /// <summary>
//        /// Xóa combo
//        /// </summary>
//        private void btnDeleteCombo_Click(object sender, EventArgs e)
//        {
//            if (currentComposite == null || string.IsNullOrEmpty(currentComposite.Id))
//            {
//                MessageBox.Show("Vui lòng chọn combo cần xóa!", "Thông báo", 
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            DialogResult result = MessageBox.Show(
//                $"Bạn có chắc chắn muốn xóa combo '{currentComposite.Name}'?",
//                "Xác nhận xóa",
//                MessageBoxButtons.YesNo,
//                MessageBoxIcon.Question);

//            if (result == DialogResult.Yes)
//            {
//                if (compositeProductData.DeleteCompositeProduct(currentComposite.Id))
//                {
//                    MessageBox.Show("Xóa combo thành công!", "Thông báo", 
//                        MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    LoadCompositeProducts();
//                    btnNewCombo_Click(sender, e); // Reset form
//                }
//                else
//                {
//                    MessageBox.Show("Lỗi khi xóa combo!", "Thông báo", 
//                        MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//            }
//        }

//        /// <summary>
//        /// Thêm sản phẩm vào combo
//        /// </summary>
//        private void btnAddToCombo_Click(object sender, EventArgs e)
//        {
//            if (currentComposite == null)
//            {
//                MessageBox.Show("Vui lòng tạo combo mới hoặc chọn combo cần chỉnh sửa!", 
//                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            if (gridAvailableProducts.CurrentRow == null)
//            {
//                MessageBox.Show("Vui lòng chọn sản phẩm cần thêm!", "Thông báo", 
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            Product selectedProduct = (Product)gridAvailableProducts.CurrentRow.DataBoundItem;
//            if (selectedProduct != null)
//            {
//                // Kiểm tra xem sản phẩm đã có trong combo chưa
//                if (currentComposite.GetChildren().Any(c => c.Id == selectedProduct.Id))
//                {
//                    MessageBox.Show("Sản phẩm này đã có trong combo!", "Thông báo", 
//                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                currentComposite.Add(selectedProduct);
//                RefreshProductsInCombo();
//                UpdatePriceDisplay();
//            }
//        }

//        /// <summary>
//        /// Xóa sản phẩm khỏi combo
//        /// </summary>
//        private void btnRemoveFromCombo_Click(object sender, EventArgs e)
//        {
//            if (currentComposite == null)
//            {
//                MessageBox.Show("Không có combo nào đang được chỉnh sửa!", "Thông báo", 
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            if (gridProductsInCombo.CurrentRow == null)
//            {
//                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo", 
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            IProductComponent selectedComponent = (IProductComponent)gridProductsInCombo.CurrentRow.DataBoundItem;
//            if (selectedComponent != null)
//            {
//                currentComposite.Remove(selectedComponent);
//                RefreshProductsInCombo();
//                UpdatePriceDisplay();
//            }
//        }

//        /// <summary>
//        /// Refresh danh sách sản phẩm trong combo
//        /// </summary>
//        private void RefreshProductsInCombo()
//        {
//            if (currentComposite != null)
//            {
//                productsInComboBindingSource.DataSource = currentComposite.GetChildren();
//                productsInComboBindingSource.ResetBindings(true);
//            }
//        }

//        /// <summary>
//        /// Cập nhật hiển thị giá
//        /// </summary>
//        private void UpdatePriceDisplay()
//        {
//            if (currentComposite != null)
//            {
//                lblOriginalPrice.Text = $"Giá gốc: {currentComposite.GetOriginalPrice():C}";
//                lblFinalPrice.Text = $"Giá sau giảm: {currentComposite.Price:C}";
//                lblSavings.Text = $"Tiết kiệm: {(currentComposite.GetOriginalPrice() - currentComposite.Price):C}";
//            }
//            else
//            {
//                lblOriginalPrice.Text = "Giá gốc: 0 ₫";
//                lblFinalPrice.Text = "Giá sau giảm: 0 ₫";
//                lblSavings.Text = "Tiết kiệm: 0 ₫";
//            }
//        }

//        /// <summary>
//        /// Khi chọn combo trong danh sách
//        /// </summary>
//        private void gridComboList_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (gridComboList.CurrentRow == null || gridComboList.CurrentRow.IsNewRow)
//                return;

//            currentComposite = (ComboProduct)gridComboList.CurrentRow.DataBoundItem;
//            if (currentComposite != null)
//            {
//                DisplayComposite(currentComposite);
//            }
//        }

//        /// <summary>
//        /// Hiển thị thông tin combo
//        /// </summary>
//        private void DisplayComposite(ComboProduct composite)
//        {
//            txtComboId.Text = composite.Id;
//            txtComboName.Text = composite.Name;
//            txtDescription.Text = composite.Description;
//            numDiscount.Value = composite.DiscountPercentage;

//            RefreshProductsInCombo();
//            UpdatePriceDisplay();
//        }

//        /// <summary>
//        /// Khi thay đổi % giảm giá
//        /// </summary>
//        private void numDiscount_ValueChanged(object sender, EventArgs e)
//        {
//            if (currentComposite != null)
//            {
//                currentComposite.DiscountPercentage = numDiscount.Value;
//                UpdatePriceDisplay();
//            }
//        }

//        /// <summary>
//        /// Xem chi tiết combo
//        /// </summary>
//        private void btnViewDetails_Click(object sender, EventArgs e)
//        {
//            if (currentComposite == null)
//            {
//                MessageBox.Show("Vui lòng chọn combo!", "Thông báo", 
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            string details = currentComposite.Info();
//            MessageBox.Show(details, "Chi tiết Combo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//        }
//    }
//}


//using OOP_finalProject.Base;
//using OOP_finalProject.Data;
//using OOP_finalProject.Interfaces;
//using OOP_finalProject.Products;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Windows.Forms;

//namespace OOP_finalProject.EntityForm
//{
//    public partial class ComboProductForm : Form
//    {
//        private ComboProductData compositeProductData = new ComboProductData();
//        private List<ComboProduct> compositeProducts = new List<ComboProduct>();

//        // Danh sách tất cả sản phẩm có sẵn để thêm vào combo
//        private List<Product> availableProducts = new List<Product>();

//        // Combo hiện tại đang chỉnh sửa
//        private ComboProduct currentComposite = null;

//        BindingSource comboBindingSource = new BindingSource();
//        BindingSource productsInComboBindingSource = new BindingSource();
//        BindingSource availableProductsBindingSource = new BindingSource();

//        public ComboProductForm()
//        {
//            InitializeComponent();
//        }

//        private void CompositeProductForm_Load(object sender, EventArgs e)
//        {
//            // Cấu hình DataGridView
//            gridComboList.DataSource = comboBindingSource;
//            gridComboList.AllowUserToAddRows = false;
//            gridComboList.ReadOnly = true;

//            gridProductsInCombo.DataSource = productsInComboBindingSource;
//            gridProductsInCombo.AllowUserToAddRows = false;
//            gridProductsInCombo.ReadOnly = true;

//            gridAvailableProducts.DataSource = availableProductsBindingSource;
//            gridAvailableProducts.AllowUserToAddRows = false;
//            gridAvailableProducts.ReadOnly = true;

//            // Tùy chỉnh giao diện DataGridView
//            CustomizeDataGridView(gridComboList);
//            CustomizeDataGridView(gridProductsInCombo);
//            CustomizeDataGridView(gridAvailableProducts);

//            // Load dữ liệu
//            LoadCompositeProducts();
//            LoadAvailableProducts();

//            // Thiết lập mặc định
//            numQuantity.Value = 1;
//            statusLabel.Text = "Sẵn sàng";
//        }

//        private void CustomizeDataGridView(DataGridView gridView)
//        {
//            gridView.BorderStyle = BorderStyle.None;
//            gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 245);
//            gridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
//            gridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 105, 225);
//            gridView.DefaultCellStyle.SelectionForeColor = Color.White;
//            gridView.BackgroundColor = Color.White;
//            gridView.EnableHeadersVisualStyles = false;
//            gridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
//            gridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(65, 105, 225);
//            gridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
//            gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
//        }

//        /// <summary>
//        /// Load danh sách composite products
//        /// </summary>
//        private void LoadCompositeProducts()
//        {
//            compositeProducts = compositeProductData.GetData();
//            comboBindingSource.DataSource = compositeProducts;
//            comboBindingSource.ResetBindings(true);
//            UpdateStatistics();
//        }

//        /// <summary>
//        /// Load danh sách sản phẩm có sẵn từ tất cả các loại
//        /// </summary>
//        private void LoadAvailableProducts()
//        {
//            availableProducts.Clear();

//            // Load từ các data source khác nhau
//            DrinkProductData drinkData = new DrinkProductData();
//            FoodProductData foodData = new FoodProductData();
//            HouseholdProductData householdData = new HouseholdProductData();
//            ElectronicProductData electronicData = new ElectronicProductData();
//            ClothingProductData clothingData = new ClothingProductData();

//            availableProducts.AddRange(drinkData.GetData());
//            availableProducts.AddRange(foodData.GetData());
//            availableProducts.AddRange(householdData.GetData());
//            availableProducts.AddRange(electronicData.GetData());
//            availableProducts.AddRange(clothingData.GetData());

//            // Chỉ hiển thị sản phẩm có số lượng > 0
//            availableProducts = availableProducts.Where(p => p.Quantity > 0).ToList();

//            availableProductsBindingSource.DataSource = availableProducts;
//            availableProductsBindingSource.ResetBindings(true);
//        }

//        /// <summary>
//        /// Tạo combo mới
//        /// </summary>
//        private void btnNewCombo_Click(object sender, EventArgs e)
//        {
//            txtComboId.Text = "";
//            txtComboName.Text = "";
//            txtDescription.Text = "";
//            numDiscount.Value = 0;
//            numQuantity.Value = 1;

//            currentComposite = new ComboProduct();
//            productsInComboBindingSource.DataSource = new List<IProductComponent>();
//            productsInComboBindingSource.ResetBindings(true);

//            UpdatePriceDisplay();
//            statusLabel.Text = "Đã tạo combo mới";
//        }

//        /// <summary>
//        /// Lưu combo
//        /// </summary>
//        private void btnSaveCombo_Click(object sender, EventArgs e)
//        {
//            // Validation
//            if (string.IsNullOrWhiteSpace(txtComboId.Text))
//            {
//                MessageBox.Show("Mã combo không được để trống!", "Thông báo",
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                txtComboId.Focus();
//                return;
//            }

//            if (string.IsNullOrWhiteSpace(txtComboName.Text))
//            {
//                MessageBox.Show("Tên combo không được để trống!", "Thông báo",
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                txtComboName.Focus();
//                return;
//            }

//            if (currentComposite == null || currentComposite.GetChildCount() == 0)
//            {
//                MessageBox.Show("Combo phải có ít nhất 1 sản phẩm!", "Thông báo",
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            // Kiểm tra trùng mã combo
//            bool isNew = string.IsNullOrEmpty(currentComposite.Id);
//            if (isNew && compositeProducts.Any(c => c.Id.ToLower() == txtComboId.Text.ToLower()))
//            {
//                MessageBox.Show("Mã combo đã tồn tại! Vui lòng chọn mã khác.", "Thông báo",
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                txtComboId.Focus();
//                return;
//            }

//            // Tạo hoặc cập nhật composite
//            currentComposite.Id = txtComboId.Text;
//            currentComposite.Name = txtComboName.Text;
//            currentComposite.Description = txtDescription.Text;
//            currentComposite.DiscountPercentage = numDiscount.Value;

//            bool success;
//            if (isNew)
//            {
//                success = compositeProductData.AddCompositeProduct(currentComposite);
//                if (success)
//                {
//                    compositeProducts.Add(currentComposite);
//                }
//            }
//            else
//            {
//                success = compositeProductData.UpdateCompositeProduct(currentComposite);
//            }

//            if (success)
//            {
//                MessageBox.Show("Lưu combo thành công!", "Thông báo",
//                    MessageBoxButtons.OK, MessageBoxIcon.Information);
//                LoadCompositeProducts();
//                statusLabel.Text = "Đã lưu combo thành công";
//                statusLabel.ForeColor = Color.FromArgb(46, 204, 113);
//            }
//            else
//            {
//                MessageBox.Show("Lỗi khi lưu combo!", "Thông báo",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//                statusLabel.Text = "Lỗi khi lưu combo";
//                statusLabel.ForeColor = Color.Red;
//            }
//        }

//        /// <summary>
//        /// Xóa combo
//        /// </summary>
//        private void btnDeleteCombo_Click(object sender, EventArgs e)
//        {
//            if (currentComposite == null || string.IsNullOrEmpty(currentComposite.Id))
//            {
//                MessageBox.Show("Vui lòng chọn combo cần xóa!", "Thông báo",
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            DialogResult result = MessageBox.Show(
//                $"Bạn có chắc chắn muốn xóa combo '{currentComposite.Name}'?\n\nThao tác này không thể hoàn tác!",
//                "Xác nhận xóa",
//                MessageBoxButtons.YesNo,
//                MessageBoxIcon.Question);

//            if (result == DialogResult.Yes)
//            {
//                if (compositeProductData.DeleteCompositeProduct(currentComposite.Id))
//                {
//                    compositeProducts.Remove(currentComposite);
//                    MessageBox.Show("Xóa combo thành công!", "Thông báo",
//                        MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    LoadCompositeProducts();
//                    btnNewCombo_Click(sender, e); // Reset form
//                    statusLabel.Text = "Đã xóa combo thành công";
//                    statusLabel.ForeColor = Color.FromArgb(46, 204, 113);
//                }
//                else
//                {
//                    MessageBox.Show("Lỗi khi xóa combo!", "Thông báo",
//                        MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    statusLabel.Text = "Lỗi khi xóa combo";
//                    statusLabel.ForeColor = Color.Red;
//                }
//            }
//        }

//        /// <summary>
//        /// Thêm sản phẩm vào combo với số lượng
//        /// </summary>
//        private void btnAddToCombo_Click(object sender, EventArgs e)
//        {
//            if (currentComposite == null)
//            {
//                MessageBox.Show("Vui lòng tạo combo mới hoặc chọn combo cần chỉnh sửa!",
//                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            if (gridAvailableProducts.CurrentRow == null)
//            {
//                MessageBox.Show("Vui lòng chọn sản phẩm cần thêm!", "Thông báo",
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            if (numQuantity.Value <= 0)
//            {
//                MessageBox.Show("Số lượng phải lớn hơn 0!", "Thông báo",
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                numQuantity.Focus();
//                return;
//            }

//            Product selectedProduct = (Product)gridAvailableProducts.CurrentRow.DataBoundItem;
//            if (selectedProduct != null)
//            {
//                // Kiểm tra xem sản phẩm đã có trong combo chưa
//                var existingProduct = currentComposite.GetChildren()
//                    .OfType<Product>()
//                    .FirstOrDefault(p => p.Id == selectedProduct.Id);

//                if (existingProduct != null)
//                {
//                    // Nếu đã có, cập nhật số lượng
//                    var productInCombo = currentComposite.GetChildren()
//                        .FirstOrDefault(c => c.Id == selectedProduct.Id);

//                    if (productInCombo is Product product)
//                    {
//                        product.Quantity += (int)numQuantity.Value;
//                    }
//                }
//                else
//                {
//                    // Nếu chưa có, tạo bản sao của sản phẩm với số lượng mới
//                    Product productToAdd = CloneProductWithQuantity(selectedProduct, (int)numQuantity.Value);
//                    currentComposite.Add(productToAdd);
//                }

//                RefreshProductsInCombo();
//                UpdatePriceDisplay();

//                statusLabel.Text = $"Đã thêm {numQuantity.Value} {selectedProduct.Name} vào combo";
//            }
//        }

//        /// <summary>
//        /// Tạo bản sao sản phẩm với số lượng mới
//        /// </summary>
//        private Product CloneProductWithQuantity(Product original, int quantity)
//        {
//            // Tạo bản sao dựa trên loại sản phẩm
//            Product cloned = null;

//            if (original is DrinkProduct drink)
//            {
//                cloned = new DrinkProduct(drink.Id, drink.Name, drink.Price, quantity, drink.Carbonated);
//            }
//            else if (original is FoodProduct food)
//            {
//                cloned = new FoodProduct(food.Id, food.Name, food.Price, quantity, food.ExpirationDate);
//            }
//            else if (original is HouseholdProduct household)
//            {
//                cloned = new HouseholdProduct(household.Id, household.Name, household.Price, quantity, household.Brand);
//            }
//            else if (original is ElectronicProduct electronic)
//            {
//                cloned = new ElectronicProduct(electronic.Id, electronic.Name, electronic.Price, quantity, electronic.WarrantyPeriod);
//            }
//            else if (original is ClothingProduct clothing)
//            {
//                cloned = new ClothingProduct(clothing.Id, clothing.Name, clothing.Price, quantity, clothing.Size);
//            }
//            else
//            {
//                //// Fallback cho các loại sản phẩm khác
//                //cloned = new Product(original.Id, original.Name, original.Price, quantity, );
//            }

//            return cloned;
//        }

//        /// <summary>
//        /// Xóa sản phẩm khỏi combo
//        /// </summary>
//        private void btnRemoveFromCombo_Click(object sender, EventArgs e)
//        {
//            if (currentComposite == null)
//            {
//                MessageBox.Show("Không có combo nào đang được chỉnh sửa!", "Thông báo",
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            if (gridProductsInCombo.CurrentRow == null)
//            {
//                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Thông báo",
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            IProductComponent selectedComponent = (IProductComponent)gridProductsInCombo.CurrentRow.DataBoundItem;
//            if (selectedComponent != null)
//            {
//                string productName = selectedComponent.Name;
//                currentComposite.Remove(selectedComponent);
//                RefreshProductsInCombo();
//                UpdatePriceDisplay();

//                statusLabel.Text = $"Đã xóa {productName} khỏi combo";
//            }
//        }

//        /// <summary>
//        /// Refresh danh sách sản phẩm trong combo
//        /// </summary>
//        private void RefreshProductsInCombo()
//        {
//            if (currentComposite != null)
//            {
//                productsInComboBindingSource.DataSource = currentComposite.GetChildren().ToList();
//                productsInComboBindingSource.ResetBindings(true);
//            }
//        }

//        /// <summary>
//        /// Cập nhật hiển thị giá
//        /// </summary>
//        private void UpdatePriceDisplay()
//        {
//            if (currentComposite != null)
//            {
//                decimal originalPrice = currentComposite.GetOriginalPrice();
//                decimal finalPrice = currentComposite.Price;
//                decimal savings = originalPrice - finalPrice;

//                lblOriginalPrice.Text = $"Giá gốc: {originalPrice:N0} đ";
//                lblFinalPrice.Text = $"Giá sau giảm: {finalPrice:N0} đ";
//                lblSavings.Text = $"Tiết kiệm: {savings:N0} đ";

//                // Đổi màu theo giá trị
//                lblOriginalPrice.ForeColor = originalPrice > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
//                lblFinalPrice.ForeColor = finalPrice > 0 ? Color.FromArgb(65, 105, 225) : Color.Red;
//                lblSavings.ForeColor = savings > 0 ? Color.FromArgb(46, 204, 113) : Color.Gray;
//            }
//            else
//            {
//                lblOriginalPrice.Text = "Giá gốc: 0 đ";
//                lblFinalPrice.Text = "Giá sau giảm: 0 đ";
//                lblSavings.Text = "Tiết kiệm: 0 đ";

//                lblOriginalPrice.ForeColor = Color.Gray;
//                lblFinalPrice.ForeColor = Color.Gray;
//                lblSavings.ForeColor = Color.Gray;
//            }
//        }

//        /// <summary>
//        /// Khi chọn combo trong danh sách
//        /// </summary>
//        private void gridComboList_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (gridComboList.CurrentRow == null || gridComboList.CurrentRow.IsNewRow)
//                return;

//            currentComposite = (ComboProduct)gridComboList.CurrentRow.DataBoundItem;
//            if (currentComposite != null)
//            {
//                DisplayComposite(currentComposite);
//                statusLabel.Text = $"Đang chỉnh sửa combo: {currentComposite.Name}";
//            }
//        }

//        /// <summary>
//        /// Hiển thị thông tin combo
//        /// </summary>
//        private void DisplayComposite(ComboProduct composite)
//        {
//            txtComboId.Text = composite.Id;
//            txtComboName.Text = composite.Name;
//            txtDescription.Text = composite.Description;
//            numDiscount.Value = composite.DiscountPercentage;

//            RefreshProductsInCombo();
//            UpdatePriceDisplay();
//        }

//        /// <summary>
//        /// Khi thay đổi % giảm giá
//        /// </summary>
//        private void numDiscount_ValueChanged(object sender, EventArgs e)
//        {
//            if (currentComposite != null)
//            {
//                currentComposite.DiscountPercentage = numDiscount.Value;
//                UpdatePriceDisplay();
//            }
//        }

//        /// <summary>
//        /// Xem chi tiết combo
//        /// </summary>
//        private void btnViewDetails_Click(object sender, EventArgs e)
//        {
//            if (currentComposite == null)
//            {
//                MessageBox.Show("Vui lòng chọn combo!", "Thông báo",
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            string details = currentComposite.Info();
//            MessageBox.Show(details, "Chi tiết Combo - Composite Pattern",
//                MessageBoxButtons.OK, MessageBoxIcon.Information);
//        }

//        /// <summary>
//        /// Cập nhật thống kê
//        /// </summary>
//        private void UpdateStatistics()
//        {
//            int totalCombos = compositeProducts.Count;
//            int totalProductsInCombos = compositeProducts.Sum(c => c.GetChildCount());
//            decimal totalValue = compositeProducts.Sum(c => c.Price);
//            int activeCombos = compositeProducts.Count(c => c.GetChildCount() > 0);

//            lblTotalCombosValue.Text = totalCombos.ToString();
//            lblTotalProductsValue.Text = totalProductsInCombos.ToString();
//            lblTotalValueValue.Text = $"{totalValue:N0} đ";
//            lblActiveCombosValue.Text = activeCombos.ToString();

//            // Đổi màu theo số lượng
//            lblTotalCombosValue.ForeColor = totalCombos > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
//            lblTotalProductsValue.ForeColor = totalProductsInCombos > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
//            lblTotalValueValue.ForeColor = totalValue > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
//            lblActiveCombosValue.ForeColor = activeCombos > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
//        }

//        /// <summary>
//        /// Làm mới danh sách sản phẩm
//        /// </summary>
//        private void btnRefreshProducts_Click(object sender, EventArgs e)
//        {
//            LoadAvailableProducts();
//            statusLabel.Text = "Đã làm mới danh sách sản phẩm";
//        }

//        /// <summary>
//        /// Khi chọn sản phẩm trong danh sách có sẵn
//        /// </summary>
//        private void gridAvailableProducts_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (gridAvailableProducts.CurrentRow != null)
//            {
//                Product selectedProduct = (Product)gridAvailableProducts.CurrentRow.DataBoundItem;
//                if (selectedProduct != null)
//                {
//                    lblSelectedProduct.Text = $"Đã chọn: {selectedProduct.Name}";
//                    numQuantity.Maximum = selectedProduct.Quantity;
//                    numQuantity.Value = Math.Min(1, selectedProduct.Quantity);
//                }
//            }
//        }
//    }
//}

using OOP_finalProject.Base;
using OOP_finalProject.Data;
using OOP_finalProject.Interfaces;
using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OOP_finalProject.EntityForm
{
    public partial class ComboProductForm : Form
    {
        private ComboProductData compositeProductData = new ComboProductData();
        private List<ComboProduct> compositeProducts = new List<ComboProduct>();

        // Danh sách tất cả sản phẩm có sẵn để thêm vào combo
        private List<Product> availableProducts = new List<Product>();

        // Combo hiện tại đang chỉnh sửa
        private ComboProduct currentComposite = null;

        BindingSource comboBindingSource = new BindingSource();
        BindingSource productsInComboBindingSource = new BindingSource();
        BindingSource availableProductsBindingSource = new BindingSource();

        public ComboProductForm()
        {
            InitializeComponent();
        }

        private void CompositeProductForm_Load(object sender, EventArgs e)
        {
            // Cấu hình DataGridView
            gridComboList.DataSource = comboBindingSource;
            gridComboList.AllowUserToAddRows = false;
            gridComboList.ReadOnly = true;

            gridProductsInCombo.DataSource = productsInComboBindingSource;
            gridProductsInCombo.AllowUserToAddRows = false;
            gridProductsInCombo.ReadOnly = true;

            gridAvailableProducts.DataSource = availableProductsBindingSource;
            gridAvailableProducts.AllowUserToAddRows = false;
            gridAvailableProducts.ReadOnly = true;

            // Tùy chỉnh giao diện DataGridView
            CustomizeDataGridView(gridComboList);
            CustomizeDataGridView(gridProductsInCombo);
            CustomizeDataGridView(gridAvailableProducts);

            // Load dữ liệu
            LoadCompositeProducts();
            LoadAvailableProducts();

            // Thiết lập mặc định
            numQuantity.Value = 1;
            numComboQuantity.Value = 1; // Số lượng combo mặc định
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

        /// <summary>
        /// Load danh sách composite products
        /// </summary>
        private void LoadCompositeProducts()
        {
            compositeProducts = compositeProductData.GetData();
            comboBindingSource.DataSource = compositeProducts;
            comboBindingSource.ResetBindings(true);
            UpdateStatistics();
        }

        /// <summary>
        /// Load danh sách sản phẩm có sẵn từ tất cả các loại
        /// </summary>
        private void LoadAvailableProducts()
        {
            availableProducts.Clear();

            // Load từ các data source khác nhau
            DrinkProductData drinkData = new DrinkProductData();
            FoodProductData foodData = new FoodProductData();
            HouseholdProductData householdData = new HouseholdProductData();
            ElectronicProductData electronicData = new ElectronicProductData();
            ClothingProductData clothingData = new ClothingProductData();

            availableProducts.AddRange(drinkData.GetData());
            availableProducts.AddRange(foodData.GetData());
            availableProducts.AddRange(householdData.GetData());
            availableProducts.AddRange(electronicData.GetData());
            availableProducts.AddRange(clothingData.GetData());

            // Chỉ hiển thị sản phẩm có số lượng > 0
            availableProducts = availableProducts.Where(p => p.Quantity > 0).ToList();

            availableProductsBindingSource.DataSource = availableProducts;
            availableProductsBindingSource.ResetBindings(true);
        }

        /// <summary>
        /// Tạo combo mới
        /// </summary>
        private void btnNewCombo_Click(object sender, EventArgs e)
        {
            txtComboId.Text = "";
            txtComboName.Text = "";
            txtDescription.Text = "";
            numDiscount.Value = 0;
            numComboQuantity.Value = 1; // Số lượng combo mặc định
            numQuantity.Value = 1;

            currentComposite = new ComboProduct();
            productsInComboBindingSource.DataSource = new List<IProductComponent>();
            productsInComboBindingSource.ResetBindings(true);

            UpdatePriceDisplay();
            statusLabel.Text = "Đã tạo combo mới";
        }

        /// <summary>
        /// Lưu combo
        /// </summary>
        private void btnSaveCombo_Click(object sender, EventArgs e)
        {
            // Validation
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

            // Kiểm tra số lượng combo
            if (numComboQuantity.Value < 0)
            {
                MessageBox.Show("Số lượng combo không được âm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numComboQuantity.Focus();
                return;
            }

            // Kiểm tra trùng mã combo
            bool isNew = string.IsNullOrEmpty(currentComposite.Id);
            if (isNew && compositeProducts.Any(c => c.Id.ToLower() == txtComboId.Text.ToLower()))
            {
                MessageBox.Show("Mã combo đã tồn tại! Vui lòng chọn mã khác.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtComboId.Focus();
                return;
            }

            // Tạo hoặc cập nhật composite
            currentComposite.Id = txtComboId.Text;
            currentComposite.Name = txtComboName.Text;
            currentComposite.Description = txtDescription.Text;
            currentComposite.DiscountPercentage = numDiscount.Value;
            currentComposite.Quantity = (int)numComboQuantity.Value; // Cập nhật số lượng combo

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

        /// <summary>
        /// Xóa combo
        /// </summary>
        private void btnDeleteCombo_Click(object sender, EventArgs e)
        {
            if (currentComposite == null || string.IsNullOrEmpty(currentComposite.Id))
            {
                MessageBox.Show("Vui lòng chọn combo cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa combo '{currentComposite.Name}'?\n\nThao tác này không thể hoàn tác!",
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

        /// <summary>
        /// Thêm sản phẩm vào combo với số lượng
        /// </summary>
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
                // Kiểm tra xem sản phẩm đã có trong combo chưa
                var existingProduct = currentComposite.GetChildren()
                    .OfType<Product>()
                    .FirstOrDefault(p => p.Id == selectedProduct.Id);

                if (existingProduct != null)
                {
                    // Nếu đã có, cập nhật số lượng
                    var productInCombo = currentComposite.GetChildren()
                        .FirstOrDefault(c => c.Id == selectedProduct.Id);

                    if (productInCombo is Product product)
                    {
                        product.Quantity += (int)numQuantity.Value;
                    }
                }
                else
                {
                    // Nếu chưa có, tạo bản sao của sản phẩm với số lượng mới
                    Product productToAdd = CloneProductWithQuantity(selectedProduct, (int)numQuantity.Value);
                    currentComposite.Add(productToAdd);
                }

                RefreshProductsInCombo();
                UpdatePriceDisplay();

                statusLabel.Text = $"Đã thêm {numQuantity.Value} {selectedProduct.Name} vào combo";
            }
        }

        /// <summary>
        /// Tạo bản sao sản phẩm với số lượng mới
        /// </summary>
        private Product CloneProductWithQuantity(Product original, int quantity)
        {
            // Tạo bản sao dựa trên loại sản phẩm
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
            else
            {
                //// Fallback cho các loại sản phẩm khác
                //cloned = new Product(original.Id, original.Name, original.Price, quantity);
            }

            return cloned;
        }

        /// <summary>
        /// Xóa sản phẩm khỏi combo
        /// </summary>
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

                statusLabel.Text = $"Đã xóa {productName} khỏi combo";
            }
        }

        /// <summary>
        /// Refresh danh sách sản phẩm trong combo
        /// </summary>
        private void RefreshProductsInCombo()
        {
            if (currentComposite != null)
            {
                productsInComboBindingSource.DataSource = currentComposite.GetChildren().ToList();
                productsInComboBindingSource.ResetBindings(true);
            }
        }

        /// <summary>
        /// Cập nhật hiển thị giá
        /// </summary>
        private void UpdatePriceDisplay()
        {
            if (currentComposite != null)
            {
                decimal originalPrice = currentComposite.GetOriginalPrice();
                decimal finalPrice = currentComposite.Price;
                decimal savings = originalPrice - finalPrice;
                decimal inventoryValue = currentComposite.GetInventoryValue();

                lblOriginalPrice.Text = $"Giá gốc: {originalPrice:N0} đ";
                lblFinalPrice.Text = $"Giá sau giảm: {finalPrice:N0} đ";
                lblSavings.Text = $"Tiết kiệm: {savings:N0} đ";

                // Hiển thị thông tin tồn kho
                if (currentComposite.Quantity > 0)
                {
                    lblSavings.Text += $"\nTồn kho: {currentComposite.Quantity} combo\nGiá trị tồn kho: {inventoryValue:N0} đ";
                }

                // Đổi màu theo giá trị
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

        /// <summary>
        /// Khi chọn combo trong danh sách
        /// </summary>
        private void gridComboList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridComboList.CurrentRow == null || gridComboList.CurrentRow.IsNewRow)
                return;

            currentComposite = (ComboProduct)gridComboList.CurrentRow.DataBoundItem;
            if (currentComposite != null)
            {
                DisplayComposite(currentComposite);
                statusLabel.Text = $"Đang chỉnh sửa combo: {currentComposite.Name}";
            }
        }

        /// <summary>
        /// Hiển thị thông tin combo
        /// </summary>
        private void DisplayComposite(ComboProduct composite)
        {
            txtComboId.Text = composite.Id;
            txtComboName.Text = composite.Name;
            txtDescription.Text = composite.Description;
            numDiscount.Value = composite.DiscountPercentage;
            numComboQuantity.Value = composite.Quantity; // Hiển thị số lượng combo

            RefreshProductsInCombo();
            UpdatePriceDisplay();
        }

        /// <summary>
        /// Khi thay đổi % giảm giá
        /// </summary>
        private void numDiscount_ValueChanged(object sender, EventArgs e)
        {
            if (currentComposite != null)
            {
                currentComposite.DiscountPercentage = numDiscount.Value;
                UpdatePriceDisplay();
            }
        }

        /// <summary>
        /// Khi thay đổi số lượng combo
        /// </summary>
        private void numComboQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (currentComposite != null)
            {
                currentComposite.Quantity = (int)numComboQuantity.Value;
                UpdatePriceDisplay();

                // Cập nhật trạng thái
                if (currentComposite.Quantity == 0)
                {
                    statusLabel.Text = "Combo đã hết hàng";
                    statusLabel.ForeColor = Color.Red;
                }
                else if (currentComposite.Quantity < 10)
                {
                    statusLabel.Text = $"Cảnh báo: Chỉ còn {currentComposite.Quantity} combo";
                    statusLabel.ForeColor = Color.Orange;
                }
                else
                {
                    statusLabel.Text = $"Số lượng combo: {currentComposite.Quantity}";
                    statusLabel.ForeColor = Color.FromArgb(46, 204, 113);
                }
            }
        }

        /// <summary>
        /// Xem chi tiết combo
        /// </summary>
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

        /// <summary>
        /// Cập nhật thống kê (có tính số lượng combo)
        /// </summary>
        private void UpdateStatistics()
        {
            int totalCombos = compositeProducts.Count;
            int totalProductsInCombos = compositeProducts.Sum(c => c.GetChildCount());
            decimal totalValue = compositeProducts.Sum(c => c.GetInventoryValue()); // Tính theo giá trị tồn kho
            int activeCombos = compositeProducts.Count(c => c.GetChildCount() > 0);
            decimal totalComboQuantity = compositeProducts.Sum(c => c.Quantity); // Tổng số lượng combo

            lblTotalCombosValue.Text = totalCombos.ToString();
            lblTotalProductsValue.Text = totalProductsInCombos.ToString();
            lblTotalValueValue.Text = $"{totalValue:N0} đ";
            lblActiveCombosValue.Text = activeCombos.ToString();

            // Hiển thị thêm thông tin tổng số lượng combo
            if (totalComboQuantity > 0)
            {
                lblActiveCombosValue.Text += $"\nTổng SL: {totalComboQuantity}";
            }

            // Đổi màu theo số lượng
            lblTotalCombosValue.ForeColor = totalCombos > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalProductsValue.ForeColor = totalProductsInCombos > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalValueValue.ForeColor = totalValue > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblActiveCombosValue.ForeColor = activeCombos > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
        }

        /// <summary>
        /// Làm mới danh sách sản phẩm
        /// </summary>
        private void btnRefreshProducts_Click(object sender, EventArgs e)
        {
            LoadAvailableProducts();
            statusLabel.Text = "Đã làm mới danh sách sản phẩm";
        }

        /// <summary>
        /// Khi chọn sản phẩm trong danh sách có sẵn
        /// </summary>
        private void gridAvailableProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridAvailableProducts.CurrentRow != null)
            {
                Product selectedProduct = (Product)gridAvailableProducts.CurrentRow.DataBoundItem;
                if (selectedProduct != null)
                {
                    lblSelectedProduct.Text = $"Đã chọn: {selectedProduct.Name} (Tồn: {selectedProduct.Quantity})";
                    numQuantity.Maximum = selectedProduct.Quantity;
                    numQuantity.Value = Math.Min(1, selectedProduct.Quantity);
                }
            }
        }

        /// <summary>
        /// Kiểm tra tồn kho khi thay đổi số lượng combo
        /// </summary>
        private bool CheckInventoryForComboQuantity(int requestedQuantity)
        {
            if (currentComposite == null) return false;

            // Kiểm tra xem có đủ sản phẩm con để tạo số lượng combo mong muốn không
            var leafProducts = currentComposite.GetAllLeafProducts();
            foreach (var product in leafProducts)
            {
                // Mỗi combo cần 1 lượng sản phẩm con bằng số lượng của sản phẩm đó trong combo
                decimal requiredQuantity = product.Quantity * requestedQuantity;
                if (product.Quantity < requiredQuantity)
                {
                    MessageBox.Show($"Không đủ tồn kho cho sản phẩm: {product.Name}\n" +
                                  $"Cần: {requiredQuantity}, Hiện có: {product.Quantity}",
                                  "Cảnh báo tồn kho",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Nhập số lượng nhanh cho combo
        /// </summary>
        private void QuickSetComboQuantity(int quantity)
        {
            if (currentComposite != null && quantity >= 0)
            {
                numComboQuantity.Value = quantity;
                statusLabel.Text = $"Đã đặt số lượng combo thành {quantity}";
            }
        }
    }
}