using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using store_api.Common;

namespace store_api.Extensions;

public static class RoleInitializerServiceExtension
{
    public static async Task InitializeRoleAsync(this IServiceProvider serviceProvider)
    {
        using var score = serviceProvider.CreateScope();
        var roleManager = score.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        foreach (var role in SharedData.Roles.AllRoles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}