using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Naruto.Data;
using Naruto.Models.DTO;
using Naruto.Models.Model;
using Naruto.Service.Interface;

namespace Naruto.Service.Repositories
{
    public class RepositoryClan : IClan
    {
        private readonly Application_ContextDB _dbContext;
        private readonly IMapper _mapper;

        public RepositoryClan(Application_ContextDB dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<ClanDTO>> _GETS()
        {
            var query = await _dbContext.Clan.Where(c => c.Status == true).ToListAsync();

            return query != null
            ? _mapper.Map<List<ClanDTO>>(query)
            : null!;
        }

        public async Task<ClanDTO> _GET(int id)
        {
            var query = await _dbContext.Clan.Where(c => c.IdClan == id && c.Status == true).FirstOrDefaultAsync();

            return query != null
              ? _mapper.Map<ClanDTO>(query)
              : null!;
        }

        public async Task<ClanDTO> _POST(ClanDTO clan)
        {
            var nClan = _dbContext.Add(_mapper.Map<Clan>(clan));

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<ClanDTO>(nClan.Entity);
        }

        public async Task<bool> _PUT(ClanDTO clan, int id)
        {
            try
            {
                var query = await _dbContext.Clan.Where(c => c.IdClan == id).FirstOrDefaultAsync();

                if (query != null)
                {
                    query.ClanName = clan.ClanName;
                    query.Image = clan.Image;
                    query.RefImage = clan.RefImage;
                    query.Status = true;
                    // _dbContext.Update(query);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> _DELETE(int id)
        {
            var query = await _dbContext.Clan.Where(c => c.IdClan == id).FirstOrDefaultAsync();

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
