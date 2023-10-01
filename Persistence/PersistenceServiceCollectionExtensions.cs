using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Persistence
{
    public static class PersistenceServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<IDataContext, DataContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Default"), x => x.MigrationsAssembly(Assembly.GetExecutingAssembly().ToString()));
            });

            return services;
        }
    }
}
