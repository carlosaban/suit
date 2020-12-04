using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.BE
{
    public class BE_Token
    {
        public string sub { get; set; }
        public long iat { get; set; }
        public long exp { get; set; }

    }
}
