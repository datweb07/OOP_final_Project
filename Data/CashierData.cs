using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
<<<<<<< HEAD
    [Serializable]
    public class CashierData
    {
        private static string filePath = Path.Combine(GetPath.path, nameof(Cashier) + ".dat");

        public static void WriteObject(CashierList cashierList)
        {
            try
            {
                // Tạo NetDataContractSerializer
                NetDataContractSerializer dataContractSerializer = new NetDataContractSerializer();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file
                    dataContractSerializer.Serialize(fileStream, cashierList);
=======
    public class CashierData
    {
        private string pathXml = Path.Combine(GetPath.path, nameof(Cashier) + ".dat");

        public List<Cashier> GetData()
        {
            if (File.Exists(pathXml))
            {
                try
                {
                    // Tạo DataContractSerializer cho List<Cashier>
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<Cashier>));

                    using (FileStream fileStream = new FileStream(pathXml, FileMode.Open, FileAccess.Read))
                    {
                        // Đọc dữ liệu từ file XML và chuyển đổi thành List<Cashier>
                        List<Cashier> cashiers = (List<Cashier>)serializer.ReadObject(fileStream);
                        return cashiers ?? new List<Cashier>();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc file: {ex.Message}");

                }
            }
            return new List<Cashier>();
        }

        public void SaveData(List<Cashier> cashiers)
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(GetPath.path))
                {
                    Directory.CreateDirectory(GetPath.path);
                }

                // Tạo DataContractSerializer cho List<Cashier>
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Cashier>));

                using (FileStream fileStream = new FileStream(pathXml, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file XML
                    serializer.WriteObject(fileStream, cashiers);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }
<<<<<<< HEAD

        public CashierList ReadObject()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File {filePath} không tồn tại. Trả về danh sách rỗng.");
                    return new CashierList();
                }
                // Tạo NetDataContractSerializer
                NetDataContractSerializer serializer = new NetDataContractSerializer();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    // Đọc dữ liệu từ file và chuyển đổi thành CashierList
                    CashierList cashierList = (CashierList)serializer.Deserialize(fileStream);
                    return cashierList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi đọc file: {ex.Message}");
                return new CashierList();
            }
        }

        public List<Cashier> GetData()
        {
            CashierList cashierList = ReadObject();
            return cashierList.Cashiers ?? new List<Cashier>();
        }

        public void SaveData(List<Cashier> cashiers)
        {
            CashierList cashierList = new CashierList(cashiers);
            WriteObject(cashierList);
        }

        public static void CreateSampleData()
        {
            if (!File.Exists(filePath))
            {
                List<Cashier> cashiers = new List<Cashier>()
            {
                new Cashier("NV001", "Nguyễn Văn A", "Nam", "0901234567", "123 Lê Lợi, Q1, TP.HCM"),
                new Cashier("NV002", "Trần Thị B", "Nữ", "0912345678", "456 Nguyễn Huệ, Q3, TP.HCM"),
            };
                //  Tạo CashierList từ List<Cashier>
                CashierList cashierList = new CashierList(cashiers);

                WriteObject(cashierList);
            }
        }
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
    }
}
