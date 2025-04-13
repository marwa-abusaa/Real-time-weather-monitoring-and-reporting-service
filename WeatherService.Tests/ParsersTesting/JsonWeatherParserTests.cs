using FluentAssertions;
using WeatherService.Services.Parsers;

namespace WeatherService.Tests.ParsersTesting;

public class JsonWeatherParserTests
{
    [Fact]
    public void Parse_ShouldDeserializeValidJson_ToWeatherData()
    {
        var validInputJson = """
        {
        "Location": "Tulkarem",
        "Temperature": 23.0,
        "Humidity": 85.0
        }
        """;

        var jsonWeatherParser = new JsonWeatherParser();
        var result = jsonWeatherParser.Parse(validInputJson);

        result.Location.Should().Be("Tulkarem");
        result.Temperature.Should().Be(23.0);
        result.Humidity.Should().Be(85.0);
    }
}