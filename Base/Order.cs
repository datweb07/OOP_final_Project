using OOP_finalProject.Base;
using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;


namespace OOP_finalProject
{
    public class Order
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
                    return "Không xác định";
                return Customer.Name;
            }
        }
        public virtual Cashier Cashier { get; set; }
        public virtual string CashierName
        {
            get
            {
                if (Cashier == null)
                    return "Không xác định";
                return Cashier.Name;
            }
        }
        public virtual List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
        public virtual decimal TotalPrice
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
    }
}
