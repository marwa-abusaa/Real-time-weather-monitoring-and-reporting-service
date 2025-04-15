using FluentAssertions;
using WeatherService.Services;
using WeatherService.Services.Parsers;

namespace WeatherService.Tests.ParsersTesting;

public class WeatherDataParserFactoryTests
{
    private readonly WeatherDataParserFactory weatherDataParserFactory;

    public WeatherDataParserFactoryTests()
    {
        weatherDataParserFactory = new WeatherDataParserFactory();
    }


    [Theory]
    [InlineData("""           
         {
         "Location": "City Name",
         "Temperature": 23.0,
         "Humidity": 85.0
         }            
        """ , typeof(JsonWeatherParser)
        )]

    [InlineData(@"           
             <WeatherData>
             <Location>City Name</Location>
             <Temperature>23.0</Temperature>
             <Humidity>85.0</Humidity>
             </WeatherData>           
            ", typeof(XmlWeatherParser)
        )]

    public void Create_BasedOnInputData_ShouldReturnCorrectParser(string inputData, Type expectedReturnedType)
    {
        //Act
        var result = weatherDataParserFactory.Create(inputData);

        //Assert
        result.Should().BeOfType(expectedReturnedType);                  
    }

    [Fact]
    public void Create_WithInvalidData_ShouldReturnNull()
    {
        //Arrange
        string invalidData = "Invalid Data";

        //Act
        var result = weatherDataParserFactory.Create(invalidData);

        //Assert
        result.Should().BeNull();
    }
}