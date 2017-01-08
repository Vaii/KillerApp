using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerAppSE2.Models
{
    public class Ouder : User
    {
        public string mobielNr { get; private set; }
        public string beperkingen { get; private set; }
        public int leeftijd { get; private set; }

        public Ouder(string initalen, string achternaam, int loginPin, string eMail, string telNr, string mobielnr, string thuisAdres, int leeftijd)
        {
            base.initialen = initalen;
            base.achternaam = achternaam;
            base.loginPin = loginPin;
            base.email = eMail;
            base.telNr = telNr;
            base.thuisAdres = thuisAdres;
            this.mobielNr = mobielnr;
            this.leeftijd = leeftijd;
        }

        public Ouder(string initalen, string achternaam, string eMail, string telNr, string mobielnr, string thuisAdres, int leeftijd)
        {
            base.initialen = initalen;
            base.achternaam = achternaam;
            base.email = eMail;
            base.telNr = telNr;
            base.thuisAdres = thuisAdres;
            this.mobielNr = mobielnr;
            this.leeftijd = leeftijd;
        }
    }
}