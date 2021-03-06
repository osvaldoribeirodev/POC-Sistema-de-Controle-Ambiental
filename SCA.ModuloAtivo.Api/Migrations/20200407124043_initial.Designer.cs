﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SCA.ModuloAtivo.Api.Data;

namespace SCA.ModuloAtivo.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200407124043_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SCA.ModuloAtivo.Api.Models.Ativo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClasseId");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime?>("DataManutencao")
                        .IsRequired();

                    b.Property<DateTime>("DataUltimaAtualizacao");

                    b.Property<string>("Fabricante")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<bool>("ManutencaoAgendada")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NumeroSerie")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Situacao")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("TipoManutencao")
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("ClasseId");

                    b.ToTable("Ativo");
                });

            modelBuilder.Entity("SCA.ModuloAtivo.Api.Models.Classe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(180)");

                    b.HasKey("Id");

                    b.ToTable("Classe");
                });

            modelBuilder.Entity("SCA.ModuloAtivo.Api.Models.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Perfil");
                });

            modelBuilder.Entity("SCA.ModuloAtivo.Api.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(180)");

                    b.Property<int>("PerfilId");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(180)");

                    b.Property<string>("Situacao")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("PerfilId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("SCA.ModuloAtivo.Api.Models.Ativo", b =>
                {
                    b.HasOne("SCA.ModuloAtivo.Api.Models.Classe", "Classe")
                        .WithMany()
                        .HasForeignKey("ClasseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SCA.ModuloAtivo.Api.Models.Usuario", b =>
                {
                    b.HasOne("SCA.ModuloAtivo.Api.Models.Perfil", "Perfil")
                        .WithMany()
                        .HasForeignKey("PerfilId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
