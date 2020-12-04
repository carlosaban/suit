using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BE
{
    public class VE_PaymentAuthDetail: BE_PaymentAuthDetail
    {
        public string companyCode { get; set; }
        public int canAuthorize { get; set; }

    }
}
