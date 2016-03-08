using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using PhotoAlbum.DAL.Entities;

namespace PhotoAlbum.DAL.EF
{
    public class ApplicationContext: IdentityDbContext<ApplicationUser>
    {
        static ApplicationContext()
        {
            Database.SetInitializer(new DbInitializer()); 
        }

        public ApplicationContext(string conectionString) : base(conectionString) {  }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ClientProfile>();
            modelBuilder.Entity<Image>()
                .HasKey(key => key.Id);
            modelBuilder.Entity<Photo>()
                .HasOptional(s => s.Image)
                .WithRequired(s => s.Photo)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Vote>();
        }
    }
}