﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VariacaoAtivo.DAL;

namespace VariacaoAtivo.DAL.Migrations
{
    [DbContext(typeof(VariacaoAtivoDbContext))]
    [Migration("20230318031216_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VariacaoAtivo.VO.QuotacaoVO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.Property<double>("VariacaoD1")
                        .HasColumnType("float");

                    b.Property<double>("VariacaoPrimeiraData")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Quotacao");
                });
#pragma warning restore 612, 618
        }
    }
}
