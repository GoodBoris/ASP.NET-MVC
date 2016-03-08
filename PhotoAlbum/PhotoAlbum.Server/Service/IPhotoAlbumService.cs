using System;
using System.ServiceModel;
using System.Threading.Tasks;
using PhotoAlbum.DAL.Utilities;
using Service.Messages.Photo;
using Service.Utilities.PhotoAlbum;

namespace Service
{
    //Service for working with Photo Album
    [ServiceContract]
    public interface IPhotoAlbumService
    {
        [OperationContract]
        [FaultContract(typeof(CustomExpMsg))]
        Task<Guid> CreatePhotoAsync(PhotoDescriptionDto photoDescription);

        [OperationContract]
        [FaultContract(typeof(CustomExpMsg))]
        Task<Guid> DeletePhotoAsync(Guid photoId);

        [OperationContract]
        [FaultContract(typeof(CustomExpMsg))]
        Task<Guid> UpdatePhotoAsync(PhotoDescriptionDto photoDescription);

        [OperationContract]
        [FaultContract(typeof(CustomExpMsg))]
        Task<float> AddVoteAsync(Guid photoId, float vote);

        [OperationContract]
        [FaultContract(typeof(CustomExpMsg))]
        Task<int> CountPhotosByIdAsync(string userId);

        [OperationContract]
        [FaultContract(typeof(CustomExpMsg))]
        Task<int> CountPhotosByUserNameAsync(string userName);

        [OperationContract(Name = "GetPhotosByOrder")]
        [FaultContract(typeof(CustomExpMsg))]
        PhotoDescriptionDto[] GetPhotos(int currentPage, int pageSize, string userName, OrderBy orderBy);

        [OperationContract(Name = "GetPhotosByDefaultOrder")]
        [FaultContract(typeof(CustomExpMsg))]
        PhotoDescriptionDto[] GetPhotos(int currentPage, int pageSize, string userName);

        [OperationContract]
        PhotoDescriptionDto FindPhotoById(Guid photoId);
    }
}
