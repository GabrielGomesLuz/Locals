using Locals.Models;
using Locals.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Locals.Components
{
    public class CarrinhoReservaResumo : ViewComponent
    {

        private readonly CarrinhoReserva _carrinhoReserva;

        public CarrinhoReservaResumo(CarrinhoReserva carrinhoReserva)
        {
            _carrinhoReserva = carrinhoReserva;
        }

        public IViewComponentResult Invoke()
        {

            var itens = _carrinhoReserva.GetCarrinhoReservaImoveis();

            //var itens = new List<CarrinhoReservaImovel>()
            //{
              //  new CarrinhoReservaImovel(),
                //new CarrinhoReservaImovel()
            //};
            _carrinhoReserva.CarrinhoReservaImoveis = itens;

            var carrinhoReservaVM = new CarrinhoReservaViewModel
            {
                CarrinhoReserva = _carrinhoReserva,
                CarrinhoReservaTotal = _carrinhoReserva.GetCarrinhoTotal()
            };
            return View(carrinhoReservaVM);
        }


    }
}
