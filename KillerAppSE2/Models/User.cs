using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerAppSE2.Models
{
    public abstract class User
    {
        public string initialen { get; set; }
        public string achternaam { get; set; }
        public int loginPin { get; set; }
        public string email { get; set; }
        public string telNr { get; set; }
        public string thuisAdres { get; set; }

    }
}