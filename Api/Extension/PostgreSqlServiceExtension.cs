using Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Extension;

public static class PostgreSqlServiceExtension
{
    extension(IServiceCollection services)
    {
        public void AddPostgreSqlDbContext(IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection"));
            });
        }
    };
}