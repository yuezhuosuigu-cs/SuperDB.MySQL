using MySql.Data.MySqlClient;

using SuperDB.Config;

using System.Data;

namespace SuperDB.MySQL
{
    public class MySQLFactory : DBFactory
    {
        private IDbConnection _Connection;

        public static MySQLFactory Create()
        {
            return new MySQLFactory();
        }

        public override IDbConnection Connection
        {
            get
            {
                if (_Connection == default)
                {
                    _Connection = new MySqlConnection(DBConfig.ConnectionString);
                }
                if (_Connection.State != ConnectionState.Open)
                {
                    _Connection.Open();
                }
                return _Connection;
            }
        }
    }
}
