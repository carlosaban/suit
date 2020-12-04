using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BE
{
    public class BE_PaymentDetail
    {
        public int idPayment { get; set; }
        public int idInvoice { get; set; } 
        public decimal amount { get; set; }
    }
}
