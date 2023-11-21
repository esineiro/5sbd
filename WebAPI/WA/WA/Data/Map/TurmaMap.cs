using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WA.Models;

namespace WA.Data.Map
{
    public class TurmaMap : IEntityTypeConfiguration<TurmaModel>
    {
        public void Configure(EntityTypeBuilder<TurmaModel> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Sigla).IsRequired().HasMaxLength(15);
            builder.Property(c => c.IdDisciplina).IsRequired();
            builder.Property(c => c.IdProfessor).IsRequired();
            builder.Property(c => c.Horario).IsRequired().HasMaxLength(50);
            builder.Property(c => c.DataInicio).IsRequired().HasMaxLength(11);
            builder.Property(c => c.DataFim).HasMaxLength(11);
            builder.Property(c => c.Turno).IsRequired();
        }
    }
}
