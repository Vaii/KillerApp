using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillerAppSE2.Models;

namespace KillerAppSE2.Interfaces
{
    public interface IContextStudent
    {
        bool SetBeschikbaar(Student Student, string Begin, string Eind, DateTime Datum);
    }
}
