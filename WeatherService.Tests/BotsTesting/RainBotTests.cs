using AutoFixture;
using WeatherService.Models;
using WeatherService.Services.Bots;

namespace WeatherService.Tests.BotsTesting;

public class RainBotTests
{
    [Theory]
    [InlineData(false, 80, 70, "", false)]
    [InlineData(true, 60, 70, "", false)]
    [InlineData(true, 80, 70, "It looks like it's about to pour down!", true)]
    public void Activate_ShouldBehaveAccordingToConditions(
        bool enabled,
        double humidity,
        double threshold,
        string message,
        bool shouldPrint)
    {
        var fixture = new Fixture();
        WeatherData weatherData = fixture.Build<WeatherData>().With(w => w.Humidity, humidity).Create();
        var botConfig = new BotConfig
        {
            Enabled = enabled,
            Threshold = threshold,
            Message = message
        };

        RainBotService rainBotService = new RainBotService(botConfig);
        rainBotService.Activate(weatherData);


        if (shouldPrint)
        {
            Assert.Equal("It looks like it's about to pour down!", message);
        }
        else
        {
            Assert.Equal("", message);
        }

    }
}
