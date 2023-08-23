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
            var query = await _dbContext.Village.ToListAsync();

            return _mapper.Map<List<VillagesDTO>>(query);
        }
        public Task<VillagesDTO> _GET(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<VillagesDTO> _POST(VillagesDTO villages)
        {
            var newVillage = _mapper.Map<Villages>(villages);

            _dbContext.Village.Add(newVillage);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<VillagesDTO>(newVillage);
        }

        public Task<bool> _PUT(VillagesDTO villages, int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> _DELETE(int id)
        {
            throw new NotImplementedException();
        }
    }
}
