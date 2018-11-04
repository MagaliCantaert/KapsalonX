using System;
using System.Collections.Generic;
using System.Text;

namespace EE.KapsalonX.Domain.Boeken
{
    public class Behandeling
    {
        public Guid BehandelingId { get; set; }
        public string Geslacht { get; set; }
        public string Coupe { get; set; }
        public string Optie { get; set; }
        public TimeSpan Tijdsduur { get; set; }
    }
}
