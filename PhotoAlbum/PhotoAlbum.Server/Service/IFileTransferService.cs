using System.ServiceModel;
using Service.Messages.FileTransfer;

namespace Service
{
    //Service for transfering pictures via stream
    [ServiceContract]
    public interface IFileTransferService
    {

        [OperationContract(IsOneWay = true)]
        void UploadFile(ImageUploadRequest request);

        [OperationContract(IsOneWay = false)]
        ImageDownloadResponse DownloadFile(ImageDownloadRequest request);
    }
}
