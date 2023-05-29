using Microsoft.EntityFrameworkCore;
using Locals.Models;

namespace Locals.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        //Criando as propriedades que vão para o DB e terão os seguintes nomes.
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Imovel> Imoveis { get; set; }

    }
}
