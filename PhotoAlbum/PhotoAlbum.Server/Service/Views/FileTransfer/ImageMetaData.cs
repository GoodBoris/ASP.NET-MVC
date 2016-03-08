using System;
using System.Runtime.Serialization;

namespace Service.Views.FileTransfer
{
    [DataContract]
    public class ImageMetaData
    {
        public ImageMetaData(Guid imageId, string imageMimeType)
        {
            ImageId = imageId;
            ImageMimeType = imageMimeType;
        }

        [DataMember(Name = "ImageId", Order = 0, IsRequired = true)]
        public Guid ImageId;
        [DataMember(Name = "ImageMimeType", Order = 1, IsRequired = true)]
        public string ImageMimeType;
    }
}