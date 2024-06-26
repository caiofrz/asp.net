using asp.net_mvc.Models;
using asp.net_mvc.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace asp.net_mvc.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderRepository _repository;
        private readonly ShopCart _shopCart;

        public OrderController(ILogger<OrderController> logger, IOrderRepository repository, ShopCart shopCart)
        {
            _logger = logger;
            _repository = repository;
            _shopCart = shopCart;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {

            List<ShoppingItem> items = _shopCart.GetItems();

            if (_shopCart.Items.Count == 0)
            {
                ModelState.AddModelError("error", "Seu carrinho está vazio...");
                return View();
            }

            foreach (var item in items)
            {
                order.TotalItems += item.Quantity;
                order.Total += item.Product.Price * item.Quantity;
            }

            if (!ModelState.IsValid)
            {
                return View(order);
            }

            _repository.MakeOrder(order);

            ViewBag.CheckoutCompletoMensagem = "Obrigado pelo seu pedido :)";
            ViewBag.Total = _shopCart.GetTotalValue();

            _shopCart.Clear();
            _logger.LogWarning(_shopCart.Items.Count.ToString());
            return View("~/Views/Order/CompletedCheckout.cshtml", order);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}