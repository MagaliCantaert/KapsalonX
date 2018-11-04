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

        //public List<BehandelingVm> BehandelingenDames { get; set; }
        //public List<BehandelingVm> BehandelingenHeren{ get; set; }
        //public List<BehandelingVm> BehandelingenKinderen { get; set; }

        public string BehandelingDame { get; set; }
        public List<SelectListItem> BehandelingenDames { get; private set; }

        public string BehandelingHeer { get; set; }
        public List<SelectListItem> BehandelingenHeren { get; private set; }

        public string BehandelingKind { get; set; }
        public List<SelectListItem> BehandelingenKinderen { get; private set; }

        public BoekenIndexVm()
        {
            var firstGroup = new SelectListGroup { Name = "Kort haar" };
            var secondGroup = new SelectListGroup { Name = "Lang haar" };

            BehandelingenDames = new List<SelectListItem>
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
                    Value = "Brushing",
                    Text = "Brushing",
                    Group = firstGroup
                },
                new SelectListItem
                {
                    Value = "Knippen & Kleuren",
                    Text = "Knippen & Kleuren ",
                    Group = firstGroup
                },
                new SelectListItem
                {
                    Value = "Knippen, Kleuren & Brushen",
                    Text = "Knippen, Kleuren & Brushen",
                    Group = firstGroup
                },
                new SelectListItem
                {
                    Value = "Knippen",
                    Text = "Knippen",
                    Group = secondGroup
                },
                new SelectListItem
                {
                    Value = "Kleuren",
                    Text = "Kleuren",
                    Group = secondGroup
                },
                new SelectListItem
                {
                    Value = "Brushen",
                    Text = "Brushen",
                    Group = secondGroup
                },
                new SelectListItem
                {
                    Value = "Knippen & Kleuren",
                    Text = "Knippen & Kleuren",
                    Group = secondGroup
                },
                new SelectListItem
                {
                    Value = "Knippen, Kleuren & Brushen",
                    Text = "Knippen, Kleuren & Brushen",
                    Group = secondGroup
                }
            };

            BehandelingenHeren = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "Snit",
                    Text = "Snit"
                },
                new SelectListItem
                {
                    Value = "Tondeuze",
                    Text = "Tondeuze"
                },
                new SelectListItem
                {
                    Value = "Knippen & Kleuren",
                    Text = "Knippen & Kleuren"
                }
            };

            BehandelingenKinderen = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = "Snit meisjes",
                    Text = "Snit meisjes"
                },
                new SelectListItem
                {
                    Value = "Snit jongens",
                    Text = "Snit jongens"
                }
            };
        }

    }
}
