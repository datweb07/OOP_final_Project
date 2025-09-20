using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
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
        OrderData orderData = new OrderData();
        BindingSource src = new BindingSource();
        private void FormOrderList_Load(object sender, EventArgs e)
        {
            gridData.ReadOnly = true;
            gridData.AllowUserToAddRows = false;
            gridData.AutoGenerateColumns = false;
            gridData.DataSource = src;
            LoadGrid();
        }

        private void LoadGrid()
        {
            src.DataSource = orderData.GetData();
            src.ResetBindings(true);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OrderForm frm = new OrderForm();
            frm.ShowDialog();
            LoadGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            Order order = gridData.CurrentRow.DataBoundItem as Order;

            if (order == null)
                return;

            OrderForm frm = new OrderForm(order);
            frm.ShowDialog();

            LoadGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            Order order = gridData.CurrentRow.DataBoundItem as Order;

            if (order == null)
            {
                MessageBox.Show("Không có đơn hàng nào được chọn !"
                 , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Bạn muốn xoá đơn hàng được chọn ?"
                , "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<Order> orders = orderData.GetData();
                Order toDelete = null;
                for (int i = 0; i < orders.Count; i++)
                {
                    if (orders[i].OrderId.ToLower() == order.OrderId.ToLower())
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
                orders.Remove(toDelete);
                orderData.SaveData(orders);
                LoadGrid();
            }
        }

        private void btnXemHoaDon_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

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
    }
}
