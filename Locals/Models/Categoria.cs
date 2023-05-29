


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locals.Models
{
    public class Categoria
    {
        public int CategoriaID { get; set; }


        [StringLength(100,ErrorMessage="Nome deve ter no máximo 100 caracteres")]
        [Required(ErrorMessage ="Informe o nome da categoria")]
        [Display(Name ="Nome")]
        public string CategoriaNome { get; set; }

        [StringLength(200, ErrorMessage = "Categoria deve ter no máximo 200 caracteres")]
        [Required(ErrorMessage = "Informe a descrição da categoria")]
        [Display(Name = "Nome")]


        public string Descricao { get; set; }

        public List<Imovel> Imoveis{ get; set; }
    }

}
