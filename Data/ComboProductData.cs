using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject.Data
{
    [Serializable]
    public class ComboProductData
    {
        private string filePath = Path.Combine(GetPath.path, nameof(ComboProduct) + ".dat");

        public List<ComboProduct> GetData()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    // Tạo DataContractSerializer cho List<CompositeProduct>
                    NetDataContractSerializer serializer = new NetDataContractSerializer();

                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        // Đọc dữ liệu từ file XML và chuyển đổi thành List<CompositeProduct>
                        List<ComboProduct> compositeProducts = (List<ComboProduct>)serializer.Deserialize(fileStream);
                        return compositeProducts ?? new List<ComboProduct>();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc file CompositeProduct: {ex.Message}");
                }
            }
            return new List<ComboProduct>();
        }

        public void SaveData(List<ComboProduct> compositeProducts)
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(GetPath.path))
                {
                    Directory.CreateDirectory(GetPath.path);
                }

                // Tạo DataContractSerializer cho List<CompositeProduct>
                NetDataContractSerializer serializer = new NetDataContractSerializer();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file XML
                    serializer.Serialize(fileStream, compositeProducts);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file CompositeProduct: {ex.Message}");
            }
        }

        /// <summary>
        /// Thêm một composite product mới
        /// </summary>
        public bool AddCompositeProduct(ComboProduct compositeProduct)
        {
            try
            {
                List<ComboProduct> compositeProducts = GetData();

                // Kiểm tra trùng ID
                if (compositeProducts.Exists(p => p.Id == compositeProduct.Id))
                {
                    Console.WriteLine($"Combo với ID {compositeProduct.Id} đã tồn tại!");
                    return false;
                }

                compositeProducts.Add(compositeProduct);
                SaveData(compositeProducts);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi thêm CompositeProduct: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Cập nhật composite product
        /// </summary>
        public bool UpdateCompositeProduct(ComboProduct updatedProduct)
        {
            try
            {
                List<ComboProduct> compositeProducts = GetData();
                int index = compositeProducts.FindIndex(p => p.Id == updatedProduct.Id);

                if (index == -1)
                {
                    Console.WriteLine($"Không tìm thấy combo với ID {updatedProduct.Id}");
                    return false;
                }

                compositeProducts[index] = updatedProduct;
                SaveData(compositeProducts);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi cập nhật CompositeProduct: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Xóa composite product theo ID
        /// </summary>
        public bool DeleteCompositeProduct(string id)
        {
            try
            {
                List<ComboProduct> compositeProducts = GetData();
                int removedCount = compositeProducts.RemoveAll(p => p.Id == id);

                if (removedCount == 0)
                {
                    Console.WriteLine($"Không tìm thấy combo với ID {id}");
                    return false;
                }

                SaveData(compositeProducts);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi xóa CompositeProduct: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Tìm composite product theo ID
        /// </summary>
        public ComboProduct FindById(string id)
        {
            List<ComboProduct> compositeProducts = GetData();
            return compositeProducts.Find(p => p.Id == id);
        }

        /// <summary>
        /// Tìm kiếm composite products theo tên
        /// </summary>
        public List<ComboProduct> SearchByName(string name)
        {
            List<ComboProduct> compositeProducts = GetData();
            return compositeProducts.FindAll(p => p.Name.ToLower().Contains(name.ToLower()));
        }
    }
}
