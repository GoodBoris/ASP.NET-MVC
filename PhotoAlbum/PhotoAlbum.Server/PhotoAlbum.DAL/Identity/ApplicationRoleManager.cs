using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PhotoAlbum.DAL.Identity
{
    public class ApplicationRoleManager<TRole> : RoleManager<TRole> where TRole : IdentityRole
    {
        public ApplicationRoleManager(IRoleStore<TRole, string> store) : base(store)
        {

        }
    }
}