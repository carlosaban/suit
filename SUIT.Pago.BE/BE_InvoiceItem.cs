using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BE
{
    public class BE_InvoiceItem
    {

        public int invoiceItemId { get; set; }
        public string name { get; set; }
        public decimal suggestedPrice { get; set; }
        public string companyCode { get; set; }
        public string invoiceItemType { get; set; }
        public DateTime createdDate { get; set; }
        public string createdDateFormat { get; set; }
        public string createdBy { get; set; }
        public DateTime updatedDate { get; set; }
        public string updatedDateFormat { get; set; }
        public string updatedBy { get; set; }
        public bool igvAffected { get; set; }

    }
}
