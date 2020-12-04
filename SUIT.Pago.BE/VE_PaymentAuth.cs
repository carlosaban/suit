using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BE
{
    public class VE_PaymentAuth: BE_PaymentAuth
    {
        public string accountNumber { get; set; }
        public string bankShortName { get; set; }
        public string firstUserName { get; set; }
        public string secondUserName { get; set; }
        public string thirdUserName { get; set; }
        //public string bankAccountId { get; set; }
        public string payDateStr { get; set; }
        public int authorize { get; set; }
        //public int paymentId { get; set; }
        public string amountTotal { get; set; }
        public string bankName { get; set; }
        public string currency { get; set; }
        public List<VE_PaymentAuthDetail> paymentAuthDetail { get; set; }
        public string statusName { get; set; }
        public string statusCode { get; set; }

    }
}
