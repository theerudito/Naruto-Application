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
            var query = await _dbContext.Jutsu.ToListAsync();

            return _mapper.Map<List<JutsusDTO>>(query);
        }
        public Task<JutsusDTO> _GET(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<JutsusDTO> _POST(JutsusDTO jutsu)
        {
            var nJutsu = _dbContext.Add(_mapper.Map<Jutsus>(jutsu));

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<JutsusDTO>(nJutsu.Entity);
        }

        public Task<bool> _PUT(JutsusDTO jutsu, int id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> _DELETE(int id)
        {
            throw new NotImplementedException();
        }
    }
}
