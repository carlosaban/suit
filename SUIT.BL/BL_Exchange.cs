using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SUIT.BE;

namespace SUIT.BL
{
    public class BL_Exchange
    {
        public BE_Exchange GetExchangeRate()
        {
            BE_Exchange _exchange = new BE_Exchange();
            _exchange.date = DateTime.Now.ToShortDateString();
            _exchange.exchangeRate = 3.35m;

            return _exchange;

        }
    }
}
