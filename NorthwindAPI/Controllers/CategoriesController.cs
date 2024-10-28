using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.Data;
using NorthwindAPI.Domain;
using System.Diagnostics.Eventing.Reader;

namespace NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public CategoriesController(NorthwindContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        { 
           var categories = _context.Categories;

            if (categories == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(categories);
            }

        }

        [HttpGet("{id}")]
        public Category GetById(int id) {
            return _context.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        [HttpGet("count")]
        public int Count() => _context.Categories.Count();


        [HttpGet("{id}/products")]
        public IEnumerable<Product> GetProductsByCategoryId(int id)
        {
            return _context.Products.Where(p => p.CategoryId == id);
        }

    }
}
