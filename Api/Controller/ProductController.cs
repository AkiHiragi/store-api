using System.Net;
using Api.Data;
using Api.Model;
using Api.ProductDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controller;

public class ProductController : StoreController
{
    public ProductController(AppDbContext dbContext)
        : base(dbContext)
    {

    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var response = new ResponseServer
        {
            StatusCode = HttpStatusCode.OK,
            Result = await dbContext.Products.ToListAsync()
        };

        return Ok(response);
    }

    [HttpGet("{id}", Name = nameof(GetProductById))]
    public async Task<IActionResult> GetProductById(int id)
    {
        if (id <= 0)
        {
            return BadRequest(new ResponseServer
            {
                StatusCode = HttpStatusCode.BadRequest,
                IsSuccess = false,
                ErrorMessages = ["Неверный id"]
            });
        }

        var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

        if (product == null)
        {
            return NotFound(new ResponseServer
            {
                StatusCode = HttpStatusCode.NotFound,
                IsSuccess = false,
                ErrorMessages = ["Продукт по указанному id не найден"]
            });
        }

        return Ok(new ResponseServer
        {
            StatusCode = HttpStatusCode.OK,
            Result = product
        });
    }

    [HttpPost]
    public async Task<ActionResult<ResponseServer>> CreateProduct(
        [FromBody] ProductCreateDto productCreateDto
    )
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (productCreateDto.Image == null
                    || productCreateDto.Image.Length == 0)
                {
                    return BadRequest(new ResponseServer
                    {
                        StatusCode = HttpStatusCode.BadRequest,
                        IsSuccess = false,
                        ErrorMessages = ["Изображение продукта не может быть пустым"]
                    });
                }
                else
                {
                    var item = new Product
                    {
                        Name = productCreateDto.Name,
                        Description = productCreateDto.Description,
                        SpecialTag = productCreateDto.SpecialTag,
                        Category = productCreateDto.Category,
                        Price = productCreateDto.Price,
                        Image = $"https://placehold.co/250"
                    };
                    await dbContext.Products.AddAsync(item);
                    await dbContext.SaveChangesAsync();

                    var response = new ResponseServer
                    {
                        StatusCode = HttpStatusCode.Created,
                        Result = item
                    };

                    return CreatedAtRoute(nameof(GetProductById), new { id = item.Id }, response);
                }
            }
            else
            {
                return BadRequest(new ResponseServer
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = ["Модель данных не подходит"]
                });
            }
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