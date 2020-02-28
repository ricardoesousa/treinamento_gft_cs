using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeEventos.Models
{
    public class Local
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [Display(Name = "Local")]
        public string NomeLocal { get; set; }
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [Display(Name = "Endereço")]
        public string EnderecoLocal { get; set; }

    }
}