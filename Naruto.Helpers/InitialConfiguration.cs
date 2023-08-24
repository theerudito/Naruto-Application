using Microsoft.EntityFrameworkCore;
using Naruto.Data;
using Naruto.Models.Model;

namespace Naruto.Helpers
{
    public class InitialConfiguration
    {
        private int idInitial = 1;
        private readonly Application_ContextDB _dbContext;
        public InitialConfiguration(Application_ContextDB dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DefaultData()
        {
            await AddClan();
            await AddJutsu();
            await AddOcupation();
            await AddVillage();
            await AddStatus();
            await AddCharacter();
        }

        public async Task AddClan()
        {
            var query = await _dbContext.Clan.FirstOrDefaultAsync(x => x.IdClan == idInitial);

            if (query != null)
                return;
            else
            {
                var clan = new Clan
                {
                    IdClan = idInitial,
                    ClanName = "Uzumaki",
                    Image = "https://res.cloudinary.com/erudito/image/upload/v1692840384/clan/ClanUzumaki.webp",
                    Status = true
                };

                _dbContext.Clan.Add(clan);
                await _dbContext.SaveChangesAsync();
            }

        }
        public async Task AddJutsu()
        {
            var query = await _dbContext.Jutsu.FirstOrDefaultAsync(x => x.IdJutsu == idInitial);

            if (query != null)
                return;
            else
            {
                var jutsu = new Jutsus
                {
                    IdJutsu = idInitial,
                    JutsuName = "Rasengan",
                    Status = true
                };

                _dbContext.Jutsu.Add(jutsu);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task AddOcupation()
        {
            var query = await _dbContext.Village.FirstOrDefaultAsync(x => x.IdVillage == idInitial);

            if (query != null)
                return;
            {
                var ocupation = new Ocupations
                {
                    IdOcupation = idInitial,
                    OcupationName = "Hokage",
                    Status = true
                };

                _dbContext.Ocupation.Add(ocupation);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task AddVillage()
        {
            var query = await _dbContext.Village.FirstOrDefaultAsync(x => x.IdVillage == idInitial);

            if (query != null)
                return;
            {
                var village = new Villages
                {
                    IdVillage = idInitial,
                    VillageName = "Konoha",
                    Status = true
                };

                _dbContext.Village.Add(village);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task AddStatus()
        {
            var query = await _dbContext.Current.FirstOrDefaultAsync(x => x.IdStatus == idInitial || x.IdStatus == 2);

            if (query != null)
                return;
            else
            {
                var status = new List<Current>
                {
                    new Current { IdStatus = 1, Alive = true, Status = true },
                    new Current { IdStatus = 2, Alive = false, Status = true }
                };

                _dbContext.Current.AddRange(status);

                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task AddCharacter()
        {
            var query = await _dbContext.Characters.FirstOrDefaultAsync(x => x.IdCharacter == idInitial);

            if (query != null)
                return;
            else
            {
                var character = new Character
                {
                    IdCharacter = idInitial,
                    FirstName = "Naruto",
                    Age = 17,
                    IdClan = idInitial,
                    IdVillage = idInitial,
                    IdJutsu = idInitial,
                    IdOcupation = idInitial,
                    IdStatus = idInitial,
                    Image = "https://res.cloudinary.com/erudito/image/upload/v1692840322/character/naruto.png",
                    Status = true
                };

                _dbContext.Characters.Add(character);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
