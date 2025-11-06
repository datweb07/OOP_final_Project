using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    [Serializable]
    public class OrderList : ISerializable
    {
        private List<Order> orders = new List<Order>();
        public List<Order> Orders { get { return orders; } set { orders = value; } }
        public OrderList()
        {
        }
        public OrderList(List<Order> orders)
        {
            Orders = orders;
        }
        public OrderList(SerializationInfo info, StreamingContext context)
        {
            Orders = (List<Order>)info.GetValue("Orders", typeof(List<Order>));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Orders", Orders);
        }
        public void AddOrder(Order order)
        {
            orders.Add(order);
        }
    }
}
