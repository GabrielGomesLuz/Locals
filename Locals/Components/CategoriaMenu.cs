using Locals.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Locals.Components
{
    public class CategoriaMenu : ViewComponent
    {

        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaMenu(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IViewComponentResult Invoke()
        {

            var categoria = _categoriaRepository.Categorias.OrderBy(p => p.CategoriaNome);
            
            return View(categoria);



        }
    }
}
