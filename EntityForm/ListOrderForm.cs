using OOP_finalProject.Base;
using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OOP_finalProject
{
    public partial class ListOrderForm : Form
    {
        public ListOrderForm()
        {
            InitializeComponent();
        }

        private DrinkProductData drinkProductData = new DrinkProductData();
        private FoodProductData foodProductData = new FoodProductData();
        private HouseholdProductData householdProductData = new HouseholdProductData();
        private ElectronicProductData electronicProductData = new ElectronicProductData();
        private ClothingProductData clothingProductData = new ClothingProductData();

        OrderData orderData = new OrderData();
        BindingSource src = new BindingSource();
        private List<Order> orders = new List<Order>();
        private List<Order> filteredOrders = new List<Order>();

        private void FormOrderList_Load(object sender, EventArgs e)
        {
            gridData.ReadOnly = true;
            gridData.AllowUserToAddRows = false;
            gridData.AutoGenerateColumns = false;
            gridData.DataSource = src;

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

            cmbSort.SelectedIndex = 0;

            orders = orderData.GetData();
            filteredOrders = new List<Order>(orders);
            LoadGrid();
            UpdateStatistics();
        }

        private void LoadGrid()
        {
            src.DataSource = filteredOrders;
            src.ResetBindings(true);
            UpdateStatistics();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OrderForm frm = new OrderForm();
            frm.ShowDialog();

            // load lại data sau khi form đóng
            orders = orderData.GetData();
            filteredOrders = new List<Order>(orders);
            LoadGrid();

            statusLabel.Text = "Đã thêm đơn hàng mới";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Order order = gridData.CurrentRow.DataBoundItem as Order;

            if (order == null)
                return;

            OrderForm frm = new OrderForm(order);
            frm.ShowDialog();

            // load lại data sau khi form đóng
            orders = orderData.GetData();
            filteredOrders = new List<Order>(orders);
            LoadGrid();

            statusLabel.Text = "Đã cập nhật đơn hàng";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Order order = gridData.CurrentRow.DataBoundItem as Order;

            if (order == null)
            {
                MessageBox.Show("Không có đơn hàng nào được chọn !"
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xoá đơn hàng '" + order.OrderId + "'?\n\nThao tác này không thể hoàn tác!",
                "Xác nhận xoá", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<Order> allOrders = orderData.GetData();
                Order toDelete = null;
                for (int i = 0; i < allOrders.Count; i++)
                {
                    if (allOrders[i].OrderId.ToLower() == order.OrderId.ToLower())
                    {
                        toDelete = allOrders[i];
                        break;
                    }
                }

                if (toDelete == null)
                {
                    MessageBox.Show("Không tìm thấy đơn hàng cần xoá !"
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // cập nhật lại số lượng sản phẩm
                RestoreProductQuantities(toDelete);

                allOrders.Remove(toDelete);
                orderData.SaveData(allOrders);

                // cập nhật danh sách
                orders = allOrders;
                filteredOrders = new List<Order>(orders);
                LoadGrid();

                MessageBox.Show("Xoá đơn hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusLabel.Text = "Đã xóa đơn hàng thành công";
                statusLabel.ForeColor = Color.FromArgb(46, 204, 113);
            }
        }

        private void RestoreProductQuantities(Order order)
        {
            List<DrinkProduct> drinkProducts = drinkProductData.GetData();
            List<FoodProduct> foodProducts = foodProductData.GetData();
            List<HouseholdProduct> householdProducts = householdProductData.GetData();
            List<ElectronicProduct> electronicProducts = electronicProductData.GetData();
            List<ClothingProduct> clothingProducts = clothingProductData.GetData();

            for (int i = 0; i < order.OrderDetails.Count; i++)
            {
                OrderDetails detail = order.OrderDetails[i];
                RestoreProductQuantity(detail.Product, detail.Quantity, drinkProducts, foodProducts, householdProducts, electronicProducts, clothingProducts);
            }

            drinkProductData.SaveData(drinkProducts);
            foodProductData.SaveData(foodProducts);
            householdProductData.SaveData(householdProducts);
            electronicProductData.SaveData(electronicProducts);
            clothingProductData.SaveData(clothingProducts);
        }

        private void RestoreProductQuantity(Product product, decimal quantity,
            List<DrinkProduct> drinkProducts, List<FoodProduct> foodProducts,
            List<HouseholdProduct> householdProducts, List<ElectronicProduct> electronicProducts,
            List<ClothingProduct> clothingProducts)
        {
            if (product is DrinkProduct)
            {
                RestoreProductListQuantity(drinkProducts, product.Id, quantity);
            }
            else if (product is FoodProduct)
            {
                RestoreProductListQuantity(foodProducts, product.Id, quantity);
            }
            else if (product is HouseholdProduct)
            {
                RestoreProductListQuantity(householdProducts, product.Id, quantity);
            }
            else if (product is ElectronicProduct)
            {
                RestoreProductListQuantity(electronicProducts, product.Id, quantity);
            }
            else if (product is ClothingProduct)
            {
                RestoreProductListQuantity(clothingProducts, product.Id, quantity);
            }
        }

        private void RestoreProductListQuantity<T>(List<T> products, string productId, decimal quantity) where T : Product
        {
            for (int j = 0; j < products.Count; j++)
            {
                if (products[j].Id.ToLower() == productId.ToLower())
                {
                    products[j].Quantity = products[j].Quantity + quantity;
                    break;
                }
            }
        }

        private void btnDisplayInvoice_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Order order = gridData.CurrentRow.DataBoundItem as Order;

            if (order == null)
            {
                MessageBox.Show("Không có đơn hàng nào được chọn !"
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        // tìm kiếm đơn hàng
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbSort.SelectedIndex = 0;

            orders = orderData.GetData();
            filteredOrders = new List<Order>(orders);
            LoadGrid();
            statusLabel.Text = "Đã làm mới danh sách";
        }

        // lọc và tìm kiếm
        private void ApplyFiltersAndSearch()
        {
            // gắn danh sách đầy đủ
            filteredOrders = new List<Order>(orders);

            //  tìm kiếm
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                List<Order> searchResults = new List<Order>();
                string searchText = txtSearch.Text.ToLower();

                for (int i = 0; i < filteredOrders.Count; i++)
                {
                    Order order = filteredOrders[i];
                    if (order.OrderId.ToLower().Contains(searchText) ||
                        order.CashierName.ToLower().Contains(searchText) ||
                        order.CustomerName.ToLower().Contains(searchText))
                    {
                        searchResults.Add(order);
                    }
                }
                filteredOrders = searchResults;
            }

            // sắp xếp
            ApplySorting();

            LoadGrid();
            statusLabel.Text = "Tìm thấy " + filteredOrders.Count + " đơn hàng";
        }

        private void ApplySorting()
        {
            if (cmbSort.SelectedIndex == -1) return;

            switch (cmbSort.SelectedIndex)
            {
                case 0: // Mã ĐH (A-Z)
                    filteredOrders.Sort((p1, p2) => p1.OrderId.CompareTo(p2.OrderId));
                    break;
                case 1: // Mã ĐH (Z-A)
                    filteredOrders.Sort((p1, p2) => p2.OrderId.CompareTo(p1.OrderId));
                    break;
                case 2: // Ngày lập (Cũ-Nhất)
                    filteredOrders.Sort((p1, p2) => p1.OrderDate.CompareTo(p2.OrderDate));
                    break;
                case 3: // Ngày lập (Mới-Nhất)
                    filteredOrders.Sort((p1, p2) => p2.OrderDate.CompareTo(p1.OrderDate));
                    break;
                case 4: // Nhân viên (A-Z)
                    filteredOrders.Sort((p1, p2) => p1.CashierName.CompareTo(p2.CashierName));
                    break;
                case 5: // Nhân viên (Z-A)
                    filteredOrders.Sort((p1, p2) => p2.CashierName.CompareTo(p1.CashierName));
                    break;
                case 6: // Khách hàng (A-Z)
                    filteredOrders.Sort((p1, p2) => p1.CustomerName.CompareTo(p2.CustomerName));
                    break;
                case 7: // Khách hàng (Z-A)
                    filteredOrders.Sort((p1, p2) => p2.CustomerName.CompareTo(p1.CustomerName));
                    break;
                case 8: // Thành tiền (Thấp-Cao)
                    filteredOrders.Sort((p1, p2) => p1.FinalTotal.CompareTo(p2.FinalTotal));
                    break;
                case 9: // Thành tiền (Cao-Thấp)
                    filteredOrders.Sort((p1, p2) => p2.FinalTotal.CompareTo(p1.FinalTotal));
                    break;
            }
        }

        // thống kê chi tiết
        private void UpdateStatistics()
        {
            int totalOrders = filteredOrders.Count;

            decimal totalRevenue = 0;
            for (int i = 0; i < filteredOrders.Count; i++)
            {
                totalRevenue += filteredOrders[i].FinalTotal;
            }

            decimal totalDiscount = 0;
            for (int i = 0; i < filteredOrders.Count; i++)
            {
                totalDiscount += filteredOrders[i].DiscountAmount;
            }

            List<string> distinctCustomers = new List<string>();
            for (int i = 0; i < filteredOrders.Count; i++)
            {
                string customerName = filteredOrders[i].CustomerName;
                if (!string.IsNullOrEmpty(customerName) && !distinctCustomers.Contains(customerName))
                {
                    distinctCustomers.Add(customerName);
                }
            }
            int customerCount = distinctCustomers.Count;

            lblTotalOrdersValue.Text = totalOrders.ToString();
            lblTotalRevenueValue.Text = totalRevenue.ToString("N0") + " đ";
            lblTotalDiscountValue.Text = totalDiscount.ToString("N0") + " đ";
            lblCustomerCountValue.Text = customerCount.ToString();

            // đổi màu theo số lượng
            lblTotalOrdersValue.ForeColor = totalOrders > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalRevenueValue.ForeColor = totalRevenue > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalDiscountValue.ForeColor = totalDiscount > 0 ? Color.FromArgb(255, 165, 0) : Color.Gray;
            lblCustomerCountValue.ForeColor = customerCount > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
        }

        private void FilterChanged(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }
    }
}