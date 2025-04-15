using WeatherService.Models;

namespace WeatherService.Bots;

public interface IBotService
{
    bool Activate(WeatherData data);
}
