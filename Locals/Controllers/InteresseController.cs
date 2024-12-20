using Locals.Repositories;
using Locals.Repositories.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Locals.Controllers
{
    public class InteresseController : Controller
    {

        private readonly IReservaRepository reservaIRepository;
        private readonly CarrinhoReserva carrinhoReserva;

        public InteresseController(IReservaRepository reservaIRepository, CarrinhoReserva carrinhoReserva)
        {
            this.reservaIRepository = reservaIRepository;
            this.carrinhoReserva = carrinhoReserva;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Checkout(ReservaInteresse reserva)
        {
            int totalItens = 0; 
            decimal precoTotal = decimal.Zero;

            List<Repositories.Models.CarrinhoReservaImovel> itens = carrinhoReserva.GetCarrinhoReservaImoveis();
            carrinhoReserva.CarrinhoReservaImoveis = itens;

            //verificar se existe imoveis no carrinho
            if(carrinhoReserva.CarrinhoReservaImoveis.Count == 0) {
                ModelState.AddModelError("","Carrinho vazio!");
            }
            
            if(ModelState.IsValid)
            {
                reservaIRepository.CriarReserva(reserva);

                ViewBag.CheckoutCompletoMensagem = "Obrigado pelo interesse :)";

                carrinhoReserva.LimparCarrinho();

                return View("~/Views/Interesse/CheckoutCompleto.cshtml", reserva);

            }
            return View(reserva);
            

        }
    }
}
