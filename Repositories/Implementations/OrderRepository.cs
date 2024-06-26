using asp.net_mvc.Data;
using asp.net_mvc.Models;
using asp.net_mvc.Repositories.Interfaces;

namespace asp.net_mvc.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ShopCart _shopCart;

        public OrderRepository(ApplicationDbContext context, ShopCart shopCart)
        {
            _context = context;
            _shopCart = shopCart;
        }

        public void MakeOrder(Order order)
        {
            order.CreatedAt = DateTime.Now;
            _context.Orders.Add(order);
            _context.SaveChanges();

            var items = _shopCart.Items;

            foreach (var item in items)
            {
                var orderDetail = new OrderDetails()
                {
                    Quantity = item.Quantity,
                    ProductId = item.Product.Id,
                    OrderId = order.Id,
                    Price = item.Product.Price
                };
                _context.OrderDetails.Add(orderDetail);
            }
            _context.SaveChanges();
        }
    }
}