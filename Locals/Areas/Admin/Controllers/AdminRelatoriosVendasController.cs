using Locals.Areas.Admin.Services;
using Microsoft.AspNetCore.Mvc;

namespace Locals.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AdminRelatoriosVendasController : Controller
    {

        private readonly RelatoriosVendasService _relatorios;

        public AdminRelatoriosVendasController(RelatoriosVendasService relatorios)
        {
            _relatorios = relatorios;
        }



        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RelatorioVendasSimples(DateTime? minDate,DateTime? maxDate)
        {

            if (!minDate.HasValue){
                minDate = new DateTime(DateTime.Now.Year,1,1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = (DateTime.Now);
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");

            var result = await _relatorios.FindByDateAsync(minDate,maxDate);
            return View(result);

        }


        

    }
}
