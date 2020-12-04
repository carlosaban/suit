using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SUIT.ViewModel
{
    public class WorkFlowNextStepViewModel
    {
        public int WorkFlowId { get; set; }
        public int InvoiceId { get; set; }
        public string userName { get; set; }
        public bool refuse { get; set; }
    }
}