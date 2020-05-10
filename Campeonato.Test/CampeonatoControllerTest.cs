using Campeonato.Api.Controllers;
using Campeonato.Data;
using Campeonato.Model;
using Campeonato.Resourses;
using Campeonato.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Campeonato.Test
{
    public abstract class CampeonatoControllerTest
    {
        protected DbContextOptions<DataContext> ContextOptions { get; }
        private DataContext context;
        private MessageModel message;

        protected CampeonatoControllerTest(DbContextOptions<DataContext> contextOptions)
        {
            ContextOptions = contextOptions;

            Seed();
        }

        private void Seed()
        {
            context = new DataContext(ContextOptions);
            message = new MessageModel();
            var stringHandler = new StringHandler();

            var jsonService = new JsonService(context, stringHandler, message);

            jsonService.jsonList = LoadJson();
            jsonService.Processar();

        }

        private IList<JsonModel> LoadJson()
        {
            var filename = "./Resourses/JsonCaseCampeonato.json";

            IList<JsonModel> jsonModel = new List<JsonModel>();

            using (StreamReader sr = File.OpenText(filename))
            {
                jsonModel = JsonConvert.DeserializeObject<List<JsonModel>>(sr.ReadToEnd());
            }

            return jsonModel;
        }

        [Fact]
        public void CanGetInfo()
        {
            var service = new CampeonatoService(context, message);
            var controller = new CampeonatoController(service, new NullLogger<CampeonatoController>());
            var result = controller.GetInfo() as OkObjectResult;
            
            Assert.Contains("Time com melhor (maior) média de gols a favor", result.Value.ToString());
        }

        [Fact]
        public void CanGetPerTime()
        {
            var service = new CampeonatoService(context, message);
            var controller = new CampeonatoController(service, new NullLogger<CampeonatoController>());
            var result = controller.GetPorTime() as OkObjectResult;

            var portime = result.Value as IList<PorTimeModel>;

            Assert.Equal(30, portime.Count);
        }

        [Fact]
        public void CanGetPorEstado()
        {
            var service = new CampeonatoService(context, message);
            var controller = new CampeonatoController(service, new NullLogger<CampeonatoController>());
            var result = controller.GetPorEstado() as OkObjectResult;

            var porEstado = result.Value as IList<PorEstadoModel>;

            Assert.Equal(30, porEstado.Count);
        }
    }
}
