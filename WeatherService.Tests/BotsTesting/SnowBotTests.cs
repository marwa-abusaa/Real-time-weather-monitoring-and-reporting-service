using WeatherService.Models;
using WeatherService.Services.Bots;

namespace WeatherService.Tests.BotsTesting;

public class SnowBotTests
{
    [Fact]
    public void Activate_TemperatureBelowThresholdAndEnabled_ShouldReturnTrue()
    {
        // Arrange
        var config = new BotConfig
        {
            Enabled = true,
            Threshold = 3,
            Message = "Brrr, it's getting chilly!"
        };
        var data = new WeatherData { Temperature = 0 };
        var service = new SnowBotService(config);

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
            Threshold = 3,
            Message = "SnowBot isn't activated."
        };
        var data = new WeatherData { Temperature = 0 };
        var service = new SnowBotService(config);

        // Act
        var result = service.Activate(data);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Activate_TemperatureAboveThreshold_ShouldReturnFalse()
    {
        // Arrange
        var config = new BotConfig
        {
            Enabled = true,
            Threshold = 3,
            Message = "SnowBot isn't activated. Temperature is above threshold."
        };
        var data = new WeatherData { Temperature = 20 };
        var service = new SnowBotService(config);

        // Act
        var result = service.Activate(data);

        // Assert
        Assert.False(result);
    }      
}
