using EE.KapsalonX.Domain.Afspraken;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EE.KapsalonX.Web.ViewModels
{
    public class AdminCreateVm
    {
        public Klant Klant { get; set; }
        public Behandeling Behandeling { get; set; }

        public List<SelectListItem> Behandelingen { get; set; }
        public List<BehandelingVm> BehandelingenDames { get; set; }
        public List<BehandelingVm> BehandelingenHeren { get; set; }
        public List<BehandelingVm> BehandelingenKinderen { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string Datum { get; set; }

        [Required]
        public string Tijdstip { get; set; }

        public string Opmerking { get; set; }

        public AdminCreateVm()
        {

        }
    }
}
