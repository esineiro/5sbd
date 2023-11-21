using Microsoft.EntityFrameworkCore;
using WA.Data.Map;
using WA.Models;

namespace WA.Data
{
    public class APICorujaDBContext : DbContext
    {
        public APICorujaDBContext(DbContextOptions<APICorujaDBContext> options)
            : base(options)
        {
        }
        public DbSet<PessoaModel> Pessoa { get; set; }
        public DbSet<DisciplinaModel> Disciplina { get; set; }
        public DbSet<TurmaModel> Turma { get; set; }
        public DbSet<InscricaoModel> Inscricao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new DisciplinaMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new InscricaoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
