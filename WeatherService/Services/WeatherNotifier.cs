
using WeatherService.Bots;
using WeatherService.Models;

namespace WeatherService.Services
{
    public class WeatherNotifier
    {
        private readonly List<IBot> _bots;

        public WeatherNotifier(List<IBot> bots)
        {
            _bots = bots;
        }

        public void NotifyBots(WeatherData data)
        {
            foreach (var bot in _bots)
            {
                bot.Activate(data);
            }
        }
    }
}
