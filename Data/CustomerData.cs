using OOP_finalProject.Base;
using OOP_finalProject.Customers;
using OOP_finalProject.Data;
using System.Collections.Generic;
using System.IO;

namespace OOP_finalProject
{
    public class CustomerData : BaseDataRepository<CustomerList, Customer>
    {
        public CustomerData() : base() { }

        public override List<Customer> GetData()
        {
            CustomerList list = Load();
            return list.Customers ?? new List<Customer>();
        }

        public override void SaveData(List<Customer> customers)
        {
            CustomerList list = new CustomerList(customers);
            Save(list);
        }

        public override void CreateSampleData()
        {
            if (!File.Exists(filePath))
            {
                List<Customer> customers = new List<Customer>()
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

                SaveData(customers);
            }
        }
    }
}