using Microsoft.AspNetCore.Mvc.Rendering;
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


        public string Behandeling { get; set; }
        public List<SelectListItem> Behandelingen { get; private set; }

        public BoekenIndexVm()
        {
            var firstGroup = new SelectListGroup { Name = "Kort haar" };
            var secondGroup = new SelectListGroup { Name = "Lang haar" };

            Behandelingen = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "Knippen",
                    Text = "Knippen",
                    Group = firstGroup
                },
                new SelectListItem
                {
                    Value = "Kleuren",
                    Text = "Kleuren",
                    Group = firstGroup
                },
                new SelectListItem
                {
                    Value = "Brushen",
                    Text = "Brushen",
                    Group = secondGroup
                },
                new SelectListItem
                {
                    Value = "Kleuren",
                    Text = "Kleuren",
                    Group = secondGroup
                }
            };
        }

    }
}
