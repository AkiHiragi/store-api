using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using store_api.Data;

namespace store_api.Extensions;

public static class PostgreSqlServiceExtension
{
    public static void AddPostgreSqlDbContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection"));
        });
    }

    public static void AddPostgreSqlIdentityContext(this IServiceCollection services)
    {
        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();
    }
}