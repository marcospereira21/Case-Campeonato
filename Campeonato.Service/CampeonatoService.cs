using AutoMapper;
using Campeonato.Data;
using Campeonato.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Campeonato.Service
{
    public class CampeonatoService : ICampeonatoService
    {

        private DataContext _data;
        public IMessageModel _message { get; set; }

        public CampeonatoService(DataContext dataContext, IMessageModel message)
        {
            _data = dataContext;
            _message = message;
        }

        public IList<PorTimeModel> PorTime()
        {
            try
            {
                var result = _data.Pontuacoes.Include(x => x.Clube).Include(c => c.Campeonato)
                        .GroupBy(x => new { x.Clube.Id, x.Clube.Nome })
                        .Select(x => new PorTimeModel
                        {
                            Posicao = x.Min(s => s.Posicao),
                            Jogos = x.Sum(s => s.Jogos),
                            TimeNome = x.Key.Nome,
                            QtdeCampeonatos = x.Count(),
                            Pontos = x.Sum(s => s.Pontos),
                            Vitorias = x.Sum(s => s.Vitorias),
                            Derrotas = x.Sum(s => s.Derrotas),
                            Empates = x.Sum(s => s.Empates),
                            GolsPro = x.Sum(s => s.GolsPro),
                            GolsContra = x.Sum(s => s.GolsContra),
                            GolsSaldo = x.Sum(s => s.GolsSaldo)
                        })
                        .ToList();

                _message.Info($"Retornaram {result.Count} da pesquisa por time.");

                return result;
            }
            catch (System.Exception ex)
            {
                _message.Erro(ex.Message);
                return null;
            }

        }

        public IList<PorEstadoModel> PorEstado()
        {
            try
            {
                var result = _data.Pontuacoes.Include(x => x.Clube).Include(c => c.Campeonato)
                     .GroupBy(x => new { x.Clube.Id, x.Clube.Estado })
                     .Select(x => new PorEstadoModel
                     {
                         Posicao = x.Min(s => s.Posicao),
                         Jogos = x.Sum(s => s.Jogos),
                         Estado = x.Key.Estado,
                         QtdeCampeonatos = x.Count(),
                         Pontos = x.Sum(s => s.Pontos),
                         Vitorias = x.Sum(s => s.Vitorias),
                         Derrotas = x.Sum(s => s.Derrotas),
                         Empates = x.Sum(s => s.Empates),
                         GolsPro = x.Sum(s => s.GolsPro),
                         GolsContra = x.Sum(s => s.GolsContra),
                         GolsSaldo = x.Sum(s => s.GolsSaldo)
                     })
                     .ToList();

                _message.Info($"Retornaram {result.Count} da pesquisa por time.");

                return result;
            }
            catch (System.Exception ex)
            {
                _message.Erro(ex.Message);
                return null;
            }

        }

        public string InfoComplementar()
        {
            var info = new Dictionary<string, string>();
            InfoComplementar(info);
            var jsonString = JsonConvert.SerializeObject(info, Formatting.Indented);
            return jsonString;
        }

        private void InfoComplementar(Dictionary<string, string> info)
        {
            try
            {
                var somaPorTime = _data.Pontuacoes.Include(x => x.Clube).Include(c => c.Campeonato)
                                       .GroupBy(x => new { x.Clube.Id, x.Clube.Nome })
                                       .Select(x => new
                                       {
                                           TimeNome = x.Key.Nome,
                                           GolsPro = x.Sum(s => s.GolsPro),
                                           GolsContra = x.Sum(s => s.GolsContra),
                                           Vitorias = x.Sum(s => s.Vitorias),
                                           GolsSaldo = x.Sum(s => s.GolsSaldo),
                                           mediaGolsPro = x.Average(s => s.GolsPro),
                                           mediaGolsContra = x.Average(s => s.GolsContra)
                                       })
                                       .ToList();

                var timeMaiorMediaGolsPro = somaPorTime.Where(x => x.mediaGolsPro == somaPorTime.Select(x => x.mediaGolsPro)
                                         .Max()).Select(x => x.TimeNome).Single();
                var timeMenorMediaGolsContra = somaPorTime.Where(x => x.mediaGolsContra == somaPorTime.Select(x => x.mediaGolsContra)
                                         .Min()).Select(x => x.TimeNome).Single();
                var timeMaiorVitorias = somaPorTime.Where(x => x.Vitorias == somaPorTime.Select(x => x.Vitorias)
                                        .Max()).Select(x => x.TimeNome).Single();
                var timeMenorVitorias = somaPorTime.Where(x => x.Vitorias == somaPorTime.Select(x => x.Vitorias)
                                        .Min()).Select(x => x.TimeNome).Single();
                var maiorMediaVitorias = somaPorTime.Where(x => x.Vitorias == somaPorTime.Select(x => x.Vitorias)
                                       .Max()).Select(x => x.TimeNome).Single();
                var menorMediaVitorias = somaPorTime.Where(x => x.Vitorias == somaPorTime.Select(x => x.Vitorias)
                                        .Min()).Select(x => x.TimeNome).Single();

                info.Add("Time com melhor (maior) média de gols a favor", timeMaiorMediaGolsPro);
                info.Add("Time com melhor (menor) média de gols contra", timeMenorMediaGolsContra);
                info.Add("Time com maior numero de vitórias", timeMaiorVitorias);
                info.Add("Time com menor numero de vitórias", timeMenorVitorias);
                info.Add("Time com melhor média de vitorias por campeonato", maiorMediaVitorias);
                info.Add("Time com menor média de vitórias por campeonato", menorMediaVitorias);

                _message.Info($"Informações complementares resultaram com sucesso.");
            }
            catch (System.Exception ex)
            {
                _message.Erro(ex.Message);
            }
        }

    }
}
