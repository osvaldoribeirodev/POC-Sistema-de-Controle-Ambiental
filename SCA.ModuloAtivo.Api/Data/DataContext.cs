using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SCA.ModuloAtivo.Api.Data.Maps;
using SCA.ModuloAtivo.Api.Models;
using System;
using System.IO;

namespace SCA.ModuloAtivo.Api.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Ativo> Ativos { get; set; }
        public DbSet<Classe> Classes { get; set; }
        //public DbSet<UsuarioOld> Usuarios { get; set; }
        //public DbSet<PerfilOld> Perfis { get; set; }

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
            modelBuilder.ApplyConfiguration(new AtivoMap());
            modelBuilder.ApplyConfiguration(new ClasseMap());
            //modelBuilder.ApplyConfiguration(new UsuarioMapOld());
            //modelBuilder.ApplyConfiguration(new PerfilMapOld());
        }
    }
}
