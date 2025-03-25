
using WeatherService.Models;

namespace WeatherService.Bots
{
    public class SunBot : IBot
    {
        BotConfig botConfig;

        public SunBot(BotConfig botConfig)
        {
            this.botConfig = botConfig;
        }

        public void Activate(WeatherData data)
        {
            if (botConfig.Enabled && data.Temperature < botConfig.Threshold)
            {
                Console.WriteLine("SunBot activated!");
                Console.WriteLine(botConfig.Message);
            }
        }
    }
}
