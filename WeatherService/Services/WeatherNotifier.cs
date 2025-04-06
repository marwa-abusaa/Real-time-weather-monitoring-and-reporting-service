using WeatherService.Bots;
using WeatherService.Models;

namespace WeatherService.Services;

public class WeatherNotifier
{
    private readonly List<IBotService> _bots;

    public WeatherNotifier(List<IBotService> bots)
    {
        _bots = bots;
    }

    public void NotifyBots(WeatherData data)
    {
        foreach (var bot in _bots)
        {
            bot.Activate(data);
        }
    }
}
