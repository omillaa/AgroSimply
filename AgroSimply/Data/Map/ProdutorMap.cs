using AgroSimply.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroSimply.Data.Map
{
    public class ProdutorMap : IEntityTypeConfiguration<ProdutorModels>
    {
        public void Configure(EntityTypeBuilder<ProdutorModels> builder)
        {
            builder.HasKey(x => x.IdProdutor);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Atividade).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CNPJ).IsRequired().HasMaxLength(14);
            builder.Property(x => x.CPF).IsRequired().HasMaxLength(11);
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(12);
           
        }
    }
}
