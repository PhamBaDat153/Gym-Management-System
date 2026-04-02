using System.Configuration;
using System.Data.SqlClient;

namespace Client.DataContext
{
    internal class GymManagementSystemContext
    {
        private readonly string _connectionString;

        public GymManagementSystemContext()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["GymManagementDb"].ConnectionString;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectiqonString);
        }

        public bool TestConnection()
        {
            using (SqlConnection connection = CreateConnection())
            {
                connection.Open();
                return connection.State == System.Data.ConnectionState.Open;
            }
        }
    }
}
