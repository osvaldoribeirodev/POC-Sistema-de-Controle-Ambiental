
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCA.ModuloAdmin.Api.Models;

namespace SCA.ModuloAdmin.Api.Data.Maps
{
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("Perfil");
            builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id).UseSqlServerIdentityColumn();
            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(50)");
        }
    }
}
