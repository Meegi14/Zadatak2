using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Zadatak.Models;
using Zadatak.Dto.UredjajDto;

namespace Zadatak.MapperProfiles
{
    public class UredjajProfile : Profile
    {
        public UredjajProfile()
        {
            CreateMap<Uredjaj, UredjajDtoGet>();
            CreateMap<UredjajDtoPost, Uredjaj>();
            CreateMap<UredjajDtoPut, Uredjaj>();
        }
    }
}
