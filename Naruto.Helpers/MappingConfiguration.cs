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
            CreateMap<Character, CharacterDTO>().ForMember(dest => dest.NameClan, opt => opt.MapFrom(src => src.Clan.ClanName));

            CreateMap<ClanDTO, Clan>();
            CreateMap<Clan, ClanDTO>();
        }
    }
}
