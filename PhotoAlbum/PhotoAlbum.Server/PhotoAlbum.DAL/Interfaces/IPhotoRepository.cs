using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Utilities;

namespace PhotoAlbum.DAL.Interfaces
{
    public interface IPhotoRepository : IGenericRepository<Photo>
    {
        Photo FindById(Guid photoId);
        Image GetImage(Guid photoId);
        IEnumerable<Photo> GetPhotos(int page, int pageSize, string userName, OrderBy orderBy);
        Task<int> CountByIdAsync(string userId);
        Task<int> CountByUserNameAsync(string userName);
    }
}