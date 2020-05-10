using AutoMapper;
using Campeonato.Data;
using Campeonato.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campeonato.Api
{
    class ForTimeProfile : Profile
    {
        public ForTimeProfile()
        {
            CreateMap<Pontuacao, PorTimeModel>()
                .ForMember(dest =>
                dest.TimeNome,
                opt => opt.MapFrom(src => src.Clube.Nome));
        }
    }
}
