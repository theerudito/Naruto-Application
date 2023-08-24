using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Naruto.Data;
using Naruto.Models.DTO;
using Naruto.Models.Model;
using Naruto.Service.Interface;

namespace Naruto.Service.Repositories
{
    public class RepositoryCharacter : ICharacter
    {
        private readonly Application_ContextDB _dbContext;
        private readonly IMapper _mapper;

        public RepositoryCharacter(Application_ContextDB dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<CharacterDTO>> _GETS()
        {
            var query = from character in _dbContext.Characters
                        join clan in _dbContext.Clan on character.IdClan equals clan.IdClan
                        join ocupation in _dbContext.Ocupation on character.IdOcupation equals ocupation.IdOcupation
                        join jutsu in _dbContext.Jutsu on character.IdJutsu equals jutsu.IdJutsu
                        join village in _dbContext.Village on character.IdVillage equals village.IdVillage
                        join status in _dbContext.Current on character.IdStatus equals status.IdStatus
                        where character.Status == true
                        select new CharacterDTO
                        {
                            IdCharacter = character.IdCharacter,
                            FirstName = character.FirstName,
                            Image = character.Image,
                            RefImage = character.RefImage,
                            Age = character.Age,
                            NameClan = clan.ClanName!,
                            NameVillage = village.VillageName!,
                            NameOcupation = ocupation.OcupationName!,
                            NameJutsu = jutsu.JutsuName!,
                            Status = character.Status,
                            Alive = status.Alive,


                        };
            return await query.ToListAsync();
        }
        public async Task<CharacterDTO> _GET(int id)
        {
            var query = await _dbContext.Characters
             .Include(c => c.Clan)
             .Include(o => o.Ocupations)
             .Include(v => v.Villages)
             .Include(s => s.Current)
             .Include(c => c.Jutsus)
             .Where(i => i.IdCharacter == id)
             .FirstOrDefaultAsync();

            return query != null ? _mapper.Map<CharacterDTO>(query) : null!;
        }
        public async Task<CharacterDTO> _POST(CharacterDTO character)
        {
            var query = await _dbContext.Characters
                .Where(c => c.FirstName == character.FirstName)
                .FirstOrDefaultAsync();

            if (query == null)
            {
                var newCharacter = _mapper.Map<Character>(character);

                _dbContext.Add(newCharacter);

                await _dbContext.SaveChangesAsync();

                return _mapper.Map<CharacterDTO>(newCharacter);
            }
            else
            {
                return null!;
            }
        }
        public async Task<bool> _PUT(CharacterDTO character, int id)
        {
            var query = await _dbContext.Characters
                .Where(c => c.IdCharacter == id)
                .FirstOrDefaultAsync();

            if (query != null)
            {
                query.FirstName = character.FirstName;
                query.Image = character.Image;
                query.RefImage = character.RefImage;
                query.Age = character.Age;
                query.IdClan = character.IdClan;
                query.IdJutsu = character.IdJutsu;
                query.IdOcupation = character.IdOcupation;
                query.IdStatus = character.IdStatus;
                query.IdVillage = character.IdVillage;

                _dbContext.Characters.Update(query);

                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> _DELETE(int id)
        {
            var query = await _dbContext.Characters
                .Where(c => c.IdCharacter == id)
                .FirstOrDefaultAsync();

            if (query != null)
            {

                query.Status = false;

                await _dbContext.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<List<CharacterDTO>> _SEACHING(string field)
        {
            var query = from character in _dbContext.Characters
                        join clan in _dbContext.Clan on character.IdClan equals clan.IdClan
                        join ocupation in _dbContext.Ocupation on character.IdOcupation equals ocupation.IdOcupation
                        join jutsu in _dbContext.Jutsu on character.IdJutsu equals jutsu.IdJutsu
                        join village in _dbContext.Village on character.IdVillage equals village.IdVillage
                        join status in _dbContext.Current on character.IdStatus equals status.IdStatus
                        where character.FirstName.Contains(field)
                                || clan.ClanName.Contains(field)
                                || ocupation.OcupationName.Contains(field)
                                || jutsu.JutsuName.Contains(field)
                                || village.VillageName.Contains(field)
                                && character.Status == true
                        select new CharacterDTO
                        {
                            IdCharacter = character.IdCharacter,
                            FirstName = character.FirstName,
                            Image = character.Image,
                            RefImage = character.RefImage,
                            Age = character.Age,
                            NameClan = clan.ClanName!,
                            NameVillage = village.VillageName!,
                            NameOcupation = ocupation.OcupationName!,
                            NameJutsu = jutsu.JutsuName!,
                            Alive = status.Alive,
                            Status = character.Status,
                        };
            return await query.ToListAsync();
        }
    }
}
