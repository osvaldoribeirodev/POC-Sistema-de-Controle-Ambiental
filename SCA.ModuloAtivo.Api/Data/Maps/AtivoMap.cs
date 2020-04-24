using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCA.ModuloAtivo.Api.Models;

namespace SCA.ModuloAtivo.Api.Data.Maps
{
    public class AtivoMap : IEntityTypeConfiguration<Ativo>
    {
        public void Configure(EntityTypeBuilder<Ativo> builder)
        {
            builder.ToTable("Ativo");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(200)");
            builder.Property(x => x.Fabricante).IsRequired().HasColumnType("varchar(200)");
            builder.Property(x => x.NumeroSerie).IsRequired().HasColumnType("varchar(20)");
            builder.Property(x => x.ManutencaoAgendada).IsRequired().HasColumnType("bit");
            builder.Property(x => x.DataManutencao);
            builder.Property(x => x.TipoManutencao).HasColumnType("varchar(15)");
            builder.Property(x => x.Situacao).IsRequired().HasColumnType("varchar(10)");
            builder.Property(x => x.DataCriacao).IsRequired();
            builder.Property(x => x.DataUltimaAtualizacao).IsRequired();

            //Relacionamento um para muitos
            //builder.HasOne(x => x.Classe).WithMany(x => x.Ativos);
            builder.HasOne(x => x.Classe).WithMany();
        }
    }
}
