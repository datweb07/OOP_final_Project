using OOP_finalProject.Data;
using System.Collections.Generic;

namespace OOP_finalProject
{
    public class OrderData : BaseDataRepository<OrderList, Order>
    {
        public OrderData() : base() { }
        public override List<Order> GetData()
        {
            OrderList orderList = Load();
            return orderList.Orders ?? new List<Order>();
        }
        public override void SaveData(List<Order> items)
        {
            OrderList orderList = new OrderList(items);
            Save(orderList);
        }
    }
}
