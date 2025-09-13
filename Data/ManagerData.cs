using OOP_finalProject.Employees;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace OOP_finalProject
{
    public class ManagerData
    {
        private string pathJson = Path.Combine(GetPath.path, nameof(Manager) + ".json");
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        };

        public List<Manager> GetData()
        {
            if (File.Exists(pathJson))
            {
                try
                {
                    string jsonString = File.ReadAllText(pathJson, Encoding.UTF8);
                    List<Manager> managers = JsonSerializer.Deserialize<List<Manager>>(jsonString, options);
                    return managers;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi đọc file: {ex.Message}");

                }
            }
            return new List<Manager>();
        }

        public void SaveData(List<Manager> managers)
        {
            try
            {
                if (!Directory.Exists(GetPath.path))
                {
                    Directory.CreateDirectory(GetPath.path);
                }

                string jsonString = JsonSerializer.Serialize(managers, options);

                File.WriteAllText(pathJson, jsonString, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi ghi file: {ex.Message}");
            }
        }
    }
}
