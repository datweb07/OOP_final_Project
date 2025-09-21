using OOP_finalProject.Base;
using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
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
