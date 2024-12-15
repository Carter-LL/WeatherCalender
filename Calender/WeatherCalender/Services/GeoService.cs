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
            string jsonString = await client.GetStringAsync("https://api.ipgeolocation.io/ipgeo?apiKey=3bbdd7651d2848afbe0706c3562788c3");

            // Regex pattern to extract latitude and longitude from the JSON-like structure
            string pattern = @"""latitude"":\s*""?(-?\d+\.\d+)""?,\s*""longitude"":\s*""?(-?\d+\.\d+)""?";

            // Use regex to match the pattern
            Match match = Regex.Match(jsonString, pattern);

            if (match.Success)
            {
                // Extract latitude and longitude from the matched groups
                double latitude = double.Parse(match.Groups[1].Value);
                double longitude = double.Parse(match.Groups[2].Value);

                // Output the results
                Console.WriteLine($"Latitude: {latitude}");
                Console.WriteLine($"Longitude: {longitude}");

                geo.Lat = latitude;
                geo.Lon = longitude;
            }
            else
            {
                Console.WriteLine("Latitude and Longitude not found in the response.");
            }

            return geo;
        }
    }
}
