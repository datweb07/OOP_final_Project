using OOP_finalProject.Base;
using OOP_finalProject.Employees;
using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        public OrderForm(Order order)
            : this()
        {
            _order = order;
        }

        private OrderData orderDAL = new OrderData();
        private CashierData cashierDAL = new CashierData();
        private CustomerData customerDAL = new CustomerData();
        private DrinkProductData drinkProductData = new DrinkProductData();
        private FoodProductData foodProductData = new FoodProductData();
        private HouseholdProductData householdProductData = new HouseholdProductData();
        private List<Order> orders;
        private List<Product> products = new List<Product>();
        private void FormOrder_Load(object sender, EventArgs e)
        {
            gridDataDetail.ReadOnly = true;
            gridDataDetail.AllowUserToAddRows = false;
            gridDataDetail.AutoGenerateColumns = false;
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
            }
        }

        private void LoadCustomers()
        {
            List<Customer> customers = customerDAL.GetData();
            cboCustomer.DataSource = customers;
            cboCustomer.ValueMember = "Id";
            cboCustomer.DisplayMember = "Name";
            if (cboCustomer.Items.Count > 0)
                cboCustomer.SelectedIndex = 0;
        }

        private void LoadSellers()
        {
            List<Cashier> cashiers = cashierDAL.GetData();
            cboSeller.DataSource = cashiers;
            cboSeller.ValueMember = "Id";
            cboSeller.DisplayMember = "Name";
            if (cboSeller.Items.Count > 0)
                cboSeller.SelectedIndex = 0;
        }

        private void LoadProducts()
        {
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
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
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
            }

            if (cboCustomer.SelectedIndex < 0)
            {
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
            }

            drinkProductData.SaveData(drinkProducts);
            foodProductData.SaveData(foodProducts);
            householdProductData.SaveData(householdProducts);

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
