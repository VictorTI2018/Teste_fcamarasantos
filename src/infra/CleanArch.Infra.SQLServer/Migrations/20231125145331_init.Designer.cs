﻿// <auto-generated />
using System;
using CleanArch.Infra.SQLServer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CleanArch.Infra.SQLServer.Migrations
{
    [DbContext(typeof(EstacionamentoSqlServerContext))]
    [Migration("20231125145331_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CleanArch.Core.Domain.Entities.Aggregates.EnderecoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar")
                        .HasColumnName("Bairro");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Cidade");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int")
                        .HasColumnName("EmpresaId");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Endereco");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar")
                        .HasColumnName("Numero");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar")
                        .HasColumnName("UF");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.HasIndex("EmpresaId")
                        .IsUnique();

                    b.ToTable("Endereco", (string)null);
                });

            modelBuilder.Entity("CleanArch.Core.Domain.Entities.EmpresaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar")
                        .HasColumnName("CNPJ");

                    b.Property<DateTime?>("Created")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("_created")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar")
                        .HasColumnName("Nome");

                    b.Property<int>("QuantidadeVagasCarros")
                        .HasColumnType("int")
                        .HasColumnName("QuantidadeVagasCarros");

                    b.Property<int>("QuantidadeVagasMotos")
                        .HasColumnType("int")
                        .HasColumnName("QuantidadeVagasMotos");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar")
                        .HasColumnName("Telefone");

                    b.Property<DateTime?>("Updated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("_updated")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.ToTable("Empresa", (string)null);
                });

            modelBuilder.Entity("CleanArch.Core.Domain.Entities.VeiculosEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar")
                        .HasColumnName("Cor");

                    b.Property<DateTime?>("Created")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("_created")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("varchar")
                        .HasColumnName("Marca");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Modelo");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar")
                        .HasColumnName("Placa");

                    b.Property<int>("Tipo")
                        .HasMaxLength(10)
                        .HasColumnType("int")
                        .HasColumnName("Tipo");

                    b.Property<DateTime?>("Updated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("_updated")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.HasIndex("EmpresaId");

                    b.ToTable("Veiculos", (string)null);
                });

            modelBuilder.Entity("CleanArch.Core.Domain.Entities.Aggregates.EnderecoEntity", b =>
                {
                    b.HasOne("CleanArch.Core.Domain.Entities.EmpresaEntity", "Empresa")
                        .WithOne("Endereco")
                        .HasForeignKey("CleanArch.Core.Domain.Entities.Aggregates.EnderecoEntity", "EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("CleanArch.Core.Domain.Entities.VeiculosEntity", b =>
                {
                    b.HasOne("CleanArch.Core.Domain.Entities.EmpresaEntity", "Empresa")
                        .WithMany("Veiculos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("CleanArch.Core.Domain.Entities.EmpresaEntity", b =>
                {
                    b.Navigation("Endereco")
                        .IsRequired();

                    b.Navigation("Veiculos");
                });
#pragma warning restore 612, 618
        }
    }
}