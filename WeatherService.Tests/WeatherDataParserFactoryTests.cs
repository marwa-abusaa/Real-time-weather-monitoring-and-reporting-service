
using FluentAssertions;
using WeatherService.Services;
using WeatherService.Services.Parsers;

namespace WeatherService.Tests
{
    public class WeatherDataParserFactoryTests
    {
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

        [InlineData("Invalid Data", null)]

        public void Create_ShouldReturnCorrectParserBasedOnInputData(string inputData, Type expectedReturnedType)
        {
            var weatherDataParserFactory = new WeatherDataParserFactory();

            var result = weatherDataParserFactory.Create(inputData);

            if (expectedReturnedType == null)
            {
                result.Should().BeNull();
            }
            else
            {
                result.Should().BeOfType(expectedReturnedType);
            }           
        }
    }
}
