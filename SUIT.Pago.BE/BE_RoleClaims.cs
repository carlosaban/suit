using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SUIT.Pago.BE
{
    public class BE_RoleClaims
    {
        public Int64 roleClaimsId { get; set; }
        public long claimType { get; set; }
        public long claimValue { get; set; }
        public string roleId { get; set; }
        
    }
}
