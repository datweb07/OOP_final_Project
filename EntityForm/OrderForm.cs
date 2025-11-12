using OOP_finalProject.Base;
using OOP_finalProject.Data;
using OOP_finalProject.Employees;
using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
            InitializeDataGrid();
        }

        public OrderForm(Order order) : this()
        {
            this.order = order;
        }

        private OrderData orderData = new OrderData();
        private CashierData cashierData = new CashierData();
        private CustomerData customerData = new CustomerData();
        private DrinkProductData drinkProductData = new DrinkProductData();
        private FoodProductData foodProductData = new FoodProductData();
        private HouseholdProductData householdProductData = new HouseholdProductData();
        private ElectronicProductData electronicProductData = new ElectronicProductData();
        private ClothingProductData clothingProductData = new ClothingProductData();
        private ComboProductData comboProductData = new ComboProductData();

        private List<Order> orders;
        private List<Product> products = new List<Product>();
        private Order order;
        private BindingSource src = new BindingSource();

        private void InitializeDataGrid()
        {
            gridDataDetail.ReadOnly = true;
            gridDataDetail.AllowUserToAddRows = false;
            gridDataDetail.AutoGenerateColumns = false;  // tắt để thêm thủ công

            gridDataDetail.Columns.Clear();

            // thêm columns mới (thủ công)
            gridDataDetail.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ProductID",
                HeaderText = "Mã SP",
                Width = 80
            });

            gridDataDetail.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ProductName",
                HeaderText = "Tên sản phẩm",
                Width = 150,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            gridDataDetail.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "UnitPrice",
                HeaderText = "Đơn giá",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "N0" }
            });

            gridDataDetail.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Quantity",
                HeaderText = "Số lượng",
                Width = 80
            });

            gridDataDetail.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TotalPrice",
                HeaderText = "Tổng tiền",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "N0" }
            });

            gridDataDetail.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colDiscountedPrice",
                HeaderText = "Thành tiền",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "N0" }
            });

            gridDataDetail.DataSource = src;

            // tùy chỉnh giao diện cho DataGridView
            gridDataDetail.BorderStyle = BorderStyle.None;
            gridDataDetail.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 245);
            gridDataDetail.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            gridDataDetail.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 105, 225);
            gridDataDetail.DefaultCellStyle.SelectionForeColor = Color.White;
            gridDataDetail.BackgroundColor = Color.White;
            gridDataDetail.EnableHeadersVisualStyles = false;
            gridDataDetail.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            gridDataDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(65, 105, 225);
            gridDataDetail.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridDataDetail.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            LoadAllData();
            InitializeOrder();
            UpdateAllDisplays();
        }

        private void LoadAllData()
        {
            try
            {
                orders = orderData.GetData();
                LoadProducts();
                LoadSellers();
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCustomers()
        {
            try
            {
                List<Customer> customers = customerData.GetData();
                cboCustomer.DataSource = customers;
                cboCustomer.ValueMember = "Id";
                cboCustomer.DisplayMember = "Name";
                cboCustomer.SelectedIndexChanged += cboCustomer_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSellers()
        {
            try
            {
                List<Cashier> cashiers = cashierData.GetData();
                cboSeller.DataSource = cashiers;
                cboSeller.ValueMember = "Id";
                cboSeller.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            try
            {
                products.Clear();

                List<DrinkProduct> drinkProducts = drinkProductData.GetData();
                for (int i = 0; i < drinkProducts.Count; i++)
                {
                    products.Add(drinkProducts[i]);
                }

                List<FoodProduct> foodProducts = foodProductData.GetData();
                for (int i = 0; i < foodProducts.Count; i++)
                {
                    products.Add(foodProducts[i]);
                }

                List<HouseholdProduct> householdProducts = householdProductData.GetData();
                for (int i = 0; i < householdProducts.Count; i++)
                {
                    products.Add(householdProducts[i]);
                }

                List<ElectronicProduct> electronicProducts = electronicProductData.GetData();
                for (int i = 0; i < electronicProducts.Count; i++)
                {
                    products.Add(electronicProducts[i]);
                }

                List<ClothingProduct> clothingProducts = clothingProductData.GetData();
                for (int i = 0; i < clothingProducts.Count; i++)
                {
                    products.Add(clothingProducts[i]);
                }

                List<ComboProduct> comboProducts = comboProductData.GetData();
                for (int i = 0; i < comboProducts.Count; i++)
                {
                    products.Add(comboProducts[i]);
                }

                // hiển thị sản phẩm còn hàng
                List<Product> availableProducts = new List<Product>();
                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i].Quantity > 0)
                    {
                        availableProducts.Add(products[i]);
                    }
                }
                products = availableProducts;

                cboProduct.DataSource = products;
                cboProduct.ValueMember = "Id";
                cboProduct.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeOrder()
        {
            if (order == null)
            {
                order = new Order();
                txtCode.Text = order.OrderId;
                dtCreateDate.Value = order.OrderDate;
            }
            else
            {
                txtCode.Text = order.OrderId;
                dtCreateDate.Value = order.OrderDate;


                if (order.Cashier != null)
                    cboSeller.SelectedValue = order.Cashier.Id;

                if (order.Customer != null)
                    cboCustomer.SelectedValue = order.Customer.Id;
            }

            src.DataSource = order.OrderDetails;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            order = new Order();
            txtCode.Text = order.OrderId;
            dtCreateDate.Value = DateTime.Now;

            if (cboCustomer.Items.Count > 0) cboCustomer.SelectedIndex = 0;
            if (cboSeller.Items.Count > 0) cboSeller.SelectedIndex = 0;
            if (cboProduct.Items.Count > 0) cboProduct.SelectedIndex = 0;

            txtQty.Value = 1;
            src.DataSource = order.OrderDetails;
            src.ResetBindings(false);

            UpdateAllDisplays();
            statusLabel.Text = "Đã làm mới đơn hàng";
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (!ValidateAddProduct()) return;

            Product product = cboProduct.SelectedItem as Product;
            decimal quantity = txtQty.Value;

            // kiểm tra tồn kho
            if (product.Quantity < quantity)
            {
                MessageBox.Show("Sản phẩm không đủ số lượng! Chỉ còn " + product.Quantity + " sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // tìm hoặc thêm order detail
            OrderDetails existingDetail = null;
            for (int i = 0; i < order.OrderDetails.Count; i++)
            {
                if (order.OrderDetails[i].Product.Id == product.Id)
                {
                    existingDetail = order.OrderDetails[i];
                    break;
                }
            }

            if (existingDetail != null)
            {
                existingDetail.Quantity += quantity;
            }
            else
            {
                OrderDetails newDetail = new OrderDetails();
                newDetail.Product = product;
                newDetail.Quantity = quantity;
                order.OrderDetails.Add(newDetail);
            }

            // cập nhật số lượng hiển thị (không trừ thật cho đến khi save)
            product.Quantity -= quantity;

            RefreshDataGrid();
            UpdateAllDisplays();

            statusLabel.Text = "Đã thêm " + quantity + " " + product.Name + " vào đơn hàng";
        }

        private bool ValidateAddProduct()
        {
            if (order == null)
            {
                MessageBox.Show("Không có đơn hàng nào được khởi tạo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cboProduct.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboProduct.Focus();
                return false;
            }

            if (txtQty.Value <= 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQty.Focus();
                return false;
            }

            return true;
        }

        private void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            if (gridDataDetail.CurrentRow != null && gridDataDetail.CurrentRow.DataBoundItem is OrderDetails detail)
            {
                // trả lại số lương sản phẩm
                detail.Product.Quantity += detail.Quantity;
                order.OrderDetails.Remove(detail);

                RefreshDataGrid();
                UpdateAllDisplays();
                statusLabel.Text = "Đã xóa sản phẩm khỏi đơn hàng";
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateSave()) return;

            // cập nhật thông tin đơn hàng
            order.OrderId = txtCode.Text.Trim();
            order.OrderDate = dtCreateDate.Value;
            order.Cashier = cboSeller.SelectedItem as Cashier;
            order.Customer = cboCustomer.SelectedItem as Customer;

            // kiểm tra trùng order ID
            Order existingOrder = null;
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].OrderId == order.OrderId && orders[i] != order)
                {
                    existingOrder = orders[i];
                    break;
                }
            }

            if (existingOrder != null)
            {
                MessageBox.Show("Mã đơn hàng đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Focus();
                return;
            }

            // thêm hoặc cập nhật order
            bool containsOrder = false;
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i] == order)
                {
                    containsOrder = true;
                    break;
                }
            }

            if (!containsOrder)
                orders.Add(order);

            // lưu data
            orderData.SaveData(orders);
            UpdateProductQuantities();
            LoadProducts(); // reload products để cập nhật số lượng

            MessageBox.Show("Lưu đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            statusLabel.Text = "Đã lưu đơn hàng thành công";
            statusLabel.ForeColor = Color.Green;
        }

        private bool ValidateSave()
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Mã đơn hàng không được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Focus();
                return false;
            }

            if (cboSeller.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên bán hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboSeller.Focus();
                return false;
            }

            if (cboCustomer.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboCustomer.Focus();
                return false;
            }

            if (order.OrderDetails.Count == 0)
            {
                MessageBox.Show("Đơn hàng phải có ít nhất một sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void UpdateProductQuantities()
        {
            // cập nhật số lượng sản phẩm trong product
            for (int i = 0; i < order.OrderDetails.Count; i++)
            {
                UpdateProductInventory(order.OrderDetails[i].Product, order.OrderDetails[i].Quantity);
            }
        }

        private void UpdateProductInventory(Product product, decimal quantity)
        {
            List<Product> allProducts = new List<Product>();

            List<DrinkProduct> drinkProducts = drinkProductData.GetData();
            for (int i = 0; i < drinkProducts.Count; i++)
            {
                allProducts.Add(drinkProducts[i]);
            }

            List<FoodProduct> foodProducts = foodProductData.GetData();
            for (int i = 0; i < foodProducts.Count; i++)
            {
                allProducts.Add(foodProducts[i]);
            }

            List<HouseholdProduct> householdProducts = householdProductData.GetData();
            for (int i = 0; i < householdProducts.Count; i++)
            {
                allProducts.Add(householdProducts[i]);
            }

            List<ElectronicProduct> electronicProducts = electronicProductData.GetData();
            for (int i = 0; i < electronicProducts.Count; i++)
            {
                allProducts.Add(electronicProducts[i]);
            }

            List<ClothingProduct> clothingProducts = clothingProductData.GetData();
            for (int i = 0; i < clothingProducts.Count; i++)
            {
                allProducts.Add(clothingProducts[i]);
            }

            List<ComboProduct> comboProducts = comboProductData.GetData();
            for (int i = 0; i < comboProducts.Count; i++)
            {
                allProducts.Add(comboProducts[i]);
            }

            Product targetProduct = null;
            for (int i = 0; i < allProducts.Count; i++)
            {
                if (allProducts[i].Id == product.Id)
                {
                    targetProduct = allProducts[i];
                    break;
                }
            }

            if (targetProduct != null)
            {
                targetProduct.Quantity -= quantity;
                if (targetProduct.Quantity < 0) targetProduct.Quantity = 0;
            }

            // Save all product types
            drinkProductData.SaveData(GetProductsOfType<DrinkProduct>(allProducts));
            foodProductData.SaveData(GetProductsOfType<FoodProduct>(allProducts));
            householdProductData.SaveData(GetProductsOfType<HouseholdProduct>(allProducts));
            electronicProductData.SaveData(GetProductsOfType<ElectronicProduct>(allProducts));
            clothingProductData.SaveData(GetProductsOfType<ClothingProduct>(allProducts));
            comboProductData.SaveData(GetProductsOfType<ComboProduct>(allProducts));
        }

        private List<T> GetProductsOfType<T>(List<Product> products) where T : Product
        {
            List<T> result = new List<T>();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i] is T)
                {
                    result.Add((T)products[i]);
                }
            }
            return result;
        }

        private void UpdateAllDisplays()
        {
            UpdateDiscountDisplay();
            UpdateStatistics();
            UpdateGridDiscountedPrices();
        }

        private void UpdateDiscountDisplay()
        {
            if (order == null || order.Customer == null) return;

            lblSubTotalValue.Text = order.SumTotal.ToString("N0") + " đ";
            lblDiscountValue.Text = order.DiscountAmount.ToString("N0") + " đ";
            lblFinalTotalValue.Text = order.FinalTotal.ToString("N0") + " đ";
            lblDiscountPercentValue.Text = order.DiscountPercentage.ToString() + "%";
            lblCustomerTypeValue.Text = order.Customer.CustomerType;

            lblSubTotalValue.ForeColor = Color.FromArgb(46, 204, 113);
            lblDiscountValue.ForeColor = Color.FromArgb(255, 165, 0);
            lblFinalTotalValue.ForeColor = Color.FromArgb(65, 105, 225);
        }

        private void UpdateStatistics()
        {
            if (order == null) return;

            lblItemCountValue.Text = order.OrderDetails.Count.ToString();

            int totalQuantity = 0;
            for (int i = 0; i < order.OrderDetails.Count; i++)
            {
                totalQuantity += (int)order.OrderDetails[i].Quantity;
            }
            lblProductCountValue.Text = totalQuantity.ToString();

            lblOrderValueValue.Text = order.SumTotal.ToString("N0") + " đ";

            Color positiveColor = Color.FromArgb(46, 204, 113);
            Color zeroColor = Color.Red;

            lblItemCountValue.ForeColor = order.OrderDetails.Count > 0 ? positiveColor : zeroColor;
            lblProductCountValue.ForeColor = totalQuantity > 0 ? positiveColor : zeroColor;
            lblOrderValueValue.ForeColor = order.SumTotal > 0 ? positiveColor : zeroColor;
        }

        private void UpdateGridDiscountedPrices()
        {
            if (order == null || gridDataDetail.Rows.Count == 0) return;

            for (int i = 0; i < gridDataDetail.Rows.Count; i++)
            {
                DataGridViewRow row = gridDataDetail.Rows[i];
                if (row.DataBoundItem is OrderDetails detail && row.Cells["colDiscountedPrice"] != null)
                {
                    decimal discountedPrice = order.GetDiscountedPriceForDetail(detail);
                    row.Cells["colDiscountedPrice"].Value = discountedPrice;

                    // Visual feedback
                    if (discountedPrice < detail.TotalPrice)
                    {
                        row.Cells["colDiscountedPrice"].Style.ForeColor = Color.Green;
                        row.Cells["colDiscountedPrice"].Style.Font = new Font(gridDataDetail.Font, FontStyle.Bold);
                    }
                    else
                    {
                        row.Cells["colDiscountedPrice"].Style.ForeColor = Color.Black;
                        row.Cells["colDiscountedPrice"].Style.Font = gridDataDetail.Font;
                    }
                }
            }
        }

        private void RefreshDataGrid()
        {
            src.ResetBindings(false);
            gridDataDetail.Refresh();
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomer.SelectedItem is Customer customer)
            {
                order.Customer = customer;
                UpdateAllDisplays();
            }
        }

        private void gridDataDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (gridDataDetail.CurrentRow != null && gridDataDetail.CurrentRow.DataBoundItem is OrderDetails detail)
            {
                cboProduct.SelectedValue = detail.Product.Id;
                txtQty.Value = detail.Quantity;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã đơn hàng không được để trống !"
                  , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Order toDelete = null;

            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].OrderId.ToLower() == txtCode.Text.ToLower())
                {
                    toDelete = orders[i];
                    break;
                }
            }

            if (toDelete == null)
            {
                MessageBox.Show("Không tìm thấy đơn hàng cần xoá !"
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cập nhật lại số lượng sản phẩm
            List<DrinkProduct> drinkProducts = drinkProductData.GetData();
            List<FoodProduct> foodProducts = foodProductData.GetData();
            List<HouseholdProduct> householdProducts = householdProductData.GetData();
            List<ElectronicProduct> electronicProducts = electronicProductData.GetData();
            List<ClothingProduct> clothingProducts = clothingProductData.GetData();
            List<ComboProduct> comboProducts = comboProductData.GetData();

            for (int i = 0; i < toDelete.OrderDetails.Count; i++)
            {
                if (toDelete.OrderDetails[i].Product is DrinkProduct)
                {
                    for (int j = 0; j < drinkProducts.Count; j++)
                    {
                        if (drinkProducts[j].Id.ToLower() == toDelete.OrderDetails[i].Product.Id.ToLower())
                        {
                            drinkProducts[j].Quantity = drinkProducts[j].Quantity + toDelete.OrderDetails[i].Quantity;
                            break;
                        }
                    }
                }

                if (toDelete.OrderDetails[i].Product is FoodProduct)
                {
                    for (int j = 0; j < foodProducts.Count; j++)
                    {
                        if (foodProducts[j].Id.ToLower() == toDelete.OrderDetails[i].Product.Id.ToLower())
                        {
                            foodProducts[j].Quantity = foodProducts[j].Quantity + toDelete.OrderDetails[i].Quantity;
                            break;
                        }
                    }
                }

                if (toDelete.OrderDetails[i].Product is HouseholdProduct)
                {
                    for (int j = 0; j < householdProducts.Count; j++)
                    {
                        if (householdProducts[j].Id.ToLower() == toDelete.OrderDetails[i].Product.Id.ToLower())
                        {
                            householdProducts[j].Quantity = householdProducts[j].Quantity + toDelete.OrderDetails[i].Quantity;
                            break;
                        }
                    }
                }

                if (toDelete.OrderDetails[i].Product is ElectronicProduct)
                {
                    for (int j = 0; j < electronicProducts.Count; j++)
                    {
                        if (electronicProducts[j].Id.ToLower() == toDelete.OrderDetails[i].Product.Id.ToLower())
                        {
                            electronicProducts[j].Quantity = electronicProducts[j].Quantity + toDelete.OrderDetails[i].Quantity;
                            break;
                        }
                    }
                }

                if (toDelete.OrderDetails[i].Product is ClothingProduct)
                {
                    for (int j = 0; j < clothingProducts.Count; j++)
                    {
                        if (clothingProducts[j].Id.ToLower() == toDelete.OrderDetails[i].Product.Id.ToLower())
                        {
                            clothingProducts[j].Quantity = clothingProducts[j].Quantity + toDelete.OrderDetails[i].Quantity;
                            break;
                        }
                    }
                }

                if (toDelete.OrderDetails[i].Product is ComboProduct)
                {
                    for (int j = 0; j < comboProducts.Count; j++)
                    {
                        if (comboProducts[j].Id.ToLower() == toDelete.OrderDetails[i].Product.Id.ToLower())
                        {
                            comboProducts[j].Quantity = comboProducts[j].Quantity + toDelete.OrderDetails[i].Quantity;
                            break;
                        }
                    }
                }
            }

            drinkProductData.SaveData(drinkProducts);
            foodProductData.SaveData(foodProducts);
            householdProductData.SaveData(householdProducts);
            electronicProductData.SaveData(electronicProducts);
            clothingProductData.SaveData(clothingProducts);
            comboProductData.SaveData(comboProducts);

            // Nạp lại số lượng thực tế
            LoadProducts();

            txtCode.Text = "";
            dtCreateDate.Value = DateTime.Now;
            cboCustomer.SelectedIndex = 0;
            cboSeller.SelectedIndex = 0;
            cboProduct.SelectedIndex = 0;
            txtQty.Value = 0;

            MessageBox.Show("Xoá thông tin đơn hàng thành công ! "
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnViewInvoice_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã đơn hàng không được để trống !"
                  , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Order order = null;

            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].OrderId.ToLower() == txtCode.Text.ToLower())
                {
                    order = orders[i];
                    break;
                }
            }

            if (order == null)
            {
                MessageBox.Show("Không tìm thấy đơn hàng ! "
               , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Invoice invoice = new Invoice();
            invoice.Id = order.OrderId;
            invoice.DateCreated = order.OrderDate;
            invoice.Cashier = order.Cashier;
            invoice.Customer = order.Customer;

            for (int i = 0; i < order.OrderDetails.Count; i++)
            {
                InvoiceDetails invoiceDetail = new InvoiceDetails();
                invoiceDetail.ProductID = order.OrderDetails[i].Product.Id;
                invoiceDetail.ProductName = order.OrderDetails[i].Product.Name;
                invoiceDetail.Quantity = order.OrderDetails[i].Quantity;
                invoiceDetail.UnitPrice = order.OrderDetails[i].Product.Price;
                invoice.InvoiceDetails.Add(invoiceDetail);
            }

            InvoiceForm frm = new InvoiceForm(invoice);
            frm.ShowDialog();
        }
    }
}