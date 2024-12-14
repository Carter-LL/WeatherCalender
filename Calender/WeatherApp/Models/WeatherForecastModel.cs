using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class WeatherForecastModel
    {
        [JsonProperty("items")]
        public List<ForecastItemModel> Items { get; set; }

        [JsonProperty("forecastDate")]
        public DateTime ForecastDate { get; set; }

        [JsonProperty("nextUpdate")]
        public DateTime NextUpdate { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("point")]
        public string Point { get; set; }

        [JsonProperty("fingerprint")]
        public string Fingerprint { get; set; }
    }
}
