using Moq;
using WeatherService.Models;
using WeatherService.Services.FileReaders;
using FluentAssertions;
using System.Text.Json;
using FluentAssertions.Execution;

namespace WeatherService.Tests.ParsersTesting;

public class ConfigServiceTests
{
    private readonly Mock<IFileReader> mockFileReader;

    public ConfigServiceTests()
    {
        mockFileReader = new Mock<IFileReader>();
    }


    [Fact]
    public void LoadConfigSettings_ValidJsonInput_ShouldReturnDeserializedDictionary()
    {
        // Arrange
        const string fakeJsonConfig = """
            {
            "RainBot": {
              "Enabled": true,
              "Threshold": 70,
              "Message": "It looks like it's about to pour down!"
              }
            }                
            """;

        mockFileReader.Setup(x => x.ReadAllText(It.IsAny<string>())).Returns(fakeJsonConfig);
        var configService = new ConfigService("botsSettings.json", mockFileReader.Object);

        //Act
        var results = configService.loadConfigSettings();

        //Assert
        using (new AssertionScope())
        {
        results.Should().ContainKey("RainBot");
        results["RainBot"].Enabled.Should().Be(true);
        results["RainBot"].Threshold.Should().Be(70);
        results["RainBot"].Message.Should().Be("It looks like it's about to pour down!");
        }

    }

    [Fact]
    public void LoadConfigSettings_InvalidJson_ThrowsJsonException()
    {
        // Arrange
        const string invalidJson = "This is not JSON!";
        mockFileReader.Setup(x => x.ReadAllText(It.IsAny<string>())).Returns(invalidJson);
        var configService = new ConfigService(It.IsAny<string>(), mockFileReader.Object);


        // Act & Assert
        Assert.Throws<JsonException>(() => configService.loadConfigSettings());
    }
}