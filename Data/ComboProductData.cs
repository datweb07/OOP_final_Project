//using OOP_finalProject.Products;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Runtime.Serialization;

//namespace OOP_finalProject.Data
//{
//    [Serializable]
//    public class ComboProductData
//    {
//        private string filePath = Path.Combine(GetPath.path, nameof(ComboProduct) + ".dat");

//        public List<ComboProduct> GetData()
//        {
//            if (File.Exists(filePath))
//            {
//                try
//                {
//                    // Tạo DataContractSerializer cho List<CompositeProduct>
//                    NetDataContractSerializer serializer = new NetDataContractSerializer();

//                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
//                    {
//                        // Đọc dữ liệu từ file XML và chuyển đổi thành List<CompositeProduct>
//                        List<ComboProduct> compositeProducts = (List<ComboProduct>)serializer.Deserialize(fileStream);
//                        return compositeProducts ?? new List<ComboProduct>();
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Lỗi đọc file CompositeProduct: {ex.Message}");
//                }
//            }
//            return new List<ComboProduct>();
//        }

//        public void SaveData(List<ComboProduct> compositeProducts)
//        {
//            try
//            {
//                // Tạo thư mục nếu chưa tồn tại
//                if (!Directory.Exists(GetPath.path))
//                {
//                    Directory.CreateDirectory(GetPath.path);
//                }

//                // Tạo DataContractSerializer cho List<CompositeProduct>
//                NetDataContractSerializer serializer = new NetDataContractSerializer();

//                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
//                {
//                    // Ghi dữ liệu vào file XML
//                    serializer.Serialize(fileStream, compositeProducts);
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Lỗi ghi file CompositeProduct: {ex.Message}");
//            }
//        }

//        /// <summary>
//        /// Thêm một composite product mới
//        /// </summary>
//        public bool AddCompositeProduct(ComboProduct compositeProduct)
//        {
//            try
//            {
//                List<ComboProduct> compositeProducts = GetData();

//                // Kiểm tra trùng ID
//                if (compositeProducts.Exists(p => p.Id == compositeProduct.Id))
//                {
//                    Console.WriteLine($"Combo với ID {compositeProduct.Id} đã tồn tại!");
//                    return false;
//                }

//                compositeProducts.Add(compositeProduct);
//                SaveData(compositeProducts);
//                return true;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Lỗi thêm CompositeProduct: {ex.Message}");
//                return false;
//            }
//        }

//        /// <summary>
//        /// Cập nhật composite product
//        /// </summary>
//        public bool UpdateCompositeProduct(ComboProduct updatedProduct)
//        {
//            try
//            {
//                List<ComboProduct> compositeProducts = GetData();
//                int index = compositeProducts.FindIndex(p => p.Id == updatedProduct.Id);

//                if (index == -1)
//                {
//                    Console.WriteLine($"Không tìm thấy combo với ID {updatedProduct.Id}");
//                    return false;
//                }

//                compositeProducts[index] = updatedProduct;
//                SaveData(compositeProducts);
//                return true;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Lỗi cập nhật CompositeProduct: {ex.Message}");
//                return false;
//            }
//        }

//        /// <summary>
//        /// Xóa composite product theo ID
//        /// </summary>
//        public bool DeleteCompositeProduct(string id)
//        {
//            try
//            {
//                List<ComboProduct> compositeProducts = GetData();
//                int removedCount = compositeProducts.RemoveAll(p => p.Id == id);

//                if (removedCount == 0)
//                {
//                    Console.WriteLine($"Không tìm thấy combo với ID {id}");
//                    return false;
//                }

//                SaveData(compositeProducts);
//                return true;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Lỗi xóa CompositeProduct: {ex.Message}");
//                return false;
//            }
//        }

//        /// <summary>
//        /// Tìm composite product theo ID
//        /// </summary>
//        public ComboProduct FindById(string id)
//        {
//            List<ComboProduct> compositeProducts = GetData();
//            return compositeProducts.Find(p => p.Id == id);
//        }

//        /// <summary>
//        /// Tìm kiếm composite products theo tên
//        /// </summary>
//        public List<ComboProduct> SearchByName(string name)
//        {
//            List<ComboProduct> compositeProducts = GetData();
//            return compositeProducts.FindAll(p => p.Name.ToLower().Contains(name.ToLower()));
//        }
//    }
//}


//using OOP_finalProject.Products;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Runtime.Serialization;

//namespace OOP_finalProject.Data
//{
//    [Serializable]
//    public class ComboProductData
//    {
//        private string filePath = Path.Combine(GetPath.path, nameof(ComboProduct) + ".dat");

//        //public List<ComboProduct> GetData()
//        //{
//        //    if (File.Exists(filePath))
//        //    {
//        //        try
//        //        {
//        //            // Tạo DataContractSerializer cho List<CompositeProduct>
//        //            NetDataContractSerializer serializer = new NetDataContractSerializer();

//        //            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
//        //            {
//        //                // Đọc dữ liệu từ file XML và chuyển đổi thành List<CompositeProduct>
//        //                List<ComboProduct> compositeProducts = (List<ComboProduct>)serializer.Deserialize(fileStream);

//        //                // Đảm bảo tất cả combo đều có số lượng hợp lệ
//        //                if (compositeProducts != null)
//        //                {
//        //                    foreach (var combo in compositeProducts)
//        //                    {
//        //                        if (combo.Quantity < 0)
//        //                            combo.Quantity = 0;
//        //                    }
//        //                }

//        //                return compositeProducts ?? new List<ComboProduct>();
//        //            }
//        //        }
//        //        catch (Exception ex)
//        //        {
//        //            Console.WriteLine($"Lỗi đọc file CompositeProduct: {ex.Message}");
//        //        }
//        //    }
//        //    return new List<ComboProduct>();
//        //}

//        public List<ComboProduct> GetData()
//        {
//            if (File.Exists(filePath))
//            {
//                try
//                {
//                    NetDataContractSerializer serializer = new NetDataContractSerializer();

//                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
//                    {
//                        List<ComboProduct> compositeProducts = (List<ComboProduct>)serializer.Deserialize(fileStream);

//                        if (compositeProducts != null)
//                        {
//                            // Validate và fix các combo sau khi deserialize
//                            foreach (var combo in compositeProducts)
//                            {
//                                // Đảm bảo số lượng không âm
//                                if (combo.Quantity < 0)
//                                    combo.Quantity = 0;

//                                // Đảm bảo discount percentage hợp lệ
//                                if (combo.DiscountPercentage < 0)
//                                    combo.DiscountPercentage = 0;
//                                if (combo.DiscountPercentage > 100)
//                                    combo.DiscountPercentage = 100;
//                            }
//                            return compositeProducts;
//                        }
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Lỗi đọc file CompositeProduct: {ex.Message}");
//                    // Tạo file mới nếu file cũ bị lỗi
//                    File.Delete(filePath);
//                }
//            }
//            return new List<ComboProduct>();
//        }

//        public void SaveData(List<ComboProduct> compositeProducts)
//        {
//            try
//            {
//                // Tạo thư mục nếu chưa tồn tại
//                if (!Directory.Exists(GetPath.path))
//                {
//                    Directory.CreateDirectory(GetPath.path);
//                }

//                // Tạo DataContractSerializer cho List<CompositeProduct>
//                NetDataContractSerializer serializer = new NetDataContractSerializer();

//                using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
//                {
//                    // Ghi dữ liệu vào file XML
//                    serializer.Serialize(fileStream, compositeProducts);
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Lỗi ghi file CompositeProduct: {ex.Message}");
//            }
//        }

//        /// <summary>
//        /// Thêm một composite product mới
//        /// </summary>
//        public bool AddCompositeProduct(ComboProduct compositeProduct)
//        {
//            try
//            {
//                List<ComboProduct> compositeProducts = GetData();

//                // Kiểm tra trùng ID
//                if (compositeProducts.Exists(p => p.Id == compositeProduct.Id))
//                {
//                    Console.WriteLine($"Combo với ID {compositeProduct.Id} đã tồn tại!");
//                    return false;
//                }

//                // Đảm bảo số lượng không âm
//                if (compositeProduct.Quantity < 0)
//                    compositeProduct.Quantity = 0;

//                compositeProducts.Add(compositeProduct);
//                SaveData(compositeProducts);
//                return true;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Lỗi thêm CompositeProduct: {ex.Message}");
//                return false;
//            }
//        }

//        /// <summary>
//        /// Cập nhật composite product
//        /// </summary>
//        public bool UpdateCompositeProduct(ComboProduct updatedProduct)
//        {
//            try
//            {
//                List<ComboProduct> compositeProducts = GetData();
//                int index = compositeProducts.FindIndex(p => p.Id == updatedProduct.Id);

//                if (index == -1)
//                {
//                    Console.WriteLine($"Không tìm thấy combo với ID {updatedProduct.Id}");
//                    return false;
//                }

//                // Đảm bảo số lượng không âm
//                if (updatedProduct.Quantity < 0)
//                    updatedProduct.Quantity = 0;

//                compositeProducts[index] = updatedProduct;
//                SaveData(compositeProducts);
//                return true;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Lỗi cập nhật CompositeProduct: {ex.Message}");
//                return false;
//            }
//        }

//        /// <summary>
//        /// Xóa composite product theo ID
//        /// </summary>
//        public bool DeleteCompositeProduct(string id)
//        {
//            try
//            {
//                List<ComboProduct> compositeProducts = GetData();
//                int removedCount = compositeProducts.RemoveAll(p => p.Id == id);

//                if (removedCount == 0)
//                {
//                    Console.WriteLine($"Không tìm thấy combo với ID {id}");
//                    return false;
//                }

//                SaveData(compositeProducts);
//                return true;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Lỗi xóa CompositeProduct: {ex.Message}");
//                return false;
//            }
//        }

//        /// <summary>
//        /// Tìm composite product theo ID
//        /// </summary>
//        public ComboProduct FindById(string id)
//        {
//            List<ComboProduct> compositeProducts = GetData();
//            return compositeProducts.Find(p => p.Id == id);
//        }

//        /// <summary>
//        /// Tìm kiếm composite products theo tên
//        /// </summary>
//        public List<ComboProduct> SearchByName(string name)
//        {
//            List<ComboProduct> compositeProducts = GetData();
//            return compositeProducts.FindAll(p => p.Name.ToLower().Contains(name.ToLower()));
//        }

//        /// <summary>
//        /// Cập nhật số lượng combo theo ID
//        /// </summary>
//        public bool UpdateComboQuantity(string comboId, int newQuantity)
//        {
//            try
//            {
//                if (newQuantity < 0)
//                {
//                    Console.WriteLine("Số lượng không được âm");
//                    return false;
//                }

//                List<ComboProduct> compositeProducts = GetData();
//                var combo = compositeProducts.Find(p => p.Id == comboId);

//                if (combo == null)
//                {
//                    Console.WriteLine($"Không tìm thấy combo với ID {comboId}");
//                    return false;
//                }

//                combo.Quantity = newQuantity;
//                SaveData(compositeProducts);
//                return true;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Lỗi cập nhật số lượng combo: {ex.Message}");
//                return false;
//            }
//        }

//        /// <summary>
//        /// Tăng số lượng combo
//        /// </summary>
//        public bool IncreaseComboQuantity(string comboId, int quantityToAdd)
//        {
//            try
//            {
//                if (quantityToAdd <= 0)
//                {
//                    Console.WriteLine("Số lượng thêm phải lớn hơn 0");
//                    return false;
//                }

//                List<ComboProduct> compositeProducts = GetData();
//                var combo = compositeProducts.Find(p => p.Id == comboId);

//                if (combo == null)
//                {
//                    Console.WriteLine($"Không tìm thấy combo với ID {comboId}");
//                    return false;
//                }

//                combo.Quantity += quantityToAdd;
//                SaveData(compositeProducts);
//                return true;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Lỗi tăng số lượng combo: {ex.Message}");
//                return false;
//            }
//        }

//        /// <summary>
//        /// Giảm số lượng combo
//        /// </summary>
//        public bool DecreaseComboQuantity(string comboId, int quantityToSubtract)
//        {
//            try
//            {
//                if (quantityToSubtract <= 0)
//                {
//                    Console.WriteLine("Số lượng giảm phải lớn hơn 0");
//                    return false;
//                }

//                List<ComboProduct> compositeProducts = GetData();
//                var combo = compositeProducts.Find(p => p.Id == comboId);

//                if (combo == null)
//                {
//                    Console.WriteLine($"Không tìm thấy combo với ID {comboId}");
//                    return false;
//                }

//                if (combo.Quantity < quantityToSubtract)
//                {
//                    Console.WriteLine($"Số lượng combo không đủ để giảm. Hiện có: {combo.Quantity}, Yêu cầu giảm: {quantityToSubtract}");
//                    return false;
//                }

//                combo.Quantity -= quantityToSubtract;
//                SaveData(compositeProducts);
//                return true;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Lỗi giảm số lượng combo: {ex.Message}");
//                return false;
//            }
//        }

//        /// <summary>
//        /// Lấy danh sách combo còn hàng (số lượng > 0)
//        /// </summary>
//        public List<ComboProduct> GetAvailableCombos()
//        {
//            List<ComboProduct> compositeProducts = GetData();
//            return compositeProducts.Where(p => p.Quantity > 0).ToList();
//        }

//        /// <summary>
//        /// Lấy danh sách combo hết hàng (số lượng = 0)
//        /// </summary>
//        public List<ComboProduct> GetOutOfStockCombos()
//        {
//            List<ComboProduct> compositeProducts = GetData();
//            return compositeProducts.Where(p => p.Quantity == 0).ToList();
//        }

//        /// <summary>
//        /// Lấy danh sách combo có số lượng thấp (dưới ngưỡng)
//        /// </summary>
//        public List<ComboProduct> GetLowStockCombos(int threshold = 10)
//        {
//            List<ComboProduct> compositeProducts = GetData();
//            return compositeProducts.Where(p => p.Quantity > 0 && p.Quantity <= threshold).ToList();
//        }

//        /// <summary>
//        /// Lấy tổng số lượng combo trong kho
//        /// </summary>
//        public decimal GetTotalComboQuantity()
//        {
//            List<ComboProduct> compositeProducts = GetData();
//            return compositeProducts.Sum(p => p.Quantity);
//        }

//        /// <summary>
//        /// Lấy tổng giá trị tồn kho của tất cả combo
//        /// </summary>
//        public decimal GetTotalInventoryValue()
//        {
//            List<ComboProduct> compositeProducts = GetData();
//            return compositeProducts.Sum(p => p.GetInventoryValue());
//        }

//        /// <summary>
//        /// Kiểm tra xem có thể tạo thêm combo không (kiểm tra tồn kho sản phẩm con)
//        /// </summary>
//        public bool CanCreateMoreCombos(string comboId, int requestedQuantity)
//        {
//            try
//            {
//                if (requestedQuantity <= 0)
//                    return false;

//                var combo = FindById(comboId);
//                if (combo == null)
//                    return false;

//                var leafProducts = combo.GetAllLeafProducts();
//                foreach (var product in leafProducts)
//                {
//                    // Mỗi combo cần số lượng sản phẩm con bằng với số lượng đã định trong combo
//                    decimal requiredQuantity = product.Quantity * requestedQuantity;

//                    // Cần kiểm tra tồn kho thực tế từ database của sản phẩm
//                    // Ở đây giả sử product.Quantity là tồn kho thực tế
//                    if (product.Quantity < requiredQuantity)
//                    {
//                        Console.WriteLine($"Không đủ tồn kho cho {product.Name}. Cần: {requiredQuantity}, Có: {product.Quantity}");
//                        return false;
//                    }
//                }
//                return true;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Lỗi kiểm tra tồn kho: {ex.Message}");
//                return false;
//            }
//        }

//        /// <summary>
//        /// Lấy thống kê tồn kho combo
//        /// </summary>
//        public ComboInventoryStats GetInventoryStats()
//        {
//            var allCombos = GetData();
//            var availableCombos = GetAvailableCombos();
//            var outOfStockCombos = GetOutOfStockCombos();
//            var lowStockCombos = GetLowStockCombos();

//            return new ComboInventoryStats
//            {
//                TotalCombos = allCombos.Count,
//                TotalQuantity = allCombos.Sum(c => c.Quantity),
//                TotalValue = allCombos.Sum(c => c.GetInventoryValue()),
//                AvailableCombos = availableCombos.Count,
//                OutOfStockCombos = outOfStockCombos.Count,
//                LowStockCombos = lowStockCombos.Count,
//                AveragePrice = allCombos.Any() ? allCombos.Average(c => c.Price) : 0,
//                MostExpensiveCombo = allCombos.OrderByDescending(c => c.Price).FirstOrDefault(),
//                MostValuableCombo = allCombos.OrderByDescending(c => c.GetInventoryValue()).FirstOrDefault()
//            };
//        }

//        /// <summary>
//        /// Lấy combo có giá trị tồn kho cao nhất
//        /// </summary>
//        public ComboProduct GetMostValuableCombo()
//        {
//            var allCombos = GetData();
//            return allCombos.OrderByDescending(c => c.GetInventoryValue()).FirstOrDefault();
//        }

//        /// <summary>
//        /// Lấy combo có số lượng nhiều nhất
//        /// </summary>
//        public ComboProduct GetMostStockedCombo()
//        {
//            var allCombos = GetData();
//            return allCombos.OrderByDescending(c => c.Quantity).FirstOrDefault();
//        }
//    }

//    /// <summary>
//    /// Class chứa thống kê tồn kho combo
//    /// </summary>
//    public class ComboInventoryStats
//    {
//        public int TotalCombos { get; set; }
//        public decimal TotalQuantity { get; set; }
//        public decimal TotalValue { get; set; }
//        public int AvailableCombos { get; set; }
//        public int OutOfStockCombos { get; set; }
//        public int LowStockCombos { get; set; }
//        public decimal AveragePrice { get; set; }
//        public ComboProduct MostExpensiveCombo { get; set; }
//        public ComboProduct MostValuableCombo { get; set; }

//        public override string ToString()
//        {
//            return $"Tổng combo: {TotalCombos}\n" +
//                   $"Tổng số lượng: {TotalQuantity}\n" +
//                   $"Tổng giá trị: {TotalValue:N0} đ\n" +
//                   $"Combo có hàng: {AvailableCombos}\n" +
//                   $"Combo hết hàng: {OutOfStockCombos}\n" +
//                   $"Combo sắp hết: {LowStockCombos}\n" +
//                   $"Giá trung bình: {AveragePrice:N0} đ\n" +
//                   $"Combo đắt nhất: {MostExpensiveCombo?.Name ?? "N/A"}\n" +
//                   $"Combo giá trị nhất: {MostValuableCombo?.Name ?? "N/A"}";
//        }
//    }
//}


using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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