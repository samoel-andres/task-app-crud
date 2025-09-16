using Microsoft.Data.SqlClient;

namespace Tasks_app.Config
{
    internal static class DB
    {
        private static readonly string server = Environment.GetEnvironmentVariable("DB_SERVER")
            ?? throw new InvalidOperationException("DB_SERVER Not set.");
        private static readonly string database = Environment.GetEnvironmentVariable("DB_DATABASE")
            ?? throw new InvalidOperationException("DB_DATABASE Not set.");
        private static readonly string user = Environment.GetEnvironmentVariable("DB_USER")
            ?? throw new InvalidOperationException("DB_USER Not set.");
        private static readonly string password = Environment.GetEnvironmentVariable("DB_PASSWORD")
            ?? throw new InvalidOperationException("DB_PASSWORD Not set.");

        private static readonly string stringConnection = $"Server={server};Database={database};User Id={user};Password={password};TrustServerCertificate=True;";

        internal static SqlConnection GetConnection()
        {
            return new SqlConnection(stringConnection);
        }

        internal async static Task TestConnection()
        {
            try
            {
                await using var conn = GetConnection();
                await conn.OpenAsync();
                Console.WriteLine("Test connection: successful...");
            }
            catch (Exception e)
            {
                Console.WriteLine("Test connection: failed...\n\n" + e.Message);
            }
        }
    }
}
