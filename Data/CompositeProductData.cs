using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace OOP_finalProject.Data
{
    /// <summary>
    /// Class quản lý dữ liệu CompositeProduct (Combo/Bundle)
    /// Sử dụng XML serialization để lưu trữ
    /// </summary>
    public class CompositeProductData
    {
        private string pathXml = Path.Combine(GetPath.path, nameof(CompositeProduct) + ".xml");

        /// <summary>
        /// Lấy danh sách tất cả composite products
        /// </summary>
        public List<CompositeProduct> GetData()
        {
            if (File.Exists(pathXml))
            {
                try
                {
                    // Tạo DataContractSerializer cho List<CompositeProduct>
                    DataContractSerializer serializer = new DataContractSerializer(typeof(List<CompositeProduct>));

                    using (FileStream fileStream = new FileStream(pathXml, FileMode.Open, FileAccess.Read))
                    {
                        // Đọc dữ liệu từ file XML và chuyển đổi thành List<CompositeProduct>
                        List<CompositeProduct> compositeProducts = (List<CompositeProduct>)serializer.ReadObject(fileStream);
                        return compositeProducts ?? new List<CompositeProduct>();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc file CompositeProduct: {ex.Message}");
                }
            }
            return new List<CompositeProduct>();
        }

        /// <summary>
        /// Lưu danh sách composite products
        /// </summary>
        public void SaveData(List<CompositeProduct> compositeProducts)
        {
            try
            {
                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(GetPath.path))
                {
                    Directory.CreateDirectory(GetPath.path);
                }

                // Tạo DataContractSerializer cho List<CompositeProduct>
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<CompositeProduct>));

                using (FileStream fileStream = new FileStream(pathXml, FileMode.Create, FileAccess.Write))
                {
                    // Ghi dữ liệu vào file XML
                    serializer.WriteObject(fileStream, compositeProducts);
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
        public bool AddCompositeProduct(CompositeProduct compositeProduct)
        {
            try
            {
                List<CompositeProduct> compositeProducts = GetData();

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
        public bool UpdateCompositeProduct(CompositeProduct updatedProduct)
        {
            try
            {
                List<CompositeProduct> compositeProducts = GetData();
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
                List<CompositeProduct> compositeProducts = GetData();
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
        public CompositeProduct FindById(string id)
        {
            List<CompositeProduct> compositeProducts = GetData();
            return compositeProducts.Find(p => p.Id == id);
        }

        /// <summary>
        /// Tìm kiếm composite products theo tên
        /// </summary>
        public List<CompositeProduct> SearchByName(string name)
        {
            List<CompositeProduct> compositeProducts = GetData();
            return compositeProducts.FindAll(p => p.Name.ToLower().Contains(name.ToLower()));
        }
    }
}
