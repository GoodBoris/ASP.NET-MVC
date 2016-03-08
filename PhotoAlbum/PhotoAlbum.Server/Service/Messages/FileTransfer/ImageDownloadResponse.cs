using System.IO;
using System.ServiceModel;
using Service.Views.FileTransfer;

namespace Service.Messages.FileTransfer
{
    [MessageContract]
    public class ImageDownloadResponse
    {
        public ImageDownloadResponse(ImageMetaData metaData, Stream stream)
        {
            DownloadedImageMetadata = metaData;
            ImageByteStream = stream;
        }

        [MessageHeader(MustUnderstand = true)]
        public ImageMetaData DownloadedImageMetadata;
        [MessageBodyMember(Order = 1)]
        public Stream ImageByteStream;
    }
}