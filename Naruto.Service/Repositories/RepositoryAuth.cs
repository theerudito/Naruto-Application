using Microsoft.EntityFrameworkCore;
using Naruto.Data;
using Naruto.Helpers;
using Naruto.Models.Model;

namespace Naruto.Service.Repositories
{
    public class RepositoryAuth
    {
        private readonly Application_ContextDB _dbContext;
        public RepositoryAuth(Application_ContextDB dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> _REGISTER(Auth auth)
        {
            var query = await _dbContext.Auth.FirstOrDefaultAsync(x => x.Username == auth.Username);

            if (query == null)
            {
                var newUser = new Auth
                {
                    Username = auth.Username,
                    Password = BCriptManager._Hash(auth.Password),
                    Email = auth.Email,
                };

                await _dbContext.Auth.AddAsync(newUser);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<bool> _LOGIN(Auth Auth)
        {
            var query = await _dbContext.Auth.FirstOrDefaultAsync(x => x.Username == Auth.Username);
            if (query != null)
            {
                if (BCriptManager._Verify(Auth.Password, query.Password) == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
