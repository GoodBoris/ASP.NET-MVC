using System;
using System.ServiceModel;

namespace Service.Messages.FileTransfer
{
    [MessageContract]
    public class ImageDownloadRequest
    {
        [MessageHeader(MustUnderstand = true)]
        public Guid ImageId;
    }
}