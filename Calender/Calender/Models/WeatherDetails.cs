using Newtonsoft.Json;

namespace Calender.Models
{
    public class WeatherDetails
    {
        [JsonProperty("state")]
        public int State { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}
