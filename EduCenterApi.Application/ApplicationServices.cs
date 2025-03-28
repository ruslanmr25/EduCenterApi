using EduCenterApi.Application.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace EduCenterApi.Application;

public static class ApplicationServices
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MainMapper).Assembly);

        return services;
    }
}
