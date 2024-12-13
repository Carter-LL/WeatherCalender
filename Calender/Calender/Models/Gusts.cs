using Newtonsoft.Json;

namespace Calender.Models
{
    public class Gusts
    {
        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("text")]
        public object Text { get; set; }
    }
}
