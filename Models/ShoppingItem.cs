using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.net_mvc.Models
{
    [Table("shopping_items")]
    public class ShoppingItem
    {
        [Key]
        public int Id { get; set; }

        public Product Product{ get; set; }

        public int Quantity { get; set; }

        public string ShopCartId { get; set; }    
    }
}