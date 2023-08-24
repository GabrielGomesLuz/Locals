using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace Locals.Models
{
    public class ReservaInteresse
    {
        [Key]
        
        public int ReservaInteresseId { get; set; }

        

        [StringLength(50)]
        [Display(Name ="Nome do titular")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Necessário informar o titular")]
        public string TitularReserva { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Necessário informar o endereço do titular")]
        [StringLength(60)]
        [Display(Name ="Endereço")]
        public string EndereçoTitular { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Necessário informar o telefone do titular" )]
        [StringLength(11)]
        [Display(Name ="Celular/Telefone")]
        public string TelefoneTitular { get; set; }


        [Display(Name ="Data do interesse no imóvel")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}")]
        public DateTime HoraReserva { get; set; }


        [Display(Name ="Imoveis")]

        public int TotalItensPedido { get; set; }


        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "E-mail em formato inválido.")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Necessário informar o email do titular")]

        public string Email { get; set; }

        public List<ReservaDetalhe> ReservaItens { get; set; }


    }
}
