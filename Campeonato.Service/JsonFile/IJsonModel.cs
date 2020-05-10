namespace Campeonato.Service
{
    public interface IJsonModel
    {
        int Ano { get; set; }
        int Derrotas { get; set; }
        int Empates { get; set; }
        string Estado { get; set; }
        int GolsContra { get; set; }
        int GolsPro { get; set; }
        int Jogos { get; set; }
        int Pontos { get; set; }
        int Posicao { get; set; }
        string Time { get; set; }
        int Vitorias { get; set; }
    }
}