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
    }
}