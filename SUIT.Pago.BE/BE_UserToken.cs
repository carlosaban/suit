using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SUIT.Pago.BE
{
    public class BE_UserToken
    {
        public string userId { get; set; }
        public string loginProvider { get; set; }
        public string name { get; set; }
        public long value { get; set; }
        

    }
}
