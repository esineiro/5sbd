namespace WA.Models;
using WA.Enums;
public class TurmaModel
{
    public int Id { get; set; }
    public string Sigla { get; set; }
    public int IdDisciplina { get; set; }
    public int IdProfessor { get; set; }
    public string Horario { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public Turno Turno { get; set; }
}
