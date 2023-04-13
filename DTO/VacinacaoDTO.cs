using System.ComponentModel.DataAnnotations;
using System;

namespace vacinacao.DTO
{
    public class VacinacaoDTO
    {   
        [Required]
        public int Id {get; set;}

        [Required]
        public DateTime Data {get; set;}

        [Required]
        public int PessoaId {get; set;}

        [Required]
        public int LoteVacinaId {get; set;}

        [Required]
        public int LocalDeVacinacaoId {get; set;}

        [Required]
        public int Dose {get; set;}

        public bool Status {get; set;}
    }
}