using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KillerAppSE2.Interfaces;
using KillerAppSE2.Models;

namespace KillerAppSE2.Repository
{
    public class OuderRepository
    {
        private IContextOuder _iContextOuder;
        private List<Rit> aangevraagdeRitten { get; set; }
        public OuderRepository(IContextOuder context)
        {
            this._iContextOuder = context;
        }

        public bool VraagRitAan(Rit rit)
        {
            return _iContextOuder.VraagRitAan(rit);
        }

        public List<Rit> GeplandeRitten(Ouder ouder)
        {
            return aangevraagdeRitten = _iContextOuder.AangevraagdeRitten(ouder);
        }
    }
}