using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using MySqlSample.Api.Ioc;

namespace MySqlSample.Api.Data.Connection
{
    public class ConnectionFactory : IConnectionFactory
    {
        private string _connectionString;
        public ConnectionFactory()
        {
            this._connectionString = ServiceLocator.Current.GetInstance<IConfiguration>()
                                        .GetSection("ConnectionStrings")
                                        .GetValue<string>("MySqlConnectionString");
        }
        public IDbConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}