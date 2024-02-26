using Microsoft.Extensions.DependencyInjection;

using OmgBreakfast.BLL.Services.Breakfasts;
using OmgBreakfast.DAL;

namespace OmgBreakfast.BLL;

public static class BllServiceRegistration
{
    public static IServiceCollection AddBllServices(this IServiceCollection services)
    {
        services.AddScoped<IBreakfastService, BreakfastService>();

        services.AddDalServices();

        return services;
    }
}
