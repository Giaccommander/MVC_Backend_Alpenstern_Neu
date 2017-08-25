using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Alpenstern_BackEnd_Neu.Models;

namespace Alpenstern_BackEnd_Neu.Models
{
    public class LoginVM
    {
        public string Login;
        public string benutzerName { get; set; }
        public string passwort { get; set; }
    }
}