using Microsoft.EntityFrameworkCore;
using WA.Data;
using WA.Infra.Repository.Interfaces;
using WA.Models;

namespace WA.Infra.Repository
{
    public class TurmaRepositorio : ITurmaRepositorio
    {
        private readonly APICorujaDBContext _dbContext;
        public TurmaRepositorio(APICorujaDBContext aPICorujaDBContext)
        {
            _dbContext = aPICorujaDBContext;
        }
        public async Task<TurmaModel> BuscarTurmaPorId(int id)
        {
            return await _dbContext.Turma.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<TurmaModel>> BuscarTodasAsTurmas()
        {
            return await _dbContext.Turma.ToListAsync();
        }
        public async Task<TurmaModel> AdicionarTurma(TurmaModel turma)
        {
            await _dbContext.Turma.AddAsync(turma);
            await _dbContext.SaveChangesAsync();

            return turma;
        }
        public async Task<TurmaModel> AtualizarTurma(TurmaModel turma, int id)
        {
            TurmaModel turmaPorId = await BuscarTurmaPorId(id);
            if (turmaPorId == null)
            {
                throw new Exception($"Não foi encontrada nenhuma turma para o Id:{id}!");
            }

            turmaPorId.IdDisciplina = turma.IdDisciplina;
            turmaPorId.IdProfessor = turma.IdProfessor;
            turmaPorId.Horario = turma.Horario;
            turmaPorId.DataInicio = turma.DataInicio;
            turmaPorId.DataFim = turma.DataFim;
            turmaPorId.Turno = turma.Turno; 

            _ = _dbContext.Update(turmaPorId);
            _ = await _dbContext.SaveChangesAsync();

            return turma;
        }
        public async Task<bool> ApagarTurma(int id)
        {
            TurmaModel turmaPorId = await BuscarTurmaPorId(id);
            if (turmaPorId == null)
            {
                throw new Exception($"Não foi encontrada nenhuma turma para o Id:{id}!");
            }

            _dbContext.Turma.Remove(turmaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
