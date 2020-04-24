using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SistemaAquisicao.Api.Data.Maps;
using SistemaAquisicao.Api.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaAquisicao.Api.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Estoque> Estoques { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //var stringConnection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SCA;User ID=sca;Password=sca";
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EstoqueMap());
        }
    }
}
