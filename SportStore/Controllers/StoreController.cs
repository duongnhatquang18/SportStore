using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using SportStore.Models.Paging;

namespace SportStore.Controllers
{
    public class StoreController : Controller
    {
        private IRepository _productRepo;
        private ICategoryRepository _categoryRepo;

        public StoreController(IRepository repository, ICategoryRepository categoryRepository)
        {
            _productRepo = repository;
            _categoryRepo = categoryRepository;
        }

        public IActionResult Index([FromQuery(Name ="options")] QueryOptions productOptions, QueryOptions catOptions, long category)
        {
            ViewBag.Categories = _categoryRepo.GetCategories(catOptions);
            ViewBag.SelectedCategory = category;
            return View(_productRepo.GetProduct(productOptions, category));
        }
    }
}