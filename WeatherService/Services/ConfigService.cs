
using System.Text.Json;
using WeatherService.Models;

namespace WeatherService.Services
{
    public class ConfigService
    {
        private readonly string _JsonFilePath;

        public ConfigService(string jsonFilePath)
        {
            _JsonFilePath = jsonFilePath;
        }

        public Dictionary<string, BotConfig> loadConfigSettings()
        {
            string configText = File.ReadAllText(_JsonFilePath);
            var results = JsonSerializer.Deserialize<Dictionary<string,BotConfig>>(configText);
            return results;
        }
    }
}
