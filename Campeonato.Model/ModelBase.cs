using System;
using System.Collections.Generic;
using System.Text;

namespace Campeonato.Model
{
    public class ModelBase : IModelBase
    {
        public int Posicao { get; set; }
        public int Pontos { get; set; }
        public int Jogos { get; set; }
        public int Vitorias { get; set; }
        public int Empates { get; set; }
        public int Derrotas { get; set; }
        public int GolsPro { get; set; }
        public int GolsContra { get; set; }
        public int GolsSaldo { get; set; }
        public int QtdeCampeonatos { get; set; }
    }
}
