using OOP_finalProject.Data;
using OOP_finalProject.Products;
using System.Collections.Generic;
using System.IO;

namespace OOP_finalProject
{
    public class HouseholdProductData : BaseDataRepository<HouseholdProductList, HouseholdProduct>
    {
        public HouseholdProductData() : base() { }
        public override List<HouseholdProduct> GetData()
        {
            HouseholdProductList householdProductList = Load();
            return householdProductList.HouseholdProducts ?? new List<HouseholdProduct>();
        }
        public override void SaveData(List<HouseholdProduct> items)
        {
            HouseholdProductList householdProductList = new HouseholdProductList(items);
            Save(householdProductList);
        }
        public override void CreateSampleData()
        {
            if (!File.Exists(filePath))
            {
                List<HouseholdProduct> householdProducts = new List<HouseholdProduct>
                {
                    new HouseholdProduct("HP001", "Bột giặt ABC", 50000m, 100m, "Sony"),
                    new HouseholdProduct("HP002", "Nước rửa chén Sunlight", 30000m, 200m, "Samsung"),
                    new HouseholdProduct("HP003", "Giấy vệ sinh Vinda", 20000m, 150m, "Apple"),
                    new HouseholdProduct("HP004", "Nước lau sàn Mr. Muscle", 40000m, 120m, "Nature Hike"),
                    new HouseholdProduct("HP005", "Khăn giấy ăn Hảo Hảo", 15000m, 250m, "IKIA")
                };
                SaveData(householdProducts);
            }
        }
    }
}
