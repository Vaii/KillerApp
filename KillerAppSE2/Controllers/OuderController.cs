using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillerAppSE2.Connector;
using KillerAppSE2.Context.Ouder;
using KillerAppSE2.Models;
using KillerAppSE2.Repository;
using KillerAppSE2.ViewModel;

namespace KillerAppSE2.Controllers
{
    public class OuderController : Controller
    {
        private RegisterViewModelOuder currentOuder = new RegisterViewModelOuder();
        private OuderRepository ouderRepo = new OuderRepository(new SQLContextOuder(new MSSQLConnector()));
        private List<Rit> aangevraagdeRitten { get; set; }
        private Ouder ouder { get; set; }
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

        public ActionResult Planning()
        {
            aangevraagdeRitten = ouderRepo.GeplandeRitten((Ouder) Session["Ouder"]);
            return View(aangevraagdeRitten);
        }

        public ActionResult VraagAan(DateTime Date, DateTime Begin, string startAdres, string eindAdres, int duratie)
        {
            string beginTijd = Begin.ToString("t");
            ouder = (Ouder) Session["Ouder"];
            Rit rit = new Rit(ouder, Date, beginTijd, startAdres, eindAdres, duratie);

            if (ouderRepo.VraagRitAan(rit))
            {
                return RedirectToAction("OuderBase");

            }
            else
            {
                return RedirectToAction("Aanvraag");
            }

        }
    }
}