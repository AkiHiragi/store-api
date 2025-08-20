using Microsoft.AspNetCore.Mvc;
using store_api.Data;

namespace store_api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoreController(AppDbContext dbContext) : ControllerBase
    {
        protected AppDbContext dbContext = dbContext;
    }
}