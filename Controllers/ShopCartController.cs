using asp.net_mvc.Models;
using asp.net_mvc.Repositories.Interfaces;
using asp.net_mvc.ViewModel.ShopCart;
using Microsoft.AspNetCore.Mvc;

namespace asp.net_mvc.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly ILogger<ShopCartController> _logger;
        private readonly IProductRepository _repository;
        private readonly ShopCart _shopCart;

        public ShopCartController
            (
            ILogger<ShopCartController> logger,
            IProductRepository repository,
            ShopCart shopCart
            )
        {
            _logger = logger;
            _repository = repository;
            _shopCart = shopCart;
        }

        public IActionResult Index()
        {
            var items = _shopCart.GetItems();
            _shopCart.Items = items;

            var viewModel = new IndexViewModel
            {
                Title = "Carrinho de compras",
                ShopCart = _shopCart,
                TotalValue = _shopCart.GetTotalValue(),
            };

            return View(viewModel);
        }

        public IActionResult AddItem(int productId)
        {
            var product = _repository.GetById(productId).Result;

            if (product is null) RedirectToAction("Error");

            _shopCart.Add(product);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveItem(int productId)
        {
            var product = _repository.GetById(productId).Result;

            if (product is null) RedirectToAction("Error");

            _shopCart.Remove(product);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}