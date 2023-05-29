using Locals.Models;

namespace Locals.ViewModels
{
    public class ImovelListViewModel
    {
        public IEnumerable<Imovel> Imoveis { get; set; }

        public string CategoriaAtual { get; set; }
    }
}
