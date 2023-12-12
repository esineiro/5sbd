namespace WA.Models;

using System.ComponentModel.DataAnnotations.Schema;
using WA.Enums;
    public class Inscricao
{
    public int Id { get; set; }
    public int IdAluno { get; set; }
    public int IdTurma{ get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public decimal? NotaAV1 {  get; set; }
    public decimal? NotaAV2 { get; set; }
    public decimal? NotaAVS { get; set; }
    public decimal? NotaAVF { get; set; }
    public int? Faltas { get; set; }
}
