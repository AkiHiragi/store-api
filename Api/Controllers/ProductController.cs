using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store_api.Data;
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

    [HttpGet]
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
}