using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    public class OrderData
    {
        private static string pathXml = Path.Combine(GetPath.path, nameof(Order) + ".dat");

        public static void WriteObject(OrderList orderList)
        {
            try
            {
                NetDataContractSerializer dataContractSerializer = new NetDataContractSerializer();
                using (FileStream fileStream = new FileStream(pathXml, FileMode.Create, FileAccess.Write))
                {
                    dataContractSerializer.Serialize(fileStream, orderList);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }

        public OrderList ReadObject()
        {
            try
            {
                if (!File.Exists(pathXml))
                {
                    Console.WriteLine($"File {pathXml} không tồn tại. Trả về danh sách rỗng.");
                    return new OrderList();
                }
                NetDataContractSerializer serializer = new NetDataContractSerializer();
                using (FileStream fileStream = new FileStream(pathXml, FileMode.Open))
                {
                    OrderList orderList = (OrderList)serializer.Deserialize(fileStream);
                    return orderList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi đọc file: {ex.Message}");
                return new OrderList();
            }
        }

        public List<Order> GetData()
        {
            OrderList orderList = ReadObject();
            return orderList.Orders ?? new List<Order>();
        }

        public void SaveData(List<Order> orders)
        {
            OrderList orderList = new OrderList(orders);
            WriteObject(orderList);
        }
    }
}
