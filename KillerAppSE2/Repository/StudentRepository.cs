using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerAppSE2.Interfaces;
using KillerAppSE2.Models;

namespace KillerAppSE2.Repository
{
    public class StudentRepository
    {
        private IContextStudent _icontextStudent;
        private List<Beschikbaarheid> beschikbaarheden { get; set; }
        public StudentRepository(IContextStudent Context)
        {
            this._icontextStudent = Context;
        }

        public bool RegistreerBeschikbaarheid(Beschikbaarheid Beschikbaarheid)
        {
            if (_icontextStudent.SetBeschikbaar(Beschikbaarheid))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Beschikbaarheid> Planning(Student student)
        {
            beschikbaarheden = _icontextStudent.GetPlanning(student);
            return beschikbaarheden;
        }
    }
}