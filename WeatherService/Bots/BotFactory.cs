
namespace WeatherService.Bots
{
    public class BotFactory
    {
        private readonly Dictionary<string, BotConfig> _botConfigurations;

        public BotFactory(Dictionary<string, BotConfig> botConfigurations)
        {
            _botConfigurations = botConfigurations;
        }
        
    }
}
