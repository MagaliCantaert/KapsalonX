using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EE.KapsalonX.Web.ViewModels
{
    public class ContactIndexVm
    {
        [Display(Name = "Achternaam")]
        [Required(ErrorMessage = "Dit is een verplicht veld")]
        public string Achternaam { get; set; }

        [Display(Name = "Voornaam")]
        [Required(ErrorMessage = "Dit is een verplicht veld")]
        public string Voornaam { get; set; }

        [EmailAddress(ErrorMessage = "Vul een geldig e-mailadres in a.u.b.")]
        [Required(ErrorMessage = "Dit is een verplicht veld")]
        public string Emailadres { get; set; }

        [Phone(ErrorMessage = "Vul een geldig telefoonnummer in a.u.b.")]
        [Required(ErrorMessage = "Dit is een verplicht veld")]
        public string Telefoonnummer { get; set; }

        [Display(Name = "Uw bericht")]
        [StringLength(500)]
        [Required(ErrorMessage = "Dit is een verplicht veld")]
        public string Bericht { get; set; }
    }
}
