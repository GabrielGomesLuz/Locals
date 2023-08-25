using Microsoft.AspNetCore.Mvc;

namespace Locals.Controllers
{
    public class SobreNosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
