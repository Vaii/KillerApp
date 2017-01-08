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

        public StudentRepository(IContextStudent Context)
        {
            this._icontextStudent = Context;
        }

        public bool RegistreerBeschikbaarheid(Student student, string Begin, string Eind, DateTime Date)
        {
            if (_icontextStudent.SetBeschikbaar(student, Begin, Eind, Date))
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