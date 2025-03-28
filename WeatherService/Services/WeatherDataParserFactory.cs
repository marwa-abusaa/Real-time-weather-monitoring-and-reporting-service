using WeatherService.Services.Parsers;

namespace WeatherService.Services;

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
