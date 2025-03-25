
using WeatherService.Models;

namespace WeatherService.Parsers
{
    public interface IWeatherDataParser
    {
        WeatherData Parse(string input);
    }
}
