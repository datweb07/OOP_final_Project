using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    [Serializable]
    public class InvoiceData
    {
        private static string filaPath = Path.Combine(GetPath.path, nameof(Invoice) + ".dat");

        public static void WriteObject(InvoiceList invoiceList)
        {
            try
            {
                NetDataContractSerializer netDataContractSerializer = new NetDataContractSerializer();

                using (FileStream fileStream = new FileStream(filaPath, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file
                    netDataContractSerializer.Serialize(fileStream, invoiceList);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }

        public InvoiceList ReadObject()
        {
            try
            {
                if (!File.Exists(filaPath))
                {
                    Console.WriteLine($"File {filaPath} không tồn tại. Trả về danh sách rỗng.");
                    return new InvoiceList();
                }
         
                NetDataContractSerializer netDataContractSerializer = new NetDataContractSerializer();

                using (FileStream fileStream = new FileStream(filaPath, FileMode.Open))
                {
                    // Đọc dữ liệu từ file và chuyển đổi thành InvoiceList
                    InvoiceList invoiceList = (InvoiceList)netDataContractSerializer.Deserialize(fileStream);
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
    }
}
