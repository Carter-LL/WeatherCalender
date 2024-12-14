using System.Text.RegularExpressions;
using WeatherCalender.Models;

namespace WeatherCalender.Services
{
    public class GeoService
    {
        public async Task<string> GetIP(HttpClient client)
        {
            string ipString = await client.GetStringAsync("http://icanhazip.com");
            return ipString;
        }
        public async Task<GeoLocationModel> GetGeoLocation(HttpClient client)
        {
            GeoLocationModel geo = new();

            // Fetch the JSON data from the API
            string jsonString = await client.GetStringAsync("https://api.my-ip.io/v2/ip.json");

            // Regex pattern to capture latitude and longitude values
            string latLonPattern = @"""lat"":\s*(-?\d+\.\d+)\s*,\s*""lon"":\s*(-?\d+\.\d+)";
            Regex latLonRegex = new Regex(latLonPattern);
            Match latLonMatch = latLonRegex.Match(jsonString);

            if (latLonMatch.Success)
            {
                string latString = latLonMatch.Groups[1].Value;
                string lonString = latLonMatch.Groups[2].Value;

                // Try parsing the latitude and longitude
                if (double.TryParse(latString, out double latDouble) && double.TryParse(lonString, out double lonDouble))
                {
                    geo.Lat = latDouble;  // Store the latitude
                    geo.Lon = lonDouble;  // Store the longitude
                }
            }

            return geo;
        }
    }
}
