using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    public class OrderData
    {
        private static string filePath = Path.Combine(GetPath.path, nameof(Order) + ".dat");

        public static void WriteObject(OrderList orderList)
        {
            try
            {
                NetDataContractSerializer netDataContractSerializer = new NetDataContractSerializer();
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    netDataContractSerializer.Serialize(fileStream, orderList);
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
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File {filePath} không tồn tại. Trả về danh sách rỗng.");
                    return new OrderList();
                }

                NetDataContractSerializer netDataContractSerializer = new NetDataContractSerializer();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    OrderList orderList = (OrderList)netDataContractSerializer.Deserialize(fileStream);
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
