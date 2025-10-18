using OOP_finalProject.Base;
using OOP_finalProject.Employees;
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
        
        /// <summary>
        /// Tổng giá trị đơn hàng (chưa giảm giá)
        /// </summary>
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

        /// <summary>
        /// Số tiền được giảm giá (Strategy Pattern)
        /// </summary>
        public virtual decimal DiscountAmount
        {
            get
            {
                if (Customer == null)
                {
                    return 0;
                }
                return Customer.CalculateDiscount(SumTotal);
            }
        }

        /// <summary>
        /// Tổng giá trị sau khi giảm giá
        /// </summary>
        public virtual decimal FinalTotal
        {
            get
            {
                return SumTotal - DiscountAmount;
            }
        }

        /// <summary>
        /// Phần trăm giảm giá của khách hàng
        /// </summary>
        public virtual decimal DiscountPercentage
        {
            get
            {
                if (Customer == null)
                {
                    return 0;
                }
                return Customer.GetDiscountPercentage();
            }
        }

        public Order()
        {
        }

        public Order(SerializationInfo info, StreamingContext context)
        {
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
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("OrderId", OrderId);
            info.AddValue("OrderDate", OrderDate);
            info.AddValue("CustomerName", CustomerName);
            info.AddValue("CashierName", CashierName);
            info.AddValue("OrderDetails", OrderDetails);
            info.AddValue("SumTotal", SumTotal);
        }
    }
}
