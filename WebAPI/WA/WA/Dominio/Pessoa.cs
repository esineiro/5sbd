using System.ComponentModel.DataAnnotations;
using WA.Enums;

namespace WA.Models
{
    public class Pessoa
    {
      
        public int Id { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string? Endereco { get; set; }
        public TipoPessoa Tipo { get; set; }
        public string? Senha { get; set; }
        public Boolean Ativo { get; set; }
    }
}
