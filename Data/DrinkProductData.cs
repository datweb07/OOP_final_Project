using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    public class DrinkProductData
    {
        private string pathXml = Path.Combine(GetPath.path, nameof(DrinkProduct) + ".xml");

        public List<DrinkProduct> GetData()
        {
            if (File.Exists(pathXml))
            {
                try
                {
                    // Tạo DataContractSerializer cho List<DrinkProduct>
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<DrinkProduct>));

                    using (FileStream fileStream = new FileStream(pathXml, FileMode.Open, FileAccess.Read))
                    {
                        // Đọc dữ liệu từ file XML và chuyển đổi thành List<DrinkProduct>
                        List<DrinkProduct> drinkProducts = (List<DrinkProduct>)serializer.ReadObject(fileStream);
                        return drinkProducts ?? new List<DrinkProduct>();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc file: {ex.Message}");

                }
            }
            return new List<DrinkProduct>();
        }

        public void SaveData(List<DrinkProduct> drinkProducts)
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(GetPath.path))
                {
                    Directory.CreateDirectory(GetPath.path);
                }

                // Tạo DataContractSerializer cho List<DrinkProduct>
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<DrinkProduct>));

                using (FileStream fileStream = new FileStream(pathXml, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file XML
                    serializer.WriteObject(fileStream, drinkProducts);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }
    }
}
