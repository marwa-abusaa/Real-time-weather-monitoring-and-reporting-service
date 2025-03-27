
using System.Xml.Linq;
using WeatherService.Models;

namespace WeatherService.Services.Parsers
{
    public class XmlWeatherParser : IWeatherDataParser
    {
        public WeatherData Parse(string input)
        {
            var xDoc = XDocument.Parse(input);

            var weatherData = new WeatherData
            {
                Location = xDoc.Root!.Element("Location")?.Value ?? string.Empty,
                Temperature = double.TryParse(xDoc.Root.Element("Temperature")?.Value, out var temp) ? temp : 0, 
                Humidity = double.TryParse(xDoc.Root.Element("Humidity")?.Value, out var humidity) ? humidity : 0                 
            };

            return weatherData;
        }
    }
}