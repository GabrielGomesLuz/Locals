using Locals.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Locals.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminImagensController : Controller
    {


        private readonly ConfigurationImagensImoveis _myconfig;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AdminImagensController(IWebHostEnvironment hostEnvironment,
            IOptions<ConfigurationImagensImoveis> myConfiguration)
        {
            _hostingEnvironment = hostEnvironment;
            _myconfig = myConfiguration.Value;
        }



        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                ViewData["Erro"] = "Erro: Arquivo(s) não selecionado(s)";
                return View(ViewData);
            }

            if (files.Count > 10)
            {
                ViewData["Erro"] = "Erro: Quantidade de arquivos excedeu o limite";
                return View(ViewData);
            }

            long size = files.Sum(f => f.Length);

            var filePathsName = new List<string>();

            var filePath = Path.Combine(_hostingEnvironment.WebRootPath,_myconfig.NomePastaImagensProdutos);


            foreach (var formFile in files)
            {
                if (formFile.FileName.Contains(".jpg") || formFile.FileName.Contains(".gif") || formFile.FileName.Contains(".png"))
                {

                    var fileNameWithPath = string.Concat(filePath, "\\", formFile.FileName);

                    filePathsName.Add(fileNameWithPath);

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }

                }
            }

            ViewData["Resultado"] = $"{files.Count} arquivos foram enviados ao servidor, " + $"com tamanho total de : {size} bytes";

            ViewBag.Arquivos = filePathsName;
            return View(ViewData);
        }
    }
}
