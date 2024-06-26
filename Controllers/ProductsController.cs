using System.Runtime.CompilerServices;
using asp.net_mvc.Repositories.Interfaces;
using asp.net_mvc.ViewModel.Products;
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

        public IActionResult Index(string category = null)
        {
            var viewModel = new IndexViewModel();
            viewModel.Products = _repository.GetAll().Result;

            if (category is not null)
            {
                viewModel.Products = viewModel.Products
                        .Where(product => 
                                product.Category.Name.Equals(category, StringComparison.OrdinalIgnoreCase));
            }
            viewModel.TotalProducts = viewModel.Products.Count();

            _logger.LogInformation($"Products find: {viewModel.TotalProducts}");
            return View(viewModel);
        }

        public IActionResult Details(int id){
            var product = _repository.GetById(id).Result;
            return View(product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogWarning("Erro ProductController");
            return View("Error!");
        }
    }
}