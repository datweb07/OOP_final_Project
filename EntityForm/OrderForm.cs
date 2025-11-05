<<<<<<< HEAD
//using OOP_finalProject.Base;
//using OOP_finalProject.Employees;
//using OOP_finalProject.Products;
//using System;
//using System.Collections.Generic;
//using System.Windows.Forms;

//namespace OOP_finalProject
//{
//    public partial class OrderForm : Form
//    {
//        public OrderForm()
//        {
//            InitializeComponent();
//        }

//        public OrderForm(Order order)
//            : this()
//        {
//            _order = order;
//        }

//        private OrderData orderDAL = new OrderData();
//        private CashierData cashierDAL = new CashierData();
//        private CustomerData customerDAL = new CustomerData();
//        private DrinkProductData drinkProductData = new DrinkProductData();
//        private FoodProductData foodProductData = new FoodProductData();
//        private HouseholdProductData householdProductData = new HouseholdProductData();
//        private List<Order> orders;
//        private List<Product> products = new List<Product>();
//        private void FormOrder_Load(object sender, EventArgs e)
//        {
//            gridDataDetail.ReadOnly = true;
//            gridDataDetail.AllowUserToAddRows = false;
//            gridDataDetail.AutoGenerateColumns = false;
//            gridDataDetail.DataSource = src;
//            orders = orderDAL.GetData();
//            LoadProducts();
//            LoadSellers();
//            LoadCustomers();

//            // Setup event handler for customer selection change
//            cboCustomer.SelectedIndexChanged += cboCustomer_SelectedIndexChanged;

//            if (_order == null)
//                _order = new Order();
//            else
//            {
//                txtCode.Text = _order.OrderId;
//                dtCreateDate.Value = _order.OrderDate;
//                cboSeller.SelectedValue = _order.Cashier.Name;
//                cboCustomer.SelectedValue = _order.Customer.Name;
//                src.DataSource = _order.OrderDetails;
//                src.ResetBindings(true);
//            }

//            // Initial discount display
//            UpdateDiscountDisplay();
//        }

//        private void LoadCustomers()
//        {
//            List<Customer> customers = customerDAL.GetData();
//            cboCustomer.DataSource = customers;
//            cboCustomer.ValueMember = "Id";
//            cboCustomer.DisplayMember = "Name";
//            if (cboCustomer.Items.Count > 0)
//                cboCustomer.SelectedIndex = 0;
//        }

//        private void LoadSellers()
//        {
//            List<Cashier> cashiers = cashierDAL.GetData();
//            cboSeller.DataSource = cashiers;
//            cboSeller.ValueMember = "Id";
//            cboSeller.DisplayMember = "Name";
//            if (cboSeller.Items.Count > 0)
//                cboSeller.SelectedIndex = 0;
//        }

//        private void LoadProducts()
//        {
//            List<DrinkProduct> drinkProducts = drinkProductData.GetData();
//            List<FoodProduct> foods = foodProductData.GetData();
//            List<HouseholdProduct> householdProducts = householdProductData.GetData();

//            for (int i = 0; i < drinkProducts.Count; i++)
//            {
//                products.Add(drinkProducts[i]);
//            }

//            for (int i = 0; i < foods.Count; i++)
//            {
//                products.Add(foods[i]);
//            }

//            for (int i = 0; i < householdProducts.Count; i++)
//            {
//                products.Add(householdProducts[i]);
//            }

//            cboProduct.DataSource = products;
//            cboProduct.ValueMember = "Id";
//            cboProduct.DisplayMember = "Name";

//            if (cboProduct.Items.Count > 0)
//                cboProduct.SelectedIndex = 0;
//        }

//        private void btnRefresh_Click(object sender, EventArgs e)
//        {
//            txtCode.Text = "";
//            dtCreateDate.Value = DateTime.Now;
//            cboCustomer.SelectedIndex = 0;
//            cboSeller.SelectedIndex = 0;
//            cboProduct.SelectedIndex = 0;
//            txtQty.Value = 0;
//            _order = new Order();
//        }

//        private Order _order;

//        private void btnSave_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrEmpty(txtCode.Text))
//            {
//                MessageBox.Show("Mã đơn hàng không được để trống !"
//                  , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            if (cboSeller.SelectedIndex < 0)
//            {
//                MessageBox.Show("Vui lòng chọn nhân viên bán hàng !"
//                  , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            if (cboCustomer.SelectedIndex < 0)
//            {
//                MessageBox.Show("Vui lòng chọn khách hàng !"
//                  , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            if (_order == null)
//            {
//                MessageBox.Show("Không có đơn hàng nào được khởi tạo ! Vui lòng nhấn làm mới để nhập đơn hàng "
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            if (_order.OrderDetails.Count <= 0)
//            {
//                MessageBox.Show("Không có sản phẩm nào trong đơn hàng, không thể lưu đơn hàng này ! "
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            // Kiểm tra trùng order
//            bool found = false;

//            for (int i = 0; i < orders.Count; i++)
//            {
//                if (orders[i].OrderId.ToLower() == txtCode.Text.ToLower())
//                {
//                    orders[i] = _order;
//                    found = true;
//                    break;
//                }
//            }

//            if (!found)
//                orders.Add(_order);

//            // Gán các giá trị nhập cho order
//            _order.OrderId = txtCode.Text;
//            _order.OrderDate = dtCreateDate.Value;
//            _order.Cashier = cboSeller.SelectedItem as Cashier;
//            _order.Customer = cboCustomer.SelectedItem as Customer;

//            orderDAL.SaveData(orders);

//            // Cập nhật lại số lượng sản phẩm

//            List<DrinkProduct> drinkProducts = drinkProductData.GetData();
//            List<FoodProduct> foodProducts = foodProductData.GetData();
//            List<HouseholdProduct> householdProducts = householdProductData.GetData();

//            for (int i = 0; i < _order.OrderDetails.Count; i++)
//            {
//                if (_order.OrderDetails[i].Product is DrinkProduct)
//                {
//                    for (int j = 0; j < drinkProducts.Count; j++)
//                    {
//                        if (drinkProducts[j].Id.ToLower() == _order.OrderDetails[i].Product.Id.ToLower())
//                        {
//                            drinkProducts[j].Quantity = drinkProducts[j].Quantity - _order.OrderDetails[i].Quantity;
//                            if (drinkProducts[j].Quantity < 0)
//                                drinkProducts[j].Quantity = 0;
//                            break;
//                        }
//                    }
//                }

//                if (_order.OrderDetails[i].Product is FoodProduct)
//                {
//                    for (int j = 0; j < foodProducts.Count; j++)
//                    {
//                        if (foodProducts[j].Id.ToLower() == _order.OrderDetails[i].Product.Id.ToLower())
//                        {
//                            foodProducts[j].Quantity = foodProducts[j].Quantity - _order.OrderDetails[i].Quantity;
//                            if (foodProducts[j].Quantity < 0)
//                                foodProducts[j].Quantity = 0;
//                            break;
//                        }
//                    }
//                }

//                if (_order.OrderDetails[i].Product is HouseholdProduct)
//                {
//                    for (int j = 0; j < householdProducts.Count; j++)
//                    {
//                        if (householdProducts[j].Id.ToLower() == _order.OrderDetails[i].Product.Id.ToLower())
//                        {
//                            householdProducts[j].Quantity = householdProducts[j].Quantity - _order.OrderDetails[i].Quantity;
//                            if (householdProducts[j].Quantity < 0)
//                                householdProducts[j].Quantity = 0;
//                            break;
//                        }
//                    }
//                }
//            }

//            drinkProductData.SaveData(drinkProducts);
//            foodProductData.SaveData(foodProducts);
//            householdProductData.SaveData(householdProducts);

//            // Nạp lại số lượng thực tế
//            LoadProducts();

//            MessageBox.Show("Lưu thông tin đơn hàng thành công ! "
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            return;

//        }

//        BindingSource src = new BindingSource();
//        private void btnAddDetail_Click(object sender, EventArgs e)
//        {
//            if (_order == null)
//            {
//                MessageBox.Show("Không có đơn hàng nào được khởi tạo ! Vui lòng nhấn làm mới để nhập đơn hàng "
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            if (cboProduct.SelectedIndex < 0)
//            {
//                MessageBox.Show("Vui lòng chọn sản phẩm hàng hoá ! "
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            if (txtQty.Value <= 0)
//            {
//                MessageBox.Show("Số lượng hàng hoá phải lớn hơn 0 !"
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            Product product = cboProduct.SelectedItem as Product;

//            if (product.Quantity - txtQty.Value < 0)
//            {

//                MessageBox.Show("Sản phẩm không đủ số lượng ! Chỉ còn lại " + product.Quantity + " sản phẩm !"
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            bool found = false;

//            for (int i = 0; i < _order.OrderDetails.Count; i++)
//            {
//                if (_order.OrderDetails[i].Product.Id.ToLower() == product.Id.ToLower())
//                {
//                    found = true;
//                    _order.OrderDetails[i].Quantity = _order.OrderDetails[i].Quantity + txtQty.Value;
//                    break;
//                }
//            }

//            if (!found)
//            {
//                _order.OrderDetails.Add(new OrderDetails()
//                {
//                    Product = product,
//                    Quantity = txtQty.Value,
//                });
//            }

//            // Trừ số lượng trong sản phẩm

//            product.Quantity = product.Quantity - txtQty.Value;

//            src.DataSource = _order.OrderDetails;
//            src.ResetBindings(true);

//            // Update discount display after adding product
//            UpdateDiscountDisplay();
//        }

//        private void btnDeleteDetail_Click(object sender, EventArgs e)
//        {
//            if (_order == null)
//            {
//                MessageBox.Show("Không có đơn hàng nào được khởi tạo ! Vui lòng nhấn làm mới để nhập đơn hàng "
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            if (cboProduct.SelectedIndex < 0)
//            {
//                MessageBox.Show("Vui lòng chọn sản phẩm hàng hoá ! "
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            Product product = cboProduct.SelectedItem as Product;

//            for (int i = 0; i < _order.OrderDetails.Count; i++)
//            {
//                if (_order.OrderDetails[i].Product.Id.ToLower() == product.Id.ToLower())
//                {
//                    product.Quantity = product.Quantity + _order.OrderDetails[i].Quantity;
//                    _order.OrderDetails.Remove(_order.OrderDetails[i]);
//                    break;
//                }
//            }

//            src.DataSource = _order.OrderDetails;
//            src.ResetBindings(true);

//            // Update discount display after deleting product
//            UpdateDiscountDisplay();
//        }

//        private void btnDelete_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrEmpty(txtCode.Text))
//            {
//                MessageBox.Show("Mã đơn hàng không được để trống !"
//                  , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            Order toDelete = null;

//            for (int i = 0; i < orders.Count; i++)
//            {
//                if (orders[i].OrderId.ToLower() == txtCode.Text.ToLower())
//                {
//                    toDelete = orders[i];
//                    break;
//                }
//            }

//            if (toDelete == null)
//            {
//                MessageBox.Show("Không tìm thấy đơn hàng cần xoá !"
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            // Cập nhật lại số lượng sản phẩm

//            List<DrinkProduct> drinkProducts = drinkProductData.GetData();
//            List<FoodProduct> foodProducts = foodProductData.GetData();
//            List<HouseholdProduct> householdProducts = householdProductData.GetData();

//            for (int i = 0; i < toDelete.OrderDetails.Count; i++)
//            {
//                if (toDelete.OrderDetails[i].Product is DrinkProduct)
//                {
//                    for (int j = 0; j < drinkProducts.Count; j++)
//                    {
//                        if (drinkProducts[j].Id.ToLower() == toDelete.OrderDetails[i].Product.Id.ToLower())
//                        {
//                            drinkProducts[j].Quantity = drinkProducts[j].Quantity + toDelete.OrderDetails[i].Quantity;
//                            break;
//                        }
//                    }
//                }

//                if (toDelete.OrderDetails[i].Product is FoodProduct)
//                {
//                    for (int j = 0; j < foodProducts.Count; j++)
//                    {
//                        if (foodProducts[j].Id.ToLower() == toDelete.OrderDetails[i].Product.Id.ToLower())
//                        {
//                            foodProducts[j].Quantity = foodProducts[j].Quantity + toDelete.OrderDetails[i].Quantity;

//                            break;
//                        }
//                    }
//                }

//                if (toDelete.OrderDetails[i].Product is HouseholdProduct)
//                {
//                    for (int j = 0; j < householdProducts.Count; j++)
//                    {
//                        if (householdProducts[j].Id.ToLower() == toDelete.OrderDetails[i].Product.Id.ToLower())
//                        {
//                            householdProducts[j].Quantity = householdProducts[j].Quantity + toDelete.OrderDetails[i].Quantity;
//                            break;
//                        }
//                    }
//                }
//            }

//            drinkProductData.SaveData(drinkProducts);
//            foodProductData.SaveData(foodProducts);
//            householdProductData.SaveData(householdProducts);

//            // Nạp lại số lượng thực tế
//            LoadProducts();

//            txtCode.Text = "";
//            dtCreateDate.Value = DateTime.Now;
//            cboCustomer.SelectedIndex = 0;
//            cboSeller.SelectedIndex = 0;
//            cboProduct.SelectedIndex = 0;
//            txtQty.Value = 0;

//            MessageBox.Show("Xoá thông tin đơn hàng thành công ! "
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            return;
//        }

//        private void btnViewInvoice_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrEmpty(txtCode.Text))
//            {
//                MessageBox.Show("Mã đơn hàng không được để trống !"
//                  , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            Order order = null;

//            for (int i = 0; i < orders.Count; i++)
//            {
//                if (orders[i].OrderId.ToLower() == txtCode.Text.ToLower())
//                {
//                    order = orders[i];
//                    break;
//                }
//            }

//            if (order == null)
//            {
//                MessageBox.Show("Không tìm thấy đơn hàng ! "
//               , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }

//            Invoice invoice = new Invoice();
//            invoice.Id = order.OrderId;
//            invoice.DateCreated = order.OrderDate;
//            invoice.Cashier = order.Cashier;
//            invoice.Customer = order.Customer;

//            for (int i = 0; i < order.OrderDetails.Count; i++)
//            {
//                invoice.InvoiceDetails.Add(new InvoiceDetails()
//                {
//                    ProductID = order.OrderDetails[i].Product.Id,
//                    ProductName = order.OrderDetails[i].Product.Name,
//                    Quantity = order.OrderDetails[i].Quantity,
//                    UnitPrice = order.OrderDetails[i].Product.Price
//                });

//            }

//            InvoiceForm frm = new InvoiceForm(invoice);
//            frm.ShowDialog();
//        }

//        /// <summary>
//        /// Strategy Pattern: Cập nhật hiển thị discount information
//        /// </summary>
//        private void UpdateDiscountDisplay()
//        {
//            if (_order == null)
//                return;

//            // Gán customer từ combobox vào order
//            _order.Customer = cboCustomer.SelectedItem as Customer;

//            if (_order.Customer == null)
//                return;

//            // Lấy thông tin discount
//            decimal subTotal = _order.SumTotal;
//            decimal discount = _order.DiscountAmount;
//            decimal finalTotal = _order.FinalTotal;
//            decimal discountPercent = _order.DiscountPercentage;

//            // Hiển thị loại khách hàng
//            string customerType = _order.Customer is OOP_finalProject.Customers.VIPCustomer ? "VIP" : "Regular";
//            string discountInfo = _order.Customer.GetDiscountInfo();

//            // Update text trong form title hoặc status
//            this.Text = $"ĐƠN HÀNG - Khách hàng: {customerType} ({discountPercent}% discount)";

//            // Hiển thị trong MessageBox khi cần (có thể comment nếu không muốn)
//            // MessageBox.Show($"Tổng: {subTotal:#,###}đ\nGiảm giá: {discount:#,###}đ\nThành tiền: {finalTotal:#,###}đ", 
//            //     "Thông tin đơn hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
//        }

//        /// <summary>
//        /// Strategy Pattern: Xử lý khi thay đổi customer
//        /// </summary>
//        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            UpdateDiscountDisplay();
//        }
//    }
//}

//using OOP_finalProject.Base;
//using OOP_finalProject.Employees;
//using OOP_finalProject.Products;
//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Windows.Forms;

//namespace OOP_finalProject
//{
//    public partial class OrderForm : Form
//    {
//        public OrderForm()
//        {
//            InitializeComponent();
//        }

//        public OrderForm(Order order)
//            : this()
//        {
//            _order = order;
//        }

//        private OrderData orderDAL = new OrderData();
//        private CashierData cashierDAL = new CashierData();
//        private CustomerData customerDAL = new CustomerData();
//        private DrinkProductData drinkProductData = new DrinkProductData();
//        private FoodProductData foodProductData = new FoodProductData();
//        private HouseholdProductData householdProductData = new HouseholdProductData();
//        private ElectronicProductData electronicProductData = new ElectronicProductData();
//        private ClothingProductData clothingProductData = new ClothingProductData();

//        private List<Order> orders;
//        private List<Product> products = new List<Product>();
//        private Order _order;
//        BindingSource src = new BindingSource();

//        private void FormOrder_Load(object sender, EventArgs e)
//        {
//            // Cấu hình DataGridView
//            gridDataDetail.ReadOnly = true;
//            gridDataDetail.AllowUserToAddRows = false;
//            gridDataDetail.AutoGenerateColumns = false;
//            gridDataDetail.DataSource = src;
//            gridDataDetail.CellFormatting += gridDataDetail_CellFormatting;

//            // Tùy chỉnh giao diện DataGridView
//            gridDataDetail.BorderStyle = BorderStyle.None;
//            gridDataDetail.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 245);
//            gridDataDetail.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
//            gridDataDetail.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 105, 225);
//            gridDataDetail.DefaultCellStyle.SelectionForeColor = Color.White;
//            gridDataDetail.BackgroundColor = Color.White;
//            gridDataDetail.EnableHeadersVisualStyles = false;
//            gridDataDetail.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
//            gridDataDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(65, 105, 225);
//            gridDataDetail.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
//            gridDataDetail.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

//            orders = orderDAL.GetData();
//            LoadProducts();
//            LoadSellers();
//            LoadCustomers();

//            // Setup event handler for customer selection change
//            cboCustomer.SelectedIndexChanged += cboCustomer_SelectedIndexChanged;

//            if (_order == null)
//                _order = new Order();
//            else
//            {
//                txtCode.Text = _order.OrderId;
//                dtCreateDate.Value = _order.OrderDate;
//                cboSeller.SelectedValue = _order.Cashier.Id;
//                cboCustomer.SelectedValue = _order.Customer.Id;
//                src.DataSource = _order.OrderDetails;
//                src.ResetBindings(true);
//            }

//            // Initial discount display
//            UpdateDiscountDisplay();
//            UpdateStatistics();
//        }

//        private void LoadCustomers()
//        {
//            List<Customer> customers = customerDAL.GetData();
//            cboCustomer.DataSource = customers;
//            cboCustomer.ValueMember = "Id";
//            cboCustomer.DisplayMember = "Name";
//            if (cboCustomer.Items.Count > 0)
//                cboCustomer.SelectedIndex = 0;
//        }

//        private void LoadSellers()
//        {
//            List<Cashier> cashiers = cashierDAL.GetData();
//            cboSeller.DataSource = cashiers;
//            cboSeller.ValueMember = "Id";
//            cboSeller.DisplayMember = "Name";
//            if (cboSeller.Items.Count > 0)
//                cboSeller.SelectedIndex = 0;
//        }

//        private void LoadProducts()
//        {
//            products.Clear();

//            // Load all product types
//            List<DrinkProduct> drinkProducts = drinkProductData.GetData();
//            List<FoodProduct> foods = foodProductData.GetData();
//            List<HouseholdProduct> householdProducts = householdProductData.GetData();
//            List<ElectronicProduct> electronicProducts = electronicProductData.GetData();
//            List<ClothingProduct> clothingProducts = clothingProductData.GetData();

//            products.AddRange(drinkProducts);
//            products.AddRange(foods);
//            products.AddRange(householdProducts);
//            products.AddRange(electronicProducts);
//            products.AddRange(clothingProducts);

//            // Filter only products with quantity > 0
//            products = products.Where(p => p.Quantity > 0).ToList();

//            cboProduct.DataSource = products;
//            cboProduct.ValueMember = "Id";
//            cboProduct.DisplayMember = "Name";

//            if (cboProduct.Items.Count > 0)
//                cboProduct.SelectedIndex = 0;
//        }

//        private void btnRefresh_Click(object sender, EventArgs e)
//        {
//            txtCode.Text = "";
//            dtCreateDate.Value = DateTime.Now;
//            cboCustomer.SelectedIndex = 0;
//            cboSeller.SelectedIndex = 0;
//            cboProduct.SelectedIndex = 0;
//            txtQty.Value = 1;
//            _order = new Order();
//            src.DataSource = _order.OrderDetails;
//            src.ResetBindings(true);

//            UpdateDiscountDisplay();
//            UpdateStatistics();
//            statusLabel.Text = "Đã làm mới đơn hàng";
//        }

//        private void btnSave_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrEmpty(txtCode.Text))
//            {
//                MessageBox.Show("Mã đơn hàng không được để trống !"
//                  , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                txtCode.Focus();
//                return;
//            }

//            if (cboSeller.SelectedIndex < 0)
//            {
//                MessageBox.Show("Vui lòng chọn nhân viên bán hàng !"
//                  , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                cboSeller.Focus();
//                return;
//            }

//            if (cboCustomer.SelectedIndex < 0)
//            {
//                MessageBox.Show("Vui lòng chọn khách hàng !"
//                  , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                cboCustomer.Focus();
//                return;
//            }

//            if (_order == null)
//            {
//                MessageBox.Show("Không có đơn hàng nào được khởi tạo ! Vui lòng nhấn làm mới để nhập đơn hàng "
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            if (_order.OrderDetails.Count <= 0)
//            {
//                MessageBox.Show("Không có sản phẩm nào trong đơn hàng, không thể lưu đơn hàng này ! "
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            // Kiểm tra trùng order
//            bool found = false;

//            for (int i = 0; i < orders.Count; i++)
//            {
//                if (orders[i].OrderId.ToLower() == txtCode.Text.ToLower())
//                {
//                    orders[i] = _order;
//                    found = true;
//                    break;
//                }
//            }

//            if (!found)
//                orders.Add(_order);

//            // Gán các giá trị nhập cho order
//            _order.OrderId = txtCode.Text;
//            _order.OrderDate = dtCreateDate.Value;
//            _order.Cashier = cboSeller.SelectedItem as Cashier;
//            _order.Customer = cboCustomer.SelectedItem as Customer;

//            orderDAL.SaveData(orders);

//            // Cập nhật lại số lượng sản phẩm
//            UpdateProductQuantities();

//            // Nạp lại số lượng thực tế
//            LoadProducts();

//            MessageBox.Show("Lưu thông tin đơn hàng thành công ! "
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

//            statusLabel.Text = "Đã lưu đơn hàng thành công";
//            statusLabel.ForeColor = Color.FromArgb(46, 204, 113);

//            UpdateStatistics();
//        }

//        private void UpdateProductQuantities()
//        {
//            List<DrinkProduct> drinkProducts = drinkProductData.GetData();
//            List<FoodProduct> foodProducts = foodProductData.GetData();
//            List<HouseholdProduct> householdProducts = householdProductData.GetData();
//            List<ElectronicProduct> electronicProducts = electronicProductData.GetData();
//            List<ClothingProduct> clothingProducts = clothingProductData.GetData();

//            for (int i = 0; i < _order.OrderDetails.Count; i++)
//            {
//                var detail = _order.OrderDetails[i];
//                UpdateProductQuantity(detail.Product, detail.Quantity, drinkProducts, foodProducts, householdProducts, electronicProducts, clothingProducts);
//            }

//            drinkProductData.SaveData(drinkProducts);
//            foodProductData.SaveData(foodProducts);
//            householdProductData.SaveData(householdProducts);
//            electronicProductData.SaveData(electronicProducts);
//            clothingProductData.SaveData(clothingProducts);
//        }

//        private void UpdateProductQuantity(Product product, decimal quantity,
//            List<DrinkProduct> drinkProducts, List<FoodProduct> foodProducts,
//            List<HouseholdProduct> householdProducts, List<ElectronicProduct> electronicProducts,
//            List<ClothingProduct> clothingProducts)
//        {
//            if (product is DrinkProduct)
//            {
//                UpdateProductListQuantity(drinkProducts, product.Id, quantity);
//            }
//            else if (product is FoodProduct)
//            {
//                UpdateProductListQuantity(foodProducts, product.Id, quantity);
//            }
//            else if (product is HouseholdProduct)
//            {
//                UpdateProductListQuantity(householdProducts, product.Id, quantity);
//            }
//            else if (product is ElectronicProduct)
//            {
//                UpdateProductListQuantity(electronicProducts, product.Id, quantity);
//            }
//            else if (product is ClothingProduct)
//            {
//                UpdateProductListQuantity(clothingProducts, product.Id, quantity);
//            }
//        }

//        private void UpdateProductListQuantity<T>(List<T> products, string productId, decimal quantity) where T : Product
//        {
//            for (int j = 0; j < products.Count; j++)
//            {
//                if (products[j].Id.ToLower() == productId.ToLower())
//                {
//                    products[j].Quantity = products[j].Quantity - quantity;
//                    if (products[j].Quantity < 0)
//                        products[j].Quantity = 0;
//                    break;
//                }
//            }
//        }

//        private void btnAddDetail_Click(object sender, EventArgs e)
//        {
//            if (_order == null)
//            {
//                MessageBox.Show("Không có đơn hàng nào được khởi tạo ! Vui lòng nhấn làm mới để nhập đơn hàng "
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            if (cboProduct.SelectedIndex < 0)
//            {
//                MessageBox.Show("Vui lòng chọn sản phẩm hàng hoá ! "
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                cboProduct.Focus();
//                return;
//            }

//            if (txtQty.Value <= 0)
//            {
//                MessageBox.Show("Số lượng hàng hoá phải lớn hơn 0 !"
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                txtQty.Focus();
//                return;
//            }

//            Product product = cboProduct.SelectedItem as Product;

//            if (product.Quantity - txtQty.Value < 0)
//            {
//                MessageBox.Show("Sản phẩm không đủ số lượng ! Chỉ còn lại " + product.Quantity + " sản phẩm !"
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                txtQty.Focus();
//                return;
//            }

//            bool found = false;

//            for (int i = 0; i < _order.OrderDetails.Count; i++)
//            {
//                if (_order.OrderDetails[i].Product.Id.ToLower() == product.Id.ToLower())
//                {
//                    found = true;
//                    _order.OrderDetails[i].Quantity = _order.OrderDetails[i].Quantity + txtQty.Value;
//                    break;
//                }
//            }

//            if (!found)
//            {
//                _order.OrderDetails.Add(new OrderDetails()
//                {
//                    Product = product,
//                    Quantity = txtQty.Value,
//                });
//            }

//            // Trừ số lượng trong sản phẩm tạm thời để hiển thị
//            product.Quantity = product.Quantity - txtQty.Value;

//            src.DataSource = _order.OrderDetails;
//            src.ResetBindings(true);

//            // Update discount display after adding product
//            UpdateDiscountDisplay();
//            UpdateStatistics();

//            statusLabel.Text = $"Đã thêm {txtQty.Value} {product.Name} vào đơn hàng";
//        }

//        private void btnDeleteDetail_Click(object sender, EventArgs e)
//        {
//            if (_order == null || gridDataDetail.CurrentRow == null)
//            {
//                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa!"
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            var selectedDetail = gridDataDetail.CurrentRow.DataBoundItem as OrderDetails;
//            if (selectedDetail == null)
//                return;

//            // Trả lại số lượng cho sản phẩm
//            selectedDetail.Product.Quantity = selectedDetail.Product.Quantity + selectedDetail.Quantity;
//            _order.OrderDetails.Remove(selectedDetail);

//            src.DataSource = _order.OrderDetails;
//            src.ResetBindings(true);

//            // Update discount display after deleting product
//            UpdateDiscountDisplay();
//            UpdateStatistics();

//            statusLabel.Text = "Đã xóa sản phẩm khỏi đơn hàng";
//        }

//        private void btnDelete_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrEmpty(txtCode.Text))
//            {
//                MessageBox.Show("Mã đơn hàng không được để trống !"
//                  , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                txtCode.Focus();
//                return;
//            }

//            Order toDelete = null;

//            for (int i = 0; i < orders.Count; i++)
//            {
//                if (orders[i].OrderId.ToLower() == txtCode.Text.ToLower())
//                {
//                    toDelete = orders[i];
//                    break;
//                }
//            }

//            if (toDelete == null)
//            {
//                MessageBox.Show("Không tìm thấy đơn hàng cần xoá !"
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            // Cập nhật lại số lượng sản phẩm
//            RestoreProductQuantities(toDelete);

//            orders.Remove(toDelete);
//            orderDAL.SaveData(orders);

//            btnRefresh_Click(null, null);

//            MessageBox.Show("Xoá thông tin đơn hàng thành công ! "
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

//            statusLabel.Text = "Đã xóa đơn hàng thành công";
//            statusLabel.ForeColor = Color.FromArgb(46, 204, 113);
//        }

//        private void RestoreProductQuantities(Order order)
//        {
//            List<DrinkProduct> drinkProducts = drinkProductData.GetData();
//            List<FoodProduct> foodProducts = foodProductData.GetData();
//            List<HouseholdProduct> householdProducts = householdProductData.GetData();
//            List<ElectronicProduct> electronicProducts = electronicProductData.GetData();
//            List<ClothingProduct> clothingProducts = clothingProductData.GetData();

//            for (int i = 0; i < order.OrderDetails.Count; i++)
//            {
//                var detail = order.OrderDetails[i];
//                RestoreProductQuantity(detail.Product, detail.Quantity, drinkProducts, foodProducts, householdProducts, electronicProducts, clothingProducts);
//            }

//            drinkProductData.SaveData(drinkProducts);
//            foodProductData.SaveData(foodProducts);
//            householdProductData.SaveData(householdProducts);
//            electronicProductData.SaveData(electronicProducts);
//            clothingProductData.SaveData(clothingProducts);
//        }

//        private void RestoreProductQuantity(Product product, decimal quantity,
//            List<DrinkProduct> drinkProducts, List<FoodProduct> foodProducts,
//            List<HouseholdProduct> householdProducts, List<ElectronicProduct> electronicProducts,
//            List<ClothingProduct> clothingProducts)
//        {
//            if (product is DrinkProduct)
//            {
//                RestoreProductListQuantity(drinkProducts, product.Id, quantity);
//            }
//            else if (product is FoodProduct)
//            {
//                RestoreProductListQuantity(foodProducts, product.Id, quantity);
//            }
//            else if (product is HouseholdProduct)
//            {
//                RestoreProductListQuantity(householdProducts, product.Id, quantity);
//            }
//            else if (product is ElectronicProduct)
//            {
//                RestoreProductListQuantity(electronicProducts, product.Id, quantity);
//            }
//            else if (product is ClothingProduct)
//            {
//                RestoreProductListQuantity(clothingProducts, product.Id, quantity);
//            }
//        }

//        private void RestoreProductListQuantity<T>(List<T> products, string productId, decimal quantity) where T : Product
//        {
//            for (int j = 0; j < products.Count; j++)
//            {
//                if (products[j].Id.ToLower() == productId.ToLower())
//                {
//                    products[j].Quantity = products[j].Quantity + quantity;
//                    break;
//                }
//            }
//        }

//        private void btnViewInvoice_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrEmpty(txtCode.Text))
//            {
//                MessageBox.Show("Mã đơn hàng không được để trống !"
//                  , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                txtCode.Focus();
//                return;
//            }

//            Order order = null;

//            for (int i = 0; i < orders.Count; i++)
//            {
//                if (orders[i].OrderId.ToLower() == txtCode.Text.ToLower())
//                {
//                    order = orders[i];
//                    break;
//                }
//            }

//            if (order == null)
//            {
//                MessageBox.Show("Không tìm thấy đơn hàng ! "
//               , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return;
//            }

//            Invoice invoice = new Invoice();
//            invoice.Id = order.OrderId;
//            invoice.DateCreated = order.OrderDate;
//            invoice.Cashier = order.Cashier;
//            invoice.Customer = order.Customer;

//            for (int i = 0; i < order.OrderDetails.Count; i++)
//            {
//                invoice.InvoiceDetails.Add(new InvoiceDetails()
//                {
//                    ProductID = order.OrderDetails[i].Product.Id,
//                    ProductName = order.OrderDetails[i].Product.Name,
//                    Quantity = order.OrderDetails[i].Quantity,
//                    UnitPrice = order.OrderDetails[i].Product.Price
//                });
//            }

//            InvoiceForm frm = new InvoiceForm(invoice);
//            frm.ShowDialog();
//        }

//        /// <summary>
//        /// Strategy Pattern: Cập nhật hiển thị discount information
//        /// </summary>
//        private void UpdateDiscountDisplay()
//        {
//            if (_order == null)
//                return;

//            // Gán customer từ combobox vào order
//            _order.Customer = cboCustomer.SelectedItem as Customer;

//            if (_order.Customer == null)
//                return;

//            // Lấy thông tin discount
//            decimal subTotal = _order.SumTotal;
//            decimal discount = _order.DiscountAmount;
//            decimal finalTotal = _order.FinalTotal;
//            decimal discountPercent = _order.DiscountPercentage;

//            // Hiển thị thông tin
//            lblSubTotalValue.Text = $"{subTotal:N0} đ";
//            lblDiscountValue.Text = $"{discount:N0} đ";
//            lblFinalTotalValue.Text = $"{finalTotal:N0} đ";
//            lblDiscountPercentValue.Text = $"{discountPercent}%";

//            // Hiển thị loại khách hàng
//            string customerType = _order.Customer is OOP_finalProject.Customers.VIPCustomer ? "VIP" : "Thường";
//            lblCustomerTypeValue.Text = customerType;

//            // Đổi màu theo giá trị
//            lblSubTotalValue.ForeColor = subTotal > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
//            lblDiscountValue.ForeColor = discount > 0 ? Color.FromArgb(255, 165, 0) : Color.Gray;
//            lblFinalTotalValue.ForeColor = finalTotal > 0 ? Color.FromArgb(65, 105, 225) : Color.Red;
//        }

//        /// <summary>
//        /// Cập nhật thống kê
//        /// </summary>
//        private void UpdateStatistics()
//        {
//            if (_order == null)
//                return;

//            int itemCount = _order.OrderDetails.Count;
//            int productCount = _order.OrderDetails.Sum(od => (int)od.Quantity);
//            decimal totalValue = _order.SumTotal;

//            lblItemCountValue.Text = itemCount.ToString();
//            lblProductCountValue.Text = productCount.ToString();
//            lblOrderValueValue.Text = $"{totalValue:N0} đ";

//            // Đổi màu theo số lượng
//            lblItemCountValue.ForeColor = itemCount > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
//            lblProductCountValue.ForeColor = productCount > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
//            lblOrderValueValue.ForeColor = totalValue > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
//        }

//        /// <summary>
//        /// Strategy Pattern: Xử lý khi thay đổi customer
//        /// </summary>
//        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            UpdateDiscountDisplay();
//            UpdateStatistics();
//            // Làm mới hiển thị để CellFormatting áp dụng giảm giá mới
//            gridDataDetail.Refresh();
//        }

//        private void gridDataDetail_SelectionChanged(object sender, EventArgs e)
//        {
//            if (gridDataDetail.CurrentRow != null && gridDataDetail.CurrentRow.DataBoundItem is OrderDetails detail)
//            {
//                cboProduct.SelectedValue = detail.Product.Id;
//                txtQty.Value = detail.Quantity;
//            }
//        }

//        private void gridDataDetail_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
//        {
//            if (gridDataDetail.Columns[e.ColumnIndex].DataPropertyName == "TotalPrice")
//            {
//                var detail = gridDataDetail.Rows[e.RowIndex].DataBoundItem as OrderDetails;
//                if (detail == null)
//                    return;

//                // Tính thành tiền sau giảm giá theo % giảm của khách hàng (Strategy Pattern)
//                decimal lineTotal = detail.TotalPrice;
//                decimal discountPercent = 0;

//                if (_order != null && _order.Customer != null)
//                {
//                    discountPercent = _order.DiscountPercentage;
//                }

//                decimal discountedTotal = lineTotal * (1 - (discountPercent / 100m));

//                // Gán lại giá trị hiển thị
//                e.Value = string.Format("{0:N0} đ", discountedTotal);
//                e.FormattingApplied = true;

//                // Cập nhật tiêu đề cột để người dùng biết là đã áp dụng giảm giá
//                var col = gridDataDetail.Columns[e.ColumnIndex];
//                if (col.HeaderText != "Thành tiền (sau giảm)")
//                {
//                    col.HeaderText = "Thành tiền (sau giảm)";
//                }
//            }
//        }
//    }
//}


using OOP_finalProject.Base;
using OOP_finalProject.Data;
=======
﻿using OOP_finalProject.Base;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
using OOP_finalProject.Employees;
using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Drawing;
using System.Linq;
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
<<<<<<< HEAD
            InitializeDataGrid();
        }

        public OrderForm(Order order) : this()
=======
        }

        public OrderForm(Order order)
            : this()
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        {
            _order = order;
        }

        private OrderData orderDAL = new OrderData();
        private CashierData cashierDAL = new CashierData();
        private CustomerData customerDAL = new CustomerData();
        private DrinkProductData drinkProductData = new DrinkProductData();
        private FoodProductData foodProductData = new FoodProductData();
        private HouseholdProductData householdProductData = new HouseholdProductData();
<<<<<<< HEAD
        private ElectronicProductData electronicProductData = new ElectronicProductData();
        private ClothingProductData clothingProductData = new ClothingProductData();
        private ComboProductData comboProductData = new ComboProductData(); 

        private List<Order> orders;
        private List<Product> products = new List<Product>();
        private Order _order;
        private BindingSource src = new BindingSource();

        private void InitializeDataGrid()
=======
        private List<Order> orders;
        private List<Product> products = new List<Product>();
        private void FormOrder_Load(object sender, EventArgs e)
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        {
            gridDataDetail.ReadOnly = true;
            gridDataDetail.AllowUserToAddRows = false;
            gridDataDetail.AutoGenerateColumns = false;
<<<<<<< HEAD

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
=======
            gridDataDetail.DataSource = src;
            orders = orderDAL.GetData();
            LoadProducts();
            LoadSellers();
            LoadCustomers();
            if (_order == null)
                _order = new Order();
            else
            {
                txtCode.Text = _order.OrderId;
                dtCreateDate.Value = _order.OrderDate;
                cboSeller.SelectedValue = _order.Cashier.Id;
                cboCustomer.SelectedValue = _order.Customer.Id;
                src.DataSource = _order.OrderDetails;
                src.ResetBindings(true);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            }
        }

        private void LoadCustomers()
        {
<<<<<<< HEAD
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
=======
            List<Customer> customers = customerDAL.GetData();
            cboCustomer.DataSource = customers;
            cboCustomer.ValueMember = "Id";
            cboCustomer.DisplayMember = "Name";
            if (cboCustomer.Items.Count > 0)
                cboCustomer.SelectedIndex = 0;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        }

        private void LoadSellers()
        {
<<<<<<< HEAD
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
=======
            List<Cashier> cashiers = cashierDAL.GetData();
            cboSeller.DataSource = cashiers;
            cboSeller.ValueMember = "Id";
            cboSeller.DisplayMember = "Name";
            if (cboSeller.Items.Count > 0)
                cboSeller.SelectedIndex = 0;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        }

        private void LoadProducts()
        {
<<<<<<< HEAD
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
=======
            List<DrinkProduct> drinkProducts = drinkProductData.GetData();
            List<FoodProduct> foods = foodProductData.GetData();
            List<HouseholdProduct> householdProducts = householdProductData.GetData();

            for (int i = 0; i < drinkProducts.Count; i++)
            {
                products.Add(drinkProducts[i]);
            }

            for (int i = 0; i < foods.Count; i++)
            {
                products.Add(foods[i]);
            }

            for (int i = 0; i < householdProducts.Count; i++)
            {
                products.Add(householdProducts[i]);
            }

            cboProduct.DataSource = products;
            cboProduct.ValueMember = "Id";
            cboProduct.DisplayMember = "Name";

            if (cboProduct.Items.Count > 0)
                cboProduct.SelectedIndex = 0;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
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
=======
            txtCode.Text = "";
            dtCreateDate.Value = DateTime.Now;
            cboCustomer.SelectedIndex = 0;
            cboSeller.SelectedIndex = 0;
            cboProduct.SelectedIndex = 0;
            txtQty.Value = 0;
            _order = new Order();
        }

        private Order _order;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show("Mã đơn hàng không được để trống !"
                  , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboSeller.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên bán hàng !"
                  , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            }

            if (cboCustomer.SelectedIndex < 0)
            {
<<<<<<< HEAD
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
=======
                MessageBox.Show("Vui lòng chọn khách hàng !"
                  , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_order == null)
            {
                MessageBox.Show("Không có đơn hàng nào được khởi tạo ! Vui lòng nhấn làm mới để nhập đơn hàng "
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_order.OrderDetails.Count <= 0)
            {
                MessageBox.Show("Không có sản phẩm nào trong đơn hàng, không thể lưu đơn hàng này ! "
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra trùng order
            bool found = false;

            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].OrderId.ToLower() == txtCode.Text.ToLower())
                {
                    orders[i] = _order;
                    found = true;
                    break;
                }
            }

            if (!found)
                orders.Add(_order);

            // Gán các giá trị nhập cho order
            _order.OrderId = txtCode.Text;
            _order.OrderDate = dtCreateDate.Value;
            _order.Cashier = cboSeller.SelectedItem as Cashier;
            _order.Customer = cboCustomer.SelectedItem as Customer;

            orderDAL.SaveData(orders);

            // Cập nhật lại số lượng sản phẩm

            List<DrinkProduct> drinkProducts = drinkProductData.GetData();
            List<FoodProduct> foodProducts = foodProductData.GetData();
            List<HouseholdProduct> householdProducts = householdProductData.GetData();

            for (int i = 0; i < _order.OrderDetails.Count; i++)
            {
                if (_order.OrderDetails[i].Product is DrinkProduct)
                {
                    for (int j = 0; j < drinkProducts.Count; j++)
                    {
                        if (drinkProducts[j].Id.ToLower() == _order.OrderDetails[i].Product.Id.ToLower())
                        {
                            drinkProducts[j].Quantity = drinkProducts[j].Quantity - _order.OrderDetails[i].Quantity;
                            if (drinkProducts[j].Quantity < 0)
                                drinkProducts[j].Quantity = 0;
                            break;
                        }
                    }
                }

                if (_order.OrderDetails[i].Product is FoodProduct)
                {
                    for (int j = 0; j < foodProducts.Count; j++)
                    {
                        if (foodProducts[j].Id.ToLower() == _order.OrderDetails[i].Product.Id.ToLower())
                        {
                            foodProducts[j].Quantity = foodProducts[j].Quantity - _order.OrderDetails[i].Quantity;
                            if (foodProducts[j].Quantity < 0)
                                foodProducts[j].Quantity = 0;
                            break;
                        }
                    }
                }

                if (_order.OrderDetails[i].Product is HouseholdProduct)
                {
                    for (int j = 0; j < householdProducts.Count; j++)
                    {
                        if (householdProducts[j].Id.ToLower() == _order.OrderDetails[i].Product.Id.ToLower())
                        {
                            householdProducts[j].Quantity = householdProducts[j].Quantity - _order.OrderDetails[i].Quantity;
                            if (householdProducts[j].Quantity < 0)
                                householdProducts[j].Quantity = 0;
                            break;
                        }
                    }
                }
            }

            drinkProductData.SaveData(drinkProducts);
            foodProductData.SaveData(foodProducts);
            householdProductData.SaveData(householdProducts);

            // Nạp lại số lượng thực tế
            LoadProducts();

            MessageBox.Show("Lưu thông tin đơn hàng thành công ! "
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;

        }

        BindingSource src = new BindingSource();
        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            if (_order == null)
            {
                MessageBox.Show("Không có đơn hàng nào được khởi tạo ! Vui lòng nhấn làm mới để nhập đơn hàng "
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboProduct.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm hàng hoá ! "
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtQty.Value <= 0)
            {
                MessageBox.Show("Số lượng hàng hoá phải lớn hơn 0 !"
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Product product = cboProduct.SelectedItem as Product;

            if (product.Quantity - txtQty.Value < 0)
            {

                MessageBox.Show("Sản phẩm không đủ số lượng ! Chỉ còn lại " + product.Quantity + " sản phẩm !"
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool found = false;

            for (int i = 0; i < _order.OrderDetails.Count; i++)
            {
                if (_order.OrderDetails[i].Product.Id.ToLower() == product.Id.ToLower())
                {
                    found = true;
                    _order.OrderDetails[i].Quantity = _order.OrderDetails[i].Quantity + txtQty.Value;
                    break;
                }
            }

            if (!found)
            {
                _order.OrderDetails.Add(new OrderDetails()
                {
                    Product = product,
                    Quantity = txtQty.Value,
                });
            }

            // Trừ số lượng trong sản phẩm

            product.Quantity = product.Quantity - txtQty.Value;

            src.DataSource = _order.OrderDetails;
            src.ResetBindings(true);

        }

        private void btnDeleteDetail_Click(object sender, EventArgs e)
        {
            if (_order == null)
            {
                MessageBox.Show("Không có đơn hàng nào được khởi tạo ! Vui lòng nhấn làm mới để nhập đơn hàng "
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboProduct.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm hàng hoá ! "
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Product product = cboProduct.SelectedItem as Product;

            for (int i = 0; i < _order.OrderDetails.Count; i++)
            {
                if (_order.OrderDetails[i].Product.Id.ToLower() == product.Id.ToLower())
                {
                    product.Quantity = product.Quantity + _order.OrderDetails[i].Quantity;
                    _order.OrderDetails.Remove(_order.OrderDetails[i]);
                    break;
                }
            }

            src.DataSource = _order.OrderDetails;
            src.ResetBindings(true);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
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
<<<<<<< HEAD
            List<ElectronicProduct> electronicProducts = electronicProductData.GetData();
            List<ClothingProduct> clothingProducts = clothingProductData.GetData();
            List<ComboProduct> comboProducts = comboProductData.GetData();
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7

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
<<<<<<< HEAD

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
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
            }

            drinkProductData.SaveData(drinkProducts);
            foodProductData.SaveData(foodProducts);
            householdProductData.SaveData(householdProducts);
<<<<<<< HEAD
            electronicProductData.SaveData(electronicProducts);
            clothingProductData.SaveData(clothingProducts);
            comboProductData.SaveData(comboProducts);
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7

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
<<<<<<< HEAD
}
=======
}
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
