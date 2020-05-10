using System;
using System.Collections.Generic;
using System.Text;

namespace Campeonato.Data
{
    public class Clube : IClube
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }

    }
}
