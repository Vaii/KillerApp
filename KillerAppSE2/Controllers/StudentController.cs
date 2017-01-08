using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using KillerAppSE2.Connector;
using KillerAppSE2.Context.Student;
using KillerAppSE2.Models;
using KillerAppSE2.Repository;
using KillerAppSE2.ViewModel;

namespace KillerAppSE2.Controllers
{
    public class StudentController : Controller
    {
        private RegisterViewModelStudent CurrentStudent = new RegisterViewModelStudent();
        private StudentRepository StudentRepo = new StudentRepository(new MemoryContextStudent());
        // GET: Student
        public ActionResult StudentBase()
        {
            CurrentStudent.Student = (Student)Session["Student"];
            return View(CurrentStudent);
        }

        public ActionResult Beschikbaarheid()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SetSingleBeschikbaar(DateTime Begin, DateTime Eind, DateTime Date)
        {
            Student student = new Student();
            student = (Student) Session["Student"];
            string beginTijd = Begin.ToString("t");
            string eindTijd = Eind.ToString("t");
            Date = Date.Date;

            if (StudentRepo.RegistreerBeschikbaarheid(student, beginTijd, eindTijd, Date))
            {
                return RedirectToAction("StudentBase", "Student");
            }
            else
            {
                return RedirectToAction("StudentBase", "Student");
            }
        }
    }
}