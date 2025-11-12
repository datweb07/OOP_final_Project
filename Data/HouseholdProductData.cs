using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    public class HouseholdProductData
    {
        private static string filePath = Path.Combine(GetPath.path, nameof(HouseholdProduct) + ".dat");

        public static void WriteObject(HouseholdProductList householdProductList)
        {
            try
            {
                NetDataContractSerializer netDataContractSerializer = new NetDataContractSerializer();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file
                    netDataContractSerializer.Serialize(fileStream, householdProductList);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }

        public HouseholdProductList ReadObject()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File {filePath} không tồn tại. Trả về danh sách rỗng.");
                    return new HouseholdProductList();
                }

                NetDataContractSerializer netDataContractSerializer = new NetDataContractSerializer();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    // Đọc dữ liệu từ file và chuyển đổi thành HouseholdProductList
                    HouseholdProductList householdProductList = (HouseholdProductList)netDataContractSerializer.Deserialize(fileStream);
                    return householdProductList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi đọc file: {ex.Message}");
                return new HouseholdProductList();
            }
        }

        public List<HouseholdProduct> GetData()
        {
            HouseholdProductList householdProductList = ReadObject();
            return householdProductList.HouseholdProducts ?? new List<HouseholdProduct>();
        }

        public void SaveData(List<HouseholdProduct> householdProducts)
        {
            HouseholdProductList householdProductList = new HouseholdProductList(householdProducts);
            WriteObject(householdProductList);
        }

        public static void CreateSampleData()
        {
            if (!File.Exists(filePath))
            {
                List<HouseholdProduct> householdProducts = new List<HouseholdProduct>
                {
                    new HouseholdProduct("HP001", "Bột giặt ABC", 50000m, 100m, "Sony"),
                    new HouseholdProduct("HP002", "Nước rửa chén Sunlight", 30000m, 200m, "Samsung"),
                    new HouseholdProduct("HP003", "Giấy vệ sinh Vinda", 20000m, 150m, "Apple"),
                    new HouseholdProduct("HP004", "Nước lau sàn Mr. Muscle", 40000m, 120m, "Nature Hike"),
                    new HouseholdProduct("HP005", "Khăn giấy ăn Hảo Hảo", 15000m, 250m, "IKIA")
                };
                HouseholdProductList householdProductList = new HouseholdProductList(householdProducts);
                WriteObject(householdProductList);
            }
        }
    }
}
