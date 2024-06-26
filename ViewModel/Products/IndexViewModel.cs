using asp.net_mvc.Models;

namespace asp.net_mvc.ViewModel.Products
{
    public class IndexViewModel
    {
        public string Title { get; } = "Catálogo";
        public IEnumerable<Product> Products { get; set;}
        public int TotalProducts { get; set; }
        public string Categoria { get; set;} = "Categoria 1";
        
    }
}