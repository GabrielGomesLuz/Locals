using Microsoft.AspNetCore.Mvc;
using Locals.Repositories;
using Locals.Repositories.Interfaces;
using Locals.ViewModels;
using Locals.Models;

namespace Locals.Controllers
{
    public class ImoveisController : Controller
    {

        private readonly I_ImovelRepository _imovelRepository;

        public ImoveisController(I_ImovelRepository imovelRepository)
        {
            _imovelRepository = imovelRepository;
        }

        public IActionResult List(string categoria)
        {

            IEnumerable<Imovel> imoveis;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                imoveis = _imovelRepository.Imoveis.OrderBy(p => p.ImovelId);
                categoriaAtual = "Todos os imóveis";

            }
            else
            {
                imoveis = _imovelRepository.Imoveis.Where(p => p.Categoria.CategoriaNome.Equals(categoria)).OrderBy(p => p.NomeImovel);
                
                categoriaAtual = categoria;
            }

            var imoveisListViewModel = new ImovelListViewModel
            {
                Imoveis = imoveis,
                CategoriaAtual = categoriaAtual,
                
            };


            return View(imoveisListViewModel);
        }


        public IActionResult Details (int imovelId)
        {
            var imovel = _imovelRepository.Imoveis.FirstOrDefault(p=> p.ImovelId == imovelId);
            return View(imovel);

        }

        
    }
}
