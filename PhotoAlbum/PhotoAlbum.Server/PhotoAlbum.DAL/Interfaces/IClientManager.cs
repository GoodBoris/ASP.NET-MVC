using System.Threading.Tasks;
using PhotoAlbum.DAL.Entities;

namespace PhotoAlbum.DAL.Interfaces
{
    public interface IClientManager : IGenericRepository<ClientProfile>
    {
        Task<ClientProfile> GetByIdAsync(string id);
        Task<ClientProfile> GetByUserNameAsync(string userName);
    }
}