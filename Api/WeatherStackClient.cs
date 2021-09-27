using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OurWeather.Api
{
    public class WeatherStackClient : IWeatherStackClient
    {
        // Normally, will put in appsettings.json file
        private const string ApiKey = "0a4e8b9b1bec0efd78ca0097c6d66225";

        private readonly HttpClient _httpClient;

        public WeatherStackClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherStackResponse> GetCurrentWeather(int zipCode)
            => await _httpClient.GetFromJsonAsync<WeatherStackResponse>($"/current?access_key={ApiKey}&query={zipCode}");

    }
}
