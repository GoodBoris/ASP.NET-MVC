using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PhotoAlbum.DAL.Entities;

namespace PhotoAlbum.DAL.EF
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            //Add admin role to database
            var adminRole = new IdentityRole("admin");
            context.Roles.AddOrUpdate(r => r.Name, new ApplicationRole { Id = adminRole.Id, Name = adminRole.Name });

            //Add another roles
            var userRole = new IdentityRole("user");
            context.Roles.AddOrUpdate(r => r.Name, new ApplicationRole { Id = userRole.Id, Name = userRole.Name });

            //Create Admin user
            var passwordHash = new PasswordHasher().HashPassword("Spocuzo12");
            var admin = new ApplicationUser
            {
                UserName = "Boris",
                PasswordHash = passwordHash,
                PhoneNumber = "+79831395246",
                Email = "boris.illarionov@gmail.com",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            admin.ClientProfile = new ClientProfile { Id = admin.Id, UserName = "Boris", FullName = "Boris Illarionov" };
            admin.Roles.Add(new IdentityUserRole { RoleId = adminRole.Id, UserId = admin.Id });

            context.Users.AddOrUpdate(u => u.UserName, admin);
            base.Seed(context);
        }
    }
}