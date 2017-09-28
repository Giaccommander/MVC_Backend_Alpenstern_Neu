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
        public DateTime datumVon { get; set; }
        public DateTime datumBis { get; set; }
        public int? naechte { get; set; }
        public int zimmerNummer { get; set; }
        public string kategorie { get; set; }
        public decimal preisProNacht { get; set; }
        public decimal? zimmerPreisGesamt { get; set; }
    }
}