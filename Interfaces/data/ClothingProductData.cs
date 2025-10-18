using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    public class ClothingProductData
    {
        private string pathXml = Path.Combine(GetPath.path, nameof(ClothingProduct) + ".xml");

        public List<ClothingProduct> GetData()
        {
            if (File.Exists(pathXml))
            {
                try
                {
                    // Tạo DataContractSerializer cho List<ClothingProduct>
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<ClothingProduct>));

                    using (FileStream fileStream = new FileStream(pathXml, FileMode.Open, FileAccess.Read))
                    {
                        // Đọc dữ liệu từ file XML và chuyển đổi thành List<ClothingProduct>
                        List<ClothingProduct> clothingProducts = (List<ClothingProduct>)serializer.ReadObject(fileStream);
                        return clothingProducts ?? new List<ClothingProduct>();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc file: {ex.Message}");

                }
            }
            return new List<ClothingProduct>();
        }

        public void SaveData(List<ClothingProduct> clothingProducts)
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(GetPath.path))
                {
                    Directory.CreateDirectory(GetPath.path);
                }

                // Tạo DataContractSerializer cho List<ClothingProduct>
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<ClothingProduct>));

                using (FileStream fileStream = new FileStream(pathXml, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file XML
                    serializer.WriteObject(fileStream, clothingProducts);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }
    }
}
