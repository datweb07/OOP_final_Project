//using OOP_finalProject.Products;
//using System;
//using System.Collections.Generic;
//using System.Windows.Forms;

//namespace OOP_finalProject
//{
//    public partial class ListOrderForm : Form
//    {
//        public ListOrderForm()
//        {
//            InitializeComponent();
//        }

//        private DrinkProductData drinkProductData = new DrinkProductData();
//        private FoodProductData foodProductData = new FoodProductData();
//        private HouseholdProductData householdProductData = new HouseholdProductData();
//        OrderData orderData = new OrderData();
//        BindingSource src = new BindingSource();
//        private void FormOrderList_Load(object sender, EventArgs e)
//        {
//            gridData.ReadOnly = true;
//            gridData.AllowUserToAddRows = false;
//            gridData.AutoGenerateColumns = false;
//            gridData.DataSource = src;
//            LoadGrid();
//        }

//        private void LoadGrid()
//        {
//            src.DataSource = orderData.GetData();
//            src.ResetBindings(true);
//        }

//        private void btnAdd_Click(object sender, EventArgs e)
//        {
//            OrderForm frm = new OrderForm();
//            frm.ShowDialog();
//            LoadGrid();
//        }

//        private void btnEdit_Click(object sender, EventArgs e)
//        {
//            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
//                return;

//            Order order = gridData.CurrentRow.DataBoundItem as Order;

//            if (order == null)
//                return;

//            OrderForm frm = new OrderForm(order);
//            frm.ShowDialog();

//            LoadGrid();
//        }

//        private void btnDelete_Click(object sender, EventArgs e)
//        {
//            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
//                return;

//            Order order = gridData.CurrentRow.DataBoundItem as Order;

//            if (order == null)
//            {
//                MessageBox.Show("Không có đơn hàng nào được chọn !"
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            if (MessageBox.Show("Bạn muốn xoá đơn hàng được chọn ?"
//                , "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
//            {
//                List<Order> orders = orderData.GetData();
//                Order toDelete = null;
//                for (int i = 0; i < orders.Count; i++)
//                {
//                    if (orders[i].OrderId.ToLower() == order.OrderId.ToLower())
//                    {
//                        toDelete = orders[i];
//                        break;
//                    }
//                }

//                if (toDelete == null)
//                {
//                    MessageBox.Show("Không tìm thấy đơn hàng cần xoá !"
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                    return;
//                }
//                // Cập nhật lại số lượng sản phẩm

//                List<DrinkProduct> drinkProducts = drinkProductData.GetData();
//                List<FoodProduct> foodProducts = foodProductData.GetData();
//                List<HouseholdProduct> householdProducts = householdProductData.GetData();

//                for (int i = 0; i < toDelete.OrderDetails.Count; i++)
//                {
//                    if (toDelete.OrderDetails[i].Product is DrinkProduct)
//                    {
//                        for (int j = 0; j < drinkProducts.Count; j++)
//                        {
//                            if (drinkProducts[j].Id.ToLower() == toDelete.OrderDetails[i].Product.Id.ToLower())
//                            {
//                                drinkProducts[j].Quantity = drinkProducts[j].Quantity + toDelete.OrderDetails[i].Quantity;
//                                break;
//                            }
//                        }
//                    }

//                    if (toDelete.OrderDetails[i].Product is FoodProduct)
//                    {
//                        for (int j = 0; j < foodProducts.Count; j++)
//                        {
//                            if (foodProducts[j].Id.ToLower() == toDelete.OrderDetails[i].Product.Id.ToLower())
//                            {
//                                foodProducts[j].Quantity = foodProducts[j].Quantity + toDelete.OrderDetails[i].Quantity;

//                                break;
//                            }
//                        }
//                    }

//                    if (toDelete.OrderDetails[i].Product is HouseholdProduct)
//                    {
//                        for (int j = 0; j < householdProducts.Count; j++)
//                        {
//                            if (householdProducts[j].Id.ToLower() == toDelete.OrderDetails[i].Product.Id.ToLower())
//                            {
//                                householdProducts[j].Quantity = householdProducts[j].Quantity + toDelete.OrderDetails[i].Quantity;
//                                break;
//                            }
//                        }
//                    }
//                }

//                drinkProductData.SaveData(drinkProducts);
//                foodProductData.SaveData(foodProducts);
//                householdProductData.SaveData(householdProducts);
//                orders.Remove(toDelete);
//                orderData.SaveData(orders);
//                LoadGrid();
//            }
//        }

//        private void btnXemHoaDon_Click(object sender, EventArgs e)
//        {
//            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
//                return;

//            Order order = gridData.CurrentRow.DataBoundItem as Order;

//            if (order == null)
//            {
//                MessageBox.Show("Không có đơn hàng nào được chọn !"
//                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
//    }
//}

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
        private OrderData orderData = new OrderData();
        private BindingSource src = new BindingSource();

        private void FormOrderList_Load(object sender, EventArgs e)
        {
            InitializeDataGrid();
            LoadGrid();
        }

        private void InitializeDataGrid()
        {
            gridData.ReadOnly = true;
            gridData.AllowUserToAddRows = false;
            gridData.AutoGenerateColumns = false;
            gridData.DataSource = src;
        }

        private void LoadGrid()
        {
            try
            {
                var orders = orderData.GetData();
                src.DataSource = orders;
                src.ResetBindings(false);

                UpdateSummary(orders);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load danh sách đơn hàng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSummary(List<Order> orders)
        {
            if (orders == null || orders.Count == 0)
            {
                lblSummary.Text = "Tổng số: 0 đơn hàng";
                return;
            }

            int totalOrders = orders.Count;
            decimal totalRevenue = orders.Sum(o => o.FinalTotal);
            int totalItems = orders.Sum(o => o.OrderDetails.Sum(od => (int)od.Quantity));

            lblSummary.Text = $"Tổng số: {totalOrders} đơn hàng | {totalItems} sản phẩm | Doanh thu: {totalRevenue:N0} đ";
            lblSummary.ForeColor = Color.FromArgb(46, 204, 113);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                OrderForm frm = new OrderForm();
                frm.ShowDialog();
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm đơn hàng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridData.CurrentRow == null || gridData.CurrentRow.DataBoundItem == null)
                {
                    MessageBox.Show("Vui lòng chọn đơn hàng cần sửa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Order order = gridData.CurrentRow.DataBoundItem as Order;
                if (order == null)
                {
                    MessageBox.Show("Đơn hàng không hợp lệ!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                OrderForm frm = new OrderForm(order);
                frm.ShowDialog();
                LoadGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sửa đơn hàng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridData.CurrentRow == null || gridData.CurrentRow.DataBoundItem == null)
                {
                    MessageBox.Show("Vui lòng chọn đơn hàng cần xóa!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Order order = gridData.CurrentRow.DataBoundItem as Order;
                if (order == null)
                {
                    MessageBox.Show("Đơn hàng không hợp lệ!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var result = MessageBox.Show(
                    $"Bạn có chắc muốn xóa đơn hàng {order.OrderId}?\nThao tác này không thể hoàn tác!",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteOrder(order);
                    LoadGrid();
                    MessageBox.Show("Đã xóa đơn hàng thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa đơn hàng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteOrder(Order orderToDelete)
        {
            List<Order> orders = orderData.GetData();
            Order order = orders.FirstOrDefault(o => o.OrderId == orderToDelete.OrderId);
            if (order != null)
            {
                RestoreProductQuantities(order);
                orders.Remove(order);
                orderData.SaveData(orders);
            }
        }

        private void RestoreProductQuantities(Order order)
        {
            var drinkProducts = drinkProductData.GetData();
            var foodProducts = foodProductData.GetData();
            var householdProducts = householdProductData.GetData();
            var electronicProducts = electronicProductData.GetData();
            var clothingProducts = clothingProductData.GetData();

            foreach (var detail in order.OrderDetails)
            {
                RestoreProductQuantity(detail.Product, detail.Quantity,
                    drinkProducts, foodProducts, householdProducts,
                    electronicProducts, clothingProducts);
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
            var product = products.FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                product.Quantity += quantity;
            }
        }

        private void btnXemHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridData.CurrentRow == null || gridData.CurrentRow.DataBoundItem == null)
                {
                    MessageBox.Show("Vui lòng chọn đơn hàng cần xem hóa đơn!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Order order = gridData.CurrentRow.DataBoundItem as Order;
                if (order == null)
                {
                    MessageBox.Show("Đơn hàng không hợp lệ!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Invoice invoice = CreateInvoiceFromOrder(order);
                InvoiceForm frm = new InvoiceForm(invoice);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xem hóa đơn: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Invoice CreateInvoiceFromOrder(Order order)
        {
            var invoice = new Invoice
            {
                Id = order.OrderId,
                DateCreated = order.OrderDate,
                Cashier = order.Cashier,
                Customer = order.Customer,
                //SubTotal = order.SumTotal,
                //DiscountAmount = order.DiscountAmount,
                //DiscountPercentage = order.DiscountPercentage,
                //FinalTotal = order.FinalTotal
            };

            foreach (var detail in order.OrderDetails)
            {
                invoice.InvoiceDetails.Add(new InvoiceDetails()
                {
                    ProductID = detail.Product.Id,
                    ProductName = detail.Product.Name,
                    Quantity = detail.Quantity,
                    UnitPrice = detail.Product.Price,
                    //TotalPrice = detail.TotalPrice
                });
            }

            return invoice;
        }

        private void gridData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gridData.Columns[e.ColumnIndex].DataPropertyName == "FinalTotal" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal value))
                {
                    e.Value = value.ToString("N0") + " đ";
                    e.FormattingApplied = true;
                }
            }

            if (gridData.Columns[e.ColumnIndex].DataPropertyName == "OrderDate" && e.Value != null)
            {
                if (DateTime.TryParse(e.Value.ToString(), out DateTime date))
                {
                    e.Value = date.ToString("dd/MM/yyyy HH:mm");
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadGrid();
        }
    }
}