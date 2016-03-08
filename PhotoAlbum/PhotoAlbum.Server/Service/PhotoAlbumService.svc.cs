using System;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using AutoMapper;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces;
using PhotoAlbum.DAL.Utilities;
using Service.Messages.Photo;
using Service.Utilities.PhotoAlbum;

namespace Service
{
    public class PhotoAlbumService : IPhotoAlbumService
    {
        public PhotoAlbumService(IUnitOfWork database)
        {
            Database = database;
        }

        //It would be better to get photos by User Id not by User Name. 
        //But it is more convenient for implementing 2.3 paragraph of technical specifications.
        //By the way User Name is unique member too
        //See the client side.
        public PhotoDescriptionDto[] GetPhotos(int currentPage, int pageSize, string userName, OrderBy orderBy)
        {
            try
            {
                var photos = Database.PhotoRepository.GetPhotos(currentPage, pageSize, userName, orderBy).ToArray();
                var response = new PhotoDescriptionDto[photos.Count()];
                var position = 0;
                foreach (var photo in photos)
                {
                    response.SetValue(Mapper.Map<Photo, PhotoDescriptionDto>(photo), position);
                    position++;
                }
                return response;
            }
            catch (Exception e)
            {
                var customMsg = new CustomExpMsg(e.Message);
                throw new FaultException<CustomExpMsg>(customMsg, new
                FaultReason(customMsg.ErrorMsg), new FaultCode("GET"));
            }
        }

        public PhotoDescriptionDto[] GetPhotos(int currentPage, int pageSize, string userName) =>
            GetPhotos(currentPage, pageSize, userName, OrderBy.TimeOfCreation);


        public async Task<Guid> CreatePhotoAsync(PhotoDescriptionDto photoDescriptionDto)
        {
            var newPhotoId = new PrimitiveTypeWrapper<Guid>();
            return await SurroundWithTryCatchAsync(async () =>
            {
                var photo = Database.PhotoRepository.Add(Mapper.Map<PhotoDescriptionDto, Photo>(photoDescriptionDto));
                await Database.CommitAsync();
                newPhotoId.Value = photo.Id;
            }, newPhotoId);
        }

        public async Task<Guid> DeletePhotoAsync(Guid photoId)
        {
            var deletedPhotoId = new PrimitiveTypeWrapper<Guid>();
            return await SurroundWithTryCatchAsync(async () =>
            {
                var photo = Database.PhotoRepository.FindById(photoId);
                Database.PhotoRepository.Delete(photo);
                await Database.CommitAsync();
                deletedPhotoId.Value = photo.Id;
            }, deletedPhotoId);
        }

        public async Task<Guid> UpdatePhotoAsync(PhotoDescriptionDto photoDescription)
        {
            var updatedPhotoId = new PrimitiveTypeWrapper<Guid>();
            return await SurroundWithTryCatchAsync(async () =>
            {
                var oldPhoto = Database.PhotoRepository.FindById(photoDescription.PhotoId);
                Mapper.Map(photoDescription, oldPhoto);
                Database.PhotoRepository.Update(oldPhoto);
                await Database.CommitAsync();
                updatedPhotoId.Value = oldPhoto.Id;
            }, updatedPhotoId);
        }

        public async Task<float> AddVoteAsync(Guid photoId, float vote)
        {

            var newAverageVote = new PrimitiveTypeWrapper<float>();
            return await SurroundWithTryCatchAsync(async () =>
            {
                var oldPhoto = Database.PhotoRepository.FindById(photoId);
                oldPhoto.Votes.Add(new Vote { PhotoId = oldPhoto.Id, NodeVote = vote });
                Database.PhotoRepository.Update(oldPhoto);
                await Database.CommitAsync();
                newAverageVote.Value = oldPhoto.Votes.Average(x => x.NodeVote);
            }, newAverageVote);
        }

        public async Task<int> CountPhotosByIdAsync(string userId)
        {
            var amount = new PrimitiveTypeWrapper<int>();
            return string.IsNullOrEmpty(userId)
                ? await SurroundWithTryCatchAsync(async () => amount.Value = await Database.PhotoRepository.CountAsync(), amount)
                : await SurroundWithTryCatchAsync(async () => amount.Value = await Database.PhotoRepository.CountByIdAsync(userId), amount);
        }

        public async Task<int> CountPhotosByUserNameAsync(string userName)
        {
            var amount = new PrimitiveTypeWrapper<int>();
            return string.IsNullOrEmpty(userName)
                ? await SurroundWithTryCatchAsync(async () => amount.Value = await Database.PhotoRepository.CountAsync(), amount)
                : await SurroundWithTryCatchAsync(async () => amount.Value = await Database.PhotoRepository.CountByIdAsync(userName), amount);
        }

        public PhotoDescriptionDto FindPhotoById(Guid photoId) =>
            Mapper.Map<Photo, PhotoDescriptionDto>(Database.PhotoRepository.FindById(photoId));

        #region helpers

        private async Task<T> SurroundWithTryCatchAsync<T>(Func<Task> t, T value)
        {
            try
            {
                await t();
                return value;
            }
            catch (Exception e)
            {
                //Get the most detaile exception
                if (e.InnerException != null)
                    while (e.InnerException != null)
                        e = e.InnerException;
                var customMsg = new CustomExpMsg(e.Message);
                throw new FaultException<CustomExpMsg>(customMsg, new
                FaultReason(customMsg.ErrorMsg), new FaultCode("CRUD"));
            }
        }

        #endregion

        private IUnitOfWork Database { get; }
    }


}
