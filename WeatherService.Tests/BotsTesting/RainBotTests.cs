using WeatherService.Models;
using WeatherService.Services.Bots;

namespace WeatherService.Tests.BotsTesting;

public class RainBotTests
{
    [Fact]
    public void Activate_ShouldReturnTrue_WhenEnabledAndHumidityAboveThreshold()
    {
        // Arrange
        var config = new BotConfig
        {
            Enabled = true,
            Threshold = 70,
            Message = "It looks like it's about to pour down!"
        };
        var data = new WeatherData { Humidity = 80 };
        var service = new RainBotService(config);

        // Act
        var result = service.Activate(data);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void Activate_ShouldReturnFalse_WhenNotEnabled()
    {
        // Arrange
        var config = new BotConfig
        {
            Enabled = false,
            Threshold = 70,
            Message = "RainBot isn't activated."
        };
        var data = new WeatherData { Humidity = 80 };
        var service = new RainBotService(config);

        // Act
        var result = service.Activate(data);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Activate_ShouldReturnFalse_WhenHumidityBelowThreshold()
    {
        // Arrange
        var config = new BotConfig
        {
            Enabled = true,
            Threshold = 70,
            Message = "RainBot isn't activated. Humidity is below threshold."
        };
        var data = new WeatherData { Humidity = 60 };
        var service = new RainBotService(config);

        // Act
        var result = service.Activate(data);

        // Assert
        Assert.False(result);
    }
}