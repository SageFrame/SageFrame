using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SageFrame.PaymentGateWay
{
    public class IPaymentGateway
    {

    }
    public interface ILog
    {
        //fields for logger
    }
    public interface IPaymentLogger
    {
        void Log(ILog log);
    }

    public interface IPaymentService
    {
        List<string> SupportedCurrency { get; set; }
        bool AllowRefund { get; set; }
        bool AllowCancel { get; set; }
        Dictionary<string, object> Settings { get; set; }
    }

    public interface IPay
    {
        void ProcessPayment();
        void AdditionalFee();
        void Refund();
        void Cancel();
        void GetTax();
        void PaymentSuccess();
    }

    public class GatewayConfiguration : IPaymentService
    {
        public string GatewayConfigurationID { get; set; }
        public string Name { get; set; }
        private string Version;
        private string AuthorName;
        //more fields if any...
        public Dictionary<string, object> Settings { get; set; }
        public List<string> SupportedCurrency { get; set; }
        public bool AllowRefund { get; set; }
        public bool AllowCancel { get; set; }
    }

    public class GatewayManager
    {
        private IPaymentLogger _logger;
        private ILog _log;

        public void Install(GatewayConfiguration config)
        {
        }
        public void UnInstall(GatewayConfiguration config)
        {

        }
        public void ProcessPayment(IPay processor)
        {
            processor.ProcessPayment();
            _logger.Log(_log);
        }

        public void AdditionalFee()
        {

        }

        public void Refund()
        {

        }

        public void Cancel()
        {

        }

        public void GetTax()
        {

        }
    }
}
