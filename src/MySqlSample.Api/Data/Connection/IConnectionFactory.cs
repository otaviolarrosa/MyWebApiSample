using System.Data;

namespace MySqlSample.Api.Data.Connection
{
    public interface IConnectionFactory
    {
         IDbConnection GetConnection();
    }
}