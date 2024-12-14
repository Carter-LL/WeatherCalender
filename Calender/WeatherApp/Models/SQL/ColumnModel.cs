namespace WeatherApp.Models.SQL
{
    public class ColumnModel
    {
        public string Name { get; set; }
        public string DataType { get; set; }

        public ColumnModel(string name, string dataType)
        {
            Name = name;
            DataType = dataType;
        }
    }
}
