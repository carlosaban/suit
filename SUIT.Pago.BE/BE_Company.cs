using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SUIT.Pago.BE
{
    public class BE_Company
    {
        public string companyCode { get; set; }
        public decimal companyLimit { get; set; }
        public string companyName { get; set; }
        public string companyRUC { get; set; }
        public string companySys { get; set; }
        public Boolean isEnabled { get; set; }
        public string userAudit { get; set; }
        public string companyType { get; set; }
        public string districtId { get; set; }
        public string quantityAuth { get; set; }

    }
}
