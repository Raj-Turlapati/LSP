using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URHealth.Service.Payment.LSPViolation
{
   public class PaymentServiceFactory
    {
        public static PaymentServiceBase GetPaymentServiceFrom(MealCardType mealCardType)
        {
            switch (mealCardType)
            {
                case MealCardType.Sodexho:
                    return new SodexhoPayment();
                case MealCardType.Zeta:
                    return new ZetaPayment();
                default:
                    throw new ApplicationException("No Payment Service available for " + mealCardType.ToString());

            }
        }
    }
}
