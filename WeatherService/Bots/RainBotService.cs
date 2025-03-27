
using WeatherService.Models;

namespace WeatherService.Bots
{
    public class RainBotService : IBot
    {
        private BotConfig botConfig;

        public RainBotService(BotConfig botConfig)
        {
            this.botConfig = botConfig;
        }

        public void Activate(WeatherData data)
        {
            if(botConfig.Enabled && data.Humidity > botConfig.Threshold)
            {
                Console.WriteLine("RainBot activated!");
                Console.WriteLine(botConfig.Message);
            }
        }
    }
}
