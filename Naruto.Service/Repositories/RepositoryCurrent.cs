using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Naruto.Data;
using Naruto.Models.DTO;
using Naruto.Models.Model;

namespace Naruto.Service.Repositories
{
    public class RepositoryCurrent
    {
        private readonly Application_ContextDB _dbContext;
        private readonly IMapper _mapper;
        public RepositoryCurrent(Application_ContextDB dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<CurrentDTO>> _GETS()
        {
            var query = await _dbContext.Current.ToListAsync();

            return _mapper.Map<List<CurrentDTO>>(query);
        }
        public Task<CurrentDTO> _GET(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CurrentDTO> _POST(CurrentDTO status)
        {
            var newStatus = _mapper.Map<Current>(status);
            _dbContext.Current.Add(newStatus);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CurrentDTO>(newStatus);
        }

        public Task<bool> _PUT(CurrentDTO status, int id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> _DELETE(int id)
        {
            throw new NotImplementedException();
        }
    }
}
