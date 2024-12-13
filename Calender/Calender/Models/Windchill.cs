using Newtonsoft.Json;

namespace Calender.Models
{
    public class Windchill
    {
        [JsonProperty("min")]
        public double Min { get; set; }

        [JsonProperty("max")]
        public double Max { get; set; }

        [JsonProperty("avg")]
        public object Avg { get; set; }
    }
}
