using System.ComponentModel.DataAnnotations;

namespace vacinacao.DTO
{
    public class VacinaDTO
    {   
        [Required]
        public int Id {get; set;}

        [Required]
        public string Nome {get; set;}

        [Required]
        public string Laboratorio {get; set;}

        [Required]
        public int Posologia {get; set;}

        [Required]
        public int IntervaloEntreDoses {get; set;}

        public bool Status {get; set;}
    }
}