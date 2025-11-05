using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    public class DrinkProductData
    {
        private static string filePath = Path.Combine(GetPath.path, nameof(DrinkProduct) + ".dat");

        public static void WriteObject(DrinkProductList drinkProductList)
        {
            try
            {
                // Tạo NetDataContractSerializer
                NetDataContractSerializer dataContractSerializer = new NetDataContractSerializer();
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file
                    dataContractSerializer.Serialize(fileStream, drinkProductList);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }

        public DrinkProductList ReadObject()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File {filePath} không tồn tại. Trả về danh sách rỗng.");
                    return new DrinkProductList();
                }
                // Tạo NetDataContractSerializer
                NetDataContractSerializer serializer = new NetDataContractSerializer();
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    // Đọc dữ liệu từ file và chuyển đổi thành DrinkProductList
                    DrinkProductList drinkProductList = (DrinkProductList)serializer.Deserialize(fileStream);
                    return drinkProductList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi đọc file: {ex.Message}");
                return new DrinkProductList();
            }
        }

        public List<DrinkProduct> GetData()
        {
            DrinkProductList drinkProductList = ReadObject();
            return drinkProductList.DrinkProducts ?? new List<DrinkProduct>();
        }

        public void SaveData(List<DrinkProduct> drinkProducts)
        {
            DrinkProductList drinkProductList = new DrinkProductList(drinkProducts);
            WriteObject(drinkProductList);
        }

        public static void CreateSampleData()
        {
            if (!File.Exists(filePath))
            {
                List<DrinkProduct> drinkProducts = new List<DrinkProduct>() 
                {
                    new DrinkProduct("DP001", "Coca-Cola", 15000, 100, true),
                    new DrinkProduct("DP002", "Pepsi", 14000, 120, true),
                    new DrinkProduct("DP003", "Fanta", 13000, 80, true)
                };
                DrinkProductList drinkProductList = new DrinkProductList(drinkProducts);
                WriteObject(drinkProductList);
            }
            
        }
    }
}
