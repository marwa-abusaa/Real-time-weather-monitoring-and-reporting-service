
namespace WeatherService.Bots
{
    public class BotConfig
    {
        public required bool Enabled { get; set; }
        public required double Threshold { get; set; }
        public required string Message { get; set; } 
    }
}
