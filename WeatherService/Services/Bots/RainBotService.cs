using WeatherService.Bots;
using WeatherService.Models;

namespace WeatherService.Services.Bots;

public class RainBotService : IBotService
{
    private BotConfig botConfig;

    public RainBotService(BotConfig botConfig)
    {
        this.botConfig = botConfig;
    }

    public bool Activate(WeatherData data)
    {
        if(botConfig.Enabled && data.Humidity > botConfig.Threshold)
        {
            ConsoleMessageWriter.Write($"RainBot activated!\n{botConfig.Message}");
            return true;
        }
        return false;
    }
}
