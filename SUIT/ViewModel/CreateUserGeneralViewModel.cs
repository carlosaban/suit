using SUIT.Security.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUIT.ViewModel
{
    public class CreateUserGeneralViewModel
    {
        public VE_User user { get; set; }
        public List<string> CompanyCodeList { get; set; }
        public List<string> RoleIdList { get; set; }
        public bool authorize { get; set; }
    }
}