using Microsoft.AspNet.Identity;
using PhotoAlbum.DAL.Entities;

namespace PhotoAlbum.DAL.Interfaces
{
    public interface IUserRepository
    {
        UserManager<ApplicationUser> UserManager { get; }
        RoleManager<ApplicationRole> RoleManager { get; }
    }
}