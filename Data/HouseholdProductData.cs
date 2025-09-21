using OOP_finalProject.Employees;
using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;

namespace OOP_finalProject
{
    public class HouseholdProductData
    {
        private string pathXml = Path.Combine(GetPath.path, nameof(HouseholdProduct) + ".xml");

        public List<HouseholdProduct> GetData()
        {
            if (File.Exists(pathXml))
            {
                try
                {
                    // Tạo DataContractSerializer cho List<HouseholdProduct>
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<HouseholdProduct>));

                    using (FileStream fileStream = new FileStream(pathXml, FileMode.Open, FileAccess.Read))
                    {
                        // Đọc dữ liệu từ file XML và chuyển đổi thành List<HouseholdProduct>
                        List<HouseholdProduct> householdProducts = (List<HouseholdProduct>)serializer.ReadObject(fileStream);
                        return householdProducts ?? new List<HouseholdProduct>();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc file: {ex.Message}");

                }
            }
            return new List<HouseholdProduct>();
        }

        public void SaveData(List<HouseholdProduct> householdProducts)
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(GetPath.path))
                {
                    Directory.CreateDirectory(GetPath.path);
                }

                // Tạo DataContractSerializer cho List<HouseholdProduct>
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<HouseholdProduct>));

                using (FileStream fileStream = new FileStream(pathXml, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file XML
                    serializer.WriteObject(fileStream, householdProducts);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }
    }
}
