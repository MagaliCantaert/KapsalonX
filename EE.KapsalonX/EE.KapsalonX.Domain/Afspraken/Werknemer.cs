using System;
using System.Collections.Generic;
using System.Text;

namespace EE.KapsalonX.Domain.Boeken
{
    public class Werknemer
    {
        Guid WerknemerId { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
    }
}
