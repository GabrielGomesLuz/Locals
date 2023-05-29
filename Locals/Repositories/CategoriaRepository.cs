using Locals.Models;
using Locals.Repositories.Interfaces;
using Locals.Context;

namespace Locals.Repositories
{
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
