using Npgsql;
using Npgsql.Replication.PgOutput.Messages;

namespace HouseWorkAPI.Modules
{
    public class PostgreSQLModule
    {
        private string _connectionstring;
        private NpgsqlDataSource _dataSource;

        public PostgreSQLModule(string connectionstring)
        {
            _connectionstring = connectionstring;
            _dataSource = NpgsqlDataSource.Create(_connectionstring);
        }

        public bool Insert()
        {
            return true;
        }

        public bool Update()
        {
            return true;
        }

        public bool Delete()
        {
            return true;
        }

        public string Query(string query)
        {
            return "";
        }
    }
}
