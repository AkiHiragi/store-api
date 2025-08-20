using Microsoft.AspNetCore.Identity;

namespace store_api.Models;

public class AppUser:IdentityUser
{
    public string FirstName { get; set; }
}