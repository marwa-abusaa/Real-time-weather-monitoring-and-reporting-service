using Moq;
using WeatherService.Models;
using WeatherService.Services.FileReaders;
using FluentAssertions;

namespace WeatherService.Tests;

public class ConfigServiceTests
{
    [Fact]
    public void LoadConfigSettings_ShouldReturnDeserializedDictionary()
    {
        var fakeJsonConfig = """
            {
            "RainBot": {
              "Enabled": true,
              "Threshold": 70,
              "Message": "It looks like it's about to pour down!"
              }
            }                
            """;
        var mockFileReader = new Mock<IFileReader>();
        mockFileReader.Setup(x => x.ReadAllText(It.IsAny<string>())).Returns(fakeJsonConfig);
        var configService = new ConfigService("botsSettings.json", mockFileReader.Object);


        var results = configService.loadConfigSettings();


        results.Should().ContainKey("RainBot");
        results["RainBot"].Enabled.Should().Be(true);
        results["RainBot"].Threshold.Should().Be(70);
        results["RainBot"].Message.Should().Be("It looks like it's about to pour down!");

    }
}
