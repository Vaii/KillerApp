using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerAppSE2.Models
{
    public class Student : User
    {
        public int credits { get; private set; }
        public string emailRef { get; private set; }
        public string studeerLocatie { get; private set; }

        public Student(string initalen, string achternaam, int loginPin, string eMail, string telNr, string thuisAdres, string studeerlocatie)
        {
            base.initialen = initalen;
            base.achternaam = achternaam;
            base.loginPin = loginPin;
            base.email = eMail;
            base.telNr = telNr;
            base.thuisAdres = thuisAdres;
            this.studeerLocatie = studeerlocatie;
            this.emailRef = "";
        }

        public Student(string initalen, string achternaam, string eMail, string telNr, string thuisAdres, string studeerlocatie)
        {
            base.initialen = initalen;
            base.achternaam = achternaam;
            base.email = eMail;
            base.telNr = telNr;
            base.thuisAdres = thuisAdres;
            this.studeerLocatie = studeerlocatie;
            this.emailRef = "";
        }

        public Student()
        {
            
        }
    }
}