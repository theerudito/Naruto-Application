using AutoMapper;
using Naruto.Models.DTO;
using Naruto.Models.Model;

namespace Naruto.Helpers
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {

            CreateMap<CharacterDTO, Character>();
            CreateMap<Character, CharacterDTO>()
                .ForMember(dest => dest.NameClan, opt => opt.MapFrom(src => src.Clan.ClanName))
                .ForMember(dest => dest.NameJutsu, opt => opt.MapFrom(src => src.Jutsus.JutsuName))
                .ForMember(dest => dest.NameOcupation, opt => opt.MapFrom(src => src.Ocupations.OcupationName))
                .ForMember(dest => dest.NameVillage, opt => opt.MapFrom(src => src.Villages.VillageName))
                .ForMember(dest => dest.Alive, opt => opt.MapFrom(src => src.Current.Alive));

            CreateMap<ClanDTO, Clan>();
            CreateMap<Clan, ClanDTO>();

            CreateMap<JutsusDTO, Jutsus>();
            CreateMap<Jutsus, JutsusDTO>();

            CreateMap<OcupationDTO, Ocupations>();
            CreateMap<Ocupations, OcupationDTO>();

            CreateMap<CurrentDTO, Current>();
            CreateMap<Current, CurrentDTO>();

            CreateMap<VillagesDTO, Villages>();
            CreateMap<Villages, VillagesDTO>();

        }
    }
}
