using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WA.Models;

namespace WA.Data.Map
{
    public class DisciplinaMap : IEntityTypeConfiguration<DisciplinaModel>
    {
        public void Configure(EntityTypeBuilder<DisciplinaModel> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c=> c.Nome).IsRequired().HasMaxLength(150);
            builder.Property(c => c.Sigla).IsRequired().HasMaxLength(15);
            builder.Property(c => c.Periodo).IsRequired().HasMaxLength(1);
            builder.Property(c => c.Creditos).IsRequired().HasMaxLength(3);
            builder.Property(c => c.DataInicio).IsRequired().HasMaxLength(11);
            builder.Property(c => c.DataFim).HasMaxLength(11);
        }
    }
}
