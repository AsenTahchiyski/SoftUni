﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DistanceCalcClient.DistanceService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DistanceService.IDistanceCalculator")]
    public interface IDistanceCalculator {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistanceCalculator/CalculateDistance", ReplyAction="http://tempuri.org/IDistanceCalculator/CalculateDistanceResponse")]
        double CalculateDistance(int x1, int y1, int x2, int y2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDistanceCalculator/CalculateDistance", ReplyAction="http://tempuri.org/IDistanceCalculator/CalculateDistanceResponse")]
        System.Threading.Tasks.Task<double> CalculateDistanceAsync(int x1, int y1, int x2, int y2);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDistanceCalculatorChannel : DistanceCalcClient.DistanceService.IDistanceCalculator, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DistanceCalculatorClient : System.ServiceModel.ClientBase<DistanceCalcClient.DistanceService.IDistanceCalculator>, DistanceCalcClient.DistanceService.IDistanceCalculator {
        
        public DistanceCalculatorClient() {
        }
        
        public DistanceCalculatorClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DistanceCalculatorClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DistanceCalculatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DistanceCalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double CalculateDistance(int x1, int y1, int x2, int y2) {
            return base.Channel.CalculateDistance(x1, y1, x2, y2);
        }
        
        public System.Threading.Tasks.Task<double> CalculateDistanceAsync(int x1, int y1, int x2, int y2) {
            return base.Channel.CalculateDistanceAsync(x1, y1, x2, y2);
        }
    }
}