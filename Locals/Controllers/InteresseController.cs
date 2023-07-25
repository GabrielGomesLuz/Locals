using Microsoft.AspNetCore.Mvc;
using Locals.Repositories.Interfaces;
using Locals.Models;

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


        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(ReservaInteresse reserva)
        {
            return View();
        }
    }
}
