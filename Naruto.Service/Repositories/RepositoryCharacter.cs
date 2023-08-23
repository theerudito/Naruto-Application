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
            var query = await _dbContext.Characters

             .ToListAsync();

            return query != null ? _mapper.Map<List<CharacterDTO>>(query) : null!;
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
                _dbContext.Characters.Remove(query);

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
            var query = _dbContext.Characters
                .Include(c => c.Clan)
                .Where(c => c.FirstName.Contains(field))
                .ToListAsync();

            if (query != null)
            {
                return _mapper.Map<List<CharacterDTO>>(await query);
            }
            else
            {

                var query2 = _dbContext.Characters.ToListAsync();

                return _mapper.Map<List<CharacterDTO>>(query2);
            }
        }
    }
}
