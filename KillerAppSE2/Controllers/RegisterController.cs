using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillerAppSE2.Connector;
using KillerAppSE2.Context;
using KillerAppSE2.Models;
using KillerAppSE2.Repository;

namespace KillerAppSE2.Controllers
{
    public class RegisterController : Controller
    {
        public UserRepository UserRepository = new UserRepository(new SQLContextUser(new MSSQLConnector()));
        public Ouder ouder { get; private set; }

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Ouder()
        {
            return View();
        }

        public ActionResult Student()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterOuder(string initialen, string achternaam, int loginPin, string email, string telNr, string mobNr, string thuisAdres, int leeftijd)
        {
            Ouder ouder = new Ouder(initialen, achternaam, loginPin, email, telNr, mobNr, thuisAdres, leeftijd);

            if (UserRepository.UserRegister(ouder))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Response.Write("<script>alert('Registreren mislukt, probeer opnieuw');</script>");
                return View("Ouder");
            }

        }

        [HttpPost]
        public ActionResult RegisterStudent(string initialen, string achternaam, int loginPin, string email, string telNr, string thuisAdres, string StudLocatie)
        {
            Student student = new Student(initialen, achternaam, loginPin, email, telNr, thuisAdres, StudLocatie);

            if (UserRepository.UserRegister(student))
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Response.Write("<script>alert('Registreren mislukt, probeer opnieuw');</script>");
                return View("Student");
            }

        } 

    }
}