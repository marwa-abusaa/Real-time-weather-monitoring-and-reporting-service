using FluentAssertions;
using FluentAssertions.Execution;
using System.Text.Json;
using WeatherService.Services.Parsers;

namespace WeatherService.Tests.ParsersTesting;

public class JsonWeatherParserTests
{
    private readonly JsonWeatherParser jsonWeatherParser;

    public JsonWeatherParserTests()
    {
        jsonWeatherParser = new JsonWeatherParser();
    }


    [Fact]
    public void Parse_ValidJsonInput_ShouldDeserializeToWeatherData()
    {
        //Arrange
        const string validInputJson = """
        {
        "Location": "Tulkarem",
        "Temperature": 23.0,
        "Humidity": 85.0
        }
        """;

        //Act
        var result = jsonWeatherParser.Parse(validInputJson);

        //Assert
        using (new AssertionScope())
        {
            result.Location.Should().Be("Tulkarem");
            result.Temperature.Should().Be(23.0);
            result.Humidity.Should().Be(85.0);
        }
    }

    [Fact]
    public void Parse_InvalidJson_ThrowsJsonException()
    {
        // Arrange
        const string invalidJson = "{ this is not valid JSON }";

        // Act & Assert
        Assert.Throws<JsonException>(() => jsonWeatherParser.Parse(invalidJson));
    }

    [Fact]
    public void Parse_NullInput_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => jsonWeatherParser.Parse(null!));
    }

}