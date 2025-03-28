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

    public void Activate(WeatherData data)
    {
        if(botConfig.Enabled && data.Humidity > botConfig.Threshold)
        {
            Console.WriteLine("RainBot activated!");
            Console.WriteLine(botConfig.Message);
        }
    }
}
