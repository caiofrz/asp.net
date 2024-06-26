using asp.net_mvc.Models;
using asp.net_mvc.ViewModel.ShopCart;
using Microsoft.AspNetCore.Mvc;

namespace asp.net_mvc.Components
{
    public class ShopCartOverview : ViewComponent
    {
        private readonly ShopCart _shopCart;

        public ShopCartOverview(ShopCart shopCart)
        {
            _shopCart = shopCart;
        }

        public IViewComponentResult Invoke(){
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
    }
}