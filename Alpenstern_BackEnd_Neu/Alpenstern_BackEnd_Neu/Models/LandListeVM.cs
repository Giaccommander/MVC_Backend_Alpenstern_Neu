using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alpenstern_BackEnd_Neu.Models
{
    public class LandListeVM
    {
        public List<LandDetailsVM> Liste { get; set; }
        public LandListeVM()
        {
            Liste = new List<LandDetailsVM>();
        }
    }
}