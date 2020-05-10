using Campeonato.Data;
using Campeonato.Model;
using Campeonato.Resourses;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Campeonato.Service
{
    public class JsonService : IJsonService
    {
        public IList<JsonModel> jsonList { get; set; } = new List<JsonModel>();
        public IMessageModel _message { get; set; }

        private readonly DataContext _context;
        private IStringHandler _stringHandler;

        IList<Campeonato.Data.Campeonato> campeonatos = new List<Campeonato.Data.Campeonato>();
        IList<Clube> clubes = new List<Clube>();
        IList<Pontuacao> pontuacoes = new List<Pontuacao>();

        private bool isRunning = true;

        public JsonService(DataContext context, IStringHandler stringHandler, IMessageModel message)
        {
            _context = context;
            _stringHandler = stringHandler;
            _message = message;
        }

        public void ParseJson(JObject[] jsonString)
        {
            try
            {
                foreach (var item in jsonString)
                    jsonList.Add(item.ToObject<JsonModel>());

                Processar();
            }
            catch (System.Exception ex)
            {
                _message.Erro(ex.Message);
            }

        }


        public void Processar()
        {
            PadronizarClubes();
            ClearTables();
            GetCampeonato();
            GetClubes();
            GetPontuacao();
        }

        private void PadronizarClubes()
        {
            if (!isRunning)
                return;
            try
            {
                foreach (var item in jsonList)
                {
                    item.Time = _stringHandler.ToUpper(item.Time);
                    item.Time = _stringHandler.RemoveAccents(item.Time);
                    item.Time = _stringHandler.HiffenLastWord(item.Time, 2);
                }
            }
            catch (System.Exception ex)
            {
                _message.Erro(ex.Message);
                isRunning = false;
            }


        }

        private void ClearTables()
        {
            if (!isRunning)
                return;

            try
            {
                ClearPontuacoes();
                ClearClubes();
                ClearCampeonatos();
            }
            catch (System.Exception ex)
            {
                _message.Erro(ex.Message);
                isRunning = false;
            }

        }

        private void ClearPontuacoes()
        {
            var itemsToDelete = _context.Set<Pontuacao>();
            _context.Pontuacoes.RemoveRange(itemsToDelete);
            _context.SaveChanges();
        }

        private void ClearClubes()
        {
            var itemsToDelete = _context.Set<Clube>();
            _context.Clubes.RemoveRange(itemsToDelete);
            _context.SaveChanges();
        }

        private void ClearCampeonatos()
        {
            var itemsToDelete = _context.Set<Campeonato.Data.Campeonato>();
            _context.Campeonatos.RemoveRange(itemsToDelete);
            _context.SaveChanges();
        }

        private void GetCampeonato()
        {
            if (!isRunning)
                return;

            try
            {
                IList<int> anos = jsonList.Select(x => x.Ano).Distinct().ToList();
                foreach (var item in anos)
                {
                    campeonatos.Add(new Campeonato.Data.Campeonato { Ano = item });
                }

                _context.AddRange(campeonatos);
                _context.SaveChanges();

                isRunning = true;
            }
            catch (System.Exception ex)
            {
                _message.Erro(ex.Message);
                isRunning = false;
            }

        }

        private void GetClubes()
        {
            if (!isRunning)
                return;
            try
            {
                var listClubesDistinct = jsonList.Select(x => new { x.Time, x.Estado }).Distinct().ToList();

                foreach (var item in listClubesDistinct)
                {
                    clubes.Add(new Clube { Nome = item.Time, Estado = item.Estado });
                }

                _context.AddRange(clubes);
                _context.SaveChanges();

            }
            catch (System.Exception ex)
            {
                _message.Erro(ex.Message);
                isRunning = false;
            }
        }

        private void GetPontuacao()
        {
            if (!isRunning)
                return;

            try
            {
                foreach (var item in jsonList)
                {
                    var camp = campeonatos.FirstOrDefault(x => x.Ano == item.Ano);
                    var clube = clubes.FirstOrDefault(x => x.Nome == item.Time);

                    pontuacoes.Add(new Pontuacao
                    {
                        CampeonatoId = camp.Id,
                        ClubeId = clube.Id,
                        Pontos = item.Pontos,
                        Empates = item.Empates,
                        Derrotas = item.Derrotas,
                        GolsContra = item.GolsContra,
                        GolsPro = item.GolsPro,
                        Posicao = item.Posicao,
                        Jogos = item.Jogos,
                        Vitorias = item.Vitorias,
                        GolsSaldo = item.GolsPro - item.GolsContra
                    });

                }

                _context.AddRange(pontuacoes);
                _context.SaveChanges();


            }
            catch (System.Exception ex)
            {
                _message.Erro(ex.Message);
                isRunning = false;
            }

        }

    }

}
