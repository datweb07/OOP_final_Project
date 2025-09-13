using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace OOP_finalProject
{
    public class CashierData
    {
        private string pathJson = Path.Combine(GetPath.path, nameof(Cashier) + ".json");
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };

        public List<Cashier> GetData()
        {
            if (File.Exists(pathJson))
            {
                try
                {
                    string jsonString = File.ReadAllText(pathJson, Encoding.UTF8);
                    List<Cashier> cashiers = JsonSerializer.Deserialize<List<Cashier>>(jsonString, options);
                    return cashiers;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc file: {ex.Message}");

                }
            }
            return new List<Cashier>();
        }

        public void SaveData(List<Cashier> cashiers)
        {
            try
            {
                if (!Directory.Exists(GetPath.path))
                {
                    Directory.CreateDirectory(GetPath.path);
                }

                string jsonString = JsonSerializer.Serialize(cashiers, options);

                File.WriteAllText(pathJson, jsonString, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }
    }
}
