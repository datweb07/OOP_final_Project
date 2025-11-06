using OOP_finalProject.Base;
using OOP_finalProject.Customers;
using OOP_finalProject.Employees;
using OOP_finalProject.Interfaces;
using OOP_finalProject.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    [Serializable]
    public class Invoice : ISerializable
    {
        private string id;
        private DateTime dateCreated;
        private Customer customer;
        private Cashier cashier;
        private List<InvoiceDetails> invoiceDetails;


        public string Id { get { return id; } set { id = value; } }


        public DateTime DateCreated { get { return dateCreated; } set { dateCreated = value; } }


        public Customer Customer
        {
            get { return customer; }
            set
            {
                customer = value;
                if (customer != null)
                {
                    RestoreCustomerDiscountStrategy(customer);
                }
            }
        }

        public Cashier Cashier { get { return cashier; } set { cashier = value; } }


        public List<InvoiceDetails> InvoiceDetails
        {
            get { return invoiceDetails ?? (invoiceDetails = new List<InvoiceDetails>()); }
            set { invoiceDetails = value; }
        }

        public string CashierName
        {
            get
            {
                return Cashier?.Name ?? "Không xác định";
            }
        }

        public string CustomerName
        {
            get
            {
                return Customer?.Name ?? "Không xác định";
            }
        }

        public string CustomerTypeDisplay
        {
            get
            {
                return Customer?.CustomerType ?? "Không xác định";
            }
        }

        public decimal SubTotal => InvoiceDetails.Sum(d => d.TotalPrice);
        public decimal SumTotal => SubTotal; // Alias cho tương thích
        public decimal DiscountPercentage => Customer?.GetDiscountPercentage() ?? 0;
        public decimal DiscountAmount => Customer?.CalculateDiscount(SubTotal) ?? 0;
        public decimal FinalTotal => SubTotal - DiscountAmount;
        public string DiscountInfo => Customer?.GetDiscountInfo() ?? "Không có giảm giá";

        public Invoice()
        {
            InvoiceDetails = new List<InvoiceDetails>();
            DateCreated = DateTime.Now;
        }

        public Invoice(SerializationInfo info, StreamingContext context)
        {
            // Xử lý tất cả trường hợp lỗi
            try { Id = info.GetString("Id") ?? GenerateInvoiceId(); }
            catch { Id = GenerateInvoiceId(); }

            try { DateCreated = info.GetDateTime("DateCreated"); }
            catch { DateCreated = DateTime.Now; }

            // Xử lý Cashier
            try { Cashier = (Cashier)info.GetValue("Cashier", typeof(Cashier)); }
            catch
            {
                try
                {
                    string cashierName = info.GetString("CashierName");
                    Cashier = CreateCashierFromName(cashierName);
                }
                catch { Cashier = GetDefaultCashier(); }
            }

            // Xử lý Customer - QUAN TRỌNG
            try { Customer = (Customer)info.GetValue("Customer", typeof(Customer)); }
            catch
            {
                Customer = CreateCustomerFromAvailableData(info);
            }

            // Đảm bảo Customer có discount strategy
            if (Customer != null)
            {
                RestoreCustomerDiscountStrategy(Customer);
            }

            // Xử lý InvoiceDetails
            try { InvoiceDetails = (List<InvoiceDetails>)info.GetValue("InvoiceDetails", typeof(List<InvoiceDetails>)); }
            catch { InvoiceDetails = new List<InvoiceDetails>(); }
        }

        private Customer CreateCustomerFromAvailableData(SerializationInfo info)
        {
            try
            {
                // Thử lấy Customer object trực tiếp
                var customer = (Customer)info.GetValue("Customer", typeof(Customer));
                if (customer != null) return customer;
            }
            catch { }

            try
            {
                // Thử lấy CustomerName cũ
                string customerName = info.GetString("CustomerName");
                if (!string.IsNullOrEmpty(customerName))
                {
                    //return FindOrCreateCustomerByName(customerName);
                }
            }
            catch { }

            return GetDefaultCustomer();
        }

        //private Customer FindOrCreateCustomerByName(string customerName)
        //{
        //    try
        //    {
        //        var customerData = new CustomerData();
        //        var customers = customerData.GetData();
        //        var existingCustomer = customers.FirstOrDefault(c =>
        //            c.Name.Equals(customerName, StringComparison.OrdinalIgnoreCase));

        //        return existingCustomer ?? CreateCustomerFromName(customerName);
        //    }
        //    catch
        //    {
        //        return CreateCustomerFromName(customerName);
        //    }
        //}

        //private Customer CreateCustomerFromName(string name)
        //{
        //    // Xác định loại customer dựa trên name
        //    var vipNames = new[] { "Trương Thị Hương", "Võ Văn Giang", "Đặng Thị Hoa", "Bùi Văn Hùng", "Lý Thị Kim" };

        //    if (vipNames.Contains(name))
        //    {
        //        var vip = new VIPCustomer
        //        {
        //            Name = name,
        //            CustomerType = "Khách hàng VIP"
        //        };
        //        vip.SetDiscountStrategy(new VIPCustomerDiscountStrategy());
        //        return vip;
        //    }
        //    else
        //    {
        //        var regular = new RegularCustomer
        //        {
        //            Name = name,
        //            CustomerType = "Khách hàng thường"
        //        };
        //        regular.SetDiscountStrategy(new RegularCustomerDiscountStrategy());
        //        return regular;
        //    }
        //}

        private void RestoreCustomerDiscountStrategy(Customer customer)
        {
            if (customer == null) return;

            if (customer is VIPCustomer || customer.CustomerType?.Contains("VIP") == true)
            {
                customer.SetDiscountStrategy(new VIPCustomerDiscountStrategy());
            }
            else
            {
                customer.SetDiscountStrategy(new RegularCustomerDiscountStrategy());
            }
        }

        private Cashier CreateCashierFromName(string name)
        {
            return new Cashier { Name = name ?? "Nhân viên" };
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("DateCreated", DateCreated);
            info.AddValue("Cashier", Cashier);
            info.AddValue("Customer", Customer);
            info.AddValue("InvoiceDetails", InvoiceDetails);
        }

        private string GenerateInvoiceId()
        {
            return $"HD{DateTime.Now:yyyyMMddHHmmss}";
        }

        private Cashier GetDefaultCashier()
        {
            return new Cashier { Name = "Nhân viên" };
        }

        private Customer GetDefaultCustomer()
        {
            var customer = new RegularCustomer
            {
                Name = "Khách lẻ",
                CustomerType = "Khách hàng thường"
            };
            customer.SetDiscountStrategy(new RegularCustomerDiscountStrategy());
            return customer;
        }

        // Method để tạo Invoice từ Order
        public static Invoice CreateFromOrder(Order order)
        {
            var invoice = new Invoice
            {
                Id = order.OrderId,
                DateCreated = order.OrderDate,
                Cashier = order.Cashier,
                Customer = order.Customer
            };

            // Copy order details sang invoice details
            foreach (var orderDetail in order.OrderDetails)
            {
                invoice.InvoiceDetails.Add(new InvoiceDetails
                {
                    ProductID = orderDetail.Product.Id,
                    ProductName = orderDetail.Product.Name,
                    Quantity = orderDetail.Quantity,
                    UnitPrice = orderDetail.Product.Price,
                    TotalPrice = orderDetail.TotalPrice
                });
            }

            return invoice;
        }

        // Method để validate invoice
        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Id) &&
                   InvoiceDetails != null &&
                   InvoiceDetails.Count > 0 &&
                   InvoiceDetails.All(d => d.Quantity > 0 && d.UnitPrice >= 0);
        }

        // Method để thêm invoice detail
        public void AddInvoiceDetail(InvoiceDetails detail)
        {
            if (detail == null) return;

            // Kiểm tra xem sản phẩm đã tồn tại chưa
            var existingDetail = InvoiceDetails.FirstOrDefault(d => d.ProductID == detail.ProductID);
            if (existingDetail != null)
            {
                existingDetail.Quantity += detail.Quantity;
            }
            else
            {
                InvoiceDetails.Add(detail);
            }
        }

        // Method để xóa invoice detail
        public bool RemoveInvoiceDetail(string productId)
        {
            var detail = InvoiceDetails.FirstOrDefault(d => d.ProductID == productId);
            if (detail != null)
            {
                return InvoiceDetails.Remove(detail);
            }
            return false;
        }

        // Method để clear all details
        public void ClearInvoiceDetails()
        {
            InvoiceDetails.Clear();
        }

        // Method để lấy thông tin summary
        public string GetSummary()
        {
            return $"Hóa đơn {Id}: {InvoiceDetails.Count} sản phẩm, Tổng: {SubTotal:N0}đ, Giảm: {DiscountAmount:N0}đ, Thành tiền: {FinalTotal:N0}đ";
        }
    }
}
