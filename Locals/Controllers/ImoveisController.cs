using Microsoft.AspNetCore.Mvc;
using Locals.Repositories;
using Locals.Repositories.Interfaces;
using Locals.ViewModels;

namespace Locals.Controllers
{
    public class ImoveisController : Controller
    {

        private readonly I_ImovelRepository _imovelRepository;

        public ImoveisController(I_ImovelRepository imovelRepository)
        {
            _imovelRepository = imovelRepository;
        }

        public IActionResult List()
        {
            //var imoveis = _imovelRepository.Imoveis;
            //return View(imoveis);
            var imoveisListViewModel = new ImovelListViewModel();
            imoveisListViewModel.Imoveis = _imovelRepository.Imoveis;
            imoveisListViewModel.CategoriaAtual = "Categoria Atual";
            return View(imoveisListViewModel);
        }
    }
}
