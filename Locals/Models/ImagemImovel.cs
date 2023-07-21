using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locals.Models
{

    [Table("ImagensImovel")]
    public class ImagemImovel
    {

        
        [Key]
        public int ImagemImovelId { get; set; }

        [Required(ErrorMessage ="O caminho da imagem é obrigatório")]
        [StringLength(200,ErrorMessage = "O caminho da imagem deve ter no máximo {1} caracteres")]
        public string CaminhoImagem { get; set; }

        public int ImovelId { get; set; }
        public virtual Imovel Imovel { get; set; }
    }
}
