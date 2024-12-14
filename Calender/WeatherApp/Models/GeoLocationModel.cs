using System.Security.Cryptography;
using System.Text;

namespace WeatherApp.Models
{
    public class GeoLocationModel
    {
        public string ip { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}
