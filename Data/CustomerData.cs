using OOP_finalProject.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    [Serializable]
    public class CustomerData
    {
        private string filePath = Path.Combine(GetPath.path, nameof(Customer) + ".dat");
        public void WriteObject(CustomerList customerList)
        {
            try
            {
                NetDataContractSerializer formatter = new NetDataContractSerializer();
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    formatter.Serialize(fileStream, customerList);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }

        public CustomerList ReadObject()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File {filePath} không tồn tại. Trả về danh sách rỗng.");
                    return new CustomerList();
                }

                NetDataContractSerializer serializer = new NetDataContractSerializer();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    CustomerList customerList = (CustomerList)serializer.Deserialize(fileStream);
                    return customerList;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi đọc file: {ex.Message}");
                return new CustomerList();
            }
        }
        public List<Customer> GetData()
        {
            CustomerList customerList = ReadObject();
            return customerList.Customers ?? new List<Customer>();
        }

        public void SaveData(List<Customer> customers)
        {
            CustomerList customerList = new CustomerList(customers);
            WriteObject(customerList);
        }
    }
}
