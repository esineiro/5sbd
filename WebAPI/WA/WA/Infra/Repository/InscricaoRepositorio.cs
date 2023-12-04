using Microsoft.EntityFrameworkCore;
using WA.Data;
using WA.Infra.Repository.Interfaces;
using WA.Models;

namespace WA.Infra.Repository
{
    public class InscricaoRepositorio : IInscricaoRepositorio
    {
        private readonly APICorujaDBContext _dbContext;
        public InscricaoRepositorio(APICorujaDBContext aPICorujaDBContext)
        {
            _dbContext = aPICorujaDBContext;
        }
        public async Task<Inscricao> BuscarInscricaoPorId(int id)
        {
            return await _dbContext.Inscricao.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Inscricao>> BuscarTodasAsInscricoes()
        {
            return await _dbContext.Inscricao.ToListAsync();
        }

         public async Task<Inscricao> AdicionarInscricao(Inscricao inscricao)
        {
            await _dbContext.Inscricao.AddAsync(inscricao);
            await _dbContext.SaveChangesAsync();

            return inscricao;
        }
        public async Task<Inscricao> AtualizarInscricao(Inscricao inscricao, int id)
        {
            Inscricao inscricaoPorId = await BuscarInscricaoPorId(id);
            if (inscricaoPorId == null)
            {
                throw new Exception($"Não foi encontrada nenhuma inscrição para o Id:{id}!");
            }

            inscricaoPorId.IdAluno = inscricao.IdAluno;
            inscricaoPorId.IdTurma = inscricao.IdTurma;
            inscricaoPorId.DataInicio = inscricao.DataInicio;
            inscricaoPorId.DataFim = inscricao.DataFim;
            inscricaoPorId.NotaAV1 = inscricao.NotaAV1;
            inscricaoPorId.NotaAV2 = inscricao.NotaAV2;
            inscricaoPorId.NotaAVS = inscricao.NotaAVS;
            inscricaoPorId.NotaAVF = inscricao.NotaAVF;
            inscricaoPorId.Faltas = inscricao.Faltas;

            _ = _dbContext.Update(inscricaoPorId);
            _ = await _dbContext.SaveChangesAsync();

            return inscricao;
        }
        public async Task<bool> ApagarInscricao(int id)
        {
            Inscricao inscricaoPorId = await BuscarInscricaoPorId(id);
            if (inscricaoPorId == null)
            {
                throw new Exception($"Não foi encontrada nenhuma inscrição para o Id:{id}!");
            }

            _dbContext.Inscricao.Remove(inscricaoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
