using Proj.Mvc.Models;
using Proj.Mvc.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proj.Mvc.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public SearchController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        [Route("Search-Page")]
        public IActionResult Index()
        {
            return View();
        }

        //Burada isteği keyword şeklinde Api a atıp orada işlemleri gerçekleştirmek mümkün fakat bunun id bazlı yapılmasını daha güvenli olduğunu düşünerek bu yolu tercih ettim.
        [HttpPost("Search")]
        public async Task<IActionResult> Search(Search search)
        {
            var categorylist = await _categoryRepository.GetAllAsync(ApiStatics.Statics.GetCategories);
            var productlist = await _productRepository.GetAllAsync(ApiStatics.Statics.GetProducts);
            List<int> prodId = new List<int>();
            List<int> catId = new List<int>();
            List<Product> products = new List<Product>();
            List<Category> categories = new List<Category>();
            if (productlist != null)
            {
                foreach (var item in productlist)
                {
                    if (item.Title != null)
                    {
                        if (item.Title.Contains(search.SearchKeyword))
                        {
                            if (prodId != null || prodId.Count > 0)
                            {
                                if (!prodId.Contains(item.Id))
                                {
                                    prodId.Add(item.Id);
                                }
                            }
                            else if (prodId == null || prodId.Count <= 0)
                            {
                                prodId.Add(item.Id);
                            }
                        }
                    }
                    if (item.Description != null)
                    {
                        if (item.Description.Contains(search.SearchKeyword))
                        {
                            if (prodId != null || prodId.Count > 0)
                            {
                                if (!prodId.Contains(item.Id))
                                {
                                    prodId.Add(item.Id);
                                }
                            }
                            else if (prodId == null || prodId.Count <= 0)
                            {
                                prodId.Add(item.Id);
                            }
                        }
                    }
                    if (item.Category != null)
                    {
                        if (item.Category.CategoryName != null)
                        {
                            if (item.Category.CategoryName.Contains(search.SearchKeyword))
                            {
                                if (prodId != null || prodId.Count > 0)
                                {
                                    if (!prodId.Contains(item.Id))
                                    {
                                        prodId.Add(item.Id);
                                    }
                                }
                                else if (prodId == null || prodId.Count <= 0)
                                {
                                    prodId.Add(item.Id);
                                }
                            }
                        }
                    }
                }
                var d = prodId;
            }
            if (categorylist != null)
            {
                foreach (var item in categorylist)
                {
                    if (item.CategoryName != null)
                    {
                        if (item.CategoryName.Contains(search.SearchKeyword))
                        {
                            if (catId != null || catId.Count > 0)
                            {
                                if (!catId.Contains(item.Id))
                                {
                                    catId.Add(item.Id);
                                }
                            }
                            else if (catId == null || catId.Count <= 0)
                            {
                                catId.Add(item.Id);
                            }
                        }
                    }
                }
                var e = catId;
            }
            // productlist = productlist.ToList();
            foreach (var item in prodId)
            {
                var matchprod = productlist.Where(a => a.Id == item).FirstOrDefault();
                products.Add(matchprod);
            }
            foreach (var item in catId)
            {
                var matchcat = categorylist.Where(a => a.Id == item).FirstOrDefault();
                categories.Add(matchcat);
            }
            ViewBag.Products = products;
            ViewBag.Categories = categories;
            ViewBag.SearchKeyword = search.SearchKeyword;
            return View();
        }

        [HttpPost("Search-by-range")]
        public async Task<IActionResult> SearchByRange(int start, int finish)
        {
            int tmp = 0;
            if (start > finish)
            {
                tmp = finish;
                finish = start;
                start = tmp;
            }
            else if (start == finish)
            {
                finish++;
            }
            var productlist = await _productRepository.GetAllWithRangeAsync(ApiStatics.Statics.GetProductsWithRange, start, finish);
            productlist = productlist.Where(a => a.Category != null && a.Category.CategoryName != null).ToList();
            return View(productlist);
        }
    }
}
