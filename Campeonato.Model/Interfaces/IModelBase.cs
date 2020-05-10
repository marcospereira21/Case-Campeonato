namespace Campeonato.Model
{
    public interface IModelBase
    {
        int Derrotas { get; set; }
        int Empates { get; set; }
        int GolsContra { get; set; }
        int GolsPro { get; set; }
        int GolsSaldo { get; set; }
        int Jogos { get; set; }
        int Pontos { get; set; }
        int Posicao { get; set; }
        int QtdeCampeonatos { get; set; }
        int Vitorias { get; set; }
    }
}