using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    public class ClothingProductData
    {
        private static string filePath = Path.Combine(GetPath.path, nameof(ClothingProduct) + ".dat");

        public static void WriteObject(ClothingProductList clothingProductList)
        {
            try
            {
                NetDataContractSerializer netDataContractSerializer = new NetDataContractSerializer();
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    netDataContractSerializer.Serialize(fileStream, clothingProductList);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }

        public ClothingProductList ReadObject()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File {filePath} không tồn tại. Trả về danh sách rỗng.");
                    return new ClothingProductList();
                }

                NetDataContractSerializer netDataContractSerializer = new NetDataContractSerializer();
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    // Đọc dữ liệu từ file và chuyển đổi thành ClothingProductList
                    ClothingProductList clothingProductList = (ClothingProductList)netDataContractSerializer.Deserialize(fileStream);
                    return clothingProductList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi đọc file: {ex.Message}");
                return new ClothingProductList();
            }
        }

        public List<ClothingProduct> GetData()
        {
            ClothingProductList clothingProductList = ReadObject();
            return clothingProductList.ClothingProducts ?? new List<ClothingProduct>();
        }

        public void SaveData(List<ClothingProduct> clothingProducts)
        {
            ClothingProductList clothingProductList = new ClothingProductList(clothingProducts);
            WriteObject(clothingProductList);
        }

        public static void CreateSampleData()
        {
            if(!File.Exists(filePath))
            {
                List<ClothingProduct> clothingProducts = new List<ClothingProduct>
            {
                new ClothingProduct("C001", "Áo Thun Nam", 150000, 50, "M"),
                new ClothingProduct("C002", "Quần Jeans Nữ", 300000, 30, "S"),
                new ClothingProduct("C003", "Váy Dạ Hội", 500000, 20, "XL"),
            };
                ClothingProductList clothingProductList = new ClothingProductList(clothingProducts);
                WriteObject(clothingProductList);
            }
            
        }
    }
}
