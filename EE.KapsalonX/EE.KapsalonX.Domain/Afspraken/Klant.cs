using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EE.KapsalonX.Domain.Afspraken
{
    public class Klant
    {
        public Guid KlantId { get; set; }
        [Required(ErrorMessage = "Dit is een verplicht veld")]
        public string Voornaam { get; set; }
        [Required(ErrorMessage = "Dit is een verplicht veld")]
        public string Achternaam { get; set; }
        [Required(ErrorMessage = "Dit is een verplicht veld")]
        public string Emailadres { get; set; }
        [Required(ErrorMessage = "Dit is een verplicht veld")]
        public string Telefoonnummer { get; set; }

        public ICollection<Afspraak> Afspraken { get; set; }
    }
}
