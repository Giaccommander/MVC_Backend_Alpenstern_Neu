using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Alpenstern_BackEnd_Neu.Models
{
    public class landListeVM
    {
        public List<LandDetailsVM> Liste { get; set; }
        public landListeVM()
        {
            Liste = new List<LandDetailsVM>();
        }
    }
}