using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store_api.Common;
using store_api.Data;
using store_api.ModelDto;
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

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterRequestDto dto)
    {
        if (dto == null)
        {
            return BadRequest(new ResponseServer
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = ["Некорректная модель запроса"]
            });
        }

        var userFromDb = await dbContext.AppUsers.FirstOrDefaultAsync(u=>u.NormalizedUserName == dto.UserName.ToUpper());

        if (userFromDb != null)
        {
            return BadRequest(new ResponseServer
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = ["Такой пользователь есть"]
            });
        }

        var newAppUser = new AppUser
        {
            UserName = dto.UserName,
            Email = dto.Email,
            FirstName = dto.UserName,
            NormalizedEmail = dto.Email.ToUpper(),
        };
        
        var result = await _userManager.CreateAsync(newAppUser, dto.Password);

        if (!result.Succeeded)
        {
            return BadRequest(new ResponseServer
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = ["Ошибка регистрации"]
            });
        }

        var newRoleAppUser = dto.Role.Equals(
            SharedData.Roles.Admin, StringComparison.OrdinalIgnoreCase)
            ? SharedData.Roles.Admin
            : SharedData.Roles.Consumer;
        
        await _userManager.AddToRoleAsync(newAppUser, newRoleAppUser);

        return Ok(new ResponseServer
        {
            StatusCode = HttpStatusCode.OK,
            Result = "Регистрация завершена"
        });
    }
}