using Locals.Context;
using Locals.Models;
using Locals.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Locals.Repositories
{
    public class ImovelRepository : I_ImovelRepository
    {

        //declarando um objeto de dbcontext para ter acesso aos dados do banco
        
        private readonly AppDbContext _context;


        //utilizando injeção de dependencia por meio de construtor 
        public ImovelRepository(AppDbContext context)
        {
            _context = context;
        }

        //Essa lista me retornará todos os imoveis incluindo suas categorias
        public IEnumerable<Imovel> Imoveis => _context.Imoveis.Include(p=> p.Categoria);

        //Essa lista me retornará os imoveis cujo valor de destaque for true
        //e as categorias dos imoveis em destaque
        public IEnumerable<Imovel> ImovelDestaques => _context.Imoveis.
            Where(p=> p.IsImovelDestaque).Include(p=> p.Categoria);


        //metodo para buscar um imovel por um id em especifico
        public Imovel GetImovelById(int id)
        {
            return _context.Imoveis.FirstOrDefault(p => p.ImovelId == id);
        }
    }
}
