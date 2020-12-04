using System;
using System.Collections.Generic;
using System.Text;

namespace SUIT.Security.BE
{
    public class BE_Option
    {
        public int idOption { get; set; }
        public string title { get; set; }
        public int ismenu { get; set; }
        public string url { get; set; }
        public int idOptionParent { get; set; }
        public int order { get; set; }
        public string description { get; set; }

    }
}
