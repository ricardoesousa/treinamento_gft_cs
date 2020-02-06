using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarrosImportados.Models
{
    [Table("Carros")]
    public class Carro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O modelo do carro é obrigatório", AllowEmptyStrings = false)]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "A marca do carro é obrigatório", AllowEmptyStrings = false)]
        public int Marca { get; set; }
        [Required(ErrorMessage = "O modelo do carro é obrigatória", AllowEmptyStrings = false)]

        public string Cor { get; set; }
        [Required(ErrorMessage = "A cor do carro é obrigatória", AllowEmptyStrings = false)]

        public int Ano { get; set; }
        [Required(ErrorMessage = "O ano do carro é obrigatório", AllowEmptyStrings = false)]

        public string Sobre { get; set; }
        
        public string Imagem { get; set; }
    }
}