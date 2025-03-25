
using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;
using WeatherService.Models;

namespace WeatherService.Parsers
{
    public class XmlWeatherParser : IWeatherDataParser
    {
        public WeatherData Parse(string input)
        {
            var xDoc = XDocument.Parse(input);

            var weatherData = new WeatherData
            {
                Location = xDoc.Root.Element("Location").Value,
                Temperature=double.Parse(xDoc.Root.Element("Temperature").Value),
                Humidity = double.Parse(xDoc.Root.Element("Humidity").Value),
            };

            return weatherData;
        }
    }
}
