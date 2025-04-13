using AutoFixture;
using WeatherService.Models;
using WeatherService.Services.Bots;

namespace WeatherService.Tests.BotsTesting;

public class SunBotTests
{
    [Theory]
    [InlineData(false, 80, 30, "", false)]
    [InlineData(true, 20, 30, "", false)]
    [InlineData(true, 36, 30, "Wow, it's a scorcher out there!", true)]
    public void Activate_ShouldBehaveAccordingToConditions(
        bool enabled,
        double temperature,
        double threshold,
        string message,
        bool shouldPrint)
    {
        var fixture = new Fixture();
        WeatherData weatherData = fixture.Build<WeatherData>().With(w => w.Temperature, temperature).Create();
        var botConfig = new BotConfig
        {
            Enabled = enabled,
            Threshold = threshold,
            Message = message
        };

        SunBotService sunBotService = new SunBotService(botConfig);
        sunBotService.Activate(weatherData);


        if (shouldPrint)
        {
            Assert.Equal("Wow, it's a scorcher out there!", message);
        }
        else
        {
            Assert.Equal("", message);
        }

    }
}
