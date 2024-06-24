using asp.net_mvc.Data;
using asp.net_mvc.Models;
using asp.net_mvc.Repositories.Interfaces;

namespace asp.net_mvc.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll() => _context.Categories;

    }
}
