using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class ForecastItemModel
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("dateWithTimezone")]
        public DateTime DateWithTimezone { get; set; }

        [JsonProperty("temperature")]
        public TemperatureModel Temperature { get; set; }
    }
}
