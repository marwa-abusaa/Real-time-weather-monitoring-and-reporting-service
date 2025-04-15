using WeatherService.Models;
using WeatherService.Services.Bots;

namespace WeatherService.Tests.BotsTesting;

public class SunBotTests
{
    [Fact]
    public void Activate_TemperatureAboveThresholdAndEnabled_ShouldReturnTrue()
    {
        // Arrange
        var config = new BotConfig
        {
            Enabled = true,
            Threshold = 30,
            Message = "Wow, it's a scorcher out there!"
        };
        var data = new WeatherData { Temperature = 36 };
        var service = new SunBotService(config);

        // Act
        var result = service.Activate(data);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Activate_BotNotEnabled_ShouldReturnFalse()
    {
        // Arrange
        var config = new BotConfig
        {
            Enabled = false,
            Threshold = 30,
            Message = "SunBot isn't activated."
        };
        var data = new WeatherData { Temperature = 36 };
        var service = new SnowBotService(config);

        // Act
        var result = service.Activate(data);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Activate_TemperatureBelowThreshold_ShouldReturnFalse()
    {
        // Arrange
        var config = new BotConfig
        {
            Enabled = true,
            Threshold = 30,
            Message = "SunBot isn't activated. Temperature is below threshold."
        };
        var data = new WeatherData { Temperature = 20 };
        var service = new SunBotService(config);

        // Act
        var result = service.Activate(data);

        // Assert
        Assert.False(result);
    }
}