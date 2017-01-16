using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillerAppSE2.Models;
using KillerAppSE2.ViewModel;

namespace KillerAppSE2.Controllers
{
    public class OuderController : Controller
    {
        private RegisterViewModelOuder currentOuder = new RegisterViewModelOuder();
        // GET: Ouder
        public ActionResult OuderBase()
        {
            currentOuder.Ouder = (Ouder)Session["Ouder"];
            return View(currentOuder);
        }

        public ActionResult Aanvraag()
        {
            return View();
        }

        public ActionResult VraagAan()
        {
            return View();
        }
    }
}