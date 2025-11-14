using OOP_finalProject.Data;
using OOP_finalProject.Products;
using System.Collections.Generic;
using System.IO;

namespace OOP_finalProject
{
    public class ClothingProductData : BaseDataRepository<ClothingProductList, ClothingProduct>
    {
        public ClothingProductData() : base()
        {

        }
        public override List<ClothingProduct> GetData()
        {
            ClothingProductList clothingProduct = Load();
            return clothingProduct.ClothingProducts ?? new List<ClothingProduct>();
        }
        public override void SaveData(List<ClothingProduct> clothingProducts)
        {
            ClothingProductList clothingProduct = new ClothingProductList(clothingProducts);
            Save(clothingProduct);
        }
        public override void CreateSampleData()
        {
            if (!File.Exists(filePath))
            {
                List<ClothingProduct> clothingProducts = new List<ClothingProduct>
            {
                new ClothingProduct("C001", "Áo Thun Nam", 150000, 50, "M"),
                new ClothingProduct("C002", "Quần Jeans Nữ", 300000, 30, "S"),
                new ClothingProduct("C003", "Váy Dạ Hội", 500000, 20, "XL"),
            };
                SaveData(clothingProducts);
            }
        }
    }
}
