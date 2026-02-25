using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PRG_MAUI_Car_Register.Model;

namespace PRG_MAUI_Car_Register.Service
{
    public class JsonCarStorageService : ICarStorageService
    {
        private readonly string _filepath;

        public JsonCarStorageService()
        {
            _filepath = Path.Combine(FileSystem.AppDataDirectory, "carstorage.json");
        }
        public async Task SaveAsync(IEnumerable<Vehicle> vehicles)
        {
            var json = JsonSerializer.Serialize(vehicles, new JsonSerializerOptions { WriteIndented = true});

            await File.WriteAllTextAsync(_filepath, json);
        }
        public async Task<IList<Vehicle>> LoadAsync()
        {
            if (!File.Exists(_filepath))
                return new List<Vehicle>();

            var json = await File.ReadAllTextAsync(_filepath);
            return JsonSerializer.Deserialize<List<Vehicle>>(json) ?? new List<Vehicle>();
        }

    }
}
