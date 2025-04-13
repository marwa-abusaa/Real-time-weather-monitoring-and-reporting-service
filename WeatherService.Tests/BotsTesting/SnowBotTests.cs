using AutoFixture;
using WeatherService.Models;
using WeatherService.Services.Bots;

namespace WeatherService.Tests.BotsTesting;

public class SnowBotTests
{
    [Theory]
    [InlineData(false, 80, 3, "", false)]
    [InlineData(true, 20, 3, "", false)]
    [InlineData(true, 0, 3, "Brrr, it's getting chilly!", true)]
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

        SnowBotService snowBotService = new SnowBotService(botConfig);
        snowBotService.Activate(weatherData);


        if (shouldPrint)
        {
            Assert.Equal("Brrr, it's getting chilly!", message);
        }
        else
        {
            Assert.Equal("", message);
        }

    }
}
