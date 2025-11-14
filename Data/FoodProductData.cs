using OOP_finalProject.Data;
using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.IO;

namespace OOP_finalProject
{
    public class FoodProductData : BaseDataRepository<FoodProductList, FoodProduct>
    {
        public FoodProductData() : base() { }
        public override List<FoodProduct> GetData()
        {
            FoodProductList foodProductList = Load();
            return foodProductList.FoodProducts ?? new List<FoodProduct>();
        }
        public override void SaveData(List<FoodProduct> items)
        {
            FoodProductList foodProductList = new FoodProductList(items);
            Save(foodProductList);
        }
        public override void CreateSampleData()
        {
            if (!File.Exists(filePath))
            {
                List<FoodProduct> foodProducts = new List<FoodProduct>
            {
                new FoodProduct("F001", "Bánh mì", 15000, 100, DateTime.Now.AddDays(7).Date.AddHours(23).AddMinutes(59).AddSeconds(59)),
                new FoodProduct("F002", "Phở bò", 30000, 50, DateTime.Now.AddDays(3).Date.AddHours(23).AddMinutes(59).AddSeconds(59)),
                new FoodProduct("F003", "Cơm tấm", 25000, 80, DateTime.Now.AddDays(5).Date.AddHours(23).AddMinutes(59).AddSeconds(59))
            };
                SaveData(foodProducts);
            }
        }
    }
}