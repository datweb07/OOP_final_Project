using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    public class ElectronicProductData
    {
        private string pathXml = Path.Combine(GetPath.path, nameof(ElectronicProduct) + ".xml");

        public List<ElectronicProduct> GetData()
        {
            if (File.Exists(pathXml))
            {
                try
                {
                    // Tạo DataContractSerializer cho List<ElectronicProduct>
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<ElectronicProduct>));

                    using (FileStream fileStream = new FileStream(pathXml, FileMode.Open, FileAccess.Read))
                    {
                        // Đọc dữ liệu từ file XML và chuyển đổi thành List<ElectronicProduct>
                        List<ElectronicProduct> electronicProducts = (List<ElectronicProduct>)serializer.ReadObject(fileStream);
                        return electronicProducts ?? new List<ElectronicProduct>();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc file: {ex.Message}");

                }
            }
            return new List<ElectronicProduct>();
        }

        public void SaveData(List<ElectronicProduct> electronicProducts)
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(GetPath.path))
                {
                    Directory.CreateDirectory(GetPath.path);
                }

                // Tạo DataContractSerializer cho List<ElectronicProduct>
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<ElectronicProduct>));

                using (FileStream fileStream = new FileStream(pathXml, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file XML
                    serializer.WriteObject(fileStream, electronicProducts);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }
    }
}
