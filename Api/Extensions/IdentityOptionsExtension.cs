using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace store_api.Extensions;

public static class IdentityOptionsExtension
{
    public static IServiceCollection AddConfigureIdentityOptions(this IServiceCollection services)
    {
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 1;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
        });

        return services;
    }
}