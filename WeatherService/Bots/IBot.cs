
using WeatherService.Models;

namespace WeatherService.Bots
{
    public interface IBot
    {
        void Activate(WeatherData data);
    }
}
