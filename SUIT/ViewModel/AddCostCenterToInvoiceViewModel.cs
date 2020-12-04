using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUIT.ViewModel
{
    public class AddCostCenterToInvoiceViewModel
    {
        public string Username { get; set; }
        public string CostCenterId { get; set; }
        public string invoiceId { get; set; }
    }
}