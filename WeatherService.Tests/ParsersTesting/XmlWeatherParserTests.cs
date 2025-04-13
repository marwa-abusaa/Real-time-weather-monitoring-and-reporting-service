using FluentAssertions;
using WeatherService.Services.Parsers;

namespace WeatherService.Tests.ParsersTesting;

public class XmlWeatherParserTests
{
    [Fact]
    public void Parse_ShouldDeserializeValidXml_ToWeatherData()
    {
        var validInputJson = @"           
             <WeatherData>
             <Location>City Name</Location>
             <Temperature>23.0</Temperature>
             <Humidity>85.0</Humidity>
             </WeatherData>           
            ";

        var xmlWeatherParser = new XmlWeatherParser();
        var result = xmlWeatherParser.Parse(validInputJson);


        result.Location.Should().Be("City Name");
        result.Temperature.Should().Be(23.0);
        result.Humidity.Should().Be(85.0);
    }
}
