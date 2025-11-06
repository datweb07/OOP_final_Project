using OOP_finalProject.Base;
using OOP_finalProject.Customers;
using OOP_finalProject.Employees;
using OOP_finalProject.Strategies;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    [Serializable]

    public class Order : ISerializable
    {
        private string orderId;
        private DateTime orderDate;
        private Cashier cashier;
        private Customer customer;
        private List<OrderDetails> orderDetails;


        public string OrderId { get { return orderId; } set { orderId = value; } }


        public DateTime OrderDate { get { return orderDate; } set { orderDate = value; } }


        public Cashier Cashier { get { return cashier; } set { cashier = value; } }


        public Customer Customer { get { return customer; } set { customer = value; } }


        public List<OrderDetails> OrderDetails
        {
            get 
            { 
                return orderDetails ?? (orderDetails = new List<OrderDetails>()); 
            }
            set 
            { 
                orderDetails = value; 
            }
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


        public decimal SumTotal
        {
            get
            {
                decimal total = 0;
                foreach (var detail in OrderDetails)
                {
                    total += detail.TotalPrice;
                }
                return total;
            }
        }
        public decimal DiscountPercentage
        {
            get
            {
                if (Customer != null)
                    return Customer.GetDiscountPercentage();
                return 0;
            }
        }
        public decimal DiscountAmount
        {
            get
            {
                if (Customer != null)
                    return Customer.CalculateDiscount(SumTotal);
                return 0;
            }
        }
        public decimal FinalTotal
        {
            get { return SumTotal - DiscountAmount; }
        }
        public string DiscountInfo
        {
            get
            {
                if (Customer != null)
                    return Customer.GetDiscountInfo();
                return "Không có giảm giá";
            }
        }

        public Order()
        {
            OrderDetails = new List<OrderDetails>();
            OrderDate = DateTime.Now;
        }

        public Order(SerializationInfo info, StreamingContext context)
        {
            // Xử lý tất cả trường hợp lỗi
            try 
            { 
                OrderId = info.GetString("OrderId") ?? GenerateOrderId(); 
            }
            catch 
            { 
                OrderId = GenerateOrderId(); 
            }

            try 
            { 
                OrderDate = info.GetDateTime("OrderDate"); 
            }
            catch 
            { 
                OrderDate = DateTime.Now; 
            }

            // Xử lý Cashier
            try 
            { 
                Cashier = (Cashier)info.GetValue("Cashier", typeof(Cashier)); 
            }
            catch
            {
                try
                {
                    string cashierName = info.GetString("CashierName");
                    Cashier = CreateCashierFromName(cashierName);
                }
                catch 
                { 
                    Cashier = GetDefaultCashier();
                }
            }

            // Xử lý Customer 
            try 
            { 
                Customer = (Customer)info.GetValue("Customer", typeof(Customer)); 
            }
            catch
            {
                Customer = CreateCustomerFromAvailableData(info);
            }

            // Đảm bảo Customer có discount strategy
            if (Customer != null)
            {
                RestoreCustomerDiscountStrategy(Customer);
            }

            // Xử lý OrderDetails
            try 
            { 
                OrderDetails = (List<OrderDetails>)info.GetValue("OrderDetails", typeof(List<OrderDetails>)); 
            }
            catch 
            { 
                OrderDetails = new List<OrderDetails>(); 
            }
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

            return GetDefaultCustomer();
        }

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
            return new Cashier { 
                Name = name ?? "Nhân viên" 
            };
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("OrderId", OrderId);
            info.AddValue("OrderDate", OrderDate);
            info.AddValue("Cashier", Cashier);
            info.AddValue("Customer", Customer);
            info.AddValue("OrderDetails", OrderDetails);
        }

        private string GenerateOrderId()
        {
            return $"DH{DateTime.Now:yyyyMMddHHmmss}";
        }

        private Cashier GetDefaultCashier()
        {
            return new Cashier { 
                Name = "Nhân viên" 
            };
        }

        private Customer GetDefaultCustomer()
        {
            RegularCustomer customer = new RegularCustomer
            {
                Name = "Khách lẻ",
                CustomerType = "Khách hàng thường"
            };
            customer.SetDiscountStrategy(new RegularCustomerDiscountStrategy());
            return customer;
        }

        public decimal GetDiscountedPriceForDetail(OrderDetails detail)
        {
            if (detail == null)
            {
                return 0;
            }

            decimal discountRate = DiscountPercentage / 100;
            return detail.TotalPrice * (1 - discountRate);
        }
    }
}