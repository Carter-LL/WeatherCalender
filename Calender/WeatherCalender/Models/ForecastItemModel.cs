using Newtonsoft.Json;

namespace WeatherCalender.Models
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
