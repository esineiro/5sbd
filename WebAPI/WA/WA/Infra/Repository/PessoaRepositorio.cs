using Microsoft.EntityFrameworkCore;
using WA.Data;
using WA.Infra.Repository.Interfaces;
using WA.Models;

namespace WA.Infra.Repository
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private readonly APICorujaDBContext _dbContext;
        public PessoaRepositorio(APICorujaDBContext aPICorujaDBContext)
        {
            _dbContext = aPICorujaDBContext;
        }
        public async Task<PessoaModel> BuscarPessoaPorId(int id)
        {
            return await _dbContext.Pessoa.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<PessoaModel>> BuscarTodasAsPessoas()
        {
            return await _dbContext.Pessoa.ToListAsync();
        }
        public async Task<PessoaModel> AdicionarPessoa(PessoaModel pessoa)
        {
            await _dbContext.Pessoa.AddAsync(pessoa);
            await _dbContext.SaveChangesAsync();

            return pessoa;
        }
        public async Task<PessoaModel> AtualizarPessoa(PessoaModel pessoa, int id)
        {
            PessoaModel pessoaPorId = await BuscarPessoaPorId(id);
            if (pessoaPorId == null)
            {
                throw new Exception($"Não foi encontrada nenhuma pessoa para o Id:{id}!");
            }
            pessoaPorId.Nome = pessoa.Nome;
            pessoaPorId.Matricula = pessoa.Matricula;
            pessoaPorId.DataNascimento = pessoa.DataNascimento;
            pessoaPorId.Sexo = pessoa.Sexo;
            pessoaPorId.Email = pessoa.Email;
            pessoaPorId.Endereco = pessoa.Endereco;
            pessoaPorId.Tipo = pessoa.Tipo;
            pessoaPorId.Ativo = pessoa.Ativo;

            _ = _dbContext.Update(pessoaPorId);
            _ = await _dbContext.SaveChangesAsync();

            return pessoa;
        }
        public async Task<bool> ApagarPessoa(int id)
        {
            PessoaModel pessoaPorId = await BuscarPessoaPorId(id);
            if (pessoaPorId == null)
            {
                throw new Exception($"Não foi encontrada nenhuma pessoa para o Id:{id}!");
            }

            _dbContext.Pessoa.Remove(pessoaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
