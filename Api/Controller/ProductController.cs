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

    [HttpPut]
    public async Task<ActionResult<ResponseServer>> UpdateProduct(
        int id, [FromBody] ProductUpdateDto productUpdateDto
    )
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (productUpdateDto == null
                    || productUpdateDto.Id != id)
                {
                    return BadRequest(new ResponseServer
                    {
                        IsSuccess = false,
                        StatusCode = HttpStatusCode.BadRequest,
                        ErrorMessages = ["Несоответствие модели данных"]
                    });
                }
                else
                {
                    var productFromDb = await dbContext
                        .Products
                        .FindAsync(id);

                    if (productFromDb == null)
                    {
                        return NotFound(new ResponseServer
                        {
                            IsSuccess = false,
                            StatusCode = HttpStatusCode.NotFound,
                            ErrorMessages = ["Продукт с таким id не найден"]
                        });
                    }

                    productFromDb.Name = productUpdateDto.Name;
                    productFromDb.Description = productUpdateDto.Description;
                    productFromDb.SpecialTag = productUpdateDto.SpecialTag;
                    productFromDb.Category = productUpdateDto.Category;
                    productFromDb.Price = productUpdateDto.Price;

                    if (productUpdateDto.Image != null
                        && productUpdateDto.Image.Length > 0)
                    {
                        productFromDb.Image = $"https://placehold.co/300";
                    }

                    dbContext.Products.Update(productFromDb);
                    await dbContext.SaveChangesAsync();

                    return Ok(new ResponseServer
                    {
                        StatusCode = HttpStatusCode.OK,
                        Result = productFromDb
                    });
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
                ErrorMessages = ["Что-то пошло не так", ex.Message]
            });
        }
    }

    [HttpDelete]
    public async Task<ActionResult<ResponseServer>> RemoveProductById(int id)
    {
        try
        {
            if (id <= 0)
            {
                return BadRequest(new ResponseServer
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    ErrorMessages = ["Неверный id"]
                });
            }

            var productFromDb = await dbContext.Products.FindAsync(id);

            if (productFromDb == null)
            {
                return NotFound(new ResponseServer
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.NotFound,
                    ErrorMessages = ["Продукт по указанному id не найден"]
                });
            }

            dbContext.Products.Remove(productFromDb);
            await dbContext.SaveChangesAsync();

            return Ok(new ResponseServer
            {
                StatusCode = HttpStatusCode.NoContent,
            });
        }
        catch (Exception ex)
        {
            return BadRequest(new ResponseServer
            {
                IsSuccess = false,
                StatusCode = HttpStatusCode.BadRequest,
                ErrorMessages = ["Все плохо", ex.Message]
            });
        }
    }
}