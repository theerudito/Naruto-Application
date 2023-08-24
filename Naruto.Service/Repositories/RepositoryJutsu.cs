using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Naruto.Data;
using Naruto.Models.DTO;
using Naruto.Models.Model;

namespace Naruto.Service.Repositories
{
    public class RepositoryJutsu
    {
        private readonly Application_ContextDB _dbContext;
        private readonly IMapper _mapper;
        public RepositoryJutsu(Application_ContextDB dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<JutsusDTO>> _GETS()
        {
            var query = await _dbContext.Jutsu.Where(c => c.Status == true).ToListAsync();

            return _mapper.Map<List<JutsusDTO>>(query);
        }
        public async Task<JutsusDTO> _GET(int id)
        {
            var query = await _dbContext.Jutsu.Where(c => c.Status == true && c.IdJutsu == id).FirstOrDefaultAsync();

            return _mapper.Map<JutsusDTO>(query);
        }
        public async Task<JutsusDTO> _POST(JutsusDTO jutsu)
        {
            var nJutsu = _dbContext.Add(_mapper.Map<Jutsus>(jutsu));

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<JutsusDTO>(nJutsu.Entity);
        }
        public async Task<bool> _PUT(JutsusDTO jutsu, int id)
        {
            var query = await _dbContext.Jutsu.Where(c => c.IdJutsu == id).FirstOrDefaultAsync();

            if (query != null)
            {
                query.JutsuName = jutsu.JutsuName;
                query.Status = true;
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
            var query = await _dbContext.Jutsu.Where(c => c.IdJutsu == id).FirstOrDefaultAsync();
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
    }
}
