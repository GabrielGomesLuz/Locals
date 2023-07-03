using Microsoft.AspNetCore.Mvc;

namespace Locals.Controllers
{
    public class testeController : Controller
    {
        public string Index()
        {
            return $"Testando metodo index {DateTime.Now}";
        }
    }
}
