using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadatak.Models;
using Zadatak.Dto;
using Zadatak.Dto.OsobaDto;

namespace Zadatak.MapperProfiles
{
    public class OsobaProfile : Profile
    {
        public OsobaProfile()
        {

            CreateMap<OsobaProfile, OsobaDtoGet>();
            CreateMap<OsobaDtoPost, Osoba>();
            CreateMap<OsobaDtoPut, Osoba>();

            CreateMap<Kancelarija, GetByKancelarijaDto>().ForMember(a => a.KancelarijaIme, b => b.MapFrom(c => c.Ime)) ;
        }

    }
}
