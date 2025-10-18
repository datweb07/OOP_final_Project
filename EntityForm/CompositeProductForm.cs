using OOP_finalProject.Base;
using OOP_finalProject.Data;
using OOP_finalProject.Interfaces;
using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OOP_finalProject.EntityForm
{
    public partial class CompositeProductForm : Form
    {
        private CompositeProductData compositeProductData = new CompositeProductData();
        private List<CompositeProduct> compositeProducts = new List<CompositeProduct>();

        // Danh sách tất cả sản phẩm có sẵn để thêm vào combo
        private List<Product> availableProducts = new List<Product>();

        // Combo hiện tại đang chỉnh sửa
        private CompositeProduct currentComposite = null;

        BindingSource comboBindingSource = new BindingSource();
        BindingSource productsInComboBindingSource = new BindingSource();
        BindingSource availableProductsBindingSource = new BindingSource();

        public CompositeProductForm()
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

            // Load dữ liệu
            LoadCompositeProducts();
            LoadAvailableProducts();
        }

        /// <summary>
        /// Load danh sách composite products
        /// </summary>
        private void LoadCompositeProducts()
        {
            compositeProducts = compositeProductData.GetData();
            comboBindingSource.DataSource = compositeProducts;
            comboBindingSource.ResetBindings(true);
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

            currentComposite = new CompositeProduct();
            productsInComboBindingSource.DataSource = new List<IProductComponent>();
            productsInComboBindingSource.ResetBindings(true);

            UpdatePriceDisplay();
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
                return;
            }

            if (string.IsNullOrWhiteSpace(txtComboName.Text))
            {
                MessageBox.Show("Tên combo không được để trống!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentComposite == null || currentComposite.GetChildCount() == 0)
            {
                MessageBox.Show("Combo phải có ít nhất 1 sản phẩm!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo hoặc cập nhật composite
            bool isNew = string.IsNullOrEmpty(currentComposite.Id);

            currentComposite.Id = txtComboId.Text;
            currentComposite.Name = txtComboName.Text;
            currentComposite.Description = txtDescription.Text;
            currentComposite.DiscountPercentage = numDiscount.Value;

            bool success;
            if (isNew || !compositeProducts.Exists(c => c.Id == currentComposite.Id))
            {
                success = compositeProductData.AddCompositeProduct(currentComposite);
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
            }
            else
            {
                MessageBox.Show("Lỗi khi lưu combo!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                $"Bạn có chắc chắn muốn xóa combo '{currentComposite.Name}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (compositeProductData.DeleteCompositeProduct(currentComposite.Id))
                {
                    MessageBox.Show("Xóa combo thành công!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCompositeProducts();
                    btnNewCombo_Click(sender, e); // Reset form
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa combo!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Thêm sản phẩm vào combo
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

            Product selectedProduct = (Product)gridAvailableProducts.CurrentRow.DataBoundItem;
            if (selectedProduct != null)
            {
                // Kiểm tra xem sản phẩm đã có trong combo chưa
                if (currentComposite.GetChildren().Any(c => c.Id == selectedProduct.Id))
                {
                    MessageBox.Show("Sản phẩm này đã có trong combo!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                currentComposite.Add(selectedProduct);
                RefreshProductsInCombo();
                UpdatePriceDisplay();
            }
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
                currentComposite.Remove(selectedComponent);
                RefreshProductsInCombo();
                UpdatePriceDisplay();
            }
        }

        /// <summary>
        /// Refresh danh sách sản phẩm trong combo
        /// </summary>
        private void RefreshProductsInCombo()
        {
            if (currentComposite != null)
            {
                productsInComboBindingSource.DataSource = currentComposite.GetChildren();
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
                lblOriginalPrice.Text = $"Giá gốc: {currentComposite.GetOriginalPrice():C}";
                lblFinalPrice.Text = $"Giá sau giảm: {currentComposite.Price:C}";
                lblSavings.Text = $"Tiết kiệm: {(currentComposite.GetOriginalPrice() - currentComposite.Price):C}";
            }
            else
            {
                lblOriginalPrice.Text = "Giá gốc: 0 ₫";
                lblFinalPrice.Text = "Giá sau giảm: 0 ₫";
                lblSavings.Text = "Tiết kiệm: 0 ₫";
            }
        }

        /// <summary>
        /// Khi chọn combo trong danh sách
        /// </summary>
        private void gridComboList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (gridComboList.CurrentRow == null || gridComboList.CurrentRow.IsNewRow)
                return;

            currentComposite = (CompositeProduct)gridComboList.CurrentRow.DataBoundItem;
            if (currentComposite != null)
            {
                DisplayComposite(currentComposite);
            }
        }

        /// <summary>
        /// Hiển thị thông tin combo
        /// </summary>
        private void DisplayComposite(CompositeProduct composite)
        {
            txtComboId.Text = composite.Id;
            txtComboName.Text = composite.Name;
            txtDescription.Text = composite.Description;
            numDiscount.Value = composite.DiscountPercentage;

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
            MessageBox.Show(details, "Chi tiết Combo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
