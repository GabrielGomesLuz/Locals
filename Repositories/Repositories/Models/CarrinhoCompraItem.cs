using Locals.Models;
using System.ComponentModel.DataAnnotations;

namespace Locals.Repositories.Models
{
    public class CarrinhoReservaImovel
    {
        public int CarrinhoReservaImovelId { get; set; }
        public Imovel Imovel { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }


        [StringLength(200)]
        public string CarrinhoReservaId { get; set; }

        public DateTime HoraReservado { get; set; }
    }








}
