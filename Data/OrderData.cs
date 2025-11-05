<<<<<<< HEAD
=======
﻿using OOP_finalProject.Employees;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
<<<<<<< HEAD
=======
using System.Text;
using System.Text.Json;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7

namespace OOP_finalProject
{
    public class OrderData
    {
<<<<<<< HEAD
        private static string pathXml = Path.Combine(GetPath.path, nameof(Order) + ".dat");

        public static void WriteObject(OrderList orderList)
        {
            try
            {
                NetDataContractSerializer dataContractSerializer = new NetDataContractSerializer();
                using (FileStream fileStream = new FileStream(pathXml, FileMode.Create, FileAccess.Write))
                {
                    dataContractSerializer.Serialize(fileStream, orderList);
=======
        private string pathXml = Path.Combine(GetPath.path, nameof(Order) + ".xml");

        public List<Order> GetData()
        {
            if (File.Exists(pathXml))
            {
                try
                {
                    // Tạo DataContractSerializer cho List<Order>
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<Order>));

                    using (FileStream fileStream = new FileStream(pathXml, FileMode.Open, FileAccess.Read))
                    {
                        // Đọc dữ liệu từ file XML và chuyển đổi thành List<Order>
                        List<Order> orders = (List<Order>)serializer.ReadObject(fileStream);
                        return orders ?? new List<Order>();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc file: {ex.Message}");

                }
            }
            return new List<Order>();
        }

        public void SaveData(List<Order> orders)
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(GetPath.path))
                {
                    Directory.CreateDirectory(GetPath.path);
                }

                // Tạo DataContractSerializer cho List<Order>
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Order>));

                using (FileStream fileStream = new FileStream(pathXml, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file XML
                    serializer.WriteObject(fileStream, orders);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }
<<<<<<< HEAD

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
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
    }
}
