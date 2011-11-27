﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.488
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AzureBlog.Model.TagCloudService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TagCloudEntry", Namespace="http://schemas.datacontract.org/2004/07/AzureBlog.TagCloudService")]
    [System.SerializableAttribute()]
    public partial class TagCloudEntry : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TagField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double WeightField;
        
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
        public string Tag {
            get {
                return this.TagField;
            }
            set {
                if ((object.ReferenceEquals(this.TagField, value) != true)) {
                    this.TagField = value;
                    this.RaisePropertyChanged("Tag");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Weight {
            get {
                return this.WeightField;
            }
            set {
                if ((this.WeightField.Equals(value) != true)) {
                    this.WeightField = value;
                    this.RaisePropertyChanged("Weight");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TagCloudService.ITagCloudService")]
    public interface ITagCloudService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITagCloudService/GetTagCloudEntries", ReplyAction="http://tempuri.org/ITagCloudService/GetTagCloudEntriesResponse")]
        AzureBlog.Model.TagCloudService.TagCloudEntry[] GetTagCloudEntries();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITagCloudServiceChannel : AzureBlog.Model.TagCloudService.ITagCloudService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TagCloudServiceClient : System.ServiceModel.ClientBase<AzureBlog.Model.TagCloudService.ITagCloudService>, AzureBlog.Model.TagCloudService.ITagCloudService {
        
        public TagCloudServiceClient() {
        }
        
        public TagCloudServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TagCloudServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TagCloudServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TagCloudServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public AzureBlog.Model.TagCloudService.TagCloudEntry[] GetTagCloudEntries() {
            return base.Channel.GetTagCloudEntries();
        }
    }
}
