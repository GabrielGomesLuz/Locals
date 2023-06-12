using Locals.Models;
using Locals.Repositories.Interfaces;
using Locals.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Locals.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly I_ImovelRepository _movelRepository;

        public HomeController(I_ImovelRepository movelRepository)
        {
            _movelRepository = movelRepository;
        }

        public IActionResult Index()
        {

            var homeViewModel = new HomeViewModel
            {
                ImoveisDestaques = _movelRepository.ImovelDestaques
            };
            return View(homeViewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}