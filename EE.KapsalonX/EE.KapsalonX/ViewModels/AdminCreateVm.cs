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
        public string Datum { get; set; }
        public string Tijdstip { get; set; }

        public Klant Klant { get; set; }
        public Behandeling Behandeling { get; set; }

        public List<SelectListItem> Behandelingen { get; set; }
        public List<BehandelingVm> BehandelingenDames { get; set; }
        public List<BehandelingVm> BehandelingenHeren { get; set; }
        public List<BehandelingVm> BehandelingenKinderen { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Tijdstip")]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }

        public string Opmerkingen { get; set; }

        public AdminCreateVm()
        {

        }
    }
}
