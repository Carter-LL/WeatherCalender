using System.ComponentModel.DataAnnotations;

namespace WeatherCalender.Models.SQL.Tables
{
    public class UserDataModel
    {
        [Key]
        public string Desktop { get; set; }
        public string Lat_Encrypted { get; set; }
        public string Lon_Encrypted { get; set; }
    }
}
