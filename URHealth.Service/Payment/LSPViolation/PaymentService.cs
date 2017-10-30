using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URHealth.Service.Payment.LSPViolation
{
    public class PaymentService
    {
        public PaymentResponse Pay(PaymentRequest paymentRequest)
        {
            PaymentServiceBase paymentService = PaymentServiceFactory.GetPaymentServiceFrom(paymentRequest.CardType);

            PaymentResponse paymentResponse = new PaymentResponse();

            if((paymentService as SodexhoPayment) != null)
            {
                ((SodexhoPayment)paymentService).AccountName = "Raj-SP";
                ((SodexhoPayment)paymentService).Password = "xxxx";
            }

            if ((paymentService as ZetaPayment) != null)
            {
                ((ZetaPayment)paymentService).AccountName = "Raj-ZP";
                ((ZetaPayment)paymentService).Password = "xxxx";
                ((ZetaPayment)paymentService).ProductId = "ZP1111";
            }

            string merchantResponse = paymentService.PayToVendor(paymentRequest.Amount, paymentRequest.PaymentTransactionId);
            
            paymentResponse.Message = merchantResponse;

            if(merchantResponse.Contains("SODEXO - 1111") || merchantResponse.Contains("Z - E - T - A - 1111"))
            {
                paymentResponse.Success = true;

            }
            else
            {
                paymentResponse.Success = false;
            }

            return paymentResponse;
        }
    }
}
