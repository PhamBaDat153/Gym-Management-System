using System.Configuration;
using System.Data.SqlClient;

namespace Client.DataContext
{
    public static class GymManagementSystemContext
    {
        private static readonly string _connectionString;

        static GymManagementSystemContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["GymManagementSystem"].ConnectionString;
        }

        public static SqlConnection Connect()
        {
            return new SqlConnection(_connectionString);
        }

        public static bool TestConnection()
        {
            using (SqlConnection connection = Connect())
            {
                connection.Open();
                return connection.State == System.Data.ConnectionState.Open;
            }
        }
    }
}
