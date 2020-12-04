using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BE
{
    public class VE_Bank:BE_Bank
    {
        public string accountNumber { get; set; }
        public string currency { get; set; }
        public string status { get; set; }
        public string balance { get; set; }
        public string accounting { get; set; }
        public string cash { get; set; }
        public int bankAccountId { get; set; }
        public int paymentAuthId { get; set; }


    }
}
