using Newtonsoft.Json;

namespace Calender.Models
{
    public class Astronomy
    {
        [JsonProperty("dawn")]
        public DateTime Dawn { get; set; }

        [JsonProperty("sunrise")]
        public DateTime Sunrise { get; set; }

        [JsonProperty("suntransit")]
        public DateTime SunTransit { get; set; }

        [JsonProperty("sunset")]
        public DateTime Sunset { get; set; }

        [JsonProperty("dusk")]
        public DateTime Dusk { get; set; }

        [JsonProperty("moonrise")]
        public DateTime Moonrise { get; set; }

        [JsonProperty("moontransit")]
        public DateTime MoonTransit { get; set; }

        [JsonProperty("moonset")]
        public DateTime Moonset { get; set; }

        [JsonProperty("moonphase")]
        public int MoonPhase { get; set; }

        [JsonProperty("moonzodiac")]
        public int MoonZodiac { get; set; }
    }
}
