using EduCenterApi.Application.Abstractions.Hasher;
using EduCenterApi.Application.Mapper;
using EduCenterApi.Application.PasswordHashing;
using Microsoft.Extensions.DependencyInjection;

namespace EduCenterApi.Application;

public static class ApplicationServices
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MainMapper).Assembly);
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}
