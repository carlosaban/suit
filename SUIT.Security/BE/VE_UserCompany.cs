using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Security.BE
{
    public class VE_UserCompany:BE_UserCompany
    {
        public string companyName { get; set; }
        public string companyRuc { get; set; }
        public string email { get; set; }
        public string userAudit { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int authorize { get; set; }
        public decimal amountTotal { get; set; }
        public int quantityAuth { get; set; }
    }
}
