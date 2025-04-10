using Moq;
using WeatherService.Bots;
using WeatherService.Models;
using WeatherService.Services;

namespace WeatherService.Tests;

public class WeatherNotifierTests
{
    [Fact]
    public void NotifyBots_ShouldActivateABots_WhenCalled()
    {
        var mockWeatherData = new WeatherData();
        var mockBotService1 = new Mock<IBotService>();
        var mockBotService2 = new Mock<IBotService>();
        var mockBotServiceList = new List<IBotService> { mockBotService1.Object, mockBotService2.Object };
        var weatherNotifier = new WeatherNotifier(mockBotServiceList);

        weatherNotifier.NotifyBots(mockWeatherData);

        mockBotService1.Verify(x => x.Activate(mockWeatherData), Times.Once);
        mockBotService2.Verify(x => x.Activate(mockWeatherData), Times.Once);
    }
}