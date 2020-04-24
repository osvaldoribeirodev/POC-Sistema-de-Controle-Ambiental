using System;

namespace SCA.ModuloAtivo.Api.Models
{
    public class Ativo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Fabricante { get; set; }
        public string NumeroSerie { get; set; }
        public bool ManutencaoAgendada { get; set; }
        public DateTime? DataManutencao { get; set; }
        public string TipoManutencao { get; set; }
        public string Situacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; }
        public int ClasseId { get; set; }
        public Classe Classe { get; set; }
    }
}