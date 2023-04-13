using System;

namespace vacinacao.Models
{
    public class Vacinacao
    {
        public int Id {get; set;}
        public DateTime Data {get; set;}
        public Pessoa Pessoa {get; set;}
        public LoteVacina LoteVacina {get; set;}
        public LocalDeVacinacao LocalDeVacinacao {get; set;}
        public int Dose {get; set;}
        public bool Status {get; set;}
    }
}