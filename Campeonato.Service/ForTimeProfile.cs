using AutoMapper;
using Campeonato.Data;
using Campeonato.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campeonato.Service
{
    class ForTimeProfile : Profile
    {
        public ForTimeProfile()
        {
            CreateMap<Pontuacao, PorTimeModel>();
        }
    }
}
