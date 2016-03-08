using System.IO;
using System.ServiceModel;
using Service.Views.FileTransfer;

namespace Service.Messages.FileTransfer
{
    [MessageContract]
    public class ImageUploadRequest
    {
        [MessageHeader(MustUnderstand = true)]
        public ImageMetaData Metadata;
        [MessageBodyMember(Order = 1)]
        public Stream FileByteStream;
    }
}