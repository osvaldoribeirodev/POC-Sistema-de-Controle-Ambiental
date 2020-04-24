using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SCA.ModuloAdmin.Api.Data.Maps;
using SCA.ModuloAdmin.Api.Models;
using System;
using System.IO;

namespace SCA.ModuloAdmin.Api.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())//AppDomain.CurrentDomain.BaseDirectory
                .AddJsonFile("appsettings.json")
                .Build();

            //var stringConnection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCA;User ID=sca;Password=sca";
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PerfilMap());
        }
    }
}
