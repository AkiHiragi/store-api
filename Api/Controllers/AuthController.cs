using Microsoft.AspNetCore.Identity;
using store_api.Data;
using store_api.Models;

namespace store_api.Controllers;

public class AuthController(
    AppDbContext dbContext,
    UserManager<AppUser> userManager,
    RoleManager<IdentityRole> roleManager)
    : StoreController(dbContext)
{
    private readonly UserManager<AppUser> _userManager = userManager;
    private readonly RoleManager<IdentityRole> _roleManager = roleManager;
}