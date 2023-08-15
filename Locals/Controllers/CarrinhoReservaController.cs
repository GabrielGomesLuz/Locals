using Locals.Models;
using Locals.Repositories.Interfaces;
using Locals.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Locals.Controllers
{
    public class CarrinhoReservaController : Controller
    {


        private readonly I_ImovelRepository _repository;

        private readonly CarrinhoReserva  _carrinhoReserva;

        public CarrinhoReservaController(I_ImovelRepository repository, CarrinhoReserva carrinhoReserva)
        {
            _repository = repository;
            _carrinhoReserva = carrinhoReserva;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoReserva.GetCarrinhoReservaImoveis();
            _carrinhoReserva.CarrinhoReservaImoveis = itens;

            var carrinhoReservaVM = new CarrinhoReservaViewModel
            {
                CarrinhoReserva = _carrinhoReserva,
                CarrinhoReservaTotal = _carrinhoReserva.GetCarrinhoTotal()
            };
            return View(carrinhoReservaVM);
        }

        [Authorize]
        public IActionResult AdicionarItemNoCarrinhoReserva(int imovelId)
        {
            var imovelSelecionado = _repository.Imoveis.FirstOrDefault(p => p.ImovelId == imovelId);
            if(imovelSelecionado != null)
            {
                _carrinhoReserva.AdicionarAoCarrinho(imovelSelecionado);
                
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult RemoverImovelDoCarrinho(int imovelId)
        {
            var imovelSelecionado = _repository.Imoveis.FirstOrDefault(p => p.ImovelId == imovelId);
            if (imovelSelecionado != null)
            {
                _carrinhoReserva.RemoverDoCarrinho(imovelSelecionado);

            }
            return RedirectToAction("Index");
        }
    }
}
