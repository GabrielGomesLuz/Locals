using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locals.Models
{
    public class ReservaDetalhe
    {

        public int ReservaDetalheId { get; set; }

        
        [Column(TypeName ="decimal(18,2)")]
        public decimal Preco { get; set; }

        public Imovel Imovel { get; set; }

        public int ImovelId { get; set; }

        public ReservaInteresse Reserva { get; set; }

        public int ReservaInteresseId { get; set; }




    }
}
