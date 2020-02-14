using System;

namespace CasaDeShow.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public float PrecoIngresso { get; set; }
        public DateTime Data { get; set; }
        public Local Local { get; set; }
        public Genero Genero { get; set; }
        public int QtdIngressos { get; set; }
    }
}