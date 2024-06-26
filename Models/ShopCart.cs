using asp.net_mvc.Data;
using Microsoft.EntityFrameworkCore;

namespace asp.net_mvc.Models
{
    public class ShopCart
    {
        public string Id { get; set; }
        public List<ShoppingItem> Items { get; set; }
        private readonly ApplicationDbContext _context;
        private static ISession? _session;
        public ShopCart(ApplicationDbContext context)
        {
            _context = context;
        }

        public static ShopCart GetShopCart(IServiceProvider services)
        {
            _session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            var context = services.GetService<ApplicationDbContext>();

            string shopCartId = _session?.GetString("shopCartId") ?? Guid.NewGuid().ToString();
            _session?.SetString("shopCartId", shopCartId);

            return new ShopCart(context)
            {
                Id = shopCartId
            };
        }
        public void Add(Product product)
        {
            var shoppingItem = _context.ShoppingItems.SingleOrDefault(
                     s => s.Product.Id == product.Id &&
                     s.ShopCartId.Equals(Id));

            if (shoppingItem is null)
            {
                shoppingItem = new ShoppingItem
                {
                    ShopCartId = Id,
                    Product = product,
                    Quantity = 1
                };
                _context.ShoppingItems.Add(shoppingItem);
            }
            else
            {
                shoppingItem.Quantity++;
            }
            _context.SaveChanges();
        }

        public int Remove(Product product)
        {
            var shoppingItem = _context.ShoppingItems
                                        .SingleOrDefault(
                                                s => s.Product.Id == product.Id &&
                                                s.ShopCartId.Equals(Id)
                                                );

            var quantityLocal = 0;

            if (shoppingItem is not null)
            {
                if (shoppingItem.Quantity > 1)
                {
                    shoppingItem.Quantity--;
                    quantityLocal = shoppingItem.Quantity;
                }
                else
                {
                    _context.ShoppingItems.Remove(shoppingItem);
                }
            }
            _context.SaveChanges();
            return quantityLocal;
        }

        public List<ShoppingItem> GetItems()
        {
            return Items ??
                   (Items =
                       _context.ShoppingItems.Where(c => c.ShopCartId == Id)
                           .Include(s => s.Product)
                           .ToList());
        }

        public void Clear()
        {
            var items = _context.ShoppingItems
                                 .Where(sc => sc.Id.Equals(Id));

            _context.ShoppingItems.RemoveRange(items);
            Items.Clear();
            _session.Clear();
            _context.SaveChanges();
        }

        public double GetTotalValue()
        {
            var total = _context.ShoppingItems.Where(sc => sc.ShopCartId == Id)
                .Select(sc => (double)sc.Product.Price * sc.Quantity).Sum();
            return total;
        }
    }
}