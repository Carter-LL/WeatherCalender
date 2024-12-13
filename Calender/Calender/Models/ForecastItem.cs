using Newtonsoft.Json;

namespace Calender.Models
{
    public class ForecastItem
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("dateWithTimezone")]
        public DateTime DateWithTimezone { get; set; }

        [JsonProperty("temperature")]
        public Temperature Temperature { get; set; }
    }
}
