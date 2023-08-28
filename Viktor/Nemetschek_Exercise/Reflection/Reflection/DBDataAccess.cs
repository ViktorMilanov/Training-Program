using System.Data.SqlClient;

namespace Reflection
{
    internal class DBDataAccess
    {
        private readonly string _connection;

        public DBDataAccess()
        {
            _connection = "data source=VMILANOV-DUAL; database=PluginLogs; integrated security=SSPI";
        }
        public void CreateLogsTable()
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                SqlCommand cm = new SqlCommand("CREATE TABLE Logs (" +
                                               "Id INT IDENTITY(1,1) PRIMARY KEY, " +
                                               "Name VARCHAR(100) NOT NULL, " +
                                               "Version VARCHAR(50) NOT NULL, " +
                                               "Time DATETIME NOT NULL)", connection);
                cm.ExecuteNonQuery();
            }
        }
        public void InsertLog(string pluginName, string version)
        {
            using (SqlConnection connection = new SqlConnection(_connection))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Logs (Name, Version, Time) " +
                                     "VALUES (@Name, @Version, @Time)";

                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Name", pluginName);
                    command.Parameters.AddWithValue("@Version", version);
                    command.Parameters.AddWithValue("@Time", DateTime.Now);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Plugin choice logged successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Error logging plugin choice.");
                    }
                }
            }
        }
    }
}