using System;
using System.Collections.Generic;
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
                    // Tạo DataContractSerializer cho Store
                    NetDataContractSerializer serializer = new NetDataContractSerializer();

                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        // Đọc dữ liệu từ file XML và chuyển đổi thành Store
                        Store store = (Store)serializer.Deserialize(fileStream);
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
                // Tạo DataContractSerializer cho Store
                NetDataContractSerializer serializer = new NetDataContractSerializer();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file XML
                    serializer.Serialize(fileStream, store);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }
    }
}
