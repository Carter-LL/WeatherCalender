using Newtonsoft.Json;

namespace Calender.Models;

public class Month
{
    public string month_name { get; set; }
    public int starting_day { get; set; }
    public int ending_day { get; set; }
    public Dictionary<int, string> holidays { get; set; }
    public string summary { get; set; }
}