using asp.net_mvc.Data;
using asp.net_mvc.Models;
using asp.net_mvc.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace asp.net_mvc.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            try
            {
                return await _context.Products
                                .Include(p => p.Category)
                                .OrderBy(o => o.Id)
                                .ToArrayAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Product>> GetAllAvailable()
        {
            try
            {
                return await _context.Products
                                .Where(p => p.IsAvailable)
                                .Include(p => p.Category)
                                .OrderBy(p => p.CategoryId)
                                .ToArrayAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product> GetById(int id)
        {
            try
            {
                return await _context.Products
                                .FirstAsync(p => p.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product> GetByName(string name)
        {
            try
            {
                return await _context.Products
                                .FirstAsync(p => p.Name == name);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}