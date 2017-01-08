using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KillerAppSE2.Models;

namespace KillerAppSE2.Interfaces
{
    public interface IContextUser
    {
        bool RegisterUser(Student User);
        bool RegisterUser(Ouder User);

        Student LoginStudent(string email, string password);
        Ouder LoginOuder(string email, string password);
    }
}
