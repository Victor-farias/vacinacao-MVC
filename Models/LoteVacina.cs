using System;

namespace vacinacao.Models
{
    public class LoteVacina
    {
        public int Id {get; set;}
        public Vacina Vacina {get; set;}
        public string IdentificacaoDoLote {get; set;}
        public int QuantidadeRecebida {get; set;}
        public int QuantidadeRestante {get; set;}
        public DateTime DataDeRecebimento {get; set;}
        public DateTime DataDeValidade {get; set;}
        public bool Status {get; set;}
    }
}