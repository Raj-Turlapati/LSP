using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URHealth.Service.Payment.LSPViolation
{
    public class ZetaPayment : PaymentServiceBase
    {
        public string AccountName { get; set; }
        public string Password { get; set; }
        public string ProductId { get; set; }
        public override string PayToVendor(decimal amount, string transactionId)
        {
            MockZetaWebService mockZetaWebService = new MockZetaWebService();
            string response = mockZetaWebService.MakePayment(amount, transactionId, AccountName, Password, ProductId);
            return response;
        }
    }
}
