<<<<<<< HEAD
using OOP_finalProject.Products;
=======
﻿using OOP_finalProject.Products;
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    public class HouseholdProductData
    {
<<<<<<< HEAD
        private static string filePath = Path.Combine(GetPath.path, nameof(HouseholdProduct) + ".dat");

        public static void WriteObject(HouseholdProductList householdProductList)
        {
            try
            {
                // Tạo NetDataContractSerializer
                NetDataContractSerializer dataContractSerializer = new NetDataContractSerializer();
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file
                    dataContractSerializer.Serialize(fileStream, householdProductList);
=======
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
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }
<<<<<<< HEAD

        public HouseholdProductList ReadObject()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File {filePath} không tồn tại. Trả về danh sách rỗng.");
                    return new HouseholdProductList();
                }
                // Tạo NetDataContractSerializer
                NetDataContractSerializer serializer = new NetDataContractSerializer();
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    // Đọc dữ liệu từ file và chuyển đổi thành HouseholdProductList
                    HouseholdProductList householdProductList = (HouseholdProductList)serializer.Deserialize(fileStream);
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
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
    }
}
