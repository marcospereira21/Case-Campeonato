using System;
using System.Collections.Generic;
using System.Text;

namespace Campeonato.Service
{
    public class JsonModel : IJsonModel
    {
        public int Posicao { get; set; }
        public string Time { get; set; }
        public string Estado { get; set; }
        public int Pontos { get; set; }
        public int Jogos { get; set; }
        public int Vitorias { get; set; }
        public int Empates { get; set; }
        public int Derrotas { get; set; }
        public int GolsPro { get; set; }
        public int GolsContra { get; set; }
        public int Ano { get; set; }

    }
}
