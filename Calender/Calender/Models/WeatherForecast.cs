using Newtonsoft.Json;

namespace Calender.Models
{
    public class WeatherForecast
    {
        [JsonProperty("items")]
        public List<ForecastItem> Items { get; set; }

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
