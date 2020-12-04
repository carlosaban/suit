using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BE
{
    public class BE_WorkFlowDetail
    {
        public int workFlowDetailId { get; set; }
        public int workFlowId { get; set; }
        public int order { get; set; }
        public byte withOrder{ get; set; }
        public int actualStatusId { get; set; }
        public int nextStatusId { get; set; }
        public int quantity { get; set; }
                              
    }
}
