using OOP_finalProject.Base;
using OOP_finalProject.Data;
using OOP_finalProject.Employees;
using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            _order = order;
        }

        private OrderData orderDAL = new OrderData();
        private CashierData cashierDAL = new CashierData();
        private CustomerData customerDAL = new CustomerData();
        private DrinkProductData drinkProductData = new DrinkProductData();
        private FoodProductData foodProductData = new FoodProductData();
        private HouseholdProductData householdProductData = new HouseholdProductData();
        private ElectronicProductData electronicProductData = new ElectronicProductData();
        private ClothingProductData clothingProductData = new ClothingProductData();
        private ComboProductData comboProductData = new ComboProductData(); 

        private List<Order> orders;
        private List<Product> products = new List<Product>();
        private Order _order;
        private BindingSource src = new BindingSource();

        private void InitializeDataGrid()
        {
            gridDataDetail.ReadOnly = true;
            gridDataDetail.AllowUserToAddRows = false;
            gridDataDetail.AutoGenerateColumns = false;

            // Xóa columns cũ
            gridDataDetail.Columns.Clear();

            // Thêm columns mới
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
                HeaderText = "Tổng tiền (gốc)",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "N0" }
            });

            // Column hiển thị giá sau discount
            gridDataDetail.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colDiscountedPrice",
                HeaderText = "Thành tiền (sau KM)",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "N0" }
            });

            gridDataDetail.DataSource = src;

            // Styling
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

            // Test debug
            TestCurrentOrder();
        }

        private void LoadAllData()
        {
            try
            {
                orders = orderDAL.GetData();
                LoadProducts();
                LoadSellers();
                LoadCustomers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCustomers()
        {
            try
            {
                List<Customer> customers = customerDAL.GetData();
                cboCustomer.DataSource = customers;
                cboCustomer.ValueMember = "Id";
                cboCustomer.DisplayMember = "Name";
                cboCustomer.SelectedIndexChanged += cboCustomer_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSellers()
        {
            try
            {
                List<Cashier> cashiers = cashierDAL.GetData();
                cboSeller.DataSource = cashiers;
                cboSeller.ValueMember = "Id";
                cboSeller.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadProducts()
        {
            try
            {
                products.Clear();
                products.AddRange(drinkProductData.GetData());
                products.AddRange(foodProductData.GetData());
                products.AddRange(householdProductData.GetData());
                products.AddRange(electronicProductData.GetData());
                products.AddRange(clothingProductData.GetData());
                products.AddRange(comboProductData.GetData());


                // Chỉ hiển thị sản phẩm còn hàng
                products = products.Where(p => p.Quantity > 0).ToList();

                cboProduct.DataSource = products;
                cboProduct.ValueMember = "Id";
                cboProduct.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load sản phẩm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeOrder()
        {
            if (_order == null)
            {
                _order = new Order();
                txtCode.Text = _order.OrderId;
                dtCreateDate.Value = _order.OrderDate;
            }
            else
            {
                txtCode.Text = _order.OrderId;
                dtCreateDate.Value = _order.OrderDate;

                // Select cashier và customer nếu có
                if (_order.Cashier != null)
                    cboSeller.SelectedValue = _order.Cashier.Id;

                if (_order.Customer != null)
                    cboCustomer.SelectedValue = _order.Customer.Id;
            }

            src.DataSource = _order.OrderDetails;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _order = new Order();
            txtCode.Text = _order.OrderId;
            dtCreateDate.Value = DateTime.Now;

            if (cboCustomer.Items.Count > 0) cboCustomer.SelectedIndex = 0;
            if (cboSeller.Items.Count > 0) cboSeller.SelectedIndex = 0;
            if (cboProduct.Items.Count > 0) cboProduct.SelectedIndex = 0;

            txtQty.Value = 1;
            src.DataSource = _order.OrderDetails;
            src.ResetBindings(false);

            UpdateAllDisplays();
            statusLabel.Text = "Đã làm mới đơn hàng";
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (!ValidateAddProduct()) return;

            var product = cboProduct.SelectedItem as Product;
            var quantity = txtQty.Value;

            // Kiểm tra số lượng tồn kho
            if (product.Quantity < quantity)
            {
                MessageBox.Show($"Sản phẩm không đủ số lượng! Chỉ còn {product.Quantity} sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tìm hoặc thêm order detail
            var existingDetail = _order.OrderDetails.FirstOrDefault(od => od.Product.Id == product.Id);
            if (existingDetail != null)
            {
                existingDetail.Quantity += quantity;
            }
            else
            {
                _order.OrderDetails.Add(new OrderDetails
                {
                    Product = product,
                    Quantity = quantity
                });
            }

            // Cập nhật số lượng hiển thị (không trừ thật cho đến khi save)
            product.Quantity -= quantity;

            RefreshDataGrid();
            UpdateAllDisplays();

            statusLabel.Text = $"Đã thêm {quantity} {product.Name} vào đơn hàng";
        }

        private bool ValidateAddProduct()
        {
            if (_order == null)
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
            if (gridDataDetail.CurrentRow?.DataBoundItem is OrderDetails detail)
            {
                // Trả lại số lượng cho sản phẩm
                detail.Product.Quantity += detail.Quantity;
                _order.OrderDetails.Remove(detail);

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

            // Cập nhật thông tin order
            _order.OrderId = txtCode.Text.Trim();
            _order.OrderDate = dtCreateDate.Value;
            _order.Cashier = cboSeller.SelectedItem as Cashier;
            _order.Customer = cboCustomer.SelectedItem as Customer;

            // Kiểm tra trùng order ID
            var existingOrder = orders.FirstOrDefault(o => o.OrderId == _order.OrderId && o != _order);
            if (existingOrder != null)
            {
                MessageBox.Show("Mã đơn hàng đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Focus();
                return;
            }

            // Thêm hoặc cập nhật order
            if (!orders.Contains(_order))
                orders.Add(_order);

            // Lưu dữ liệu
            orderDAL.SaveData(orders);
            UpdateProductQuantities();
            LoadProducts(); // Reload products để cập nhật số lượng

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

            if (_order.OrderDetails.Count == 0)
            {
                MessageBox.Show("Đơn hàng phải có ít nhất một sản phẩm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void UpdateProductQuantities()
        {
            // Cập nhật số lượng sản phẩm trong inventory
            foreach (var detail in _order.OrderDetails)
            {
                UpdateProductInventory(detail.Product, detail.Quantity);
            }
        }

        private void UpdateProductInventory(Product product, decimal quantity)
        {
            // Implementation depends on your product data structure
            // This is a simplified version
            var allProducts = new List<Product>();
            allProducts.AddRange(drinkProductData.GetData());
            allProducts.AddRange(foodProductData.GetData());
            allProducts.AddRange(householdProductData.GetData());
            allProducts.AddRange(electronicProductData.GetData());
            allProducts.AddRange(clothingProductData.GetData());
            allProducts.AddRange(comboProductData.GetData());

            var targetProduct = allProducts.FirstOrDefault(p => p.Id == product.Id);
            if (targetProduct != null)
            {
                targetProduct.Quantity -= quantity;
                if (targetProduct.Quantity < 0) targetProduct.Quantity = 0;
            }

            // Save all product types
            drinkProductData.SaveData(allProducts.OfType<DrinkProduct>().ToList());
            foodProductData.SaveData(allProducts.OfType<FoodProduct>().ToList());
            householdProductData.SaveData(allProducts.OfType<HouseholdProduct>().ToList());
            electronicProductData.SaveData(allProducts.OfType<ElectronicProduct>().ToList());
            clothingProductData.SaveData(allProducts.OfType<ClothingProduct>().ToList());
            comboProductData.SaveData(allProducts.OfType<ComboProduct>().ToList());
        }

        private void UpdateAllDisplays()
        {
            UpdateDiscountDisplay();
            UpdateStatistics();
            UpdateGridDiscountedPrices();
        }

        private void UpdateDiscountDisplay()
        {
            if (_order?.Customer == null) return;

            lblSubTotalValue.Text = $"{_order.SumTotal:N0} đ";
            lblDiscountValue.Text = $"{_order.DiscountAmount:N0} đ";
            lblFinalTotalValue.Text = $"{_order.FinalTotal:N0} đ";
            lblDiscountPercentValue.Text = $"{_order.DiscountPercentage}%";
            lblCustomerTypeValue.Text = _order.Customer.CustomerType;

            // Màu sắc
            lblSubTotalValue.ForeColor = Color.FromArgb(46, 204, 113);
            lblDiscountValue.ForeColor = Color.FromArgb(255, 165, 0);
            lblFinalTotalValue.ForeColor = Color.FromArgb(65, 105, 225);
        }

        private void UpdateStatistics()
        {
            if (_order == null) return;

            lblItemCountValue.Text = _order.OrderDetails.Count.ToString();
            lblProductCountValue.Text = _order.OrderDetails.Sum(od => (int)od.Quantity).ToString();
            lblOrderValueValue.Text = $"{_order.SumTotal:N0} đ";

            var positiveColor = Color.FromArgb(46, 204, 113);
            var zeroColor = Color.Red;

            lblItemCountValue.ForeColor = _order.OrderDetails.Count > 0 ? positiveColor : zeroColor;
            lblProductCountValue.ForeColor = _order.OrderDetails.Sum(od => od.Quantity) > 0 ? positiveColor : zeroColor;
            lblOrderValueValue.ForeColor = _order.SumTotal > 0 ? positiveColor : zeroColor;
        }

        private void UpdateGridDiscountedPrices()
        {
            if (_order == null || gridDataDetail.Rows.Count == 0) return;

            for (int i = 0; i < gridDataDetail.Rows.Count; i++)
            {
                var row = gridDataDetail.Rows[i];
                if (row.DataBoundItem is OrderDetails detail && row.Cells["colDiscountedPrice"] != null)
                {
                    decimal discountedPrice = _order.GetDiscountedPriceForDetail(detail);
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
                _order.Customer = customer;
                UpdateAllDisplays();
            }
        }

        private void gridDataDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (gridDataDetail.CurrentRow?.DataBoundItem is OrderDetails detail)
            {
                cboProduct.SelectedValue = detail.Product.Id;
                txtQty.Value = detail.Quantity;
            }
        }

        private void gridDataDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Cell formatting sẽ được xử lý trong UpdateGridDiscountedPrices
        }

        private void TestCurrentOrder()
        {
            if (_order == null) return;

            Console.WriteLine("=== DEBUG ORDER INFO ===");
            Console.WriteLine($"Order ID: {_order.OrderId}");
            Console.WriteLine($"Customer: {_order.Customer?.Name} - {_order.Customer?.CustomerType}");
            Console.WriteLine($"Discount: {_order.DiscountPercentage}%");
            Console.WriteLine($"Total: {_order.SumTotal:N0} -> {_order.FinalTotal:N0}");
            Console.WriteLine("========================");
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
                    for (int j = 0; i < electronicProducts.Count; j++)
                    {
                        if (electronicProducts[j].Id.ToLower() == toDelete.OrderDetails[i].Product?.Id.ToLower())
                        {
                            electronicProducts[j].Quantity = electronicProducts[j].Quantity + toDelete.OrderDetails[i].Quantity; 
                            break;
                        }
                    }
                }

                if (toDelete.OrderDetails[i].Product is ClothingProduct)
                {
                    for (int j = 0; i < clothingProducts.Count; j++)
                    {
                        if (clothingProducts[j].Id.ToLower() == toDelete.OrderDetails[i].Product?.Id.ToLower())
                        {
                            clothingProducts[j].Quantity = clothingProducts[j].Quantity + toDelete.OrderDetails[i].Quantity;
                            break;
                        }
                    }
                }

                if (toDelete.OrderDetails[i].Product is ComboProduct)
                {
                    for (int j = 0; i < comboProducts.Count; j++)
                    {
                        if (comboProducts[j].Id.ToLower() == toDelete.OrderDetails[i].Product?.Id.ToLower())
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
            return;
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
            }

            Invoice invoice = new Invoice();
            invoice.Id = order.OrderId;
            invoice.DateCreated = order.OrderDate;
            invoice.Cashier = order.Cashier;
            invoice.Customer = order.Customer;

            for (int i = 0; i < order.OrderDetails.Count; i++)
            {
                invoice.InvoiceDetails.Add(new InvoiceDetails()
                {
                    ProductID = order.OrderDetails[i].Product.Id,
                    ProductName = order.OrderDetails[i].Product.Name,
                    Quantity = order.OrderDetails[i].Quantity,
                    UnitPrice = order.OrderDetails[i].Product.Price
                });

            }

            InvoiceForm frm = new InvoiceForm(invoice);
            frm.ShowDialog();
        }
    }
}