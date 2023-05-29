using Locals.Models;

namespace Locals.Repositories.Interfaces

{
    public interface ICategoriaRepository
    {
        //Esse atributo IEnumerable irá ter que ser implementado pela classe concreta,
        //pois a mesma deve me retornar uma lista das categorias de imoveis
        IEnumerable<Categoria> Categorias { get; }
    }
}
