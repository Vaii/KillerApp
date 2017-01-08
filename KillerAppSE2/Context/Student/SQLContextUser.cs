using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerAppSE2.Connector;
using KillerAppSE2.Interfaces;

namespace KillerAppSE2.Context.Student
{
    public class SQLContextUser : IContextStudent
    {
        private MSSQLConnector connector;

        public SQLContextUser(MSSQLConnector connector)
        {
            this.connector = connector;
        }

        public bool SetBeschikbaar(Models.Student student, string begin, string eind, DateTime datum)
        {
            return true;
        }
    }
}