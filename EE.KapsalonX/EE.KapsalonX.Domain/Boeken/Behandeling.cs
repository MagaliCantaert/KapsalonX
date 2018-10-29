using System;
using System.Collections.Generic;
using System.Text;

namespace EE.KapsalonX.Domain.Boeken
{
    public class Behandeling
    {
        public string Geslacht { get; set; }
        public string Optie { get; set; }
        public TimeSpan Tijdsduur { get; set; }
    }
}
