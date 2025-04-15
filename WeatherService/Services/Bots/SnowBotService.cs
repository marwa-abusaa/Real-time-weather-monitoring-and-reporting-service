using WeatherService.Bots;
using WeatherService.Models;

namespace WeatherService.Services.Bots;

public class SnowBotService : IBotService 
{
    private BotConfig botConfig;

    public SnowBotService(BotConfig botConfig)
    {
        this.botConfig = botConfig;
    }

    public bool Activate(WeatherData data)
    {
        if (botConfig.Enabled && data.Temperature < botConfig.Threshold)
        {
            ConsoleMessageWriter.Write($"SnowBot activated!\n{botConfig.Message}");
            return true;
        }
        return false;
    }
}
