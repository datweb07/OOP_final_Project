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
            if (!File.Exists(filePath))
                return new List<ComboProduct>();

            try
            {
                NetDataContractSerializer serializer = new NetDataContractSerializer();

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    List<ComboProduct> compositeProducts = (List<ComboProduct>)serializer.Deserialize(fileStream);
                    
                    if (compositeProducts != null)
                    {
                        // Validate và fix dữ liệu
                        foreach (var combo in compositeProducts)
                        {
                            if (combo.Quantity < 0) combo.Quantity = 0;
                            if (combo.DiscountPercentage < 0) combo.DiscountPercentage = 0;
                            if (combo.DiscountPercentage > 100) combo.DiscountPercentage = 100;
                        }
                        return compositeProducts;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi đọc file ComboProduct: {ex.Message}");
                // Xóa file bị lỗi và tạo mới
                TryDeleteCorruptedFile();
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

                // Tạo file tạm để tránh mất dữ liệu nếu có lỗi
                string tempFilePath = filePath + ".tmp";

                NetDataContractSerializer serializer = new NetDataContractSerializer();

                using (FileStream fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
                {
                    serializer.Serialize(fileStream, compositeProducts ?? new List<ComboProduct>());
                }

                // Xóa file cũ và đổi tên file tạm thành file chính
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                File.Move(tempFilePath, filePath);

                Console.WriteLine($"Đã lưu {compositeProducts?.Count ?? 0} combo vào file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file ComboProduct: {ex.Message}");
                throw;
            }
        }

        private void TryDeleteCorruptedFile()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine("Đã xóa file ComboProduct bị lỗi.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Không thể xóa file bị lỗi: {ex.Message}");
            }
        }

        // ... giữ nguyên các phương thức khác (AddCompositeProduct, UpdateCompositeProduct, etc.)
        public bool AddCompositeProduct(ComboProduct compositeProduct)
        {
            try
            {
                List<ComboProduct> compositeProducts = GetData();

                if (compositeProducts.Exists(p => p.Id == compositeProduct.Id))
                {
                    Console.WriteLine($"Combo với ID {compositeProduct.Id} đã tồn tại!");
                    return false;
                }

                if (compositeProduct.Quantity < 0)
                    compositeProduct.Quantity = 0;

                compositeProducts.Add(compositeProduct);
                SaveData(compositeProducts);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi thêm ComboProduct: {ex.Message}");
                return false;
            }
        }

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

                if (updatedProduct.Quantity < 0)
                    updatedProduct.Quantity = 0;

                compositeProducts[index] = updatedProduct;
                SaveData(compositeProducts);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi cập nhật ComboProduct: {ex.Message}");
                return false;
            }
        }

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
                Console.WriteLine($"Lỗi xóa ComboProduct: {ex.Message}");
                return false;
            }
        }

        public ComboProduct FindById(string id)
        {
            List<ComboProduct> compositeProducts = GetData();
            return compositeProducts.Find(p => p.Id == id);
        }

        public List<ComboProduct> SearchByName(string name)
        {
            List<ComboProduct> compositeProducts = GetData();
            return compositeProducts.FindAll(p => p.Name.ToLower().Contains(name.ToLower()));
        }
    }
}