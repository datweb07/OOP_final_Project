using OOP_finalProject.Data;
using OOP_finalProject.Products;
using System.Collections.Generic;
using System.IO;

namespace OOP_finalProject
{
    public class DrinkProductData : BaseDataRepository<DrinkProductList, DrinkProduct>
    {
        public DrinkProductData() : base() { }
        public override List<DrinkProduct> GetData()
        {
            DrinkProductList drinkProductList = Load();
            return drinkProductList.DrinkProducts ?? new List<DrinkProduct>();
        }
        public override void SaveData(List<DrinkProduct> drinkProducts)
        {
            DrinkProductList drinkProductList = new DrinkProductList(drinkProducts);
            Save(drinkProductList);
        }
        public override void CreateSampleData()
        {
            if (!File.Exists(filePath))
            {
                List<DrinkProduct> drinkProducts = new List<DrinkProduct>()
                {
                    new DrinkProduct("DP001", "Coca-Cola", 15000, 100, true),
                    new DrinkProduct("DP002", "Pepsi", 14000, 120, true),
                    new DrinkProduct("DP003", "Fanta", 13000, 80, true)
                };
                SaveData(drinkProducts);
            }
        }
    }
}
