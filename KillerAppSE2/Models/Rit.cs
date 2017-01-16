using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerAppSE2.Models
{
    public class Rit
    {
        public DateTime date { get; private set; }
        public string beginTijd { get; private set; }
        public string beginAdres { get; private set; }
        public string eindAdres { get; private set; }
        public int ritDurate { get; private set; }
        public Ouder ouder { get; private set; }

        public Rit(Ouder ouder, DateTime Date, string beginTijd, string beginAdres, string eindAdres, int ritDuratie)
        {
            this.ouder = ouder;
            this.date = Date;
            this.beginTijd = beginTijd;
            this.beginAdres = beginAdres;
            this.eindAdres = eindAdres;
            this.ritDurate = ritDuratie;
        }

        public Rit(DateTime Date, string beginTijd, string beginAdres, string eindAdres, int ritDuratie)
        {
            this.date = Date;
            this.beginTijd = beginTijd;
            this.beginAdres = beginAdres;
            this.eindAdres = eindAdres;
            this.ritDurate = ritDuratie;
        }

        public override string ToString()
        {
            return "Datum " + date.ToString("dd/MM/yyyy") + " ~~ Begin tijd: " + beginTijd + " ~~ Begin Adres: " + beginAdres
                   + " ~~ Eind Adres: " + eindAdres + " ~~ Rit duratie (in uren): " + ritDurate;
        }
    }
}