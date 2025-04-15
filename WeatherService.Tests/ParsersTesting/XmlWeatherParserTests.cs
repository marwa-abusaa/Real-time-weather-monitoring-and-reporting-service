using FluentAssertions;
using FluentAssertions.Execution;
using System.Xml;
using WeatherService.Services.Parsers;

namespace WeatherService.Tests.ParsersTesting;

public class XmlWeatherParserTests
{
    private readonly XmlWeatherParser xmlWeatherParser;

    public XmlWeatherParserTests()
    {
        xmlWeatherParser = new XmlWeatherParser();
    }
    [Fact]
    public void Parse_ValidXmlInput_ShouldDeserializeToWeatherData()
    {
        //Arrange
        const string validInputJson = @"           
             <WeatherData>
             <Location>City Name</Location>
             <Temperature>23.0</Temperature>
             <Humidity>85.0</Humidity>
             </WeatherData>           
            ";

        //Act
        var result = xmlWeatherParser.Parse(validInputJson);

        //Assert
        using(new AssertionScope())
        {
        result.Location.Should().Be("City Name");
        result.Temperature.Should().Be(23.0);
        result.Humidity.Should().Be(85.0);
        }
    }

    [Fact]
    public void Parse_InvalidXml_ThrowsXmlException()
    {
        // Arrange
        const string invalidXml = "<this is not valid JSON>";

        // Act & Assert
        Assert.Throws<XmlException>(() => xmlWeatherParser.Parse(invalidXml));
    }

    [Fact]
    public void Parse_NullInput_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => xmlWeatherParser.Parse(null!));
    }
}
