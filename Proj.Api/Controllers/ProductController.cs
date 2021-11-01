using Proj.Api.Entity;
using Proj.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Proj.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _productservice;
        public ProductController(IProductRepo productservice)
        {
            _productservice = productservice;
        }
       
    
        [HttpGet("getproducts")]
        public IActionResult GetProducts()
        {
            var result = _productservice.GetList().Where(a=>a.Id>0);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
   
        [HttpGet("getproductswithrange/{start}/{finish}")]
        public IActionResult GetProductsWithRange(int start, int finish)
        {

            var result = _productservice.GetList().Where(a => a.Quantity >= start && a.Quantity <= finish);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
        [HttpGet("getproduct/{Id}")]
        public IActionResult GetProduct(int Id)
        {

            var product = _productservice.Get(a => a.Id == Id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        [HttpPost("createproduct")]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var isExist = _productservice.Get(a => a.Id == product.Id);
            if (isExist != null)
            {
                ModelState.AddModelError("", "Category already exist");
                return StatusCode(404, ModelState);
            }
            if (!_productservice.Create(product))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {product.Title}");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }

        [HttpPost("updateproduct")]
        public IActionResult UpdateProduct([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var isExist = _productservice.Get(a => a.Id == product.Id);
            if (isExist == null)
            {
                ModelState.AddModelError("", "Category not exist");
                return StatusCode(404, ModelState);
            }
            if (!_productservice.Update(product))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {product.Title}");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }

        [HttpDelete("deleteproduct")]
        public IActionResult DeleteProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var isExist = _productservice.Get(a => a.Id == product.Id);
            if (isExist == null)
            {
                ModelState.AddModelError("", "Category not exist");
                return StatusCode(404, ModelState);
            }
            if (!_productservice.Delete(product))
            {
                ModelState.AddModelError("", $"Something went wrong when saving the record {product.Title}");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }
    }
}
