using System.ComponentModel.DataAnnotations;

namespace vacinacao.DTO
{
    public class EnderecoDTO
    {   
        [Required]
        public int Id {get; set;}

        [Required]
        public int Cep {get; set;}

        [Required]
        public string Logradouro {get; set;}

        [Required]
        public int Numero {get; set;}

        [Required]
        public string Complemento {get; set;}

        [Required]
        public string Municipio {get; set;}

        [Required]
        public string Estado {get; set;}

        public bool Status {get; set;}
    }
}