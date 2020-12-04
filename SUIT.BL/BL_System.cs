using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUIT.BE;

namespace SUIT.BL
{
    public class BL_System
    {
        public BE_Aux GetSystemDate()
        {
            BE_Aux _aux = new BE_Aux();
            _aux.date = DateTime.Now.ToShortDateString();
            

            return _aux;
        }
    }
}
