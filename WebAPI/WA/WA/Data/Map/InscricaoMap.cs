using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WA.Models;

namespace WA.Data.Map
{
    public class InscricaoMap : IEntityTypeConfiguration<Inscricao>
    {
        public void Configure(EntityTypeBuilder<Inscricao> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IdAluno).IsRequired();
            builder.Property(c => c.IdTurma).IsRequired();
            builder.Property(c => c.DataInicio).IsRequired().HasMaxLength(11);
            builder.Property(c => c.DataFim).HasMaxLength(11);
            builder.Property(c => c.NotaAV1).HasMaxLength(5).HasPrecision(4,2);
            builder.Property(c => c.NotaAV2).HasMaxLength(5).HasPrecision(4,2);
            builder.Property(c => c.NotaAVS).HasMaxLength(5).HasPrecision(4,2);
            builder.Property(c => c.NotaAVF).HasMaxLength(5).HasPrecision(4,2);
            builder.Property(c => c.Faltas).HasMaxLength(2);
        }
    }
}
