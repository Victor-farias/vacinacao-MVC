namespace vacinacao.Models
{
    public class Endereco
    {   
        public int Id {get; set;}
        public int Cep {get; set;}
        public string Logradouro {get; set;}
        public int Numero {get; set;}
        public string Complemento {get; set;}
        public string Municipio {get; set;}
        public string Estado {get; set;}
        public bool Status {get; set;}
    }
}