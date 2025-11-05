using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    public class ClothingProductData
    {
<<<<<<< HEAD
        private static string filePath = Path.Combine(GetPath.path, nameof(ClothingProduct) + ".dat");

        public static void WriteObject(ClothingProductList clothingProductList)
        {
            try
            {
                // Tạo NetDataContractSerializer
                NetDataContractSerializer dataContractSerializer = new NetDataContractSerializer();
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file
                    dataContractSerializer.Serialize(fileStream, clothingProductList);
=======
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
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }
<<<<<<< HEAD

        public ClothingProductList ReadObject()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File {filePath} không tồn tại. Trả về danh sách rỗng.");
                    return new ClothingProductList();
                }
                // Tạo NetDataContractSerializer
                NetDataContractSerializer serializer = new NetDataContractSerializer();
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    // Đọc dữ liệu từ file và chuyển đổi thành ClothingProductList
                    ClothingProductList clothingProductList = (ClothingProductList)serializer.Deserialize(fileStream);
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
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
    }
}
