﻿using WeatherService.Bots;
using WeatherService.Models;

namespace WeatherService.Services.Bots;

public class SunBotService : IBotService
{
    private BotConfig botConfig;

    public SunBotService(BotConfig botConfig)
    {
        this.botConfig = botConfig;
    }

    public void Activate(WeatherData data)
    {
        if (botConfig.Enabled && data.Temperature > botConfig.Threshold)
        {
            Console.WriteLine("SunBot activated!");
            Console.WriteLine(botConfig.Message);
        }
    }
}
