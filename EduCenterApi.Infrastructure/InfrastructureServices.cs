using EduCenterApi.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EduCenterApi.Infrastructure
{
    public static class InfrastructureServices
    {
        public static IServiceCollection RegisterInfrastructureServces(this IServiceCollection services, string connectionString)
        {

           
            services.AddDbContext<BaseContext>(options =>
            {
                options.UseNpgsql(connectionString, x => x.MigrationsHistoryTable("migrations"));
            });
            return services;
        }

    }
}
