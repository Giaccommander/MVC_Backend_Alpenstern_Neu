using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alpenstern_BackEnd_Neu.Models
{
    public class AnkunftVM
    {
        public int id { get; set; }
        public string vorname{ get; set; }
        public string nachname { get; set; }
        public DateTime geburtsdatum { get; set; }
        public string email { get; set; }
        public int zimmernummer { get; set; }
    }
}



