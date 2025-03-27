
using WeatherService.Models;

namespace WeatherService.Bots
{
    public class BotFactory
    {
        private readonly Dictionary<string, BotConfig> _botConfigurations;

        public BotFactory(Dictionary<string, BotConfig> botConfigurations)
        {
            _botConfigurations = botConfigurations;
        }

        public List<IBot> CreateBotList()
        {
            var bots = new List<IBot>();
            foreach (var item in _botConfigurations)
            {
                IBot bot = CreateBot(item.Key, item.Value);
                bots.Add(bot);
            }
            return bots;
        }

        private IBot CreateBot(string botName, BotConfig botConfig)
        {
            switch (botName)
            {
                case "RainBot":
                    return new RainBotService(botConfig);
                case "SunBot":
                    return new SunBotService(botConfig);
                case "SnowBot":
                    return new SnowBotService(botConfig);
                default:
                    throw new InvalidOperationException("Unknown bot type");
            }
        }
    }
}
