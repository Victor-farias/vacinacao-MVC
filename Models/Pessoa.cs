using System;

namespace vacinacao.Models
{
    public class Pessoa
    {
        public int Id {get; set;}
        public string Cpf {get; set;}
        public string NomeCompleto {get; set;}
        public DateTime DataDeNascimento {get; set;}
        public Endereco Endereco {get; set;}
        public bool Status {get; set;}
        public bool StatusVacinacao {get; set;}
    }
}