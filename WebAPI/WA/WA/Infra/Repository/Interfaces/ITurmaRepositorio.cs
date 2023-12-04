using WA.Models;

namespace WA.Infra.Repository.Interfaces
{
    public interface ITurmaRepositorio
    {
        Task<List<Turma>> BuscarTodasAsTurmas();
        Task<Turma> BuscarTurmaPorId(int id);
        Task<Turma> AdicionarTurma(Turma turma);
        Task<Turma> AtualizarTurma(Turma turma, int id);
        Task<bool> ApagarTurma(int id);
    }
}
