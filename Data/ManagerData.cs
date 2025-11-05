using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    public class ManagerData
    {
<<<<<<< HEAD
        private static string filePath = Path.Combine(GetPath.path, nameof(Manager) + ".dat");

        public static void WriteObject(ManagerList managerList)
        {
            try
            {
                // Tạo NetDataContractSerializer
                NetDataContractSerializer dataContractSerializer = new NetDataContractSerializer();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file
                    dataContractSerializer.Serialize(fileStream, managerList);
=======
        private string pathXml = Path.Combine(GetPath.path, nameof(Manager) + ".xml");

        public List<Manager> GetData()
        {
            if (File.Exists(pathXml))
            {
                try
                {
                    // Tạo DataContractSerializer cho List<Manager>
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<Manager>));

                    using (FileStream fileStream = new FileStream(pathXml, FileMode.Open, FileAccess.Read))
                    {
                        // Đọc dữ liệu từ file XML và chuyển đổi thành List<Manager>
                        List<Manager> managers = (List<Manager>)serializer.ReadObject(fileStream);
                        return managers ?? new List<Manager>();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc file: {ex.Message}");

                }
            }
            return new List<Manager>();
        }

        public void SaveData(List<Manager> managers)
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(GetPath.path))
                {
                    Directory.CreateDirectory(GetPath.path);
                }

                // Tạo DataContractSerializer cho List<Manager>
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Manager>));

                using (FileStream fileStream = new FileStream(pathXml, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file XML
                    serializer.WriteObject(fileStream, managers);
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }
<<<<<<< HEAD

        public ManagerList ReadObject()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File {filePath} không tồn tại. Trả về danh sách rỗng.");
                    return new ManagerList();
                }
                // Tạo NetDataContractSerializer
                NetDataContractSerializer serializer = new NetDataContractSerializer();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    // Đọc dữ liệu từ file và chuyển đổi thành ManagerList
                    ManagerList managerList = (ManagerList)serializer.Deserialize(fileStream);
                    return managerList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi đọc file: {ex.Message}");
                return new ManagerList();
            }
        }

        public List<Manager> GetData()
        {
            ManagerList managerList = ReadObject();
            return managerList.Managers ?? new List<Manager>();
        }

        public void SaveData(List<Manager> managers)
        {
            ManagerList managerList = new ManagerList(managers);
            WriteObject(managerList);
        }
        public static void CreateSampleData()
        {
            if (!File.Exists(filePath))
            {
                List<Manager> managers = new List<Manager>()
                {
                    new Manager("MG001", "Nguyễn Thị Lan", "Nữ", "0901123456", "123 Lê Lợi, Q1, TP.HCM", "Không có cửa hàng"),
                    new Manager("MG002", "Trần Văn Nam", "Nam", "0912234567", "456 Nguyễn Huệ, Q3, TP.HCM", "Không có cửa hàng"),
                };

                ManagerList managerList = new ManagerList(managers);
                WriteObject(managerList);
            }
        }
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
    }
}
