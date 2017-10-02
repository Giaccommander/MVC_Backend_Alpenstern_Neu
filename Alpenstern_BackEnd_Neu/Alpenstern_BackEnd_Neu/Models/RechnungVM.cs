using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alpenstern_BackEnd_Neu.Models
{
    public class RechnungVM
    {
        public int id { get; set; }
        public string vorname { get; set; }
        public string nachname { get; set; }
        public string strasse { get; set; }
        public string stadt { get; set; }
        public string plz { get; set; }
        public int zimmerID { get; set; }
        public int kategorieID { get; set; }
        public string katBezeichnung { get; set; }
        public string bezeichnung { get; set; }
        public decimal preis { get; set; }
        public int personenAnzahl { get; set; }
    }
}