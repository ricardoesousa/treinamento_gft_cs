using System;
using System.ComponentModel.DataAnnotations;

namespace CasaDeShow.Models
{
    public class Evento
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Dado obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Dado obrigatório")]
        public float PrecoIngresso { get; set; }
        [Required(ErrorMessage = "Dado obrigatório")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "Dado obrigatório")]
        public Local Local { get; set; }
        [Required(ErrorMessage = "Dado obrigatório")]
        public Genero Genero { get; set; }
        [Required(ErrorMessage = "Dado obrigatório")]
        public int QtdIngressos { get; set; }
        [Required(ErrorMessage = "Dado obrigatório")]
        public int Capacidade { get; set; }
        [Required(ErrorMessage = "Dado obrigatório")]
        public int LocalId { get; set; }
    }
}