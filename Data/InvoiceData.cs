using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
<<<<<<< HEAD
    [Serializable]
    public class InvoiceData
    {
        private static string pathXml = Path.Combine(GetPath.path, nameof(Invoice) + ".dat");

        public static void WriteObject(InvoiceList invoiceList)
        {
            try
            {
                // Tạo NetDataContractSerializer
                NetDataContractSerializer dataContractSerializer = new NetDataContractSerializer();
                using (FileStream fileStream = new FileStream(pathXml, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file
                    dataContractSerializer.Serialize(fileStream, invoiceList);
=======
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
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }
<<<<<<< HEAD

        public InvoiceList ReadObject()
        {
            try
            {
                if (!File.Exists(pathXml))
                {
                    Console.WriteLine($"File {pathXml} không tồn tại. Trả về danh sách rỗng.");
                    return new InvoiceList();
                }
                // Tạo NetDataContractSerializer
                NetDataContractSerializer serializer = new NetDataContractSerializer();
                using (FileStream fileStream = new FileStream(pathXml, FileMode.Open))
                {
                    // Đọc dữ liệu từ file và chuyển đổi thành InvoiceList
                    InvoiceList invoiceList = (InvoiceList)serializer.Deserialize(fileStream);
                    return invoiceList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi đọc file: {ex.Message}");
                return new InvoiceList();
            }
        }

        public List<Invoice> GetData()
        {
            InvoiceList invoiceList = ReadObject();
            return invoiceList.Invoices ?? new List<Invoice>();
        }

        public void SaveData(List<Invoice> invoices)
        {
            InvoiceList invoiceList = new InvoiceList(invoices);
            WriteObject(invoiceList);
        }   
=======
>>>>>>> 332e790e8125708e6ccf87e339604d4d0c75dbc7
    }
}
