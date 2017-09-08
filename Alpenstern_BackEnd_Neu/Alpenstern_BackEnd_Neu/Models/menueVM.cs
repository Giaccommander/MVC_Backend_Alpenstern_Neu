using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alpenstern_BackEnd_Neu.Models
{
    public class menueVM
    {
        public int id { get; set; }
        public string bezeichnung { get; set; }
        public int preis { get; set; }        
        public string gang1 { get; set; }
        public string gang2 { get; set; }
        public string gang3 { get; set; }
        public string gang4 { get; set; }
        public string gang5 { get; set; }
    }
}