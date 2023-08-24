using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Naruto.Data;
using Naruto.Models.DTO;
using Naruto.Models.Model;

namespace Naruto.Service.Repositories
{
    public class RepositoryVillage
    {
        private readonly Application_ContextDB _dbContext;
        private readonly IMapper _mapper;
        public RepositoryVillage(Application_ContextDB dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<VillagesDTO>> _GETS()
        {
            var query = await _dbContext.Village.Where(c => c.Status == true).ToListAsync();

            return _mapper.Map<List<VillagesDTO>>(query);
        }
        public async Task<VillagesDTO> _GET(int id)
        {
            var query = await _dbContext.Village.Where(c => c.Status == true && c.IdVillage == id).FirstOrDefaultAsync();

            return _mapper.Map<VillagesDTO>(query);
        }
        public async Task<VillagesDTO> _POST(VillagesDTO villages)
        {
            var newVillage = _mapper.Map<Villages>(villages);

            _dbContext.Village.Add(newVillage);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<VillagesDTO>(newVillage);
        }
        public async Task<bool> _PUT(VillagesDTO villages, int id)
        {
            var query = await _dbContext.Village.Where(c => c.IdVillage == id).FirstOrDefaultAsync();

            if (query != null)
            {
                query.VillageName = villages.VillageName;
                query.Status = true;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> _DELETE(int id)
        {
            var query = await _dbContext.Village.Where(c => c.IdVillage == id).FirstOrDefaultAsync();
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
