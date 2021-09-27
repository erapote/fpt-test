using System;
using System.Text.Json.Serialization;

namespace OurWeather.Api
{
    public class WeatherStackResponse
    {
        [JsonPropertyName("current")]
        public Current CurrentWeather { get; set; }

    }

    /// <summary>
    /// Only necessary fields are included based on requirements
    /// </summary>
    public class Current
    {

        [JsonPropertyName("weather_descriptions")]
        public string[] WeatherDescriptions { get; set; }

        [JsonPropertyName("wind_speed")]
        public int WindSpeed { get; set; }

        [JsonPropertyName("uv_index")]
        public int UvIndex { get; set; }

        public bool IsRainy
            => string.Join(',', WeatherDescriptions).ToLowerInvariant().Contains("rain");

        public override string ToString()
        {
            return @$"weather_descriptions: {string.Join(',', WeatherDescriptions)}, windspeed: {WindSpeed}, uv_index: {UvIndex}";
        }

    }
}