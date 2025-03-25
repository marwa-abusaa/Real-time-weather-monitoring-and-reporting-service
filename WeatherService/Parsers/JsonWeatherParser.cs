
using System.Text.Json;
using WeatherService.Models;

namespace WeatherService.Parsers
{
    public class JsonWeatherParser : IWeatherDataParser
    {
        public WeatherData Parse(string input)
        {
            return JsonSerializer.Deserialize<WeatherData>(input);
        }
    }
}