using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Security.BE
{
    public class BE_Roles
    {
        public string roleId { get; set; }
        public string concurrencyStamp { get; set; }
        public string description { get; set; }
        public decimal limitAmount { get; set; }
        public string name { get; set; }
        public string normalizedName { get; set; }
        public string createdBy { get; set; }
        public string updatedBy { get; set; }

    }
}
