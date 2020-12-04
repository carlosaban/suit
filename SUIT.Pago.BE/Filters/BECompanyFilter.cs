using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BE.n.Filters
{
    public class BECompanyFilter : BE_Company
    {
        public string SearchFilter { get; set; }
        public string CompanyTypeList { get; set; }
        public string userName { get; set; }
        public string CompanyCodeList { get; set; }//Eliminar en la proxima version


    }
}
