using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store_api.Data;
using store_api.ModelDto;
using store_api.Models;

namespace store_api.Controllers;

public class ProductController(AppDbContext dbContext) : StoreController(dbContext)
{
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var products = await dbContext.Products.AsNoTracking().ToListAsync();
        var response = new ResponseServer { StatusCode = HttpStatusCode.OK, Result = products };
        return Ok(response);
    }

    [HttpGet("{id}", Name = nameof(GetProductById))]
    public async Task<IActionResult> GetProductById(int id)
    {
        if (id <= 0)
            return BadRequest(new ResponseServer
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = ["Неверный id"]
            });

        var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product == null)
        {
            return NotFound(new ResponseServer
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.NotFound,
                ErrorMessages = ["Продукт по указанному id не найден"]
            });
        }

        return Ok(new ResponseServer { StatusCode = HttpStatusCode.OK, Result = product });
    }

    [HttpPost]
    public async Task<ActionResult<ResponseServer>> CreateProduct([FromBody] ProductCreateDto dto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (dto.Image == null || dto.Image.Length == 0)
                {
                    return BadRequest(new ResponseServer
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessages = ["Изображение не может быть пустым"]
                    });
                }


                var item = new Product
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    SpecialTag = dto.SpecialTag,
                    Category = dto.Category,
                    Price = dto.Price,
                    Image = $"https://place-hold.it/{Random.Shared.Next(200, 500)}x{Random.Shared.Next(200, 500)}"
                };

                await dbContext.Products.AddAsync(item);
                await dbContext.SaveChangesAsync();

                var response = new ResponseServer
                {
                    IsSuccess = true,
                    StatusCode = HttpStatusCode.Created,
                    Result = item
                };

                return CreatedAtRoute(nameof(GetProductById), new { id = item.Id }, response);
            }

            return BadRequest(new ResponseServer
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = ["Модель данных не подходит"]
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ResponseServer
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = ["Что-то поломалось", ex.Message]
            });
        }
    }
}