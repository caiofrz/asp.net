using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.net_mvc.Models
{
    [Table("categories")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório")]
        [Display(Name = "Nome")]
        [StringLength(50, ErrorMessage = "O nome da categoria deve ter no máximo 50 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O nome da categoria é obrigatório")]
        [Display(Name = "Descricao")]
        [StringLength(100, ErrorMessage = "A descrição da categoria deve ter no máximo 100 caracteres")]
        public string Description { get; set; }

        public List<Product>? Products { get; set; }

    }
}