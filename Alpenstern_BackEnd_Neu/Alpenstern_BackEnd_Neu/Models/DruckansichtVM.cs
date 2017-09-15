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
        public string strasse { get; set; }
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
        

        // kommt aus Anfrage
        public DateTime datumVon { get; set; }
        public DateTime datumBis { get; set; }

        //Kommt aus rechnungen
        public decimal gesamtpreis { get; set; }
        public byte anzahlPersonen { get; set; }
        public byte anzahlNaechte { get; set; }

    }
}