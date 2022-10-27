﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EqtyPMS.PMSReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PMSReference.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetData", ReplyAction="http://tempuri.org/IService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ExecuteSQLData", ReplyAction="http://tempuri.org/IService/ExecuteSQLDataResponse")]
        bool ExecuteSQLData(string query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ExecuteSQLData", ReplyAction="http://tempuri.org/IService/ExecuteSQLDataResponse")]
        System.Threading.Tasks.Task<bool> ExecuteSQLDataAsync(string query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/InsertTransactionData", ReplyAction="http://tempuri.org/IService/InsertTransactionDataResponse")]
        bool InsertTransactionData(string cmdText, int quantity, string securityCode, string operation, string side);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/InsertTransactionData", ReplyAction="http://tempuri.org/IService/InsertTransactionDataResponse")]
        System.Threading.Tasks.Task<bool> InsertTransactionDataAsync(string cmdText, int quantity, string securityCode, string operation, string side);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetSQLData", ReplyAction="http://tempuri.org/IService/GetSQLDataResponse")]
        System.Data.DataSet GetSQLData(string query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetSQLData", ReplyAction="http://tempuri.org/IService/GetSQLDataResponse")]
        System.Threading.Tasks.Task<System.Data.DataSet> GetSQLDataAsync(string query);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : EqtyPMS.PMSReference.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<EqtyPMS.PMSReference.IService>, EqtyPMS.PMSReference.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public bool ExecuteSQLData(string query) {
            return base.Channel.ExecuteSQLData(query);
        }
        
        public System.Threading.Tasks.Task<bool> ExecuteSQLDataAsync(string query) {
            return base.Channel.ExecuteSQLDataAsync(query);
        }
        
        public bool InsertTransactionData(string cmdText, int quantity, string securityCode, string operation, string side) {
            return base.Channel.InsertTransactionData(cmdText, quantity, securityCode, operation, side);
        }
        
        public System.Threading.Tasks.Task<bool> InsertTransactionDataAsync(string cmdText, int quantity, string securityCode, string operation, string side) {
            return base.Channel.InsertTransactionDataAsync(cmdText, quantity, securityCode, operation, side);
        }
        
        public System.Data.DataSet GetSQLData(string query) {
            return base.Channel.GetSQLData(query);
        }
        
        public System.Threading.Tasks.Task<System.Data.DataSet> GetSQLDataAsync(string query) {
            return base.Channel.GetSQLDataAsync(query);
        }
    }
}