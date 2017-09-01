using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alpenstern_BackEnd_Neu.Models
{
    public class BuchungVM
    {
        //Daten zum abspeichern

        public int gastId { get; set; }
        public string gastEmail { get; set; }

        public DateTime datumVon { get; set; }
        public DateTime datumBis { get; set; }

        public Dictionary<int, int> angefragteKategorien { get; set; }

        //Daten zum Anzeigen

        public Dictionary<int, int> verfuegbareKategorien { get; set; }
    }
}