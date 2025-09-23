using OOP_finalProject.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
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
        }

        public void SaveData(List<Customer> customers)
        {
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
