using Campeonato.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campeonato.Test
{
    public class InMemoryCampeonatoControllerTest: CampeonatoControllerTest
    {
        public InMemoryCampeonatoControllerTest()
            : base(
                new DbContextOptionsBuilder<DataContext>()
                    .UseInMemoryDatabase("TestDatabase")
                    .Options)
        {
        }
    }
}
