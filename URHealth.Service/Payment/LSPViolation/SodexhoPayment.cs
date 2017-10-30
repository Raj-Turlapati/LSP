using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URHealth.Service.Payment.LSPViolation
{
    public class SodexhoPayment : PaymentServiceBase
    {
        public string AccountName { get; set; }
        public string Password { get; set; }
        public override string PayToVendor(decimal amount, string transactionId)
        {
            MockSodexoWebService sodexoWebService = new MockSodexoWebService();
            PaymentResponse paymentResponse = new PaymentResponse();

            string token = sodexoWebService.ObtainToken(AccountName, Password);

            string response = sodexoWebService.MakePayment(amount, transactionId, token);
            return response;

        }
    }
}
