using OOP_finalProject.Base;
<<<<<<< HEAD
using OOP_finalProject.Customers;
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
<<<<<<< HEAD

namespace OOP_finalProject
{
    [Serializable]
    public class CustomerData
    {
        private static string filePath = Path.Combine(GetPath.path, nameof(Customer) + ".dat");
        public static void WriteObject(CustomerList customerList)
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
=======
using System.Runtime.Serialization.Formatters.Binary;

namespace OOP_finalProject
{
    public class CustomerData
    {
        private string pathDat = Path.Combine(GetPath.path, nameof(Customer) + ".dat");

        public List<Customer> GetData()
        {
            if (File.Exists(pathDat))
            {
                try
                {
                    using (FileStream fs = new FileStream(pathDat, FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        return (List<Customer>)bf.Deserialize(fs);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc file .dat: {ex.Message}");
                }
            }
            return new List<Customer>();
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
        }

        public void SaveData(List<Customer> customers)
        {
<<<<<<< HEAD
            CustomerList customerList = new CustomerList(customers);
            WriteObject(customerList);
        }

        public static void CreateSampleData()
        {
            if (!File.Exists(filePath))
            {
                List<Customer> sampleCustomers = new List<Customer>()
                    {
                        new RegularCustomer("KH001", "Nguyễn Văn An", "Nam", "0901234567", "123 Lê Lợi, Quận 1, TP.HCM"),
                        new RegularCustomer("KH002", "Trần Thị Bình", "Nữ", "0912345678", "45 Nguyễn Huệ, Quận 1, TP.HCM"),
                        new RegularCustomer("KH003", "Lê Văn Cường", "Nam", "0923456789", "78 Trần Hưng Đạo, Quận 5, TP.HCM"),
                        new RegularCustomer("KH004", "Phạm Thị Dung", "Nữ", "0934567890", "321 Võ Văn Tần, Quận 3, TP.HCM"),
                        new RegularCustomer("KH005", "Hoàng Văn Em", "Nam", "0945678901", "56 Cách Mạng Tháng 8, Quận 3, TP.HCM"),
                        new VIPCustomer("KH006", "Trương Thị Hương", "Nữ", "0956789012", "12 Hai Bà Trưng, Quận 1, TP.HCM"),
                        new VIPCustomer("KH007", "Võ Văn Giang", "Nam", "0967890123", "234 Pasteur, Quận 3, TP.HCM"),
                        new VIPCustomer("KH008", "Đặng Thị Hoa", "Nữ", "0978901234", "67 Lý Tự Trọng, Quận 1, TP.HCM"),
                        new VIPCustomer("KH009", "Bùi Văn Hùng", "Nam", "0989012345", "89 Nguyễn Đình Chiểu, Quận 3, TP.HCM"),
                        new VIPCustomer("KH010", "Lý Thị Kim", "Nữ", "0990123456", "101 Nam Kỳ Khởi Nghĩa, Quận 1, TP.HCM"),
                    };
                CustomerList customerList = new CustomerList(sampleCustomers);
                WriteObject(customerList);
            }
        }
    }
}
=======
            try
            {
                if (!Directory.Exists(GetPath.path))
                {
                    Directory.CreateDirectory(GetPath.path);
                }

                using (FileStream fs = new FileStream(pathDat, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, customers);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file .dat: {ex.Message}");
            }
        }
    }

}
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
