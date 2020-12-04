using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Security.BE
{
    public class BE_User
    {
        public string id { get; set; }
        public string userName { get; set; }
        public int accessFailedCount { get; set; }
        public string concurrencyStamp { get; set; }
        public string configuration { get; set; }
        public string email { get; set; }
        public bool emailConfirmed { get; set; }
        public string firstName { get; set; }
        public bool isEnabled { get; set; }
        public string lastName { get; set; }
        public bool lockoutEnabled { get; set; }
        public DateTime lockoutEnd { get; set; }
        public string lockoutEndFormat { get; set; }
        public string normalizedEmail { get; set; }
        public string normalizedUserName { get; set; }
        public string passwordHash { get; set; }
        public string phoneNumber { get; set; }
        public bool phoneNumberConfirmed { get; set; }
        public string securityStamp { get; set; }
        public bool twoFactorEnabled { get; set; }
        public List<BE.BE_Option> Options { get; set; }
        public List<BE.BE_Option> OptionsMenu { get; set; }

        public BE_User()
        {
            Options = new List<BE_Option>();
            OptionsMenu = new List<BE_Option>();

        }


    }
}
