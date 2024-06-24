using asp.net_mvc.Models;

namespace asp.net_mvc.Repositories.Interfaces
{
    public interface IProductRepository
    {
         Task<IEnumerable<Product>> GetAll();
         Task<IEnumerable<Product>> GetAllAvailable();
         Task<Product> GetById(int id);
         Task<Product> GetByName(string name);
    }
}