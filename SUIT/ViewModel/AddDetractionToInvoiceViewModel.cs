using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUIT.ViewModel
{
    public class AddDetractionToInvoiceViewModel
    {
        public string Username { get; set; }
        public decimal AmountDetraction { get; set; }
        public string invoiceId { get; set; }
    }
}