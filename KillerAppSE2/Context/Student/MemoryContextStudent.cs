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

        public bool SetBeschikbaar(Beschikbaarheid beschikbaar)
        {
            int aantalBeschikbaarHeden = Beschikbaarheden.Count;
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

        public List<Beschikbaarheid> GetPlanning(Models.Student student)
        {
            return null;
        }
    }
}