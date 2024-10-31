using System.Data.SqlClient;

namespace ContactBookAPI.Data_Access_Layer
{
    public class DbConnection
    {
        private readonly string connectionString = "Server=localhost\\MSSQLSERVER01;Database=ContactBookDB;Trusted_Connection=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
