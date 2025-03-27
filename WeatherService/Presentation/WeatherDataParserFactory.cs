
using WeatherService.Parsers;

namespace WeatherService.Presentation;

public class WeatherDataParserFactory
{
    public IWeatherDataParser? Create(string inputData)
    {
        if (inputData.TrimStart().StartsWith("{"))
            return new JsonWeatherParser();

        if (inputData.TrimStart().StartsWith("<"))
            return new XmlWeatherParser();

        return null;
    }
}
