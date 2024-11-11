using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.Data;
using NorthwindAPI.Domain;
using System.Diagnostics.Eventing.Reader;

namespace NorthwindAPI.Controllers
{
    [Authorize]
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

        [HttpPost]
        public IActionResult Create([FromBody] CreateCategoryRequest request) {
            var category = new Category { 
                CategoryId = request.CategoryId,
                CategoryName = request.CategoryName,
                Description = request.Description
            };

            _context.Categories.Add(category);
            _context.SaveChanges();
            return Created(string.Empty, null); //Return with a Created http message
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] UpdateCategoryRequest request, short id) {

            var category = _context.Categories.SingleOrDefault(c => c.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }

            category.CategoryName = request.CategoryName;
            category.Description = request.Description;
            _context.Update(category);
            _context.SaveChanges();

            return Ok();

        }

        [HttpDelete("id")]
        public IActionResult Delete(int id) {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryId == id);

            if (category == null) { return NotFound(); }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return NoContent();
        }


    }

   
}
