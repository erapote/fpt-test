using System.Threading.Tasks;

namespace OurWeather.Api
{
    internal interface IWeatherStackClient
    {
        Task<WeatherStackResponse> GetCurrentWeather(int zipCode);
    }
}
