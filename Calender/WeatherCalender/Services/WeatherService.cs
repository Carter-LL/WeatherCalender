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
                    { "x-rapidapi-key", "b757868fb8msh24d2dc1fc45869cp117554jsn15664bea7827" },
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
