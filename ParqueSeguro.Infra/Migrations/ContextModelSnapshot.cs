﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParqueSeguro.Infra.Persistence;

#nullable disable

namespace ParqueSeguro.Infra.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ParqueSeguro.Core.Entities.Registro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long?>("Duracao")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("HoraChegada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("HoraSaida")
                        .HasColumnType("datetime2");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<double?>("Preco")
                        .HasPrecision(14, 2)
                        .HasColumnType("float(14)");

                    b.Property<int?>("TotalHora")
                        .HasColumnType("int");

                    b.Property<double?>("ValorPagar")
                        .HasPrecision(14, 2)
                        .HasColumnType("float(14)");

                    b.HasKey("Id");

                    b.ToTable("Registros");
                });

            modelBuilder.Entity("ParqueSeguro.Core.Entities.TabelaPreco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<double>("ValorAdicional")
                        .HasPrecision(14, 2)
                        .HasColumnType("float(14)");

                    b.Property<double>("ValorInicial")
                        .HasPrecision(14, 2)
                        .HasColumnType("float(14)");

                    b.HasKey("Id");

                    b.ToTable("TabelaPrecos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataFinal = new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DataInicio = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ValorAdicional = 2.0,
                            ValorInicial = 2.0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
