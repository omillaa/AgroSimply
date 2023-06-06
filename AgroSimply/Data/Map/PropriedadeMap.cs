using AgroSimply.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroSimply.Data.Map
{
    public class PropriedadeMap : IEntityTypeConfiguration<PropriedadeModels>
    {
        public void Configure(EntityTypeBuilder<PropriedadeModels> builder)
        {
            builder.HasKey(x => x.IdPropriedade);
            builder.Property(x => x.IdProdutor);
            builder.Property(x => x.Endereco).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Bairro).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Numero).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Extensão).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Cidade).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Cultura).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Estado).IsRequired().HasMaxLength(255);

            builder.HasOne<ProdutorModels>()  // Indica o relacionamento com o Produtor
      .WithMany()  // Um Produtor pode ter várias Propriedades
      .HasForeignKey(x => x.IdProdutor);  // Define a chave estrangeira
      
        }
    }
}
