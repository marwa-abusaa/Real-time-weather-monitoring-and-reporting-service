using System.Text.Json;
using WeatherService.Models;

namespace WeatherService.Services.FileReaders;

public class ConfigService
{
    private readonly string _JsonFilePath;
    private readonly IFileReader _fileReader;

    public ConfigService(string jsonFilePath, IFileReader fileReader)
    {
        _JsonFilePath = jsonFilePath;
        _fileReader = fileReader;
    }

    public Dictionary<string, BotConfig> loadConfigSettings()
    {
        string configText = _fileReader.ReadAllText(_JsonFilePath);
        return JsonSerializer.Deserialize<Dictionary<string, BotConfig>>(configText)!;
    }
}
