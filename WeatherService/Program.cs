using WeatherService.Bots;
using WeatherService.Models;
using WeatherService.Presentation;
using WeatherService.Services;

namespace WeatherService;

public class Program
{
    public static void Main(string[] args)
    {
        string filePath = "C:\\Users\\hp\\source\\repos\\WeatherService\\WeatherService\\Config\\botsSettings.json";
        ConfigService configService = new ConfigService(filePath);
        var botConfigs = configService.loadConfigSettings();
        BotFactory botFactory = new BotFactory(botConfigs);
        var bots = botFactory.CreateBotList();
        var weatherNotifier = new WeatherNotifier(bots);

        Console.WriteLine("Real-Time Weather Monitoring Service");

        var menuService = new MenuService();
        var weatherDataParserFactory = new WeatherDataParserFactory();

        while (true)
        {
            menuService.ShowMenu();
            var choice = Console.ReadLine();

            if (choice == "1")
            {
                ProcessWeatherData(weatherDataParserFactory, weatherNotifier);
            }
            else if (choice == "2")
            {
                Console.WriteLine("Exiting the application...");
                break;
            }
            else
            {
                Console.WriteLine("Please select a valid option.");
            }
        }
    }

    public static void ProcessWeatherData(WeatherDataParserFactory parserFactory, WeatherNotifier weatherNotifier)
    {
        Console.WriteLine("Enter weather data (JSON or XML). Press Ctrl+Z then Enter to finish: ");
        string inputData = ReadInputData();

        var weatherDataParser = parserFactory.DetectDataFormat(inputData);
        var weatherData = weatherDataParser?.Parse(inputData);

        if (weatherData != null)
        {
            weatherNotifier.NotifyBots(weatherData);
        }
        else
        {
            Console.WriteLine("Invalid format or empty data.");
        }
    }

    public static string ReadInputData()
    {
        string inputData = string.Empty;
        string line;
        while ((line = Console.ReadLine()) != null)
        {
            inputData += line;
        }
        return inputData;
    }
}
