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
            var query = await _dbContext.Ocupation.ToListAsync();

            return _mapper.Map<List<OcupationDTO>>(query);
        }
        public Task<OcupationDTO> _GET(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<OcupationDTO> _POST(OcupationDTO ocupation)
        {
            var newOcupation = _mapper.Map<Ocupations>(ocupation);
            _dbContext.Ocupation.Add(newOcupation);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<OcupationDTO>(newOcupation);
        }

        public Task<bool> _PUT(OcupationDTO ocupation, int id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> _DELETE(int id)
        {
            throw new NotImplementedException();
        }
    }
}
