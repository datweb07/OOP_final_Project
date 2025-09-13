using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace OOP_finalProject
{
    public class DrinkProductData
    {
        private string pathJson = Path.Combine(GetPath.path, nameof(DrinkProduct) + ".json");
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };

        public List<DrinkProduct> GetData()
        {
            if (File.Exists(pathJson))
            {
                try
                {
                    string jsonString = File.ReadAllText(pathJson, Encoding.UTF8);
                    List<DrinkProduct> drinkProducts = JsonSerializer.Deserialize<List<DrinkProduct>>(jsonString, options);
                    return drinkProducts;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc file: {ex.Message}");

                }
            }
            return new List<DrinkProduct>();
        }

        public void SaveData(List<DrinkProduct> drinkProducts)
        {
            try
            {
                if (!Directory.Exists(GetPath.path))
                {
                    Directory.CreateDirectory(GetPath.path);
                }

                string jsonString = JsonSerializer.Serialize(drinkProducts, options);

                File.WriteAllText(pathJson, jsonString, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }
    }
}
