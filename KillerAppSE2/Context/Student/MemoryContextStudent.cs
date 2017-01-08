using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using KillerAppSE2.Interfaces;
using KillerAppSE2.Models;


namespace KillerAppSE2.Context.Student
{
    public class MemoryContextStudent : IContextStudent
    {
        public List<Beschikbaarheid> Beschikbaarheden = new List<Beschikbaarheid>();

        public bool SetBeschikbaar(Models.Student student, string begin, string eind, DateTime datum)
        {
            int aantalBeschikbaarHeden = Beschikbaarheden.Count;
            Beschikbaarheid beschikbaar = new Beschikbaarheid(student, begin, eind, datum);
            Beschikbaarheden.Add(beschikbaar);
            int NieuwAantal = Beschikbaarheden.Count;
            if (NieuwAantal > aantalBeschikbaarHeden)
            {
                return true;
            }
            else
            {
                return false;
            }
    }
    }
}