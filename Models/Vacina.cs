namespace vacinacao.Models
{
    public class Vacina
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Laboratorio {get; set;}
        public int Posologia {get; set;}
        public int IntervaloEntreDoses {get; set;}
        public bool Status {get; set;}
    }
}