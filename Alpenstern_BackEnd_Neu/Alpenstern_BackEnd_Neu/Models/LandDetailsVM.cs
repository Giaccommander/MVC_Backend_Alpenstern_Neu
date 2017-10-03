using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alpenstern_BackEnd_Neu.Models
{
    public class LandDetailsVM
    {
        public int LandId { get; set; }
        public string Bezeichnung { get; set; }
        public List<StadtVM> StadtListe { get; set; }
        public LandDetailsVM()
        {
            StadtListe = new List<StadtVM>();
        }
    }
}