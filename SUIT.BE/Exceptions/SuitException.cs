using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.BE.Exceptions
{
    public class SuitAppException : Exception
    {
        public SuitAppException(string message) : base(message)
        {

        }

        public SuitAppException(string message, Exception inner) : base(message, inner)
        {

        }



    }

}
