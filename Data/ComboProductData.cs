using OOP_finalProject.Products;
using System;
using System.Collections.Generic;

namespace OOP_finalProject.Data
{
    public class ComboProductData : BaseDataRepository<ComboProductList, ComboProduct>
    {
        public ComboProductData() : base() { }
        public override List<ComboProduct> GetData()
        {
            ComboProductList comboProductList = Load();
            // Validate và fix dữ liệu
            if (comboProductList?.ComboProducts != null)
            {
                foreach (var combo in comboProductList.ComboProducts)
                {
                    if (combo.Quantity < 0) combo.Quantity = 0;
                    if (combo.DiscountPercentage < 0) combo.DiscountPercentage = 0;
                    if (combo.DiscountPercentage > 100) combo.DiscountPercentage = 100;
                }
            }
            return comboProductList.ComboProducts ?? new List<ComboProduct>();
        }
        public override void SaveData(List<ComboProduct> items)
        {
            ComboProductList comboProductList = new ComboProductList(items);
            Save(comboProductList);
        }

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