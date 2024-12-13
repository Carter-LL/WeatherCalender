using Newtonsoft.Json;

namespace Calender.Models
{
    public class Temperature
    {
        [JsonProperty("min")]
        public double Min { get; set; }

        [JsonProperty("max")]
        public double Max { get; set; }
    }
}
