using Microsoft.Extensions.DependencyInjection;

using OmgBreakfast.DAL.Repositories;

namespace OmgBreakfast.DAL;

public static class DalServiceRegistration
{
    public static IServiceCollection AddDalServices(this IServiceCollection services)
    {
        services.AddScoped<IBreakfastRepository, BreakfastRepository>();
        return services;
    }
}
