using Locals.Context;
using Locals.Models;
using Microsoft.EntityFrameworkCore;

namespace Locals.Areas.Admin.Services
{
    public class RelatoriosVendasService
    {


        private readonly AppDbContext _appDbContext;

        public RelatoriosVendasService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<ReservaInteresse>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in _appDbContext.ReservaInteresse select obj;

            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.HoraReserva >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.HoraReserva <= maxDate.Value);
            }

            return await resultado.Include(x => x.ReservaItens).ThenInclude(x => x.Imovel)
                .OrderByDescending(x => x.HoraReserva).ToListAsync();
        }
    }
}
