namespace WeatherApp
{
    public class GlobalConstants
    {
        private static readonly string _Host = "150.136.90.68";
        private static readonly string _User = "publicuser";
        private static readonly string _DBname = "calenderdb";
        private static readonly string _Password = "publicuser";
        private static readonly string _Port = "6548";

        public static string ConnectionString
        {
            get
            {
                return string.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4}",
                    _Host,
                    _User,
                    _DBname,
                    _Port,
                    _Password
                );
            }
        }
    }
}
