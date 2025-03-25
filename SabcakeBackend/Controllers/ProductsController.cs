using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SabcakeBackend.Data; 
using SabcakeBackend.Models;

namespace SabcakeBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly SabcakeDbContext _context;
        public ProductsController(SabcakeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }
    }
}
