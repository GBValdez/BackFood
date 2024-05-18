using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project.utils;

namespace project.modules.foods
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private ApplicationDBContext _context;
        public FoodController(ApplicationDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Food>>> GetFoods()
        {
            return await _context.Foods.ToListAsync();
        }

        [HttpGet("search/{searchTerm}")]
        public async Task<ActionResult<IEnumerable<Food>>> SearchFoods(string searchTerm)
        {
            return await _context.Foods
                .Where(f => EF.Functions.Like(f.name, $"%{searchTerm}%"))
                .ToListAsync();
        }

        [HttpGet("tags")]
        public async Task<ActionResult<IEnumerable<object>>> GetTags()
        {
            var tags = await _context.Foods
                .SelectMany(f => f.tags)
                .GroupBy(t => t)
                .Select(g => new { Name = g.Key, Count = g.Count() })
                .OrderByDescending(t => t.Count)
                .ToListAsync();

            var all = new { Name = "All", Count = await _context.Foods.CountAsync() };
            tags.Insert(0, all);

            return Ok(tags);
        }

        [HttpGet("tag/{tagName}")]
        public async Task<ActionResult<IEnumerable<Food>>> GetFoodsByTag(string tagName)
        {
            return await _context.Foods
                .Where(f => f.tags.Contains(tagName))
                .ToListAsync();
        }

        [HttpGet("{foodId}")]
        public async Task<ActionResult<Food>> GetFood(Guid foodId)
        {
            var food = await _context.Foods.FindAsync(foodId);

            if (food == null)
                return NotFound();

            return food;
        }
    }
}