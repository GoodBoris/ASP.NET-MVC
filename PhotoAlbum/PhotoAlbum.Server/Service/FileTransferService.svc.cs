using System;
using System.IO;
using System.ServiceModel;
using AutoMapper;
using PhotoAlbum.DAL.Entities;
using PhotoAlbum.DAL.Interfaces;
using Service.Messages.FileTransfer;

namespace Service
{
    public class FileTransferService : IFileTransferService
    {
        public FileTransferService(IUnitOfWork database)
        {
            Database = database;
        }

        public void UploadFile(ImageUploadRequest request)
        {
            try
            {
                var photo = Database.PhotoRepository.FindById(request.Metadata.ImageId);
                Mapper.Map(request, photo);
                Database.PhotoRepository.Update(photo);
                Database.Commit();
            }
            catch (Exception e)
            {
                throw new FaultException(e.Message, new FaultCode("TRANSFER"));
            }
        }

        public ImageDownloadResponse DownloadFile(ImageDownloadRequest request)
        {
            try
            {
                var image = Database.PhotoRepository.GetImage(request.ImageId);
                if (image?.ImageMimeType == null)
                {
                    throw new FileNotFoundException("No image in database");
                }
                var response = Mapper.Map<Image, ImageDownloadResponse>(image);
                return response;
            }
            catch (Exception e)
            {
                throw new FaultException(e.Message, new FaultCode("TRANSFER"));
            }
        }
        private IUnitOfWork Database { get; }
    }
}
