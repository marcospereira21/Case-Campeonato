namespace Campeonato.Data
{
    public interface IPontuacao
    {
        int Posicao { get; set; }
        int CampeonatoId { get; set; }
        int ClubeId { get; set; }
        int Derrotas { get; set; }
        int Empates { get; set; }
        int GolsContra { get; set; }
        int GolsPro { get; set; }
        int Id { get; set; }
        int Jogos { get; set; }
        int Pontos { get; set; }
        int Vitorias { get; set; }
        int GolsSaldo { get; set; }
    }
}