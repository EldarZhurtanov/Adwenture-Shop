﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web.UserServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserDTO", Namespace="http://schemas.datacontract.org/2004/07/DataContracts")]
    [System.SerializableAttribute()]
    public partial class UserDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressLine1Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int AddressStateProvinceIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MiddleNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string RoleField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
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
        public string AddressLine1 {
            get {
                return this.AddressLine1Field;
            }
            set {
                if ((object.ReferenceEquals(this.AddressLine1Field, value) != true)) {
                    this.AddressLine1Field = value;
                    this.RaisePropertyChanged("AddressLine1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int AddressStateProvinceID {
            get {
                return this.AddressStateProvinceIDField;
            }
            set {
                if ((this.AddressStateProvinceIDField.Equals(value) != true)) {
                    this.AddressStateProvinceIDField = value;
                    this.RaisePropertyChanged("AddressStateProvinceID");
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
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Id {
            get {
                return this.IdField;
            }
            set {
                if ((object.ReferenceEquals(this.IdField, value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string MiddleName {
            get {
                return this.MiddleNameField;
            }
            set {
                if ((object.ReferenceEquals(this.MiddleNameField, value) != true)) {
                    this.MiddleNameField = value;
                    this.RaisePropertyChanged("MiddleName");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="OperationDetailsDTO", Namespace="http://schemas.datacontract.org/2004/07/DataContracts")]
    [System.SerializableAttribute()]
    public partial class OperationDetailsDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PropertyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool SuccedeedField;
        
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
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Property {
            get {
                return this.PropertyField;
            }
            set {
                if ((object.ReferenceEquals(this.PropertyField, value) != true)) {
                    this.PropertyField = value;
                    this.RaisePropertyChanged("Property");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Succedeed {
            get {
                return this.SuccedeedField;
            }
            set {
                if ((this.SuccedeedField.Equals(value) != true)) {
                    this.SuccedeedField = value;
                    this.RaisePropertyChanged("Succedeed");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserServiceReference.IUserService")]
    public interface IUserService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Create", ReplyAction="http://tempuri.org/IUserService/CreateResponse")]
        Web.UserServiceReference.OperationDetailsDTO Create(Web.UserServiceReference.UserDTO userDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Create", ReplyAction="http://tempuri.org/IUserService/CreateResponse")]
        System.Threading.Tasks.Task<Web.UserServiceReference.OperationDetailsDTO> CreateAsync(Web.UserServiceReference.UserDTO userDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Authenticate", ReplyAction="http://tempuri.org/IUserService/AuthenticateResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Web.UserServiceReference.UserDTO))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Web.UserServiceReference.OperationDetailsDTO))]
        System.Security.Claims.ClaimsIdentity Authenticate(Web.UserServiceReference.UserDTO userDto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserService/Authenticate", ReplyAction="http://tempuri.org/IUserService/AuthenticateResponse")]
        System.Threading.Tasks.Task<System.Security.Claims.ClaimsIdentity> AuthenticateAsync(Web.UserServiceReference.UserDTO userDto);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserServiceChannel : Web.UserServiceReference.IUserService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserServiceClient : System.ServiceModel.ClientBase<Web.UserServiceReference.IUserService>, Web.UserServiceReference.IUserService {
        
        public UserServiceClient() {
        }
        
        public UserServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Web.UserServiceReference.OperationDetailsDTO Create(Web.UserServiceReference.UserDTO userDto) {
            return base.Channel.Create(userDto);
        }
        
        public System.Threading.Tasks.Task<Web.UserServiceReference.OperationDetailsDTO> CreateAsync(Web.UserServiceReference.UserDTO userDto) {
            return base.Channel.CreateAsync(userDto);
        }
        
        public System.Security.Claims.ClaimsIdentity Authenticate(Web.UserServiceReference.UserDTO userDto) {
            return base.Channel.Authenticate(userDto);
        }
        
        public System.Threading.Tasks.Task<System.Security.Claims.ClaimsIdentity> AuthenticateAsync(Web.UserServiceReference.UserDTO userDto) {
            return base.Channel.AuthenticateAsync(userDto);
        }
    }
}
