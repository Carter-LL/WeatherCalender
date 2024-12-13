namespace Calender.Services
{
    using Calender.Models;
    using Newtonsoft.Json;
    using System.Net.Http.Headers;

    public class WeatherService
    {
        public static async Task<WeatherForecast> GetWeatherData()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://forecast9.p.rapidapi.com/rapidapi/forecast/46.95828/10.87152/summary/"),
                Headers =
                {
                    { "x-rapidapi-key", "b6ee049cc6mshfbfad3e99244a7fp1993fcjsnaaec1e28b8be" },
                    { "x-rapidapi-host", "forecast9.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                WeatherForecast forecast = JsonConvert.DeserializeObject<WeatherForecast>(body);
                return forecast;
            }
        }
    }
}
