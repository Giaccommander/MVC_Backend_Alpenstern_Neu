using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Alpenstern_BackEnd_Neu.Models;

namespace Alpenstern_BackEnd_Neu.Models
{
    public class DruckansichtVM
    {
        public int id { get; set; }
        public string vorname { get; set; }
        public string nachname { get; set; }
        public DateTime gebDatum { get; set; }
        public string strasse { get; set; }
        public string email { get; set; }
        public string telefonNr { get; set; }
        public string reisePassNr { get; set; }
        public string land { get; set; }
        public string ort { get; set; }
        public string plz { get; set; }
        public int zimmerID { get; set; }
        public int kategorieID { get; set; }
        public int zimmerNummer { get; set; }
        public string bezeichnung { get; set; }
        public decimal preis { get; set; }
        public int personenAnzahl { get; set; }
        public int groesse { get; set; }
        public DateTime datumVon { get; set; }
        public DateTime datumBis { get; set; }
       
    }
}