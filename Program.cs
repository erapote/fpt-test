// Note: Using new C# 9 feature -> TOP-LEVEL STATEMENTS

using System;
using Microsoft.Extensions.DependencyInjection;
using OurWeather.Api;

const string baseUrl = "http://api.weatherstack.com/";

var services = new ServiceCollection();
services.AddHttpClient<WeatherStackClient>(c => c.BaseAddress = new Uri(baseUrl));

Console.WriteLine("Enter Zip Code:");

var input = Console.ReadLine();

if (int.TryParse(input, out var zipCode))
{
    try
    {
        var serviceProvider = services.BuildServiceProvider();
        var client = serviceProvider.GetService<WeatherStackClient>();
        var response = await client.GetCurrentWeather(zipCode);

        if (response.CurrentWeather == null)
        {
            Console.WriteLine("\n\nInvalid zip code.");
        }
        else
        {

            // Note: For debugging
            // Console.WriteLine("\n\nWeather Data: ");
            // Console.WriteLine($"{response.CurrentWeather}\n\n");
            // --------------------------------------------------------

            // Would have parsed the codes from https://weatherstack.com/site_resources/weatherstack-weather-condition-codes.zip file
            // But will make app bit more complicated
            // Checking weather_descriptions field should suffice
            var isRainy = response.CurrentWeather.IsRainy;

            var shouldGoOutside = isRainy ? "NO" : "YES";
            var shouldWearSunscreen = response.CurrentWeather.UvIndex > 3 ? "YES" : "NO";
            var canFlyKite = !isRainy && response.CurrentWeather.WindSpeed > 15 ? "YES" : "NO";

            Console.WriteLine("\n");
            Console.WriteLine($"Should I go outside? {shouldGoOutside}");
            Console.WriteLine($"Should I wear sunscreen? {shouldWearSunscreen}");
            Console.WriteLine($"Can I fly my kite? {canFlyKite}");
        }
    }
    catch
    {
        Console.WriteLine("\n\nApplication error...");
    }
}
else
{
    Console.WriteLine("\n\nInvalid input.");
}


Console.WriteLine("\n\nPress a key to end.");
Console.ReadKey();