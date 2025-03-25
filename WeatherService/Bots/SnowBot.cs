
using WeatherService.Models;

namespace WeatherService.Bots
{
    public class SnowBot : IBot 
    {
        private BotConfig botConfig;

        public SnowBot(BotConfig botConfig)
        {
            this.botConfig = botConfig;
        }

        public void Activate(WeatherData data)
        {
            if (botConfig.Enabled && data.Temperature < botConfig.Threshold)
            {
                Console.WriteLine("SnowBot activated!");
                Console.WriteLine(botConfig.Message);
            }
        }
    }
}
