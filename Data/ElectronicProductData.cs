using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    public class ElectronicProductData
    {
        private static string filePath = Path.Combine(GetPath.path, nameof(ElectronicProduct) + ".dat");

        public static void WriteObject(ElectronicProductList electronicProductList)
        {
            try
            {
                NetDataContractSerializer netDataContractSerializer = new NetDataContractSerializer();
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file
                    netDataContractSerializer.Serialize(fileStream, electronicProductList);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }

        public ElectronicProductList ReadObject()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File {filePath} không tồn tại. Trả về danh sách rỗng.");
                    return new ElectronicProductList();
                }

                NetDataContractSerializer netDataContractSerializer = new NetDataContractSerializer();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    // Đọc dữ liệu từ file và chuyển đổi thành ElectronicProductList
                    ElectronicProductList electronicProductList = (ElectronicProductList)netDataContractSerializer.Deserialize(fileStream);
                    return electronicProductList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi đọc file: {ex.Message}");
                return new ElectronicProductList();
            }
        }

        public List<ElectronicProduct> GetData()
        {
            ElectronicProductList electronicProductList = ReadObject();
            return electronicProductList.ElectronicProducts ?? new List<ElectronicProduct>();
        }

        public void SaveData(List<ElectronicProduct> electronicProducts)
        {
            ElectronicProductList electronicProductList = new ElectronicProductList(electronicProducts);
            WriteObject(electronicProductList);
        }

        public static void CreateSampleData()
        {
            if (!File.Exists(filePath))
            {
                List<ElectronicProduct> electronicProducts = new List<ElectronicProduct>
                {
                    new ElectronicProduct("DT001", "iPhone 15 Pro Max", 32990000, 10, "12 tháng"),
                    new ElectronicProduct("LT002", "MacBook Air M2", 28990000, 5, "24 tháng"),
                    new ElectronicProduct("TK003", "Samsung Galaxy Watch 6", 7990000, 15, "18 tháng"),
                    new ElectronicProduct("TV004", "Sony Bravia 4K", 18990000, 8, "36 tháng"),
                    new ElectronicProduct("HP005", "Dell XPS 13", 24990000, 12, "24 tháng")
                };
                ElectronicProductList electronicProductList = new ElectronicProductList(electronicProducts);
                WriteObject(electronicProductList);

            }
        }
    }
}
