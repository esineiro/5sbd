using WA.Models;

namespace WA.Infra.Repository.Interfaces
{
    public interface IPessoaRepositorio
    {
        Task<List<PessoaModel>> BuscarTodasAsPessoas();
        Task<PessoaModel> BuscarPessoaPorId(int id);
        Task<PessoaModel> AdicionarPessoa(PessoaModel pessoa);
        Task<PessoaModel> AtualizarPessoa(PessoaModel pessoa, int id);
        Task<bool> ApagarPessoa(int id);   

    }
}
