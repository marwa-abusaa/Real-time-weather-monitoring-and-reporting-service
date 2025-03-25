
using WeatherService.Models;

namespace WeatherService.Bots
{
    public class RainBot : IBot
    {
        BotConfig botConfig;

        public RainBot(BotConfig botConfig)
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
