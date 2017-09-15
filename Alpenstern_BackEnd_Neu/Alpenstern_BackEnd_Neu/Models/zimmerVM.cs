using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alpenstern_BackEnd_Neu.Models
{
    public class zimmerVM
    {
        public int katid { get; set; }
        public int id { get; set; }
        public string zimmerBezeichnung { get; set; }
        public int groesse { get; set; }
        public int anzPersonen { get; set; }
        public decimal preis { get; set; }
        public int zimmerNummer { get; set; }
        public string ausstattungsBezeichnung { get; set; }
    }
}