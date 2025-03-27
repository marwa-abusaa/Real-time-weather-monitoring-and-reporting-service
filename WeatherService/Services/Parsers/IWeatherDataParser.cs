using WeatherService.Models;

namespace WeatherService.Services.Parsers
{
    public interface IWeatherDataParser
    {
        WeatherData Parse(string input);
    }
}