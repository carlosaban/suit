using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BE
{
    public class BE_InvoiceDetail
    {
        public int invoiceDetailId { get; set; }
        public int invoiceId { get; set; }
        public int invoiceItemId { get; set; }
        public decimal quantity { get; set; }
        public decimal unitprice { get; set; }
        public decimal price { get; set; }
        public DateTime createdDate { get; set; }
        public string createdDateFormat { get; set; }
        public string createdBy { get; set; }
        public DateTime updatedDate { get; set; }
        public string updatedDateFormat { get; set; }
        public string updatedBy { get; set; }
        public decimal igvAmount { get; set; }
        public bool isEnabled { get; set; }


    }
}
