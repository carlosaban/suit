using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BE
{
    public class BE_PaymentAuthDetail
    {
        public int paymentAuthDetailID { get; set; }
        public int paymentAuthId { get; set; }
        public string value { get; set;}
        public DateTime dateAuth { get; set; }
        public string dateAuthFormat { get; set; }
        public string type { get; set; }
        public string userAudit { get; set; }
    }
}
