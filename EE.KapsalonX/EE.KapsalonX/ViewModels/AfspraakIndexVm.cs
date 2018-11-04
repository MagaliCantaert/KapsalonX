using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EE.KapsalonX.Web.ViewModels
{
    public class AfspraakIndexVm
    {
        public Guid KlantId { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Emailadres { get; set; }
        public string Telefoonnummer { get; set; }

        public List<AfspraakBehandelingVm> BehandelingenDames { get; set; }
        public List<AfspraakBehandelingVm> BehandelingenHeren{ get; set; }
        public List<AfspraakBehandelingVm> BehandelingenKinderen { get; set; }
        
        public List<AfspraakBehandelingVm> Geslacht { get; set; }


    }


}
