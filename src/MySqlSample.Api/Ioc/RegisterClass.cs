using Microsoft.Extensions.DependencyInjection;
using MySqlSample.Api.Data.Connection;
using MySqlSample.Api.Data.Mapping;
using MySqlSample.Api.Data.Repository;

namespace MySqlSample.Api.Ioc
{
    public class RegisterClass
    {
        public void Register(IServiceCollection services)
        {
            services.AddTransient<IConnectionFactory, ConnectionFactory>();
            services.AddTransient<IRepository<User>, Repository<User>>();
        }
    }
}