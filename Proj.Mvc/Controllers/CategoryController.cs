using Proj.Mvc.Models;
using Proj.Mvc.Repository.IRepository;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj.Mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        [Route("Category")]//anasayfası   Crud ların sıralandığı bir menu birde arama menu
        public IActionResult Index()
        {
            return View();
        }
        [Route("Category-List")]
        [Route("Category-List/{slug}")]
        public async Task<IActionResult> Categorylist(string slug="")
        {
            ////hız açısından memory de tutulabilir sayfa arası geçişlerde ve ilk açılış haricinde hız katıcaktır
            List<Category> categories = new List<Category>();
            List<Product> products = new List<Product>();
            ViewBag.Url = this.HttpContext.Request.GetEncodedUrl();
            var productlist = await _productRepository.GetAllAsync(ApiStatics.Statics.GetProducts);
            productlist = productlist.Where(a => a.Category == null || a.Category.CategoryName == null).ToList();
            var categorylist = await _categoryRepository.GetAllAsync(ApiStatics.Statics.GetCategories);
            if (!string.IsNullOrEmpty(slug) && slug == "True")//sıfırlarıda göster
            {
                categorylist = categorylist.OrderBy(a => a.CategoryName).ToList();
                ViewBag.productlist = productlist;
                return View(categorylist);
            }

            foreach (var item in categorylist)
            {
                var PQuanity = item.Products.Select(a => new { a.Id, a.Title, a.Quantity, a.Description }).FirstOrDefault();
                if (PQuanity != null)
                {
                    if (0 < PQuanity.Quantity)
                    {
                        categories.Add(item);;
                    }
                }
            }
            categorylist = categories.OrderBy(a => a.CategoryName).ToList();
            ViewBag.productlist = productlist;
            return View(categorylist);
        }

        [Route("Category-Detail/{Id}")]
        public async Task<IActionResult> CategoryDetail(int Id)
        {
            var categorydetail = await _categoryRepository.GetAsync(ApiStatics.Statics.GetCategory, Id);
            return View(categorydetail);
        }

        [Route("Create-Category")]//fromun olduğu sayfa olucak işlem bittikten sonra id ile sorgulamaya gönderip ekrana basıcaz
        public async Task<IActionResult> CreateCategory()
        {
            var categorylist = await _categoryRepository.GetAllAsync(ApiStatics.Statics.GetCategories);
            ViewBag.Categorylist = categorylist;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(Category category)
        {
            if (_categoryRepository.CreateAsync(ApiStatics.Statics.CreateCategory, category).Result)
            {
                return PartialView("_SuccessCategory");
            }
            return PartialView("_FailUpdateCategory", category);
        }

        [Route("Update-Category/{Id}")]//detayı gösterilecek buradan update edicek
        public async Task<IActionResult> UpdateCategory(int Id)
        {
            var categorydetail = await _categoryRepository.GetAsync(ApiStatics.Statics.GetCategory, Id);
            var categorylist = await _categoryRepository.GetAllAsync(ApiStatics.Statics.GetCategories);
            ViewBag.Categorylist = categorylist;
            return View(categorydetail);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategorydetail(Category category)
        {
            if (_categoryRepository.UpdateAsync(ApiStatics.Statics.UpdateCategory, category).Result)
            {
                return PartialView("_SuccessCategory");
            }
            return PartialView("_FailUpdateCategory", category);
        }
        [Route("Delete-Category/{Id}")]//listeleme sayfasından gelen id ye göre silme işlemi
        public async Task<IActionResult> DeleteCategory(int Id)
        {
            //var categorydetail = await _categoryRepository.GetAsync(ApiStatics.Statics.GetCategory, Id);
            Category category = new Category()
            {
                Id = Id
            };
            if (_categoryRepository.DeleteAsync(ApiStatics.Statics.DeleteCategory, category).Result)
            {
                return PartialView("_SuccessCategory");
            }
            return PartialView("_FailDeleteCategory", category);
        }
    }
}
