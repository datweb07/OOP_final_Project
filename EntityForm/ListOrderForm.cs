using OOP_finalProject.Base;
using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
            // Cấu hình DataGridView
            gridData.ReadOnly = true;
            gridData.AllowUserToAddRows = false;
            gridData.AutoGenerateColumns = false;
            gridData.DataSource = src;

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

            // Thiết lập mặc định
            cmbSort.SelectedIndex = 0;

            orders = orderData.GetData();
            filteredOrders = orders.ToList();
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

            // Reload data after form closes
            orders = orderData.GetData();
            filteredOrders = orders.ToList();
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

            // Reload data after form closes
            orders = orderData.GetData();
            filteredOrders = orders.ToList();
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

            if (MessageBox.Show($"Bạn có chắc chắn muốn xoá đơn hàng '{order.OrderId}'?\n\nThao tác này không thể hoàn tác!",
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

                // Cập nhật lại số lượng sản phẩm
                RestoreProductQuantities(toDelete);

                allOrders.Remove(toDelete);
                orderData.SaveData(allOrders);

                // Cập nhật danh sách
                orders = allOrders;
                filteredOrders = orders.ToList();
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
                var detail = order.OrderDetails[i];
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

        private void btnXemHoaDon_Click(object sender, EventArgs e)
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

        #region Các chức năng mới

        /// <summary>
        /// Tìm kiếm đơn hàng
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        /// <summary>
        /// Làm mới danh sách
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbSort.SelectedIndex = 0;

            orders = orderData.GetData();
            filteredOrders = orders.ToList();
            LoadGrid();
            statusLabel.Text = "Đã làm mới danh sách";
        }

        /// <summary>
        /// Áp dụng tất cả bộ lọc và tìm kiếm
        /// </summary>
        private void ApplyFiltersAndSearch()
        {
            // Bắt đầu từ danh sách đầy đủ
            filteredOrders = orders.ToList();

            // Áp dụng tìm kiếm
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                filteredOrders = filteredOrders.Where(p =>
                    p.OrderId.ToLower().Contains(txtSearch.Text.ToLower()) ||
                    p.CashierName.ToLower().Contains(txtSearch.Text.ToLower()) ||
                    p.CustomerName.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
            }

            // Áp dụng sắp xếp
            ApplySorting();

            LoadGrid();
            statusLabel.Text = $"Tìm thấy {filteredOrders.Count} đơn hàng";
        }

        /// <summary>
        /// Áp dụng sắp xếp
        /// </summary>
        private void ApplySorting()
        {
            if (cmbSort.SelectedIndex == -1) return;

            switch (cmbSort.SelectedIndex)
            {
                case 0: // Mã ĐH (A-Z)
                    filteredOrders = filteredOrders.OrderBy(p => p.OrderId).ToList();
                    break;
                case 1: // Mã ĐH (Z-A)
                    filteredOrders = filteredOrders.OrderByDescending(p => p.OrderId).ToList();
                    break;
                case 2: // Ngày lập (Cũ-Nhất)
                    filteredOrders = filteredOrders.OrderBy(p => p.OrderDate).ToList();
                    break;
                case 3: // Ngày lập (Mới-Nhất)
                    filteredOrders = filteredOrders.OrderByDescending(p => p.OrderDate).ToList();
                    break;
                case 4: // Nhân viên (A-Z)
                    filteredOrders = filteredOrders.OrderBy(p => p.CashierName).ToList();
                    break;
                case 5: // Nhân viên (Z-A)
                    filteredOrders = filteredOrders.OrderByDescending(p => p.CashierName).ToList();
                    break;
                case 6: // Khách hàng (A-Z)
                    filteredOrders = filteredOrders.OrderBy(p => p.CustomerName).ToList();
                    break;
                case 7: // Khách hàng (Z-A)
                    filteredOrders = filteredOrders.OrderByDescending(p => p.CustomerName).ToList();
                    break;
                case 8: // Thành tiền (Thấp-Cao)
                    filteredOrders = filteredOrders.OrderBy(p => p.FinalTotal).ToList();
                    break;
                case 9: // Thành tiền (Cao-Thấp)
                    filteredOrders = filteredOrders.OrderByDescending(p => p.FinalTotal).ToList();
                    break;
            }
        }

        /// <summary>
        /// Cập nhật thống kê
        /// </summary>
        private void UpdateStatistics()
        {
            int totalOrders = filteredOrders.Count;
            decimal totalRevenue = filteredOrders.Sum(p => p.FinalTotal);
            decimal totalDiscount = filteredOrders.Sum(p => p.DiscountAmount);
            int customerCount = filteredOrders.Select(p => p.CustomerName).Distinct().Count();

            lblTotalOrdersValue.Text = totalOrders.ToString();
            lblTotalRevenueValue.Text = $"{totalRevenue:N0} đ";
            lblTotalDiscountValue.Text = $"{totalDiscount:N0} đ";
            lblCustomerCountValue.Text = customerCount.ToString();

            // Đổi màu theo số lượng
            lblTotalOrdersValue.ForeColor = totalOrders > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalRevenueValue.ForeColor = totalRevenue > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
            lblTotalDiscountValue.ForeColor = totalDiscount > 0 ? Color.FromArgb(255, 165, 0) : Color.Gray;
            lblCustomerCountValue.ForeColor = customerCount > 0 ? Color.FromArgb(46, 204, 113) : Color.Red;
        }

        /// <summary>
        /// Sự kiện khi thay đổi lựa chọn lọc
        /// </summary>
        private void FilterChanged(object sender, EventArgs e)
        {
            ApplyFiltersAndSearch();
        }

        #endregion
    }
}