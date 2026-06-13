using System.ComponentModel.DataAnnotations;

namespace aula08.Models
{
    public class Produto
    {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public decimal Preco { get; set; }
    }
}