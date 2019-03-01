using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Zadatak.Models;
using Zadatak.Dto.OsobaUredjajDto;

namespace Zadatak.MapperProfiles
{
    public class OsobaUredjajProfile : Profile
    {
        public OsobaUredjajProfile()
        {
            CreateMap<OsobaUredjaj, OsobaUredjajDtoGet>()
                .ForMember(a => a.Uredjaj, b => b.MapFrom(c => c.Uredjaj.Ime))
                .ForMember(a => a.Osoba, b => b.MapFrom(c => c.Osoba.Ime + " " + c.Osoba.Prezime));

            CreateMap<OsobaUredjaj, VrijemeOsobaUredjajDto>()
                .ForMember(a => a.VrijemeOd, b => b.MapFrom(c => c.VrijemeOd))
                .ForMember(a => a.VrijemDo, b => b.MapFrom(c => c.VrijemeDo));

            CreateMap<OsobaUredjaj, VrijemeOsobaUredjajDtoGet>()
                .ForMember(a => a.Uredjaj, b => b.MapFrom(c => c.Uredjaj.Ime));

            CreateMap<OsobaUredjaj, VrijemePoOsobiDto>()
                .ForMember(a => a.Uredjaj, b => b.MapFrom(c => c.Uredjaj.Ime))
                .ForMember(a => a.VrijemeKoriscenja, b => b.MapFrom(c => c.VrijemeOd));

               


        }
    }
}
