using OOP_finalProject.Base;
using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace OOP_finalProject
{
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
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }

        //private string pathDat = Path.Combine(GetPath.path, nameof(Cashier) + ".dat");

        //public List<Cashier> GetData()
        //{
        //    if (File.Exists(pathDat))
        //    {
        //        try
        //        {
        //            using (FileStream fs = new FileStream(pathDat, FileMode.Open))
        //            {
        //                BinaryFormatter bf = new BinaryFormatter();
        //                return (List<Cashier>)bf.Deserialize(fs);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"Lỗi đọc file .dat: {ex.Message}");
        //        }
        //    }
        //    return new List<Cashier>();
        //}

        //public void SaveData(List<Cashier> cashiers)
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
        //            bf.Serialize(fs, cashiers);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Lỗi ghi file .dat: {ex.Message}");
        //    }
        //}
    }
}
