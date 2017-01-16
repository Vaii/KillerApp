using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using KillerAppSE2.Models;

namespace KillerAppSE2.Interfaces
{
    public interface IContextOuder
    {
        bool VraagRitAan(Rit rit);

        List<Rit> AangevraagdeRitten(Ouder ouder);
    }
}
