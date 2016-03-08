﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhotoAlbum.WEB.MembershipService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseRequest", Namespace="http://schemas.datacontract.org/2004/07/Service.Messages")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PhotoAlbum.WEB.MembershipService.LoginRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PhotoAlbum.WEB.MembershipService.ChangeUserPasswordRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PhotoAlbum.WEB.MembershipService.ChangeUserInfoRequest))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PhotoAlbum.WEB.MembershipService.CreateRequest))]
    public partial class BaseRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LoginRequest", Namespace="http://schemas.datacontract.org/2004/07/Service.Messages.Membership")]
    [System.SerializableAttribute()]
    public partial class LoginRequest : PhotoAlbum.WEB.MembershipService.BaseRequest {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ChangeUserPasswordRequest", Namespace="http://schemas.datacontract.org/2004/07/Service.Messages.Membership")]
    [System.SerializableAttribute()]
    public partial class ChangeUserPasswordRequest : PhotoAlbum.WEB.MembershipService.BaseRequest {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NewPasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OldPasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NewPassword {
            get {
                return this.NewPasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.NewPasswordField, value) != true)) {
                    this.NewPasswordField = value;
                    this.RaisePropertyChanged("NewPassword");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OldPassword {
            get {
                return this.OldPasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.OldPasswordField, value) != true)) {
                    this.OldPasswordField = value;
                    this.RaisePropertyChanged("OldPassword");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((object.ReferenceEquals(this.UserIdField, value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ChangeUserInfoRequest", Namespace="http://schemas.datacontract.org/2004/07/Service.Messages.Membership")]
    [System.SerializableAttribute()]
    public partial class ChangeUserInfoRequest : PhotoAlbum.WEB.MembershipService.BaseRequest {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FullNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FullName {
            get {
                return this.FullNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FullNameField, value) != true)) {
                    this.FullNameField = value;
                    this.RaisePropertyChanged("FullName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((object.ReferenceEquals(this.UserIdField, value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CreateRequest", Namespace="http://schemas.datacontract.org/2004/07/Service.Messages.Membership")]
    [System.SerializableAttribute()]
    public partial class CreateRequest : PhotoAlbum.WEB.MembershipService.BaseRequest {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PhotoAlbum.WEB.MembershipService.AuthenticationTypeEnum AuthenticationTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FullNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RoleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PhotoAlbum.WEB.MembershipService.AuthenticationTypeEnum AuthenticationType {
            get {
                return this.AuthenticationTypeField;
            }
            set {
                if ((this.AuthenticationTypeField.Equals(value) != true)) {
                    this.AuthenticationTypeField = value;
                    this.RaisePropertyChanged("AuthenticationType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FullName {
            get {
                return this.FullNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FullNameField, value) != true)) {
                    this.FullNameField = value;
                    this.RaisePropertyChanged("FullName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Role {
            get {
                return this.RoleField;
            }
            set {
                if ((object.ReferenceEquals(this.RoleField, value) != true)) {
                    this.RoleField = value;
                    this.RaisePropertyChanged("Role");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AuthenticationTypeEnum", Namespace="http://schemas.datacontract.org/2004/07/Service.Utilities.Membership")]
    public enum AuthenticationTypeEnum : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ApplicationCookie = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ExternalCookie = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        ExternalBearer = 2,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BaseResponse", Namespace="http://schemas.datacontract.org/2004/07/Service.Messages")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PhotoAlbum.WEB.MembershipService.LoginResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PhotoAlbum.WEB.MembershipService.UserProfileResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PhotoAlbum.WEB.MembershipService.ChangeUserPasswordResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PhotoAlbum.WEB.MembershipService.ChangeUserInfoResponse))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(PhotoAlbum.WEB.MembershipService.CreateResponse))]
    public partial class BaseResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] ErrorsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool SuccessField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] Errors {
            get {
                return this.ErrorsField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorsField, value) != true)) {
                    this.ErrorsField = value;
                    this.RaisePropertyChanged("Errors");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Success {
            get {
                return this.SuccessField;
            }
            set {
                if ((this.SuccessField.Equals(value) != true)) {
                    this.SuccessField = value;
                    this.RaisePropertyChanged("Success");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LoginResponse", Namespace="http://schemas.datacontract.org/2004/07/Service.Messages.Membership")]
    [System.SerializableAttribute()]
    public partial class LoginResponse : PhotoAlbum.WEB.MembershipService.BaseResponse {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PhotoAlbum.WEB.MembershipService.ClaimIdentityView ClaimIdentityViewField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PhotoAlbum.WEB.MembershipService.ClaimIdentityView ClaimIdentityView {
            get {
                return this.ClaimIdentityViewField;
            }
            set {
                if ((object.ReferenceEquals(this.ClaimIdentityViewField, value) != true)) {
                    this.ClaimIdentityViewField = value;
                    this.RaisePropertyChanged("ClaimIdentityView");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserProfileResponse", Namespace="http://schemas.datacontract.org/2004/07/Service.Messages.Membership")]
    [System.SerializableAttribute()]
    public partial class UserProfileResponse : PhotoAlbum.WEB.MembershipService.BaseResponse {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FullNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FullName {
            get {
                return this.FullNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FullNameField, value) != true)) {
                    this.FullNameField = value;
                    this.RaisePropertyChanged("FullName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ChangeUserPasswordResponse", Namespace="http://schemas.datacontract.org/2004/07/Service.Messages.Membership")]
    [System.SerializableAttribute()]
    public partial class ChangeUserPasswordResponse : PhotoAlbum.WEB.MembershipService.BaseResponse {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ChangeUserInfoResponse", Namespace="http://schemas.datacontract.org/2004/07/Service.Messages.Membership")]
    [System.SerializableAttribute()]
    public partial class ChangeUserInfoResponse : PhotoAlbum.WEB.MembershipService.BaseResponse {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FullNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FullName {
            get {
                return this.FullNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FullNameField, value) != true)) {
                    this.FullNameField = value;
                    this.RaisePropertyChanged("FullName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((object.ReferenceEquals(this.UserIdField, value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CreateResponse", Namespace="http://schemas.datacontract.org/2004/07/Service.Messages.Membership")]
    [System.SerializableAttribute()]
    public partial class CreateResponse : PhotoAlbum.WEB.MembershipService.BaseResponse {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PhotoAlbum.WEB.MembershipService.ClaimIdentityView ClaimIdentityViewField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PhotoAlbum.WEB.MembershipService.ClaimIdentityView ClaimIdentityView {
            get {
                return this.ClaimIdentityViewField;
            }
            set {
                if ((object.ReferenceEquals(this.ClaimIdentityViewField, value) != true)) {
                    this.ClaimIdentityViewField = value;
                    this.RaisePropertyChanged("ClaimIdentityView");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((object.ReferenceEquals(this.UserIdField, value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ClaimIdentityView", Namespace="http://schemas.datacontract.org/2004/07/Service.Views.Membership")]
    [System.SerializableAttribute()]
    public partial class ClaimIdentityView : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PhotoAlbum.WEB.MembershipService.AuthenticationTypeEnum AuthenticationTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PhotoAlbum.WEB.MembershipService.ClaimView[] ClaimViewListField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameClaimTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RoleClaimTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PhotoAlbum.WEB.MembershipService.AuthenticationTypeEnum AuthenticationType {
            get {
                return this.AuthenticationTypeField;
            }
            set {
                if ((this.AuthenticationTypeField.Equals(value) != true)) {
                    this.AuthenticationTypeField = value;
                    this.RaisePropertyChanged("AuthenticationType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public PhotoAlbum.WEB.MembershipService.ClaimView[] ClaimViewList {
            get {
                return this.ClaimViewListField;
            }
            set {
                if ((object.ReferenceEquals(this.ClaimViewListField, value) != true)) {
                    this.ClaimViewListField = value;
                    this.RaisePropertyChanged("ClaimViewList");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NameClaimType {
            get {
                return this.NameClaimTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.NameClaimTypeField, value) != true)) {
                    this.NameClaimTypeField = value;
                    this.RaisePropertyChanged("NameClaimType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RoleClaimType {
            get {
                return this.RoleClaimTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.RoleClaimTypeField, value) != true)) {
                    this.RoleClaimTypeField = value;
                    this.RaisePropertyChanged("RoleClaimType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserId {
            get {
                return this.UserIdField;
            }
            set {
                if ((object.ReferenceEquals(this.UserIdField, value) != true)) {
                    this.UserIdField = value;
                    this.RaisePropertyChanged("UserId");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ClaimView", Namespace="http://schemas.datacontract.org/2004/07/Service.Views.Membership")]
    [System.SerializableAttribute()]
    public partial class ClaimView : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ValueTypeField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Type {
            get {
                return this.TypeField;
            }
            set {
                if ((object.ReferenceEquals(this.TypeField, value) != true)) {
                    this.TypeField = value;
                    this.RaisePropertyChanged("Type");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Value {
            get {
                return this.ValueField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueField, value) != true)) {
                    this.ValueField = value;
                    this.RaisePropertyChanged("Value");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ValueType {
            get {
                return this.ValueTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.ValueTypeField, value) != true)) {
                    this.ValueTypeField = value;
                    this.RaisePropertyChanged("ValueType");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MembershipService.IMembershipService")]
    public interface IMembershipService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMembershipService/Create", ReplyAction="http://tempuri.org/IMembershipService/CreateResponse")]
        PhotoAlbum.WEB.MembershipService.CreateResponse Create(PhotoAlbum.WEB.MembershipService.CreateRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMembershipService/Create", ReplyAction="http://tempuri.org/IMembershipService/CreateResponse")]
        System.Threading.Tasks.Task<PhotoAlbum.WEB.MembershipService.CreateResponse> CreateAsync(PhotoAlbum.WEB.MembershipService.CreateRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMembershipService/Login", ReplyAction="http://tempuri.org/IMembershipService/LoginResponse")]
        PhotoAlbum.WEB.MembershipService.LoginResponse Login(PhotoAlbum.WEB.MembershipService.LoginRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMembershipService/Login", ReplyAction="http://tempuri.org/IMembershipService/LoginResponse")]
        System.Threading.Tasks.Task<PhotoAlbum.WEB.MembershipService.LoginResponse> LoginAsync(PhotoAlbum.WEB.MembershipService.LoginRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMembershipService/GetProfile", ReplyAction="http://tempuri.org/IMembershipService/GetProfileResponse")]
        PhotoAlbum.WEB.MembershipService.UserProfileResponse GetProfile(string userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMembershipService/GetProfile", ReplyAction="http://tempuri.org/IMembershipService/GetProfileResponse")]
        System.Threading.Tasks.Task<PhotoAlbum.WEB.MembershipService.UserProfileResponse> GetProfileAsync(string userId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMembershipService/ChangeUserPassword", ReplyAction="http://tempuri.org/IMembershipService/ChangeUserPasswordResponse")]
        PhotoAlbum.WEB.MembershipService.ChangeUserPasswordResponse ChangeUserPassword(PhotoAlbum.WEB.MembershipService.ChangeUserPasswordRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMembershipService/ChangeUserPassword", ReplyAction="http://tempuri.org/IMembershipService/ChangeUserPasswordResponse")]
        System.Threading.Tasks.Task<PhotoAlbum.WEB.MembershipService.ChangeUserPasswordResponse> ChangeUserPasswordAsync(PhotoAlbum.WEB.MembershipService.ChangeUserPasswordRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMembershipService/ChangeUserInfo", ReplyAction="http://tempuri.org/IMembershipService/ChangeUserInfoResponse")]
        PhotoAlbum.WEB.MembershipService.ChangeUserInfoResponse ChangeUserInfo(PhotoAlbum.WEB.MembershipService.ChangeUserInfoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMembershipService/ChangeUserInfo", ReplyAction="http://tempuri.org/IMembershipService/ChangeUserInfoResponse")]
        System.Threading.Tasks.Task<PhotoAlbum.WEB.MembershipService.ChangeUserInfoResponse> ChangeUserInfoAsync(PhotoAlbum.WEB.MembershipService.ChangeUserInfoRequest request);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMembershipServiceChannel : PhotoAlbum.WEB.MembershipService.IMembershipService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MembershipServiceClient : System.ServiceModel.ClientBase<PhotoAlbum.WEB.MembershipService.IMembershipService>, PhotoAlbum.WEB.MembershipService.IMembershipService {
        
        public MembershipServiceClient() {
        }
        
        public MembershipServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MembershipServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MembershipServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MembershipServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public PhotoAlbum.WEB.MembershipService.CreateResponse Create(PhotoAlbum.WEB.MembershipService.CreateRequest request) {
            return base.Channel.Create(request);
        }
        
        public System.Threading.Tasks.Task<PhotoAlbum.WEB.MembershipService.CreateResponse> CreateAsync(PhotoAlbum.WEB.MembershipService.CreateRequest request) {
            return base.Channel.CreateAsync(request);
        }
        
        public PhotoAlbum.WEB.MembershipService.LoginResponse Login(PhotoAlbum.WEB.MembershipService.LoginRequest request) {
            return base.Channel.Login(request);
        }
        
        public System.Threading.Tasks.Task<PhotoAlbum.WEB.MembershipService.LoginResponse> LoginAsync(PhotoAlbum.WEB.MembershipService.LoginRequest request) {
            return base.Channel.LoginAsync(request);
        }
        
        public PhotoAlbum.WEB.MembershipService.UserProfileResponse GetProfile(string userId) {
            return base.Channel.GetProfile(userId);
        }
        
        public System.Threading.Tasks.Task<PhotoAlbum.WEB.MembershipService.UserProfileResponse> GetProfileAsync(string userId) {
            return base.Channel.GetProfileAsync(userId);
        }
        
        public PhotoAlbum.WEB.MembershipService.ChangeUserPasswordResponse ChangeUserPassword(PhotoAlbum.WEB.MembershipService.ChangeUserPasswordRequest request) {
            return base.Channel.ChangeUserPassword(request);
        }
        
        public System.Threading.Tasks.Task<PhotoAlbum.WEB.MembershipService.ChangeUserPasswordResponse> ChangeUserPasswordAsync(PhotoAlbum.WEB.MembershipService.ChangeUserPasswordRequest request) {
            return base.Channel.ChangeUserPasswordAsync(request);
        }
        
        public PhotoAlbum.WEB.MembershipService.ChangeUserInfoResponse ChangeUserInfo(PhotoAlbum.WEB.MembershipService.ChangeUserInfoRequest request) {
            return base.Channel.ChangeUserInfo(request);
        }
        
        public System.Threading.Tasks.Task<PhotoAlbum.WEB.MembershipService.ChangeUserInfoResponse> ChangeUserInfoAsync(PhotoAlbum.WEB.MembershipService.ChangeUserInfoRequest request) {
            return base.Channel.ChangeUserInfoAsync(request);
        }
    }
}