using Newtonsoft.Json;

namespace Calender.Models
{
    public class SnowLine
    {
        [JsonProperty("avg")]
        public object Avg { get; set; }

        [JsonProperty("min")]
        public object Min { get; set; }

        [JsonProperty("max")]
        public object Max { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }
}
