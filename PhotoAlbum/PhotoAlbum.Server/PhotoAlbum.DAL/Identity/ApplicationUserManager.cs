using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PhotoAlbum.DAL.Identity
{
    public class ApplicationUserManager<TUser> : UserManager<TUser> where TUser : IdentityUser
    {
        public ApplicationUserManager(IUserStore<TUser> store) : base(store)
        {

        }
    }
}