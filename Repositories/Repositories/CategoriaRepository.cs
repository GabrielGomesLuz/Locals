using Locals.Context;
using Locals.Repositories.Models;

namespace Locals.Repositories
{

    public interface ICategoriaRepository
    {
        //Esse atributo IEnumerable irá ter que ser implementado pela classe concreta,
        //pois a mesma deve me retornar uma lista das categorias de imoveis
        IEnumerable<Categoria> Categorias { get; }
    }

    public class CategoriaRepository : ICategoriaRepository
    {
        //declarando um objeto de dbcontext para ter acesso aos dados do banco
        //utilizando injeção de dependencia por meio de construtor                
        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        //retornando a lista de categorias existente no banco, graças ao objeto context
        public IEnumerable<Categoria> Categorias => _context.Categorias;

       
    }
}
