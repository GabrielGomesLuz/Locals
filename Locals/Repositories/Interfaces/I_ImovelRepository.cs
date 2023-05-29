using Locals.Context;
using Locals.Models;
namespace Locals.Repositories.Interfaces
{
    public interface I_ImovelRepository
    {
        //Esse atributo IEnumerable irá ter que ser implementado pela classe concreta,
        //pois a mesma deve me retornar uma lista de imoveis
        //lista de imoveis que estão em destaque
        //busca por um imovel por id em especifico



        IEnumerable<Imovel> Imoveis { get; }

        IEnumerable<Imovel> ImovelDestaques { get; }
        Imovel GetImovelById(int id);
    }
}
