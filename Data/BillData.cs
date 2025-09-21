using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    public class BillData
    {
        private string pathXml = Path.Combine(GetPath.path, nameof(Bill) + ".xml");

        public List<Bill> GetData()
        {
            if (File.Exists(pathXml))
            {
                try
                {
                    // Taọ DataContractSerializer cho List<Bill>
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<Bill>));

                    using (FileStream fileStream = new FileStream(pathXml, FileMode.Open, FileAccess.Read))
                    {
                        // Đọc dữ liệu từ file XML và chuyển đổi thành List<Bill>
                        List<Bill> bills = (List<Bill>)serializer.ReadObject(fileStream);
                        return bills ?? new List<Bill>();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc file: {ex.Message}");

                }
            }
            return new List<Bill>();
        }

        public void SaveData(List<Bill> bills)
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(GetPath.path))
                {
                    Directory.CreateDirectory(GetPath.path);
                }

                // Tạo DataContractSerializer cho List<Bill>
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Bill>));

                using (FileStream fileStream = new FileStream(pathXml, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file XML
                    serializer.WriteObject(fileStream, bills);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }
    }
}
