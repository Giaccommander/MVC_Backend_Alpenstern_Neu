using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Alpenstern_BackEnd_Neu.Models
{
    public class BilderVM
    {
        public int id {get;set;}
        [Display(Name ="Anzeige Ort")]
        public string bilderart { get; set; }
        
        [Display(Name ="Original Vorschau")]
        public string pfad { get; set; }
    }
}