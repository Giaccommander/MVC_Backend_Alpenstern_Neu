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
        [Required]
        [Display(Name ="Anzeige wählen")]
        public string bilderart { get; set; }
        [Required]
        [Display(Name ="Bild auswählen")]
        public string pfad { get; set; }
    }
}