using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Web.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config["ConnectionStrings:Default"];

        services.AddDbContext<RepositoryContext>(o => o.UseMySql(connectionString, 
            MySqlServerVersion.LatestSupportedServerVersion));
    }
    
    public static void ConfigureRepositoryWrapper(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
    }
}