// Controllers/CakesController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SabcakeBackend.Data;
using SabcakeBackend.Models;
using System.Linq;

namespace SabcakeBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CakesController : ControllerBase
    {
        private readonly SabcakeDbContext _context;

        public CakesController(SabcakeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetCakes()
        {
            var cakes = await _context.Cakes
                .Include(c => c.CakeTypes)
                .Include(c => c.CakeFillings)
                .ToListAsync();

            var response = new
            {
                cakes = cakes.Select(c => new
                {
                    c.Id,
                    c.ImageUrl,
                    c.Name,
                    types = c.CakeTypes.Select(ct => ct.TypeId).ToList(),
                    fillings = c.CakeFillings.Select(cf => cf.FillingId).ToList(),
                    c.Price,
                    c.Category,
                    c.Rating
                }).ToList()
            };

            return Ok(response);
        }
    }
}