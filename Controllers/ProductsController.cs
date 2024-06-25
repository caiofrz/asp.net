using asp.net_mvc.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp.net_mvc.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger, IProductRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var products = _repository.GetAll().Result;
            _logger.LogInformation($"Products find: {products.Count()}");
            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogWarning("Erro ProductController");
            return View("Error!");
        }
    }
}