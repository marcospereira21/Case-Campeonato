using Campeonato.Model;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Campeonato.Service
{
    public interface ICampeonatoService
    {
        string InfoComplementar();
        IList<PorEstadoModel> PorEstado();
        IList<PorTimeModel> PorTime();

        IMessageModel _message { get; set; }
    }
}