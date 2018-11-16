using System;
using System.Collections.Generic;
using System.Text;

namespace EE.KapsalonX.Domain.Boeken
{
    public class Klant
    {
        public Guid KlantId { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Emailadres { get; set; }
        public string Telefoonnummer { get; set; }

        public ICollection<Afspraak> Afspraken { get; set; }
    }
}
