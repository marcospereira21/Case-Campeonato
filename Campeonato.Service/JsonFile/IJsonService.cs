using Campeonato.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Campeonato.Service
{
    public interface IJsonService
    {
        IMessageModel _message { get; set; }
        IList<JsonModel> jsonList { get; set; }

        void ParseJson(JObject[] jsonString);
        void Processar();
    }
}