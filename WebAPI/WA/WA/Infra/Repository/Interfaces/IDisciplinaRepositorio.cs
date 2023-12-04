using WA.Models;

namespace WA.Infra.Repository.Interfaces
{
    public interface IDisciplinaRepositorio
    {
        Task<List<Disciplina>> BuscarTodasAsDisciplinas();
        Task<Disciplina> BuscarDisciplinaPorId(int id);
        Task<Disciplina> AdicionarDisciplina(Disciplina disciplina);
        Task<Disciplina> AtualizarDisciplina(Disciplina disciplina, int id);
        Task<bool> ApagarDisciplina(int id);
    }
}
