using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    public class FoodProductData
    {
        private string pathXml = Path.Combine(GetPath.path, nameof(FoodProduct) + ".xml");

        public List<FoodProduct> GetData()
        {
            if (File.Exists(pathXml))
            {
                try
                {
                    // Tạo DataContractSerializer cho List<FoodProduct>
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<FoodProduct>));

                    using (FileStream fileStream = new FileStream(pathXml, FileMode.Open, FileAccess.Read))
                    {
                        // Đọc dữ liệu từ file XML và chuyển đổi thành List<FoodProduct>
                        List<FoodProduct> foodProducts = (List<FoodProduct>)serializer.ReadObject(fileStream);
                        return foodProducts ?? new List<FoodProduct>();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc file: {ex.Message}");

                }
            }
            return new List<FoodProduct>();
        }

        public void SaveData(List<FoodProduct> foodProducts)
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(GetPath.path))
                {
                    Directory.CreateDirectory(GetPath.path);
                }

                // Tạo DataContractSerializer cho List<FoodProduct>
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<FoodProduct>));

                using (FileStream fileStream = new FileStream(pathXml, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file XML
                    serializer.WriteObject(fileStream, foodProducts);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }
    }
}
