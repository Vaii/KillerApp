using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerAppSE2.Interfaces;
using KillerAppSE2.Models;

namespace KillerAppSE2.Repository
{
    public class UserRepository
    {
        private IContextUser _iContextUser;
        private Student student { get; set; }
        private Ouder ouder { get; set; }

        public UserRepository(IContextUser context)
        {
            this._iContextUser = context;
        }

        public bool UserRegister(Ouder User)
        {
            return _iContextUser.RegisterUser(User);
        }

        public bool UserRegister(Student User)
        {
            return _iContextUser.RegisterUser(User);
        }

        public Student LoginStudent(string email, string password)
        {
            student = _iContextUser.LoginStudent(email, password);

            if (student != null)
            {
                return student;
            }
            else
            {
                return null;
            }
        }

        public Ouder LoginOuder(string email, string password)
        {
            ouder = _iContextUser.LoginOuder(email, password);
            return ouder;
        }
    }
}