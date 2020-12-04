using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BE
{
    public class VE_Invoice:BE_Invoice
    {
        public string cantidad { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
        public string userAudit { get; set; }
        public string invoiceStatus { get; set; }
        public string companyName { get; set; }
        public string companyRuc { get; set; }
        
        public int due { get; set; }
        public List<VE_InvoiceDetail> invoiceDetail { get; set; }

    }
}
