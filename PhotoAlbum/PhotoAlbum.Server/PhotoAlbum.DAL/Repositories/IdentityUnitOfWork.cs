using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces;

namespace PhotoAlbum.DAL.Repositories
{
    public class IdentityUnitOfWork : IUnitOfWork
    {

        private readonly IdentityDbContext<ApplicationUser> _db;
        private bool _disposed;

        public IdentityUnitOfWork(UserManager<ApplicationUser> userManager, IClientManager clientManager, 
            RoleManager<ApplicationRole> roleManager, IdentityDbContext<ApplicationUser> db, IPhotoRepository photoRepository)
        {
            UserManager = userManager;
            ClientManager = clientManager;
            RoleManager = roleManager;
            _db = db;
            PhotoRepository = photoRepository;
        }

        public DbSet<T> Set<T>() where T : class => _db.Set<T>();

        public async Task CommitAsync() => await _db.SaveChangesAsync();

        public void Commit() => _db.SaveChanges();

        public void Dispose()   
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                UserManager.Dispose();
                RoleManager.Dispose();
                ClientManager.Dispose();
            }
            _disposed = true;
        }

        public UserManager<ApplicationUser> UserManager { get; }
        public IClientManager ClientManager { get; }
        public RoleManager<ApplicationRole> RoleManager { get; }
        public IPhotoRepository PhotoRepository { get; }
    }
}