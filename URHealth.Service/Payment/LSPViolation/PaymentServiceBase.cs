using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URHealth.Service.Payment.LSPViolation
{
    public abstract class PaymentServiceBase
    {
        public abstract string PayToVendor(decimal amount, string transactionId);
    }
}
