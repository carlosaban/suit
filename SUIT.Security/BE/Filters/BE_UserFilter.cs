using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Security.BE.Filters
{
    public class BE_UserFilter : BE_User
    {
        public string UserEmailList { get; set; }
        public string UserNameList { get; set; }
        public string SearchFilter { get; set; }
    }
}
