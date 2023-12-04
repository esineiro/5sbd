namespace WA.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; } 
        public int Periodo { get; set; }    
        public int Creditos {  get; set; }  
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

    }
}
