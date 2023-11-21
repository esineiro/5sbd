using Microsoft.EntityFrameworkCore;
using WA.Data;
using WA.Infra.Repository.Interfaces;
using WA.Models;

namespace WA.Infra.Repository
{
    public class DisciplinaRepositorio : IDisciplinaRepositorio
    {
        private readonly APICorujaDBContext _dbContext;
        public DisciplinaRepositorio(APICorujaDBContext aPICorujaDBContext)
        {
            _dbContext = aPICorujaDBContext;
        }
        public async Task<DisciplinaModel> BuscarDisciplinaPorId(int id)
        {
            return await _dbContext.Disciplina.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<DisciplinaModel>> BuscarTodasAsDisciplinas()
        {
            return await _dbContext.Disciplina.ToListAsync();
        }
        public async Task<DisciplinaModel> AdicionarDisciplina(DisciplinaModel disciplina)
        {
            await _dbContext.Disciplina.AddAsync(disciplina);
            await _dbContext.SaveChangesAsync();

            return disciplina;
        }
        public async Task<DisciplinaModel> AtualizarDisciplina(DisciplinaModel disciplina, int id)
        {
            DisciplinaModel disciplinaPorId = await BuscarDisciplinaPorId(id);
            if (disciplinaPorId == null)
            {
                throw new Exception($"Não foi encontrada nenhuma disciplina para o Id:{id}!");
            }

            disciplinaPorId.Nome = disciplina.Nome; 
            disciplinaPorId.Sigla = disciplina.Sigla;
            disciplinaPorId.Periodo = disciplina.Periodo;
            disciplinaPorId.Creditos = disciplina.Creditos;
            disciplinaPorId.DataInicio = disciplina.DataInicio;
            disciplinaPorId.DataFim = disciplina.DataFim;

            _ = _dbContext.Update(disciplinaPorId);
            _ = await _dbContext.SaveChangesAsync();

            return disciplina;
        }
        public async Task<bool> ApagarDisciplina(int id)
        {
            DisciplinaModel disciplinaPorId = await BuscarDisciplinaPorId(id);
            if (disciplinaPorId == null)
            {
                throw new Exception($"Não foi encontrada nenhuma disciplina para o Id:{id}!");
            }

            _dbContext.Disciplina.Remove(disciplinaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
