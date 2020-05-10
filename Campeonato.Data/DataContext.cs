using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campeonato.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

           
        }

        public DbSet<Clube> Clubes { get; set; }
        public DbSet<Campeonato> Campeonatos { get; set; }
        public DbSet<Pontuacao> Pontuacoes { get; set; }
    }
}
