using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models;

namespace SportStore.Controllers
{
    public class HomeController : Controller
    {
        IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.Products);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _repository.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditProduct(long key)
        {
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