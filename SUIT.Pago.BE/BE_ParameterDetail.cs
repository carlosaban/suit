using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BE.n
{
    public class BE_ParameterDetail
    {
        public int idParameterDetail { get; set; }
        public int idParameter { get; set; }
        public string value { get; set; }
        public string text { get; set; }
        public int order { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public string createdDateFormat { get; set; }
        public string updatedBy { get; set; }
        public DateTime updatedDate { get; set; }
        public string updatedDateFormat { get; set; }
        public int idParameterDetailParent { get; set; }
        public bool isEnabled { get; set; }
    }
}
