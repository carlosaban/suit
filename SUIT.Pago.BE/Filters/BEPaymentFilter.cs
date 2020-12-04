using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BE.n.Filters
{
    public class BEPaymentFilter : BE_Payment
    {
        public string paymentIdList { get; set; }
        public string invoiceIdList { get; set; }
        public string paymentStatusIdList { get; set; }
        public string companyCodeList { get; set; }
        public string paymentMethodIdList { get; set; }
    }
}
