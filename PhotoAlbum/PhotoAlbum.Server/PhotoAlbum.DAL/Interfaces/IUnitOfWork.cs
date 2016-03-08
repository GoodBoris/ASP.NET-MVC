using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PhotoAlbum.DAL.Interfaces
{
    public interface IUnitOfWork : IUserRepository, IDisposable
    {
        IPhotoRepository PhotoRepository { get; }
        IClientManager ClientManager { get; }
        DbSet<T> Set<T>() where T : class;
        Task CommitAsync();
        void Commit();
    }
}