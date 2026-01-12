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

    [HttpGet]
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

    }
}