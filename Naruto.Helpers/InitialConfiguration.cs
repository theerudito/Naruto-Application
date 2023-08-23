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
            var query = await _dbContext.Characters.FirstOrDefaultAsync(x => x.IdCharacter == idInitial);

            if (query == null)
            {
                var clan = new Clan
                {
                    IdClan = idInitial,
                    ClanName = "Uzumaki",
                    Image = "https://res.cloudinary.com/erudito/image/upload/v1692755904/clan/clanUzumaki.webp",
                    RefImage = "clanUzumaki"
                };

                var jutsu = new Jutsus
                {
                    IdJutsu = idInitial,
                    JutsuName = "Rasengan",
                };

                var village = new Villages
                {
                    IdVillage = idInitial,
                    VillageName = "Konoha",
                };

                var ocupation = new Ocupations
                {
                    IdOcupation = idInitial,
                    OcupationName = "Hokage",
                };

                var status = new Current
                {
                    IdStatus = idInitial,
                    Alive = true
                };

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
                    Image = "https://res.cloudinary.com/erudito/image/upload/v1692755886/character/naruto.png",
                    RefImage = "naruto"
                };

                _dbContext.Clan.Add(clan);
                _dbContext.Jutsu.Add(jutsu);
                _dbContext.Village.Add(village);
                _dbContext.Ocupation.Add(ocupation);
                _dbContext.Current.Add(status);
                _dbContext.Characters.Add(character);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
