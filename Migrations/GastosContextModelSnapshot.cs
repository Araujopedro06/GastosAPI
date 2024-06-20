﻿// <auto-generated />
using System;
using GastosAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GastosAPI.Migrations
{
    [DbContext(typeof(GastosContext))]
    partial class GastosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GastosAPI.Models.CategoriaGasto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("CategoriaGastos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Lazer"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Contas"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Aluguel"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Comida"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Trasporte"
                        });
                });

            modelBuilder.Entity("GastosAPI.Models.Gasto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaGastoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaGastoId");

                    b.ToTable("Gastos", (string)null);
                });

            modelBuilder.Entity("GastosAPI.Models.Gasto", b =>
                {
                    b.HasOne("GastosAPI.Models.CategoriaGasto", "CategoriaGasto")
                        .WithMany()
                        .HasForeignKey("CategoriaGastoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaGasto");
                });
#pragma warning restore 612, 618
        }
    }
}