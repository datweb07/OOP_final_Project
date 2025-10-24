using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    [Serializable]
    public class CashierData
    {
        private string filePath = Path.Combine(GetPath.path, nameof(Cashier) + ".dat");

        public void WriteObject(CashierList cashierList)
        {
            try
            {
                NetDataContractSerializer dataContractSerializer = new NetDataContractSerializer();
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    dataContractSerializer.Serialize(fileStream, cashierList);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }

        public CashierList ReadObject()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File {filePath} không tồn tại. Trả về danh sách rỗng.");
                    return new CashierList();
                }

                NetDataContractSerializer serializer = new NetDataContractSerializer();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    CashierList cashierList = (CashierList)serializer.Deserialize(fileStream);
                    return cashierList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi đọc file: {ex.Message}");
                return new CashierList();
            }
        }

        public List<Cashier> GetData()
        {
            CashierList cashierList = ReadObject();
            return cashierList.Cashiers ?? new List<Cashier>();
        }

        public void SaveData(List<Cashier> cashiers)
        {
            CashierList cashierList = new CashierList(cashiers);
            WriteObject(cashierList);
        }
    }
}
