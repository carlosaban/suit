using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BE.n.Filters
{
    public class BEInvoiceFilter : BE_Invoice
    {
        public string invoiceIdList { get; set; }
        public string statusList { get; set; }
  
    }
}
