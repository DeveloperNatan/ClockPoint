using System.ComponentModel.DataAnnotations;

//tipar os campo que serao criado
// restricao para CRIACAO
//regras de negocio DO BANCO
namespace Clock_API.Models
{
    public class Ponto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Nome { get; set; }

        [Required]
        public int Tipo { get; set; }
    }
}
