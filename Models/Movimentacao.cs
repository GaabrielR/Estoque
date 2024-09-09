using System.ComponentModel.DataAnnotations;

namespace Estoque.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }

        [Required]
        public int ProdutoId { get; set; }
    }
}
