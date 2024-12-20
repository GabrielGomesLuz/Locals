using Locals.Context;
using Locals.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Locals.Repositories.Models
{
    public class CarrinhoReserva
    {

        private readonly AppDbContext _context;

        public CarrinhoReserva(AppDbContext context)
        {
            _context = context;
        }

        public string CarrinhoReservaId { get; set; }
        public List<CarrinhoReservaImovel> CarrinhoReservaImoveis { get; set; }


        public static CarrinhoReserva GetCarrinho(IServiceProvider services)
        {

            //se a instancia de HttpContext não for null, ira retornar uma session
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;


            //obter instancia de contexto
            var context = services.GetService<AppDbContext>();


            //obtem ou gera id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho a sessao
            session.SetString("CarrinhoId", carrinhoId);


            //retorno o carrinho id
            return new CarrinhoReserva(context)
            {
                CarrinhoReservaId = carrinhoId
            };
        }


        public void AdicionarAoCarrinho(Imovel imovel)
        {

            //Verificando se existe o imovel em carrinho
            var carrinhoReservaImovel = _context.CarrinhoReservaItens.SingleOrDefault(
                p => p.Imovel.ImovelId == imovel.ImovelId && p.CarrinhoReservaId == CarrinhoReservaId);

            if (carrinhoReservaImovel == null)
            {
                carrinhoReservaImovel = new CarrinhoReservaImovel
                {
                    CarrinhoReservaId = CarrinhoReservaId,
                    Imovel = imovel,
                    DataEntrada = DateTime.Today,
                    DataSaida = new DateTime().AddDays(1),
                    HoraReservado = DateTime.Now
                };
                _context.CarrinhoReservaItens.Add(carrinhoReservaImovel);
                _context.SaveChanges();
            }

        }

        public void RemoverDoCarrinho(Imovel imovel)
        {
            var carrinhoReservaImovel = _context.CarrinhoReservaItens.SingleOrDefault(
                p => p.Imovel.ImovelId == imovel.ImovelId && p.CarrinhoReservaId == CarrinhoReservaId);

            if (carrinhoReservaImovel != null)
            {
                _context.CarrinhoReservaItens.Remove(carrinhoReservaImovel);
            }

            _context.SaveChanges();
        }

        public List<CarrinhoReservaImovel> GetCarrinhoReservaImoveis()
        {
            return CarrinhoReservaImoveis ??
                (CarrinhoReservaImoveis = _context.CarrinhoReservaItens.Where(p => p.CarrinhoReservaId == CarrinhoReservaId).Include(p => p.Imovel).ToList());
        }

        public void LimparCarrinho()
        {
            var carrinhoItens = _context.CarrinhoReservaItens.Where(c => c.CarrinhoReservaId == CarrinhoReservaId);

            _context.CarrinhoReservaItens.RemoveRange(carrinhoItens);
            _context.SaveChanges();
        }

        public IQueryable GetCarrinhoTotal()
        {
            var total = _context.CarrinhoReservaItens.Where(p => p.CarrinhoReservaId == CarrinhoReservaId).Select(p => p.Imovel.Preco * p.DataSaida.Subtract(p.DataEntrada).Days);
            return total;
        }
    }

    public static class SessionExtensions
    {
        public static void SetString(this ISession session, string key, string value)
        {
            session.Set(key, System.Text.Encoding.UTF8.GetBytes(value));
        }

        public static string GetString(this ISession session, string key)
        {
            if (session.TryGetValue(key, out var value))
            {
                return System.Text.Encoding.UTF8.GetString(value);
            }

            return null;
        }
    }
}
