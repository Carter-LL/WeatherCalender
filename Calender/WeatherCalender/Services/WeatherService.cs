using Newtonsoft.Json;
using WeatherCalender.Models;

namespace WeatherCalender.Services
{
    public class WeatherService
    {
        public async Task<WeatherForecastModel> GetWeatherData(string lat, string log)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://forecast9.p.rapidapi.com/rapidapi/forecast/" + lat + "/" + log + "/summary/"),
                Headers =
                {
                    { "x-rapidapi-key", "b6ee049cc6mshfbfad3e99244a7fp1993fcjsnaaec1e28b8be" },
                    { "x-rapidapi-host", "forecast9.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();

                    WeatherForecastModel forecast = JsonConvert.DeserializeObject<WeatherForecastModel>(body);
                    return forecast;
                } else
                {
                    return null;
                }
            }
        }
    }
}
