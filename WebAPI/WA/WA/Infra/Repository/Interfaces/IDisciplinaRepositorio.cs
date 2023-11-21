using WA.Models;

namespace WA.Infra.Repository.Interfaces
{
    public interface IDisciplinaRepositorio
    {
        Task<List<DisciplinaModel>> BuscarTodasAsDisciplinas();
        Task<DisciplinaModel> BuscarDisciplinaPorId(int id);
        Task<DisciplinaModel> AdicionarDisciplina(DisciplinaModel disciplina);
        Task<DisciplinaModel> AtualizarDisciplina(DisciplinaModel disciplina, int id);
        Task<bool> ApagarDisciplina(int id);
    }
}
