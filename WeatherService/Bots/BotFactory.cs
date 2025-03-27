using WeatherService.Enums;
using WeatherService.Models;

namespace WeatherService.Bots;

public class BotFactory
{
    private readonly Dictionary<string, BotConfig> _botConfigurations;

    public BotFactory(Dictionary<string, BotConfig> botConfigurations)
    {
        _botConfigurations = botConfigurations;
    }

    public List<IBotService> CreateBotList()
    {
        var bots = new List<IBotService>();
        foreach (var item in _botConfigurations)
        {
            if (Enum.TryParse(item.Key, out BotType botType))
            {
                IBotService bot = CreateBot(botType, item.Value);
                bots.Add(bot);
            }
            else
            {
                throw new InvalidOperationException($"Unknown bot type: {item.Key}");
            }
        }
        return bots;
    }

    private IBotService CreateBot(BotType botName, BotConfig botConfig)
    {
        switch (botName)
        {
            case BotType.RainBot:
                return new RainBotService(botConfig);
            case BotType.SunBot:
                return new SunBotService(botConfig);
            case BotType.SnowBot:
                return new SnowBotService(botConfig);
            default:
                throw new InvalidOperationException("Unknown bot type");
        }
    }
}
