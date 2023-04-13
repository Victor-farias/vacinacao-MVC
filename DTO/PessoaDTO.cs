using System.ComponentModel.DataAnnotations;
using System;

namespace vacinacao.DTO
{
    public class PessoaDTO
    {   
        [Required]
        public int Id {get; set;}

        [Required]
        public string Cpf {get; set;}

        [Required]
        public string NomeCompleto {get; set;}

        [Required]
        public DateTime DataDeNascimento {get; set;}

        [Required]
        public int EnderecoId {get; set;}

        public bool Status {get; set;}
        public bool StatusVacinacao {get; set;}
    }
}