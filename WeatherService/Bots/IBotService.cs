
using WeatherService.Models;

namespace WeatherService.Bots
{
    public interface IBotService
    {
        void Activate(WeatherData data);
    }
}
