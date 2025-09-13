using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace OOP_finalProject
{
    public class FoodProductData
    {
        private string pathJson = Path.Combine(GetPath.path, nameof(FoodProduct) + ".json");
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };

        public List<FoodProduct> GetData()
        {
            if (File.Exists(pathJson))
            {
                try
                {
                    string jsonString = File.ReadAllText(pathJson, Encoding.UTF8);
                    List<FoodProduct> foodProducts = JsonSerializer.Deserialize<List<FoodProduct>>(jsonString, options);
                    return foodProducts;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc file: {ex.Message}");

                }
            }
            return new List<FoodProduct>();
        }

        public void SaveData(List<FoodProduct> foodProducts)
        {
            try
            {
                if (!Directory.Exists(GetPath.path))
                {
                    Directory.CreateDirectory(GetPath.path);
                }

                string jsonString = JsonSerializer.Serialize(foodProducts, options);

                File.WriteAllText(pathJson, jsonString, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }
    }
}
