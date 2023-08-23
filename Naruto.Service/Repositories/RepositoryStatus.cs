using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Naruto.Data;
using Naruto.Models.DTO;
using Naruto.Models.Model;

namespace Naruto.Service.Repositories
{
    public class RepositoryStatus
    {
        private readonly Application_ContextDB _dbContext;
        private readonly IMapper _mapper;
        public RepositoryStatus(Application_ContextDB dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<StatusDTO>> _GETS()
        {
            var query = await _dbContext.Status.ToListAsync();

            return _mapper.Map<List<StatusDTO>>(query);
        }
        public Task<StatusDTO> _GET(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<StatusDTO> _POST(StatusDTO status)
        {
            var newStatus = _mapper.Map<Status>(status);
            _dbContext.Status.Add(newStatus);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<StatusDTO>(newStatus);
        }

        public Task<bool> _PUT(StatusDTO status, int id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> _DELETE(int id)
        {
            throw new NotImplementedException();
        }
    }
}
