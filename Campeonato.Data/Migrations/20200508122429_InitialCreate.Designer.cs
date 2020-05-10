﻿// <auto-generated />
using Campeonato.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Campeonato.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200508122429_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("Campeonato.Data.Campeonato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Ano")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Campeonatos");
                });

            modelBuilder.Entity("Campeonato.Data.Clube", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Estado")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clubes");
                });

            modelBuilder.Entity("Campeonato.Data.Pontuacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CampeonatoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClubeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Derrotas")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Empates")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GolsContra")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GolsPro")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GolsSaldo")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Jogos")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Pontos")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Posicao")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Vitorias")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CampeonatoId");

                    b.HasIndex("ClubeId");

                    b.ToTable("Pontuacoes");
                });

            modelBuilder.Entity("Campeonato.Data.Pontuacao", b =>
                {
                    b.HasOne("Campeonato.Data.Campeonato", "Campeonato")
                        .WithMany()
                        .HasForeignKey("CampeonatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Campeonato.Data.Clube", "Clube")
                        .WithMany()
                        .HasForeignKey("ClubeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
