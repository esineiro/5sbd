using WA.Models;

namespace WA.Infra.Repository.Interfaces
{
    public interface IInscricaoRepositorio
    {
        Task<List<Inscricao>> BuscarTodasAsInscricoes();
        Task<Inscricao> BuscarInscricaoPorId(int id);
        Task<Inscricao> AdicionarInscricao(Inscricao inscricao);
        Task<Inscricao> AtualizarInscricao(Inscricao inscricao, int id);
        Task<bool> ApagarInscricao(int id);
    }
}
