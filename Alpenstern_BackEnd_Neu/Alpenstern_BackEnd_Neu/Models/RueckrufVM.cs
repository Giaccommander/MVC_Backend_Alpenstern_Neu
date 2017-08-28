using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alpenstern_BackEnd_Neu.Models
{
    public class RueckrufVM
    {
        public int id { get; set; }
        public string name { get; set; }
        public string telefon { get; set; }
        public string grund { get; set; }
        public DateTime datumWann { get; set; }       
    }
}