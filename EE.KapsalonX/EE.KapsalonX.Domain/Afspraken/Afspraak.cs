using System;
using System.Collections.Generic;
using System.Text;

namespace EE.KapsalonX.Domain.Boeken
{
    public class Afspraak
    {
        public Guid AfspraakId { get; set; }
        public Klant KlantGegevens { get; set; }
        public Behandeling BehandelingGegevens { get; set; }
        public DateTime DatumTijdstip { get; set; }

    }
}
