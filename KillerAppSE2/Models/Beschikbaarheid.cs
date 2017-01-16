using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerAppSE2.Models
{
    public class Beschikbaarheid
    {
        public Student Student { get; set; }
        public string StartTime { get; private set; }
        public string EindTime { get; private set; }
        public DateTime Datum { get; private set; }

        public Beschikbaarheid(Student Student, string StartTime, string EindTime, DateTime Datum)
        {
            this.Student = Student;
            this.StartTime = StartTime;
            this.EindTime = EindTime;
            this.Datum = Datum;
        }

        public Beschikbaarheid(string StartTime, string EindTime, DateTime Datum)
        {
            this.StartTime = StartTime;
            this.EindTime = EindTime;
            this.Datum = Datum;
        }

        public override string ToString()
        {
            return "Datum: " +  Datum.ToString("dd/MM/yyyy") + " " + "Begin tijd: " + StartTime + " " + "Eind Tijd: " + EindTime;
        }
    }
}