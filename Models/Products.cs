using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp.net_mvc.Models
{

    [Table("products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do lanche é obrigatório")]
        [Display(Name = "Nome do lanche")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome do lanche deve conter de 10 a 100 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A descrição do lanche é obrigatória")]
        [Display(Name = "Descricao do lanche")]
        [Length(minimumLength: 10, maximumLength: 200, ErrorMessage = "A descrição deve conter entre 20 e 200 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O preço do lanche é obrigatório")]
        [Display(Name = "Preco do lanche")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, int.MaxValue)]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        [Display(Name = "Em Estoque?")]
        public bool IsAvailable { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Timestamp]
        public DateTime? CreatedAt { get; set; }
    }
}