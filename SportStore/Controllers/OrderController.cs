using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models;

namespace SportStore.Controllers
{
    public class OrderController : Controller
    {
        private IRepository _repository;
        private ICategoryRepository _categoryRepository;
        private IOrderRepository _orderRepository;

        public OrderController(IRepository repository, ICategoryRepository categoryRepository, IOrderRepository orderRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            return View(_orderRepository.Orders);
        }

        public IActionResult CreateOrder()
        {
            Order order = new Order();
            List<OrderLine> orderLines = new List<OrderLine>();
            foreach (Product product in _repository.Products)
            {
                OrderLine orderLine = new OrderLine();
                orderLine.OrderId = order.Id;
                orderLine.ProductId = product.Id;
                orderLine.Quantity = 0;
                orderLine.Product = product;
                orderLines.Add(orderLine);
            }

            ViewBag.lines = orderLines;
            return View(order);
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            _orderRepository.AddOrder(order);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditOrder(long key)
        {
            return View(_orderRepository.GetOrder(key));
        }

        [HttpPost]
        public IActionResult EditOrder(Order order)
        {
            _orderRepository.UpdateOrder(order);
            return RedirectToAction(nameof(Index));
        }
    }
}