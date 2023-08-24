using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Naruto.Data;
using Naruto.Models.DTO;
using Naruto.Models.Model;

namespace Naruto.Service.Repositories
{
    public class RepositoryOcupation
    {

        private readonly Application_ContextDB _dbContext;
        private readonly IMapper _mapper;
        public RepositoryOcupation(Application_ContextDB dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<OcupationDTO>> _GETS()
        {
            var query = await _dbContext.Ocupation.Where(c => c.Status == true).ToListAsync();

            return _mapper.Map<List<OcupationDTO>>(query);
        }
        public async Task<OcupationDTO> _GET(int id)
        {
            var query = await _dbContext.Ocupation.Where(c => c.Status == true && c.IdOcupation == id).FirstOrDefaultAsync();

            return query != null ? _mapper.Map<OcupationDTO>(query) : null!;
        }
        public async Task<OcupationDTO> _POST(OcupationDTO ocupation)
        {
            var newOcupation = _mapper.Map<Ocupations>(ocupation);
            _dbContext.Ocupation.Add(newOcupation);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<OcupationDTO>(newOcupation);
        }
        public async Task<bool> _PUT(OcupationDTO ocupation, int id)
        {
            var query = await _dbContext.Ocupation.Where(c => c.IdOcupation == id).FirstOrDefaultAsync();
            if (query != null)
            {
                query.OcupationName = ocupation.OcupationName;
                query.Status = true;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> _DELETE(int id)
        {
            var query = await _dbContext.Ocupation.Where(c => c.IdOcupation == id).FirstOrDefaultAsync();
            if (query != null)
            {
                query.Status = false;
                await _dbContext.SaveChangesAsync();
                return true;

            }
            return false;
        }
    }
}
