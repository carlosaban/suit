using SUIT.Pago.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUIT.ViewModel
{
    public class MakePaymentsDetailsPartialsViewModel
    {
        public List<VE_Invoice> lstInvoices { get; set; }
        public BE_Payment payment { get; set; }
    }
}