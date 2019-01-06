using EE.KapsalonX.Domain.Afspraken;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EE.KapsalonX.Web.ViewModels
{
    public class AdminCreateVm
    {
        public string Datum { get; set; }
        public string Tijdstip { get; set; }

        [Required(ErrorMessage = "Dit is een verplicht veld")]
        public string Tijdsduur { get; set; }

        public Klant Klant { get; set; }
        public Behandeling Behandeling { get; set; }
        public Afspraak Afspraak { get; set; }

        public List<SelectListItem> Behandelingen { get; set; }
        public List<BehandelingVm> BehandelingenDames { get; set; }
        public List<BehandelingVm> BehandelingenHeren { get; set; }
        public List<BehandelingVm> BehandelingenKinderen { get; set; }

        [Display(Name = "Datum")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Dit is een verplicht veld")]
        public DateTime Date { get; set; }

        [Display(Name = "Tijdstip")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Dit is een verplicht veld")]
        public DateTime Time { get; set; }

        [NotMapped]
        public TimeSpan Duur { get; set; }

        public string Opmerkingen { get; set; }

        public AdminCreateVm()
        {

        }
    }
}
