using System.ComponentModel.DataAnnotations;
using System;

namespace vacinacao.DTO
{
    public class LoteVacinaDTO
    {   
        [Required]
        public int Id {get; set;}

        [Required]
        public int VacinaId {get; set;}

        [Required]
        public string IdentificacaoDoLote {get; set;}

        [Required]
        public int QuantidadeRecebida {get; set;}

        [Required]
        public int QuantidadeRestante {get; set;}

        [Required]
        public DateTime DataDeRecebimento {get; set;}

        [Required]
        public DateTime DataDeValidade {get; set;}

        public bool Status {get; set;}
    }
}