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
        //private string pathDat = Path.Combine(GetPath.path, nameof(Customer) + ".dat");

        //public List<Customer> GetData()
        //{
        //    if (File.Exists(pathDat))
        //    {
        //        try
        //        {
        //            using (FileStream fs = new FileStream(pathDat, FileMode.Open))
        //            {
        //                BinaryFormatter bf = new BinaryFormatter();
        //                return (List<Customer>)bf.Deserialize(fs);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"Lỗi đọc file .dat: {ex.Message}");
        //        }
        //    }
        //    return new List<Customer>();
        //}

        //public void SaveData(List<Customer> customers)
        //{
        //    try
        //    {
        //        if (!Directory.Exists(GetPath.path))
        //        {
        //            Directory.CreateDirectory(GetPath.path);
        //        }

        //        using (FileStream fs = new FileStream(pathDat, FileMode.Create))
        //        {
        //            BinaryFormatter bf = new BinaryFormatter();
        //            bf.Serialize(fs, customers);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Lỗi ghi file .dat: {ex.Message}");
        //    }
        //}

        private string pathXml = Path.Combine(GetPath.path, nameof(Customer) + ".dat");
        public List<Customer> GetData()
        {
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
