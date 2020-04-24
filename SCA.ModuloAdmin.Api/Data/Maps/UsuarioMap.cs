
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SCA.ModuloAdmin.Api.Models;

namespace SCA.ModuloAdmin.Api.Data.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(x => x.Id);            
            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(180)");
            builder.Property(x => x.Login).IsRequired().HasColumnType("varchar(30)");
            builder.Property(x => x.Senha).IsRequired().HasColumnType("varchar(180)");
            builder.Property(x => x.Situacao).IsRequired().HasColumnType("varchar(10)");

            //Relacionamento um para muitos
            builder.HasOne(x => x.Perfil).WithMany();
        }
    }
}
