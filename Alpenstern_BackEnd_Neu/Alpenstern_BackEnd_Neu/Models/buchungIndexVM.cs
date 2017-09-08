using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alpenstern_BackEnd_Neu.Models
{
    public class buchungIndexVM
    {
        public int id { get; set; }
        public string nachname { get; set; }
        public string vorname { get; set; }
        public int buchungsNr { get; set; }
        public DateTime? gebdatum { get; set; }
        public int radioAuswahl { get; set; }
        public List<buchungIndexVM> Liste{ get; set; }

        public buchungIndexVM()
        {
            Liste = new List<buchungIndexVM>();
        }
    }
}