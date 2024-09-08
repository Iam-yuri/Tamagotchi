using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Tamagotchi.View;


namespace TamagotchiPokemon
{
    public class MascotMapping : Profile
    {
        public MascotMapping()
        {
            CreateMap<Mascot, MascotDTO>()
                .ForMember(dest => dest.Nickname, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.MascotHeight, opt => opt.MapFrom(src => src.Height))
                .ForMember(dest => dest.MascotWeight, opt => opt.MapFrom(src => src.Weight));
        }
    }
}
