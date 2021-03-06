﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TryHardToSaveGuids.SaveALostGuidService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LostGuidStatistics", Namespace="http://schemas.datacontract.org/2004/07/SaveALostGuid")]
    [System.SerializableAttribute()]
    public partial class LostGuidStatistics : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long LostGuidsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long SavedGuidsField;
        
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
        public long LostGuids {
            get {
                return this.LostGuidsField;
            }
            set {
                if ((this.LostGuidsField.Equals(value) != true)) {
                    this.LostGuidsField = value;
                    this.RaisePropertyChanged("LostGuids");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long SavedGuids {
            get {
                return this.SavedGuidsField;
            }
            set {
                if ((this.SavedGuidsField.Equals(value) != true)) {
                    this.SavedGuidsField = value;
                    this.RaisePropertyChanged("SavedGuids");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SaveALostGuidService.ISaveGuid")]
    public interface ISaveGuid {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISaveGuid/GetGuid", ReplyAction="http://tempuri.org/ISaveGuid/GetGuidResponse")]
        string GetGuid();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISaveGuid/GetGuid", ReplyAction="http://tempuri.org/ISaveGuid/GetGuidResponse")]
        System.Threading.Tasks.Task<string> GetGuidAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISaveGuid/GetLostGuidStatistics", ReplyAction="http://tempuri.org/ISaveGuid/GetLostGuidStatisticsResponse")]
        TryHardToSaveGuids.SaveALostGuidService.LostGuidStatistics GetLostGuidStatistics();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISaveGuid/GetLostGuidStatistics", ReplyAction="http://tempuri.org/ISaveGuid/GetLostGuidStatisticsResponse")]
        System.Threading.Tasks.Task<TryHardToSaveGuids.SaveALostGuidService.LostGuidStatistics> GetLostGuidStatisticsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISaveGuidChannel : TryHardToSaveGuids.SaveALostGuidService.ISaveGuid, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SaveGuidClient : System.ServiceModel.ClientBase<TryHardToSaveGuids.SaveALostGuidService.ISaveGuid>, TryHardToSaveGuids.SaveALostGuidService.ISaveGuid {
        
        public SaveGuidClient() {
        }
        
        public SaveGuidClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SaveGuidClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SaveGuidClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SaveGuidClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetGuid() {
            return base.Channel.GetGuid();
        }
        
        public System.Threading.Tasks.Task<string> GetGuidAsync() {
            return base.Channel.GetGuidAsync();
        }
        
        public TryHardToSaveGuids.SaveALostGuidService.LostGuidStatistics GetLostGuidStatistics() {
            return base.Channel.GetLostGuidStatistics();
        }
        
        public System.Threading.Tasks.Task<TryHardToSaveGuids.SaveALostGuidService.LostGuidStatistics> GetLostGuidStatisticsAsync() {
            return base.Channel.GetLostGuidStatisticsAsync();
        }
    }
}
