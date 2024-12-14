using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class TemperatureModel
    {
        [JsonProperty("min")]
        public double Min { get; set; }

        [JsonProperty("max")]
        public double Max { get; set; }
    }
}
