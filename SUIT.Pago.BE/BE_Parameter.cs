using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.BE.n
{
    public class BE_Parameter
    {
        public int idParameter { get; set; }
        public string initials { get; set; }
        public string name { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public string createdDateFormat { get; set; }
        public string updatedBy { get; set; }
        public DateTime updatedDate { get; set; }
        public string updatedDateFormat { get; set; }
        public bool isEnabled { get; set; }
    }
}
