using AutoFixture;
using FluentAssertions;
using WeatherService.Bots;
using WeatherService.Models;

namespace WeatherService.Tests;

public class BotFactoryTests
{
    private readonly Fixture _fixture;
    private readonly BotConfig _botConfig;

    public BotFactoryTests()
    {
        _fixture = new Fixture();
        _botConfig = _fixture.Create<BotConfig>();
    }


    [Theory]
    [InlineData("RainBot")]
    [InlineData("SnowBot")]
    [InlineData("SunBot")]
    public void CreateBotList_ShouldReturnListOfBots_WhenBotTypesAreValid(string validBot)
    {       
        var bots = new Dictionary<string, BotConfig>
        {
            { validBot, _botConfig }
        };
        var botFactory = new BotFactory(bots);

        var validBots = botFactory.CreateBotList();

        validBots.Should().ContainSingle(bot => bot is IBotService);
    }


    [Fact]
    public void CreateBotList_ShouldThrowInvalidOperationException_WhenUnknownBotTypeIsProvided()
    {       
        var bots = new Dictionary<string, BotConfig>
        {
            { "UnknownBot", _botConfig }
        };
        var botFactory = new BotFactory(bots);

        Assert.Throws<InvalidOperationException>(() => botFactory.CreateBotList());
    }
}
