
using System.Text.Json;
using WeatherService.Bots;

namespace WeatherService.Services
{
    public class ConfigService
    {
        private readonly string _JsonFilePath;

        public ConfigService(string jsonFilePath)
        {
            _JsonFilePath = jsonFilePath;
        }

        public Dictionary<IBot, BotConfig> loadConfigSettings()
        {
            string configText = File.ReadAllText(_JsonFilePath);
            var results = JsonSerializer.Deserialize<Dictionary<IBot,BotConfig>>(configText);
            return results;
        }
    }
}
