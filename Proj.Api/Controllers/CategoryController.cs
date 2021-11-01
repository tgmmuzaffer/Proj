using Proj.Api.Entity;
using Proj.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Proj.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _categoryService;
        public CategoryController(ICategoryRepo categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("getcategories")]
        public IActionResult GetCategories()
        {
            var result = _categoryService.GetList();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("getcategory/{Id}")]
        public IActionResult GetCategory(int Id)
        {
            Category category = new Category();
            List<Product> products = new List<Product>();
            var result = _categoryService.Get(a => a.Id == Id);

            var PQuanity = result.Products.Select(a => new { a.Id, a.Title, a.Quantity, a.Description, a.Category }).Where(b => b.Category.Id == result.Id).FirstOrDefault();

            if (result.MinStockquantity < PQuanity.Quantity)
            {
                Product product = new Product
                {
                    Id = PQuanity.Id,
                    Title = PQuanity.Title,
                    Description = PQuanity.Description,
                    Quantity = PQuanity.Quantity
                };
                products.Add(product);
                category.Id = result.Id;
                category.CategoryName = result.CategoryName;
                category.MinStockquantity = result.MinStockquantity;
                category.Products = products;
            }

            result = category;
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }


        [HttpPost("createcategory")]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var isExist = _categoryService.Get(a => a.CategoryName == category.CategoryName);
            if (isExist != null)
            {
                ModelState.AddModelError("", "Category already exist");
                return StatusCode(404, ModelState);
            }
            if (!_categoryService.Create(category))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {category.CategoryName}");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }

        [HttpPost("updatecategory")]
        public IActionResult UpdateCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var isExist = _categoryService.Get(a => a.Id == category.Id);
            if (isExist == null)
            {
                ModelState.AddModelError("", "Category not exist");
                return StatusCode(404, ModelState);
            }
            if (!_categoryService.Update(category))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {category.CategoryName}");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }

        [HttpDelete("deletecategory")]
        public IActionResult DeleteCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var isExist = _categoryService.Get(a => a.Id == category.Id);
            if (isExist == null)
            {
                ModelState.AddModelError("", "Category not exist");
                return StatusCode(404, ModelState);
            }
            if (!_categoryService.Delete(category))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {category.CategoryName}");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }
    }
}
