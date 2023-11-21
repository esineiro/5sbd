using WA.Models;

namespace WA.Infra.Repository.Interfaces
{
    public interface ITurmaRepositorio
    {
        Task<List<TurmaModel>> BuscarTodasAsTurmas();
        Task<TurmaModel> BuscarTurmaPorId(int id);
        Task<TurmaModel> AdicionarTurma(TurmaModel turma);
        Task<TurmaModel> AtualizarTurma(TurmaModel turma, int id);
        Task<bool> ApagarTurma(int id);
    }
}
