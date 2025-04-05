using EduCenterApi.Application.Abstractions.IRepositories;
using EduCenterApi.Application.Abstractions.IValidators;
using EduCenterApi.Infrastructure.DatabaseContext;
using EduCenterApi.Infrastructure.Repositories;
using EduCenterApi.Infrastructure.Validators;
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

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ICenterRepository, CenterRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IScienceRepository, ScienceRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();



            services.AddScoped<IUniqueValidator,UniqueValidator>();
            return services;
        }

    }
}
