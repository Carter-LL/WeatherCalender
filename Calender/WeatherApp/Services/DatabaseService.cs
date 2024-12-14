using MySql.Data.MySqlClient;
using WeatherApp.Models.SQL;

namespace WeatherApp.Services
{
    public class DatabaseService
    {
        private static string Host = "150.136.90.68";
        private static string User = "publicuser";
        private static string DBname = "calenderdb";
        private static string Password = "publicuser";
        private static string Port = "6548";
        MySqlConnection conn;

        public DatabaseService()
        {
            if (CheckConnection())
            {
                Console.WriteLine("Connected to database");
            }
            else
            {
                Console.WriteLine("Unable to connect to Databse!");
            }
        }

        private bool CheckConnection()
        {
            string connString =
            string.Format(
                "Server={0};Username={1};Database={2};Port={3};Password={4}",
                Host,
                User,
                DBname,
                Port,
                Password
            );

            try
            {
                conn = new MySqlConnection(connString);
                conn.Open();
                conn.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task Insert(string tableName, List<Dictionary<string, object>> rows)
        {
            try
            {
                await conn.OpenAsync();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    // Dynamically build the column names and parameters
                    var columnNames = string.Join(", ", rows[0].Keys);
                    var parameterNames = string.Join(", ", rows[0].Keys.Select(k => "@" + k));

                    // SQL query string
                    cmd.CommandText = $"INSERT INTO {tableName} ({columnNames}) VALUES ({parameterNames})";

                    // Prepare the command
                    await cmd.PrepareAsync();

                    // Loop through each row of data
                    foreach (var row in rows)
                    {
                        // Clear the existing parameters to add new ones
                        cmd.Parameters.Clear();

                        // Add parameters for the current row
                        foreach (var kvp in row)
                        {
                            cmd.Parameters.AddWithValue("@" + kvp.Key, kvp.Value ?? DBNull.Value);
                        }

                        // Execute the query
                        await cmd.ExecuteNonQueryAsync();
                    }

                    await conn.CloseAsync();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error {ex.Number} has occurred: {ex.Message}");
            }
        }

        public async Task CreateTable(string tableName, List<ColumnModel> columns)
        {
            try
            {
                await conn.OpenAsync();
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    // Start building the CREATE TABLE IF NOT EXISTS query
                    var columnDefinitions = new List<string>();

                    // Iterate over columns and create the column definitions
                    foreach (var column in columns)
                    {
                        columnDefinitions.Add($"{column.Name} {column.DataType}");
                    }

                    // Join the column definitions into the final query
                    string query = $"CREATE TABLE IF NOT EXISTS {tableName} ({string.Join(", ", columnDefinitions)})";

                    // Set the command text
                    cmd.CommandText = query;

                    // Execute the command to create the table if it doesn't exist
                    await cmd.ExecuteNonQueryAsync();
                    Console.WriteLine($"Table '{tableName}' checked/created successfully.");

                    await conn.CloseAsync();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error {ex.Number} has occurred: {ex.Message}");
            }
        }
    }
}
