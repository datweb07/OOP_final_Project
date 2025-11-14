using OOP_finalProject.Data;
using OOP_finalProject.Products;
using System.Collections.Generic;
using System.IO;

namespace OOP_finalProject
{
    public class ElectronicProductData : BaseDataRepository<ElectronicProductList, ElectronicProduct>
    {
        public ElectronicProductData() : base() { }
        public override List<ElectronicProduct> GetData()
        {
            ElectronicProductList electronicProductList = Load();
            return electronicProductList.ElectronicProducts ?? new List<ElectronicProduct>();
        }
        public override void SaveData(List<ElectronicProduct> electronicProducts)
        {
            ElectronicProductList electronicProductList = new ElectronicProductList(electronicProducts);
            Save(electronicProductList);
        }
        public override void CreateSampleData()
        {
            if (!File.Exists(filePath))
            {
                List<ElectronicProduct> electronicProducts = new List<ElectronicProduct>
                {
                    new ElectronicProduct("DT001", "iPhone 15 Pro Max", 32990000, 10, "12 tháng"),
                    new ElectronicProduct("LT002", "MacBook Air M2", 28990000, 5, "24 tháng"),
                    new ElectronicProduct("TK003", "Samsung Galaxy Watch 6", 7990000, 15, "18 tháng"),
                    new ElectronicProduct("TV004", "Sony Bravia 4K", 18990000, 8, "36 tháng"),
                    new ElectronicProduct("HP005", "Dell XPS 13", 24990000, 12, "24 tháng")
                };
                SaveData(electronicProducts);

            }
        }
    }
}
