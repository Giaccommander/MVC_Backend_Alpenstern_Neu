using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alpenstern_BackEnd_Neu.Models
{
    public class AnfrageDatumVM
    {
        public int id { get; set; }
        public DateTime datumVon { get; set; }
        public DateTime datumBis { get; set; }
        public DateTime datumAnfrage { get; set; }
        public string vorname { get; set; }
        public string nachname { get; set; }
        public int zimmerNummer { get; set; }
    }
}