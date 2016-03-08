using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces;

namespace PhotoAlbum.DAL.Repositories
{
    public class ClientManager : BaseRepository<ClientProfile>, IClientManager
    {
        public ClientManager(IdentityDbContext<ApplicationUser> database) : base(database) { }

        public async Task<ClientProfile> GetByIdAsync(string id) => 
            await Database.Set<ClientProfile>().FirstOrDefaultAsync(clientProfile => clientProfile.Id == id);

        public async Task<ClientProfile> GetByUserNameAsync(string userName) => 
            await Database.Set<ClientProfile>().FirstOrDefaultAsync(clientProfile => clientProfile.UserName == userName);
    }
}