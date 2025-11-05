using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    public class FoodProductData
    {
        private static string filePath = Path.Combine(GetPath.path, nameof(FoodProduct) + ".dat");

        public static void WriteObject(FoodProductList foodProductList)
        {
            try
            {
                // Tạo NetDataContractSerializer
                NetDataContractSerializer dataContractSerializer = new NetDataContractSerializer();
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file
                    dataContractSerializer.Serialize(fileStream, foodProductList);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }

        public FoodProductList ReadObject()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File {filePath} không tồn tại. Trả về danh sách rỗng.");
                    return new FoodProductList();
                }
                // Tạo NetDataContractSerializer
                NetDataContractSerializer serializer = new NetDataContractSerializer();
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    // Đọc dữ liệu từ file và chuyển đổi thành FoodProductList
                    FoodProductList foodProductList = (FoodProductList)serializer.Deserialize(fileStream);
                    return foodProductList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi đọc file: {ex.Message}");
                return new FoodProductList();
            }
        }

        public List<FoodProduct> GetData()
        {
            FoodProductList foodProductList = ReadObject();
            return foodProductList.FoodProducts ?? new List<FoodProduct>();
        }

        public void SaveData(List<FoodProduct> foodProducts)
        {
            FoodProductList foodProductList = new FoodProductList(foodProducts);
            WriteObject(foodProductList);
        }

        public static void CreateSampleData()
        {
            if (!File.Exists(filePath))
            {
                List<FoodProduct> foodProducts = new List<FoodProduct>
            {
                new FoodProduct("F001", "Bánh mì", 15000, 100,
                DateTime.Now.AddDays(7).Date.AddHours(23).AddMinutes(59).AddSeconds(59)),
            new FoodProduct("F002", "Phở bò", 30000, 50,
                DateTime.Now.AddDays(3).Date.AddHours(23).AddMinutes(59).AddSeconds(59)),
            new FoodProduct("F003", "Cơm tấm", 25000, 80,
                DateTime.Now.AddDays(5).Date.AddHours(23).AddMinutes(59).AddSeconds(59))
            };
                FoodProductList foodProductList = new FoodProductList(foodProducts);
                WriteObject(foodProductList);
            }
        }
    }
}
