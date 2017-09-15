using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Alpenstern_BackEnd_Neu.Models;


namespace Alpenstern_BackEnd_Neu.Models
{
    public class RechnungVM
    {
        public int id { get; set; }
        public int anfrage_id { get; set; }
        public decimal gesamtpreis { get; set; }
        public byte anzahlPersonen { get; set; }
        public byte anzahlNaechte { get; set; }
        public System.DateTime datumAktualisiert { get; set; }

        public virtual Anfrage Anfrage { get; set; }
    }
}