using OOP_finalProject.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    public class CustomerData
    {
        private string pathXml = Path.Combine(GetPath.path, nameof(Customer) + ".xml");

        public List<Customer> GetData()
        {
            Console.WriteLine("Đường dẫn JSON: " + pathXml);
            if (File.Exists(pathXml))
            {
                try
                {
                    // Tạo DataContractSerializer cho List<Customer>
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<Customer>));

                    using (FileStream fileStream = new FileStream(pathXml, FileMode.Open, FileAccess.Read))
                    {
                        // Đọc dữ liệu từ file XML và chuyển đổi thành List<Customer>
                        List<Customer> customers = (List<Customer>)serializer.ReadObject(fileStream);
                        return customers ?? new List<Customer>();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc file: {ex.Message}");
                    
                }
            }
            return new List<Customer>();
        }

        public void SaveData(List<Customer> customers)
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(GetPath.path))
                {
                    Directory.CreateDirectory(GetPath.path);
                }

                // Tạo DataContractSerializer cho List<Customer>
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Customer>));

                using (FileStream fileStream = new FileStream(pathXml, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file XML
                    serializer.WriteObject(fileStream, customers);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }
    }
}
