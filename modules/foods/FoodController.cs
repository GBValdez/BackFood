using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nuevo.modules.foods;
using project.utils;

namespace project.modules.foods
{
    [Route("api/foods")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        public FoodController(ApplicationDBContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Food>>> GetFoods()
        {
            return await context.Foods.ToListAsync();
        }

        [HttpGet("search/{searchTerm}")]
        public async Task<ActionResult<IEnumerable<Food>>> SearchFoods(string searchTerm)
        {
            return await context.Foods
                .Where(f => EF.Functions.Like(f.name, $"%{searchTerm}%"))
                .ToListAsync();
        }

        [HttpGet("tags")]
        public async Task<ActionResult<IEnumerable<object>>> GetTags()
        {
            var foods = await context.Foods.ToListAsync();

            var tags = foods
                .SelectMany(f => f.tags)
                .GroupBy(t => t)
                .Select(g => new { Name = g.Key, Count = g.Count() })
                .OrderByDescending(t => t.Count)
                .ToList();

            var all = new { Name = "All", Count = foods.Count };
            tags.Insert(0, all);

            return Ok(tags);
        }

        [HttpGet("tag/{tagName}")]
        public async Task<ActionResult<IEnumerable<Food>>> GetFoodsByTag(string tagName)
        {
            return await context.Foods
                .Where(f => f.tags.Contains(tagName))
                .ToListAsync();
        }

        [HttpGet("{foodId}")]
        public async Task<ActionResult<Food>> GetFood(int foodId)
        {
            var food = await context.Foods.FindAsync(foodId);

            if (food == null)
                return NotFound();

            return food;
        }
    }
}