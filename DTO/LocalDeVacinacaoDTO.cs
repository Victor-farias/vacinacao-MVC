using System.ComponentModel.DataAnnotations;

namespace vacinacao.DTO
{
    public class LocalDeVacinacaoDTO
    {   
        [Required]
        public int Id {get; set;}
        
        [Required]
        public string Nome {get; set;}

        [Required]
        public int EnderecoId {get; set;}
        
        public bool Status {get; set;}
    }
}