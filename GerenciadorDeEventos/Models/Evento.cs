using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorDeEventos.Models
{
    public class Evento
    {
      public int Id { get; set; }
      [Display(Name = "Evento")]
      [Required(ErrorMessage = "Preenchimento obrigatório")]
      public string NomeEvento { get; set; } 
      [Display(Name = "Ingressos")]
      [Required(ErrorMessage = "Preenchimento obrigatório")]
      public int QtdIngressos { get; set; }
      [Display(Name = "Data")]
      [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
      [Required(ErrorMessage = "Preenchimento obrigatório")]
      public DateTime DataEvento { get; set; }
      [Display(Name = "Preço")]
      [Required(ErrorMessage = "Preenchimento obrigatório")]
      [DisplayFormat(DataFormatString = "R$ {0:N2}")]
      public decimal VlrIngresso { get; set; }
      [Display(Name = "Gênero")]
      [Required(ErrorMessage = "Preenchimento obrigatório")]
      public string GeneroEvento { get; set; }
      [Display(Name = "Local")]
      public Local LocalEvento { get; set; }
      [Required(ErrorMessage = "Preenchimento obrigatório")]
      public int LocalEventoId { get; set; }
      [Display(Name = "Imagem")]
      public string ImagemEvento { get; set; }
      [Display(Name = "Descrição")]
      [Required(ErrorMessage = "Preenchimento obrigatório")]
      public string DescricaoEvento { get; set; }

    }
}