﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSE445_A9A10.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SiteCompareTool", ReplyAction="http://tempuri.org/IService1/SiteCompareToolResponse")]
        int SiteCompareTool(string url, string url2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SiteCompareTool", ReplyAction="http://tempuri.org/IService1/SiteCompareToolResponse")]
        System.Threading.Tasks.Task<int> SiteCompareToolAsync(string url, string url2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/TopTenContentWords", ReplyAction="http://tempuri.org/IService1/TopTenContentWordsResponse")]
        string[] TopTenContentWords(string url);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/TopTenContentWords", ReplyAction="http://tempuri.org/IService1/TopTenContentWordsResponse")]
        System.Threading.Tasks.Task<string[]> TopTenContentWordsAsync(string url);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SentimentAnalysis", ReplyAction="http://tempuri.org/IService1/SentimentAnalysisResponse")]
        string SentimentAnalysis(string wordToAnalyze);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SentimentAnalysis", ReplyAction="http://tempuri.org/IService1/SentimentAnalysisResponse")]
        System.Threading.Tasks.Task<string> SentimentAnalysisAsync(string wordToAnalyze);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/WordFilter", ReplyAction="http://tempuri.org/IService1/WordFilterResponse")]
        string WordFilter(string input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/WordFilter", ReplyAction="http://tempuri.org/IService1/WordFilterResponse")]
        System.Threading.Tasks.Task<string> WordFilterAsync(string input);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : CSE445_A9A10.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<CSE445_A9A10.ServiceReference1.IService1>, CSE445_A9A10.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int SiteCompareTool(string url, string url2) {
            return base.Channel.SiteCompareTool(url, url2);
        }
        
        public System.Threading.Tasks.Task<int> SiteCompareToolAsync(string url, string url2) {
            return base.Channel.SiteCompareToolAsync(url, url2);
        }
        
        public string[] TopTenContentWords(string url) {
            return base.Channel.TopTenContentWords(url);
        }
        
        public System.Threading.Tasks.Task<string[]> TopTenContentWordsAsync(string url) {
            return base.Channel.TopTenContentWordsAsync(url);
        }
        
        public string SentimentAnalysis(string wordToAnalyze) {
            return base.Channel.SentimentAnalysis(wordToAnalyze);
        }
        
        public System.Threading.Tasks.Task<string> SentimentAnalysisAsync(string wordToAnalyze) {
            return base.Channel.SentimentAnalysisAsync(wordToAnalyze);
        }
        
        public string WordFilter(string input) {
            return base.Channel.WordFilter(input);
        }
        
        public System.Threading.Tasks.Task<string> WordFilterAsync(string input) {
            return base.Channel.WordFilterAsync(input);
        }
    }
}
