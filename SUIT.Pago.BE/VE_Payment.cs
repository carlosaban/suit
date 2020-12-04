using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BE
{
    public class VE_Payment:BE_Payment
    {
        public string periodo { get; set; }
        public string mes { get; set; }

        public string bankShortName { get; set; }
        public string userAudit { get; set; }


    }
}
