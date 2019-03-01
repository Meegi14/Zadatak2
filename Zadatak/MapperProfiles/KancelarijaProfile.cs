using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadatak.Dto.KancelarijaDto;
using Zadatak.Models;


namespace Zadatak.MapperProfiles
{
    public class KancelarijaProfile : Profile
    {
        public KancelarijaProfile()
        {
            CreateMap<KancelarijaProfile, KancelarijaDtoGet>();
            CreateMap<KancelarijaDtoPost, Kancelarija>();
            CreateMap<KancelarijaDtoPut, Kancelarija>();

        }
    }
}
