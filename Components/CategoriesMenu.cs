using asp.net_mvc.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp.net_mvc.Components
{
    public class CategoriesMenu : ViewComponent
    {

        private readonly ICategoryRepository _repository;

        public CategoriesMenu(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _repository.GetAll()
                                        .OrderBy(c => c.Name);
            return View(categories);
        }
    }
}