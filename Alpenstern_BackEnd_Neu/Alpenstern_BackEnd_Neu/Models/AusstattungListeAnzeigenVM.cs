using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alpenstern_BackEnd_Neu.Models
{
    public class AusstattungListeAnzeigenVM
    {
        public List<AusstattungVM> Liste { get; set; }
        public AusstattungListeAnzeigenVM()
        {
            Liste = new List<AusstattungVM>();
        }
    }
}