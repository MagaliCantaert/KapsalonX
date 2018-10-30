using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EE.KapsalonX.Web.Models
{
    public class BoekenIndexVm
    {
        public string Geslacht { get; set; }

        public Guid KlantId { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Emailadres { get; set; }
        public string Telefoonnummer { get; set; }

        public List<BehandelingVm> BehandelingenDames { get; set; }
        public List<BehandelingVm> BehandelingenHeren{ get; set; }
        public List<BehandelingVm> BehandelingenKinderen { get; set; }

        public List<BehandelingVm> Cart { get; set; }


    }
}
