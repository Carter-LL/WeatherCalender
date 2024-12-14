using System.ComponentModel.DataAnnotations;

namespace WeatherApp.Models.SQL.Tables
{
    public class PlannedEventModel
    {
        [Key]
        public int Id { get; set; }
        public string Desktop { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
    }
}
