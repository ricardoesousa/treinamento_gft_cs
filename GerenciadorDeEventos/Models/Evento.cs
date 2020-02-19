using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeEventos.Models
{
    public class Evento
    {
      public int Id { get; set; }
      [Display(Name = "Nome do Evento")]
      public string NomeEvento { get; set; } 
      public int QtdIngressos { get; set; }
      public DateTime DataEvento { get; set; }
      
      public float VlrIngresso { get; set; }
      public string GeneroEvento { get; set; }
      public Local LocalEvento { get; set; }
    }
}