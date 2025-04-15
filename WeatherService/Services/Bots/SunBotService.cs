using WeatherService.Bots;
using WeatherService.Models;

namespace WeatherService.Services.Bots;

public class SunBotService : IBotService
{
    private BotConfig botConfig;

    public SunBotService(BotConfig botConfig)
    {
        this.botConfig = botConfig;
    }

    public bool Activate(WeatherData data)
    {
        if (botConfig.Enabled && data.Temperature > botConfig.Threshold)
        {
            ConsoleMessageWriter.Write($"SunBot activated!\n{botConfig.Message}");
            return true;
        }
        return false;
    }
}
