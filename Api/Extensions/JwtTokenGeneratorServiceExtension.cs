using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using store_api.Service;

namespace store_api.Extensions;

public static class JwtTokenGeneratorServiceExtension
{
    public static IServiceCollection AddJwtTokenGenerator(
        this IServiceCollection services)
    {
        return services.AddScoped<JwtTokenGenerator>();
    }
}