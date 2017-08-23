using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alpenstern_BackEnd_Neu.Models
{
    public class StadtVM
    {
        public int StadtId { get; set; }
        public string Bezeichnung { get; set; }
        public string PLZ { get; set; }
    }
}