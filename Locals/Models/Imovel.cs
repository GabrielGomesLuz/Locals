using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locals.Models
{
    public class Imovel
    {
        public int ImovelId { get; set; }


        [MinLength(10, ErrorMessage = "Nome deve ter no minímo {1} caracteres")]
        [MaxLength(100, ErrorMessage = "Nome deve ter no máximo {1} caracteres")]
        [Required(ErrorMessage = "Informe o nome do imóvel")]
        [Display(Name = "Nome do Imóvel")]
        public string NomeImovel { get; set; }

        [MinLength(30,ErrorMessage ="Descrição deve ter no minímo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição deve ter no máximo {1} caracteres")]
        [Required(ErrorMessage = "Informe a descrição do imóvel")]
        [Display(Name = "Descrição do Imóvel")]
        public string DescricaoCurta { get; set; }

        [MinLength(50, ErrorMessage = "Descrição detalhada deve ter no minímo {1} caracteres")]
        [MaxLength(300, ErrorMessage = "Descrição detalhada deve ter no máximo {1} caracteres")]
        [Required(ErrorMessage = "Informe a descrição detalhada do imóvel")]
        [Display(Name = "Descrição detalhada do Imóvel")]

        public string DescricaoDetalhada { get; set; }


       
        [Required(ErrorMessage = "Informe o preço do Imóvel")]
        [Display(Name = "Preço do Imóvel")]
        [Column(TypeName ="decimal(10,2)")]
        [Range(1,999.99,ErrorMessage ="O preço deve estar entre 1 e 999,99")]

        public decimal Preco { get; set; }


        
        [Display(Name = "Caminho Imagem do Imóvel")]
        [StringLength(200,ErrorMessage ="O {0} deve ter no máximo {1} caracteres")]

        public string ImagemUrl { get; set; }


        [Display(Name = "Caminho Imagem miniatura do Imóvel")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImagemThumbnailUrl { get; set; }


        [Display(Name ="Destaque?")]
        public bool IsImovelDestaque { get; set; }


        [Display(Name ="Disponível?")]
        public bool Disponivel { get; set; }

        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }

        

        [Display(Name = "Caminho Imagem do Imóvel")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
         
        public string Imagem1 { get; set; }

        [Display(Name = "Caminho Imagem do Imóvel")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]

        public string Imagem2 { get; set; }

        [Display(Name = "Caminho Imagem do Imóvel")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]

        public string ImagemUrl3 { get; set; }

        [Display(Name = "Caminho Imagem do Imóvel")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]

        public string ImagemUrl4 { get; set; }

        [Display(Name = "Caminho Imagem do Imóvel")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]

        public string ImagemUrl5 { get; set; }
    }
}
