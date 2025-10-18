using System;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject
{
    public class StoreData
    {
        private string pathXml = Path.Combine(GetPath.path, nameof(Store) + ".dat");

        public Store GetData()
        {
            if (File.Exists(pathXml))
            {
                try
                {
                    // Tạo DataContractSerializer cho List<Store>
                    DataContractSerializer serializer = new DataContractSerializer(typeof(Store));

                    using (FileStream fileStream = new FileStream(pathXml, FileMode.Open, FileAccess.Read))
                    {
                        // Đọc dữ liệu từ file XML và chuyển đổi thành List<Store>
                        Store stores = (Store)serializer.ReadObject(fileStream);
                        return stores ?? new Store();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc file: {ex.Message}");

                }
            }
            return new Store();
        }

        public void SaveData(Store stores)
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(GetPath.path))
                {
                    Directory.CreateDirectory(GetPath.path);
                }

                // Tạo DataContractSerializer cho List<Store>
                DataContractSerializer serializer = new DataContractSerializer(typeof(Store));

                using (FileStream fileStream = new FileStream(pathXml, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file XML
                    serializer.WriteObject(fileStream, stores);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }
    }
}
