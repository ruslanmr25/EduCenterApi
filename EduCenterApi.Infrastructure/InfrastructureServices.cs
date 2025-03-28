using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Infrastructure.DatabaseContext;
using EduCenterApi.Infrastructure.Repositories;
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


            services.AddScoped<ICenterRepository, CenterRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

    }
}
