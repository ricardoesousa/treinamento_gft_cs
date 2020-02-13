using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarrosImportados.Models
{
    public class Carro
    {
        public int Id { get; set; }
       public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public int Ano { get; set; }
        public string Sobre { get; set; }
        public string Imagem { get; set; }
    }
}