﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhotoAlbum.WEB.FileTransferService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ImageMetaData", Namespace="http://schemas.datacontract.org/2004/07/Service.Views.FileTransfer")]
    [System.SerializableAttribute()]
    public partial class ImageMetaData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private System.Guid ImageIdField;
        
        private string ImageMimeTypeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public System.Guid ImageId {
            get {
                return this.ImageIdField;
            }
            set {
                if ((this.ImageIdField.Equals(value) != true)) {
                    this.ImageIdField = value;
                    this.RaisePropertyChanged("ImageId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string ImageMimeType {
            get {
                return this.ImageMimeTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.ImageMimeTypeField, value) != true)) {
                    this.ImageMimeTypeField = value;
                    this.RaisePropertyChanged("ImageMimeType");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FileTransferService.IFileTransferService")]
    public interface IFileTransferService {
        
        // CODEGEN: Контракт генерации сообщений с именем упаковщика (ImageUploadRequest) сообщения ImageUploadRequest не соответствует значению по умолчанию (UploadFile).
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IFileTransferService/UploadFile")]
        void UploadFile(PhotoAlbum.WEB.FileTransferService.ImageUploadRequest request);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IFileTransferService/UploadFile")]
        System.Threading.Tasks.Task UploadFileAsync(PhotoAlbum.WEB.FileTransferService.ImageUploadRequest request);
        
        // CODEGEN: Контракт генерации сообщений с именем упаковщика (ImageDownloadRequest) сообщения ImageDownloadRequest не соответствует значению по умолчанию (DownloadFile).
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileTransferService/DownloadFile", ReplyAction="http://tempuri.org/IFileTransferService/DownloadFileResponse")]
        PhotoAlbum.WEB.FileTransferService.ImageDownloadResponse DownloadFile(PhotoAlbum.WEB.FileTransferService.ImageDownloadRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IFileTransferService/DownloadFile", ReplyAction="http://tempuri.org/IFileTransferService/DownloadFileResponse")]
        System.Threading.Tasks.Task<PhotoAlbum.WEB.FileTransferService.ImageDownloadResponse> DownloadFileAsync(PhotoAlbum.WEB.FileTransferService.ImageDownloadRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImageUploadRequest", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImageUploadRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public PhotoAlbum.WEB.FileTransferService.ImageMetaData Metadata;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.IO.Stream FileByteStream;
        
        public ImageUploadRequest() {
        }
        
        public ImageUploadRequest(PhotoAlbum.WEB.FileTransferService.ImageMetaData Metadata, System.IO.Stream FileByteStream) {
            this.Metadata = Metadata;
            this.FileByteStream = FileByteStream;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImageDownloadRequest", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImageDownloadRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public System.Guid ImageId;
        
        public ImageDownloadRequest() {
        }
        
        public ImageDownloadRequest(System.Guid ImageId) {
            this.ImageId = ImageId;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImageDownloadResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImageDownloadResponse {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public PhotoAlbum.WEB.FileTransferService.ImageMetaData DownloadedImageMetadata;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.IO.Stream ImageByteStream;
        
        public ImageDownloadResponse() {
        }
        
        public ImageDownloadResponse(PhotoAlbum.WEB.FileTransferService.ImageMetaData DownloadedImageMetadata, System.IO.Stream ImageByteStream) {
            this.DownloadedImageMetadata = DownloadedImageMetadata;
            this.ImageByteStream = ImageByteStream;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFileTransferServiceChannel : PhotoAlbum.WEB.FileTransferService.IFileTransferService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FileTransferServiceClient : System.ServiceModel.ClientBase<PhotoAlbum.WEB.FileTransferService.IFileTransferService>, PhotoAlbum.WEB.FileTransferService.IFileTransferService {
        
        public FileTransferServiceClient() {
        }
        
        public FileTransferServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FileTransferServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileTransferServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileTransferServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        void PhotoAlbum.WEB.FileTransferService.IFileTransferService.UploadFile(PhotoAlbum.WEB.FileTransferService.ImageUploadRequest request) {
            base.Channel.UploadFile(request);
        }
        
        public void UploadFile(PhotoAlbum.WEB.FileTransferService.ImageMetaData Metadata, System.IO.Stream FileByteStream) {
            PhotoAlbum.WEB.FileTransferService.ImageUploadRequest inValue = new PhotoAlbum.WEB.FileTransferService.ImageUploadRequest();
            inValue.Metadata = Metadata;
            inValue.FileByteStream = FileByteStream;
            ((PhotoAlbum.WEB.FileTransferService.IFileTransferService)(this)).UploadFile(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task PhotoAlbum.WEB.FileTransferService.IFileTransferService.UploadFileAsync(PhotoAlbum.WEB.FileTransferService.ImageUploadRequest request) {
            return base.Channel.UploadFileAsync(request);
        }
        
        public System.Threading.Tasks.Task UploadFileAsync(PhotoAlbum.WEB.FileTransferService.ImageMetaData Metadata, System.IO.Stream FileByteStream) {
            PhotoAlbum.WEB.FileTransferService.ImageUploadRequest inValue = new PhotoAlbum.WEB.FileTransferService.ImageUploadRequest();
            inValue.Metadata = Metadata;
            inValue.FileByteStream = FileByteStream;
            return ((PhotoAlbum.WEB.FileTransferService.IFileTransferService)(this)).UploadFileAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PhotoAlbum.WEB.FileTransferService.ImageDownloadResponse PhotoAlbum.WEB.FileTransferService.IFileTransferService.DownloadFile(PhotoAlbum.WEB.FileTransferService.ImageDownloadRequest request) {
            return base.Channel.DownloadFile(request);
        }
        
        public PhotoAlbum.WEB.FileTransferService.ImageMetaData DownloadFile(System.Guid ImageId, out System.IO.Stream ImageByteStream) {
            PhotoAlbum.WEB.FileTransferService.ImageDownloadRequest inValue = new PhotoAlbum.WEB.FileTransferService.ImageDownloadRequest();
            inValue.ImageId = ImageId;
            PhotoAlbum.WEB.FileTransferService.ImageDownloadResponse retVal = ((PhotoAlbum.WEB.FileTransferService.IFileTransferService)(this)).DownloadFile(inValue);
            ImageByteStream = retVal.ImageByteStream;
            return retVal.DownloadedImageMetadata;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PhotoAlbum.WEB.FileTransferService.ImageDownloadResponse> PhotoAlbum.WEB.FileTransferService.IFileTransferService.DownloadFileAsync(PhotoAlbum.WEB.FileTransferService.ImageDownloadRequest request) {
            return base.Channel.DownloadFileAsync(request);
        }
        
        public System.Threading.Tasks.Task<PhotoAlbum.WEB.FileTransferService.ImageDownloadResponse> DownloadFileAsync(System.Guid ImageId) {
            PhotoAlbum.WEB.FileTransferService.ImageDownloadRequest inValue = new PhotoAlbum.WEB.FileTransferService.ImageDownloadRequest();
            inValue.ImageId = ImageId;
            return ((PhotoAlbum.WEB.FileTransferService.IFileTransferService)(this)).DownloadFileAsync(inValue);
        }
    }
}