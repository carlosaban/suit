using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BE
{
    public class BE_InvoiceLog
    {
        public int invoiceLogId { get; set; }
        public int invoiceId { get; set; }
        public int invoiceStatusId { get; set; }
        public string comment { get; set; }
        public DateTime createdDate { get; set; }
        public string createdDateFormat { get; set; }
        public string createdBy { get; set; }
        public DateTime updatedDate { get; set; }
        public string updatedDateFormat { get; set; }
        public string updatedBy { get; set; }
    }
}
