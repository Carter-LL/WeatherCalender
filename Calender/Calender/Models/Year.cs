using Newtonsoft.Json;

namespace Calender.Models;

public class Year
{
    [JsonProperty("January")]
    public Month January { get; set; }

    [JsonProperty("February")]
    public Month February { get; set; }

    [JsonProperty("March")]
    public Month March { get; set; }

    [JsonProperty("April")]
    public Month April { get; set; }

    [JsonProperty("May")]
    public Month May { get; set; }

    [JsonProperty("June")]
    public Month June { get; set; }

    [JsonProperty("July")]
    public Month July { get; set; }

    [JsonProperty("August")]
    public Month August { get; set; }

    [JsonProperty("September")]
    public Month September { get; set; }

    [JsonProperty("October")]
    public Month October { get; set; }

    [JsonProperty("November")]
    public Month November { get; set; }

    [JsonProperty("December")]
    public Month December { get; set; }
}