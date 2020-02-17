using System.ComponentModel.DataAnnotations;

namespace CasaDeShow.Models
{
    public class Genero
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Dado obrigatório")]
        public string Nome { get; set; }
    }
}