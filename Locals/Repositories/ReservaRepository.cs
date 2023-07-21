using Locals.Context;
using Locals.Models;
using Locals.Repositories.Interfaces;



namespace Locals.Repositories
{
    public class ReservaRepository : IReservaRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly CarrinhoReserva _carrinhoReserva;

        public ReservaRepository(AppDbContext appDbContext, CarrinhoReserva carrinhoReserva)
        {
            _appDbContext = appDbContext;
            _carrinhoReserva = carrinhoReserva;
        }

        public void CriarReserva(ReservaInteresse reserva)
        {

            reserva.HoraReserva = DateTime.Now;
            _appDbContext.ReservaInteresse.Add(reserva);
            _appDbContext.SaveChanges();

            var carrinhoReservaImoveis = _carrinhoReserva.CarrinhoReservaImoveis;

            foreach(var carrinhoImoveis in carrinhoReservaImoveis)
            {
                var reservaDetalhe = new ReservaDetalhe()
                {
                    Preco = carrinhoImoveis.Imovel.Preco,
                    ReservaInteresseId = reserva.ReservaInteresseId,
                    ImovelId = carrinhoImoveis.Imovel.ImovelId
                };
                _appDbContext.ReservaDetalhe.Add(reservaDetalhe);
            }
            _appDbContext.SaveChanges();






        }
    }
}
