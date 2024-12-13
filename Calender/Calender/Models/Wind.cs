using Newtonsoft.Json;

namespace Calender.Models
{
    public class Wind
    {
        [JsonProperty("unit")]
        public string Unit { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("avg")]
        public object Avg { get; set; }

        [JsonProperty("min")]
        public double Min { get; set; }

        [JsonProperty("max")]
        public double Max { get; set; }

        [JsonProperty("gusts")]
        public Gusts Gusts { get; set; }

        [JsonProperty("significationWind")]
        public bool SignificationWind { get; set; }
    }
}
