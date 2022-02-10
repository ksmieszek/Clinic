using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Przychodnia.App.Models;
using Przychodnia.Data.Entities;

namespace Przychodnia.App.Mappers
{
    public class LekarzMappingProfile : Profile
    {
        public LekarzMappingProfile()
        {
            CreateMap<Uzytkownik, LekarzeDto>()
                .ForMember(x => x.Imie, c => c.MapFrom(s => s.Imie))
                .ForMember(x => x.Nazwisko, c=>c.MapFrom(f=>f.Nazwisko))
                .ForMember(c=>c.Specjalizacja, d=>d.MapFrom(s=>s.Specjalizacje.Nazwa))
                .ForMember(c=>c.Id , d=>d.MapFrom(f=>f.Id));
        }
    }
}
