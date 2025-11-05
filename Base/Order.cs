<<<<<<< HEAD
//using OOP_finalProject.Base;
//using OOP_finalProject.Customers;
//using OOP_finalProject.Employees;
//using System;
//using System.Collections.Generic;
//using System.Runtime.Serialization;
//using System.Xml.Serialization;

//namespace OOP_finalProject
//{
//    [Serializable]
//    public class Order : ISerializable
//    {
//        private string orderId;
//        private DateTime orderDate;

//        public string OrderId { get { return orderId; } set { orderId = value; } }
//        public DateTime OrderDate { get { return orderDate; } set { orderDate = value; } }
//        public virtual Customer Customer { get; set; }
//        public virtual string CustomerName
//        {
//            get
//            {
//                if (Customer == null)
//                {
//                    return "Không xác định";
//                }
//                return Customer.Name;
//            }
//        }
//        public virtual Cashier Cashier { get; set; }
//        public virtual string CashierName
//        {
//            get
//            {
//                if (Cashier == null)
//                {
//                    return "Không xác định";
//                }
//                return Cashier.Name;
//            }
//        }
//        public virtual List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

//        /// <summary>
//        /// Tổng giá trị đơn hàng (chưa giảm giá)
//        /// </summary>
//        public virtual decimal SumTotal
//        {
//            get
//            {
//                decimal total = 0;
//                foreach (OrderDetails detail in OrderDetails)
//                {
//                    total += detail.TotalPrice;
//                }
//                return total;
//            }
//        }

//        /// <summary>
//        /// Số tiền được giảm giá (Strategy Pattern)
//        /// </summary>
//        public virtual decimal DiscountAmount
//        {
//            get
//            {
//                if (Customer == null)
//                {
//                    return 0;
//                }
//                return Customer.CalculateDiscount(SumTotal);
//            }
//        }

//        /// <summary>
//        /// Tổng giá trị sau khi giảm giá
//        /// </summary>
//        public virtual decimal FinalTotal
//        {
//            get
//            {
//                return SumTotal - DiscountAmount;
//            }
//        }

//        /// <summary>
//        /// Phần trăm giảm giá của khách hàng
//        /// </summary>
//        public virtual decimal DiscountPercentage
//        {
//            get
//            {
//                if (Customer == null)
//                {
//                    return 0;
//                }
//                return Customer.GetDiscountPercentage();
//            }
//        }

//        public Order()
//        {
//        }

//        public Order(SerializationInfo info, StreamingContext context)
//        {
//            OrderId = info.GetString("OrderId");
//            OrderDate = info.GetDateTime("OrderDate");

//            string customerName = info.GetString("CustomerName");
//            string cashierName = info.GetString("CashierName");

//            if (customerName != "Không xác định")
//            {
//                Customer = new Customer { Name = customerName };
//            }

//            if (cashierName != "Không xác định")
//            {
//                Cashier = new Cashier { Name = cashierName };
//            }

//            OrderDetails = (List<OrderDetails>)info.GetValue("OrderDetails", typeof(List<OrderDetails>));
//        }

//        public void GetObjectData(SerializationInfo info, StreamingContext context)
//        {
//            info.AddValue("OrderId", OrderId);
//            info.AddValue("OrderDate", OrderDate);
//            info.AddValue("CustomerName", CustomerName);
//            info.AddValue("CashierName", CashierName);
//            info.AddValue("OrderDetails", OrderDetails);
//            info.AddValue("SumTotal", SumTotal);
//        }
//    }
//}


using OOP_finalProject.Base;
using OOP_finalProject.Customers;
using OOP_finalProject.Employees;
using OOP_finalProject.Interfaces;
using OOP_finalProject.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
=======
﻿using OOP_finalProject.Base;
using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    [Serializable]
<<<<<<< HEAD

=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
    public class Order : ISerializable
    {
        private string orderId;
        private DateTime orderDate;
<<<<<<< HEAD
        private Cashier cashier;
        private Customer customer;
        private List<OrderDetails> orderDetails;


        public string OrderId { get { return orderId; } set { orderId = value; } }


        public DateTime OrderDate { get { return orderDate; } set { orderDate = value; } }


        public Cashier Cashier { get { return cashier; } set { cashier = value; } }


        public Customer Customer { get { return customer; } set { customer = value; } }


        public List<OrderDetails> OrderDetails
        {
            get { return orderDetails ?? (orderDetails = new List<OrderDetails>()); }
            set { orderDetails = value; }
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

        // Computed properties (không serialized)
        public decimal SumTotal => OrderDetails.Sum(od => od.TotalPrice);
        public decimal DiscountPercentage => Customer?.GetDiscountPercentage() ?? 0;
        public decimal DiscountAmount => Customer?.CalculateDiscount(SumTotal) ?? 0;
        public decimal FinalTotal => SumTotal - DiscountAmount;
        public string DiscountInfo => Customer?.GetDiscountInfo() ?? "Không có giảm giá";

        public Order()
        {
            OrderDetails = new List<OrderDetails>();
            OrderDate = DateTime.Now;
=======

        public string OrderId { get { return orderId; } set { orderId = value; } }
        public DateTime OrderDate { get { return orderDate; } set { orderDate = value; } }
        public virtual Customer Customer { get; set; }
        public virtual string CustomerName
        {
            get
            {
                if (Customer == null)
                {
                    return "Không xác định";
                }
                return Customer.Name;
            }
        }
        public virtual Cashier Cashier { get; set; }
        public virtual string CashierName
        {
            get
            {
                if (Cashier == null)
                {
                    return "Không xác định";
                }
                return Cashier.Name;
            }
        }
        public virtual List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
        public virtual decimal SumTotal
        {
            get
            {
                decimal total = 0;
                foreach (OrderDetails detail in OrderDetails)
                {
                    total += detail.TotalPrice;
                }
                return total;
            }
        }

        public Order()
        {
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        }

        public Order(SerializationInfo info, StreamingContext context)
        {
<<<<<<< HEAD
            // Xử lý tất cả trường hợp lỗi
            try { OrderId = info.GetString("OrderId") ?? GenerateOrderId(); }
            catch { OrderId = GenerateOrderId(); }

            try { OrderDate = info.GetDateTime("OrderDate"); }
            catch { OrderDate = DateTime.Now; }

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

            // Xử lý OrderDetails
            try { OrderDetails = (List<OrderDetails>)info.GetValue("OrderDetails", typeof(List<OrderDetails>)); }
            catch { OrderDetails = new List<OrderDetails>(); }
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
                //string customerName = info.GetString("CustomerName");
                //if (!string.IsNullOrEmpty(customerName))
                //{
                //    return FindOrCreateCustomerByName(customerName);
                //}
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
=======
            OrderId = info.GetString("OrderId");
            OrderDate = info.GetDateTime("OrderDate");

            string customerName = info.GetString("CustomerName");
            string cashierName = info.GetString("CashierName");

            if (customerName != "Không xác định")
            {
                Customer = new Customer { Name = customerName };
            }

            if (cashierName != "Không xác định")
            {
                Cashier = new Cashier { Name = cashierName };
            }

            OrderDetails = (List<OrderDetails>)info.GetValue("OrderDetails", typeof(List<OrderDetails>));
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("OrderId", OrderId);
            info.AddValue("OrderDate", OrderDate);
<<<<<<< HEAD
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

        public decimal GetDiscountedPriceForDetail(OrderDetails detail)
        {
            if (detail == null) return 0;

            decimal discountRate = DiscountPercentage / 100;
            return detail.TotalPrice * (1 - discountRate);
        }
    }
}
=======
            info.AddValue("CustomerName", CustomerName);
            info.AddValue("CashierName", CashierName);
            info.AddValue("OrderDetails", OrderDetails);
            info.AddValue("SumTotal", SumTotal);
        }
    }
}
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
