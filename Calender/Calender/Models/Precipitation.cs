using Newtonsoft.Json;

namespace Calender.Models
{
    public class Precipitation
    {
        [JsonProperty("sum")]
        public double Sum { get; set; }

        [JsonProperty("probability")]
        public int Probability { get; set; }

        [JsonProperty("sumAsRain")]
        public object SumAsRain { get; set; }

        [JsonProperty("class")]
        public int Class { get; set; }
    }
}
