using System;
using System.Collections.Generic;
using System.Text;

namespace Campeonato.Model
{
    public class PorEstadoModel : ModelBase, IModelBase, IPorEstadoModel
    {
        public string Estado { get; set; }
    }
}
