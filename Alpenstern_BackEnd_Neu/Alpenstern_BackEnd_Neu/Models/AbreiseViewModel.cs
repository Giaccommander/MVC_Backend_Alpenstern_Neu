using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Alpenstern_BackEnd_Neu.Models
{
    public class AbreiseViewModel
    {
        string vorname { get; set; }
        string nachname { get; set; }
        string email { get; set; }
        DateTime gebDatum { get; set; }
        int zimmernummer { get; set; }
    }
}