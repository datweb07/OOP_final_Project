using OOP_finalProject.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace OOP_finalProject
{
    public class HouseholdProductData
    {
        private string pathJson = Path.Combine(GetPath.path, nameof(HouseholdProduct) + ".json");
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };

        public List<HouseholdProduct> GetData()
        {
            if (File.Exists(pathJson))
            {
                try
                {
                    string jsonString = File.ReadAllText(pathJson, Encoding.UTF8);
                    List<HouseholdProduct> householdProducts = JsonSerializer.Deserialize<List<HouseholdProduct>>(jsonString, options);
                    return householdProducts;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc file: {ex.Message}");

                }
            }
            return new List<HouseholdProduct>();
        }

        public void SaveData(List<HouseholdProduct> householdProducts)
        {
            try
            {
                if (!Directory.Exists(GetPath.path))
                {
                    Directory.CreateDirectory(GetPath.path);
                }

                string jsonString = JsonSerializer.Serialize(householdProducts, options);

                File.WriteAllText(pathJson, jsonString, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }
    }
}
