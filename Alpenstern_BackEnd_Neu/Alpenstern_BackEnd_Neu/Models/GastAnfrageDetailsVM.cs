using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alpenstern_BackEnd_Neu.Models
{
    public class GastAnfrageDetailsVM
    {
        public int GastId { get; set; }
        public string vorname { get; set; }
        public string nachname { get; set; }
        public string email { get; set; }
        public string reisepassnummer { get; set; }
        public string telefonnummer { get; set; }
        public string straße { get; set; }
        public DateTime geburtsdatum { get; set; }
        public DateTime datumVon { get; set; }
        public DateTime datumBis { get; set; }
        public string Stadt { get; set; }
        public string plz { get; set; }
        public string Land { get; set; }
        public int groeZimm { get; set; }
        public string KategorieBez { get; set; }
        public int? naechte { get; set; }
        public int zimmerNummer { get; set; }
        public string kategorie { get; set; }
        public decimal preisProNacht { get; set; }
        public decimal? zimmerPreisGesamt { get; set; }

        public int personenAnzahl { get; set; }
    }
}