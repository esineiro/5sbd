using WA.Models;

namespace WA.Infra.Repository.Interfaces
{
    public interface IPessoaRepositorio
    {
        Task<List<Pessoa>> BuscarTodasAsPessoas();
        Task<Pessoa> BuscarPessoaPorId(int id);
        Task<Pessoa> AdicionarPessoa(Pessoa pessoa);
        Task<Pessoa> AtualizarPessoa(Pessoa pessoa, int id);
        Task<bool> ApagarPessoa(int id);   

    }
}
