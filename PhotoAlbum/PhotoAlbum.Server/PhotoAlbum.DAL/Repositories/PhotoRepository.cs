using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces;
using PhotoAlbum.DAL.Utilities;

namespace PhotoAlbum.DAL.Repositories
{
    public class PhotoRepository : BaseRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(IdentityDbContext<ApplicationUser> database) : base(database) { }

        public Image GetImage(Guid photoId) => FindById(photoId)?.Image;

        public Photo FindById(Guid photoId) => FindBy(x => x.Id == photoId).FirstOrDefault();

        public IEnumerable<Photo> GetPhotos(int page, int pageSize, string userName, OrderBy orderBy)
        {
            var userPhotos =
                Database.Set<Photo>().Where(p => string.IsNullOrEmpty(userName) || p.ClientProfile.UserName == userName);
            IOrderedQueryable<Photo> sortedPhotos;
            switch (orderBy)
            {
                case OrderBy.Raiting:
                    sortedPhotos = userPhotos.OrderByDescending(
                        item => (!item.Votes.Any()) ? 0 : item.Votes.Average(vote => vote.NodeVote));
                    break;
                default:
                    sortedPhotos = userPhotos.OrderByDescending(item => item.TimeOfCreation);
                    break;
            }
            return sortedPhotos.Skip((page - 1)*pageSize).Take(pageSize);
        }

        public async Task<int> CountByIdAsync(string userId) => 
            await Database.Set<Photo>().Where(photo => photo.ClientProfileId == userId).CountAsync();

        public async Task<int> CountByUserNameAsync(string userName) =>
            await Database.Set<Photo>().Where(photo => photo.ClientProfile.UserName == userName).CountAsync();
    }
}