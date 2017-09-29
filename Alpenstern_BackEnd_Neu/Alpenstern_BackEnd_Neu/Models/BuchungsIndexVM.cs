using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alpenstern_BackEnd_Neu.Models
{
    public class BuchungsIndexVM
    {
        public int id { get; set; }
        public string nachname { get; set; }
        public string vorname { get; set; }
        public int buchungsNr { get; set; }
        public DateTime? gebdatum { get; set; }
        public int radioAuswahl { get; set; }
        public List<BuchungsIndexVM> Liste { get; set; }

        public BuchungsIndexVM()
        {
            Liste = new List<BuchungsIndexVM>();
        }
    }
}
