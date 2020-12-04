using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BE
{
    public class VE_BankAccount : BE_BankAccount
    {
        public string userAudit { get; set; }
        public int paymentAuthId { get; set; }
        public string bankShortName { get; set; }
        public string companyName { get; set; }

    }
}
