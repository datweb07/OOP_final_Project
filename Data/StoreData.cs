using System;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    public class StoreData
    {
        private string filePath = Path.Combine(GetPath.path, nameof(Store) + ".dat");

        public Store GetData()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    NetDataContractSerializer netDataContractSerializer = new NetDataContractSerializer();

                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        Store store = (Store)netDataContractSerializer.Deserialize(fileStream);
                        return store ?? new Store();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc file: {ex.Message}");
                }
            }
            return new Store();
        }

        public void SaveData(Store store)
        {
            try
            {
                NetDataContractSerializer netDataContractSerializer = new NetDataContractSerializer();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file
                    netDataContractSerializer.Serialize(fileStream, store);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }
    }
}
