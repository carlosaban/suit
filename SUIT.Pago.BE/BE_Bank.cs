using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BE
{
    public class BE_Bank
    {
        public int bankId { get; set; }
        public string bankInterCode { get; set; }
        public string bankName { get; set; }
        public string bankShortName { get; set; }
        public string bankMasterId { get; set; }
        public bool isEnabled { get; set; }
        public string userAudit { get; set; }

    }
}
