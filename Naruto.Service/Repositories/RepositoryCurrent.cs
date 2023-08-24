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
            var query = await _dbContext.Current.Where(c => c.Status == true).ToListAsync();

            return _mapper.Map<List<CurrentDTO>>(query);
        }
        public async Task<CurrentDTO> _GET(int id)
        {
            var query = await _dbContext.Current.Where(c => c.Status == true && c.IdStatus == id).FirstOrDefaultAsync();
            return _mapper.Map<CurrentDTO>(query);
        }
        public async Task<CurrentDTO> _POST(CurrentDTO status)
        {
            var newStatus = _mapper.Map<Current>(status);
            _dbContext.Current.Add(newStatus);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CurrentDTO>(newStatus);
        }
        public async Task<bool> _PUT(CurrentDTO status, int id)
        {
            var query = await _dbContext.Current.Where(c => c.IdStatus == id).FirstOrDefaultAsync();

            if (query != null)
            {
                query.Alive = status.Alive;
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
            var query = await _dbContext.Current.Where(c => c.IdStatus == id).FirstOrDefaultAsync();

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
