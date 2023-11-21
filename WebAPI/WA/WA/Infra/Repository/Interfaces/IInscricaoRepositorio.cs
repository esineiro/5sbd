using WA.Models;

namespace WA.Infra.Repository.Interfaces
{
    public interface IInscricaoRepositorio
    {
        Task<List<InscricaoModel>> BuscarTodasAsInscricoes();
        Task<InscricaoModel> BuscarInscricaoPorId(int id);
        Task<InscricaoModel> AdicionarInscricao(InscricaoModel inscricao);
        Task<InscricaoModel> AtualizarInscricao(InscricaoModel inscricao, int id);
        Task<bool> ApagarInscricao(int id);
    }
}
