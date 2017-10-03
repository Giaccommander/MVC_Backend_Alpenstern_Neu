using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Alpenstern_BackEnd_Neu.Models
{
    public class GastVM
    {
        [Required]
        public string Vorname { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nachname { get; set; }
    }
}