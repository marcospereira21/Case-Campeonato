using System;
using System.Collections.Generic;
using System.Text;

namespace Campeonato.Data
{
    public class Pontuacao : IPontuacao
    {
        public int Posicao { get; set; }
        public int Id { get; set; }
        public int CampeonatoId { get; set; }
        public int ClubeId { get; set; }

        public int Pontos { get; set; }
        public int Jogos { get; set; }
        public int Vitorias { get; set; }
        public int Empates { get; set; }
        public int Derrotas { get; set; }
        public int GolsPro { get; set; }
        public int GolsContra { get; set; }
        public int GolsSaldo { get; set; }

        public Campeonato Campeonato { get; set; }
        public Clube Clube { get; set; }
       
    }
}
