using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BE
{
    public class BE_Logins
    {

        public string loginProvider { get; set; }
        public string providerKey { get; set; }
        public long providerDisplayName { get; set; }
        public string userId { get; set; }

    }
}
