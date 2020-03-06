using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using SportStore.Models.Paging;

namespace SportStore.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;
        private ICategoryRepository _categoryRepository;

        public HomeController(IRepository repository, ICategoryRepository categoryRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
        }

        //public IActionResult Index()
        //{
        //    ViewBag.Categories = _categoryRepository.Categories;
        //    return View(_repository.Products);
        //}

        public IActionResult Index(QueryOptions options)
        {
            ViewBag.Categories = _categoryRepository.Categories;
            ViewBag.searches = new string[] { "Name", "Category.Name" };
            ViewBag.sorts = new string[] { "Name", "Category.Name", "PurchasePrice", "RetailPrice" };
   
            return View(_repository.GetProduct(options));
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _repository.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditProduct(long key)
        {
            ViewBag.Categories = _categoryRepository.Categories;
            return View(_repository.GetProduct(key));
        }

        [HttpPost]
        public IActionResult EditProduct(Product p)
        {
            _repository.UpdateProduct(p);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult UpdateAll()
        {
            ViewBag.UpdateAll = true;
            ViewBag.Categories = _categoryRepository.Categories;
            return View("Index", _repository.Products);
        }

        [HttpPost]
        public IActionResult UpdateAll(Product[] products)
        {
            _repository.UpdateProducts(products);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            _repository.DeleteProduct(product);
            return RedirectToAction(nameof(Index));
        }
    }
}