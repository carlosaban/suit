using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Security.BE
{
    public class VE_UserRoles:BE_UserRoles
    {
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public string userAudit { get; set; }
    }
}
