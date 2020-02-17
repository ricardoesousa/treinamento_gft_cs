using System.ComponentModel.DataAnnotations;

namespace CasaDeShow.Models
{
    public class Ingresso
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Dado obrigatório")]
        public Evento Evento { get; set; }
        [Required(ErrorMessage = "Dado obrigatório")]
        public int Quantidade { get; set; }
    }
}