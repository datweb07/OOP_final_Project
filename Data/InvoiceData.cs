using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    public class InvoiceData
    {
        private string pathXml = Path.Combine(GetPath.path, nameof(Invoice) + ".xml");

        public List<Invoice> GetData()
        {
            if (File.Exists(pathXml))
            {
                try
                {
                    // Tạo DataContractSerializer cho List<Invoice>
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<Invoice>));

                    using (FileStream fileStream = new FileStream(pathXml, FileMode.Open, FileAccess.Read))
                    {
                        // Đọc dữ liệu từ file XML và chuyển đổi thành List<Invoice>
                        List<Invoice> invoices = (List<Invoice>)serializer.ReadObject(fileStream);
                        return invoices ?? new List<Invoice>();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc file: {ex.Message}");

                }
            }
            return new List<Invoice>();
        }

        public void SaveData(List<Invoice> invoices)
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(GetPath.path))
                {
                    Directory.CreateDirectory(GetPath.path);
                }

                // Tạo DataContractSerializer cho List<Invoice>
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Invoice>));

                using (FileStream fileStream = new FileStream(pathXml, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file XML
                    serializer.WriteObject(fileStream, invoices);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }
    }
}
