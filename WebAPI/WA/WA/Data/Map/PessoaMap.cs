using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WA.Models;

namespace WA.Data.Map
{
    public class PessoaMap : IEntityTypeConfiguration<PessoaModel>
    {
        public void Configure(EntityTypeBuilder<PessoaModel> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Matricula).IsRequired().HasMaxLength(25);
            builder.Property(c=> c.Nome).IsRequired().HasMaxLength(150);
            builder.Property(c => c.DataNascimento).IsRequired().HasMaxLength(11);
            builder.Property(c => c.Sexo).IsRequired().HasMaxLength(1);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(200);
            builder.Property(c => c.Endereco).HasMaxLength(255);
            builder.Property(c => c.Tipo).IsRequired();
            builder.Property(c => c.Senha).HasMaxLength(255);
            builder.Property(c => c.Ativo).IsRequired();
        }
    }
}
