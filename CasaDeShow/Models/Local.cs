using System.ComponentModel.DataAnnotations;

namespace CasaDeShow.Models
{
    public class Local
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Dado obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Dado obrigatório")]
        public string Endereco { get; set; }
    }
}