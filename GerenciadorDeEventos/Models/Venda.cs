namespace GerenciadorDeEventos.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public Evento EventoSelecionado { get; set; }
        public int QtdIngressos { get; set; }
    }
}